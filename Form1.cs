using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using Excel1 = Microsoft.Office.Interop.Excel;
using System.Globalization;
using ZedGraph;
using System.Threading;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        bool        loop_flag = false,              //loop_flag - началао цикла
                    end_flag = false,               //end_flag - для верного отображения pointValue на графике
                    flag_infinite_loop = false,     //flag_infinite_loop - режим бесконечного цикла 
                    flag_recieve = false,           //flag_recieve - посылка принята
                    flag_first_time = false;    

        int         b,                              //b - конечное количество посылок
                    flag_mode = 0,                  //flag_mode - режим измерения вольтметра
                    in_cnt = 0,                     //in_cnt - количество входных посылок
                    out_cnt = 0;                    //out_cnt- количество отправок
        string where_file;                          //Путь к файлу CSV
        long hour, minute, second;                  //Время для отбражения
        int small_limit = 0, max_limit = 0;         //Введены для варьирования частоты обновления графика в зависимости от интервала между запросами
        long timer2_cnt = 0;                        //Используется для режима работы по времени
        double get_val = 0;                         //Измеренное значение (передается на график)
        int _capacity = 10000;                       //Максимальное кол-во зн-ий на графике одновременно
        List<double> value_data;                     //Список данных для построения графика по Y
        List<XDate> value_date;                      //Список времени
        delegate void SetTextCallback(string text);     //обработчик  события поступления данных
        string InputData = String.Empty;                //Входные данные
        System.IO.StreamWriter filetxt;             //Для текстового файла *.csv
        DateTime startDate;                         //Дата

        Excel1.Application oXL;                     //Excel
        Excel1._Workbook oWB;
        Excel1._Worksheet oSheet;
        Excel1.Range oRng;

        public int count_number;                    //Вспомогательная переменная для понимания, где сейчас на графике точка

        public Form1()
        {
            value_data = new List<double>();
            value_date = new List<XDate>();
            InitializeComponent();
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived_1);
        }

        //Получение данных о последовательных портах
        private void updatePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cmbPortName.Items.Add(port);
            }
        }

        //Начальные установки в комбобоксы при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            updatePorts();
            cmbPortName.SelectedIndex = 0;
            cmbBaudRate.SelectedIndex = 3;
            cmbParity.SelectedIndex = 0;
            cmbDataBits.SelectedIndex = 1;
            cmbStopBits.SelectedIndex = 0;
            cmbCapacity.SelectedIndex = 1;
            cmbIteration.SelectedIndex = 2;
            cmbInterval.SelectedIndex = 0;
            cmbHours.SelectedIndex = 0;
            cmbMinutes.SelectedIndex = 1;
            DrawGraph();


   //------Справка на каждый элемент----------
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 50;
            toolTip1.ShowAlways = true;

            //Текст на кажду подсказку
            toolTip1.SetToolTip(this.btnStart, "Установить соединения");
            toolTip1.SetToolTip(this.btnRead, "Отправить тестовую команды для проверка получения данных");
            toolTip1.SetToolTip(this.btnWrite, "Отправка введеной в поле команды");
            toolTip1.SetToolTip(this.btnLoop, "Начало измерений в цикле"); 
            toolTip1.SetToolTip(this.btnSave, "Отправить данные измерений в Excel");
            toolTip1.SetToolTip(this.btnLoad, "Загрузить данные предыдущих измерений");
            toolTip1.SetToolTip(this.btnHelp, "Справка");
            toolTip1.SetToolTip(this.cmbPortName, "Имя порта");
            toolTip1.SetToolTip(this.lblPort, "Имя порта");
            toolTip1.SetToolTip(this.cmbBaudRate, "Скорость обмена данными");
            toolTip1.SetToolTip(this.lblBaudR, "Скорость обмена данными");
            toolTip1.SetToolTip(this.cmbParity, "Контроль четность");
            toolTip1.SetToolTip(this.lblParity, "Контроль четность");
            toolTip1.SetToolTip(this.cmbDataBits, "Количество бит данных");
            toolTip1.SetToolTip(this.lblDataB, "Количество бит данных");
            toolTip1.SetToolTip(this.cmbStopBits, "Длина стоп-бита");
            toolTip1.SetToolTip(this.lblStopB, "Длина стоп-бита");
            toolTip1.SetToolTip(this.cmbCapacity, "Выбор предела количества отображаемых значений на графике одновременно. \rЧем большее значение установлено, тем большая нагрузка на ПК");
            toolTip1.SetToolTip(this.lbl_Capacity, "Выбор предела количества отображаемых значений на графике одновременно. \rЧем большее значение установлено, тем большая нагрузка на ПК");
            toolTip1.SetToolTip(this.cmbIteration, "Количество повторений в цикле");
            toolTip1.SetToolTip(this.cmbIteration, "Количество повторений в цикле");
            toolTip1.SetToolTip(this.lblIteration, "Количество повторений в цикле");
            toolTip1.SetToolTip(this.cmbHours, "Длительность цикла по времени");
            toolTip1.SetToolTip(this.cmbMinutes, "Длительность цикла по времени");
            toolTip1.SetToolTip(this.cmbInterval, "Промежуток времени между запросами");
            toolTip1.SetToolTip(this.label9, "Промежуток времени между запросами");
        }

        //Событие: Закрытие программы
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            port.Close();
        }


//--------------Соединение по СОМ порту----------------------------------------------------
        public void connect()
        {
            bool error = false;

            if (cmbPortName.SelectedIndex != -1 &
               cmbBaudRate.SelectedIndex != -1 & //Проверка на то, выбран ли пункт меню
               cmbParity.SelectedIndex != -1 &
               cmbDataBits.SelectedIndex != -1 &
               cmbStopBits.SelectedIndex != -1)
            {
                //Получение настроек порта из комбобоксов
                port.PortName = cmbPortName.Text;                   
                port.BaudRate = int.Parse(cmbBaudRate.Text);
                port.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
                port.DataBits = int.Parse(cmbDataBits.Text);
                port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
                port.Handshake = Handshake.None;
                try
                {
                    port.Open();
                    timer2.Interval = 1000;          //Настройка таймера для проверки ответа от ГДМ
                    timer2_cnt = 1;                 //
                    flag_first_time = true;         //
                    timer2.Enabled = true;          //
                    textBox2.Text = "*CLS\r";
                    SendText();
                    textBox2.Text = "*CLS\r";       //Сброс ГДМ
                    SendText();
                    textBox2.Text = ":CONF:FUNC?\r";
                    SendText();
                    
                }
                catch (UnauthorizedAccessException) { error = true; }
                catch (IOException) { error = true; }
                catch (ArgumentException) { error = true; }
                if (error) MessageBox.Show(this, "Невозможно открыть порт", "СОМ порт недоступен", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            else MessageBox.Show("Установите верные настройки порта", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            if (port.IsOpen)
            {
                btnSave.Enabled = false;
                this.btnStart.Text = "Завершить";
                this.gbWrite.Enabled = true;
                this.gbCommands.Enabled = true;
                this.gbLoop.Enabled = true;
                this.gbSetup.Enabled = false;
                dGV1.Rows.Clear();
                value_data.Clear();
                value_date.Clear();
                DrawGraph();
                richTextBox1.Clear();
                btnLoad.Enabled = false;
                
            }
        }

        //Завершение соединения по СОМ порту
        public void disconnect()
        {
            btnSave.Enabled = false;
            port.Close();       //Закрываем порт
            this.btnStart.Text = "Начать";
            this.gbSetup.Enabled = true;
            this.gbWrite.Enabled = false;
            this.gbCommands.Enabled = false;
            this.gbLoop.Enabled = false;
            this.btnLoad.Enabled = true;
            progressBar1.Value = 0;
            lblInCnt.Text = Convert.ToString(0);
            lblOutCnt.Text = Convert.ToString(0);
            richTextBox1.Clear();
            value_data.Clear();
            value_date.Clear();
            DrawGraph();
            dGV1.Rows.Clear();
        }


//--------------Отправка текста из поля текстбокса--------------------------------
        public void SendText() 
        {
            if (port.IsOpen) port.WriteLine(textBox2.Text); //Если порт открыт, то пишем в него текст из текстбокса2
            else MessageBox.Show("СОМ порт закрыт", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox2.Clear();                               //Чистим текстбокс2
        }
//-------------Изменение цвета кнопок в зависимости от режима-----------------------

        public void ColorBtn()
        {     //Изменение цветов у кнопок
            this.btnRES.BackColor = System.Drawing.SystemColors.Control;
            this.btnDCV.BackColor = System.Drawing.SystemColors.Control;
            this.btnACV.BackColor = System.Drawing.SystemColors.Control;
            this.btnDCA.BackColor = System.Drawing.SystemColors.Control;
            this.btnACA.BackColor = System.Drawing.SystemColors.Control;            
            switch (flag_mode)
            {
                case 1: this.btnRES.BackColor = System.Drawing.Color.LimeGreen; break;
                case 2: this.btnDCV.BackColor = System.Drawing.Color.LimeGreen; break;
                case 3: this.btnACV.BackColor = System.Drawing.Color.LimeGreen; break;
                case 4: this.btnDCA.BackColor = System.Drawing.Color.LimeGreen; break;
                case 5: this.btnACA.BackColor = System.Drawing.Color.LimeGreen; break;
            }
            textBox2.Text = "*CLS\r";//Команда на сброс регистров у ГДМ
            SendText();
        }

//////////------------------Прием данных----------------------------------------------
        private void port_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            InputData = port.ReadLine();
            if (InputData != String.Empty)
            {
                this.BeginInvoke(new SetTextCallback(SetText), new object[] { InputData });
            }
        }

        public void SetText(string text)
        {
            if (loop_flag == false)  //Если опрос по циклу не начат (одиночные команды)
            {
                if (flag_first_time == true) { flag_first_time = false; timer2.Enabled = false; } //Для проверки получения ответа от ГДМ

                richTextBox1.AppendText(DateTime.Now + "  " + text + "\r");         //Пришедшая информация выводится в информационное поле
                richTextBox1.ScrollToCaret();                                       //Скролл к концу инф.поля
                switch (InputData)   //При получении определенных данных устанавливается режим работы, окрашиваются кнопки
                {
                    case "OHM":
                        flag_mode = 1;
                        ColorBtn();
                        break;
                    case "DCV":
                        flag_mode = 2;
                        ColorBtn();
                        break;
                    case "ACV":
                        flag_mode = 3;
                        ColorBtn();
                        break;
                    case "DCA":
                        flag_mode = 4;
                        ColorBtn();
                        break;
                    case "ACA":
                        flag_mode = 5;
                        ColorBtn();
                        break;
                }
                DrawGraph();
            }
            else //При начале опроса по циклу
            {
                if (in_cnt < b || flag_infinite_loop == true)       //Если не достигли конца принятых посылок или флаг бесконечности установлен
                {       
                    //Получаем время
                    startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
                    in_cnt++;

                    if (flag_infinite_loop == false) progressBar1.PerformStep();
                    lblInCnt.Text = Convert.ToString(in_cnt);

                    //Пытаемся получить данные
                    try
                    {
                        get_val = double.Parse(text, CultureInfo.InvariantCulture.NumberFormat);
                    }
                    catch
                    {
                        dGV1.Rows.Add(in_cnt, String.Format("{0:HH:mm:ss}", 0));
                        value_data.Add(0);
                        richTextBox1.Text += "Неверный формат полученных данных в измерении " + in_cnt + ". \r";
                    }

                    switch (flag_mode) //В зависимости от режима работаем с данными
                    {
                        case 1: //OHM
                            try
                            {
                                dGV1.Rows.Add(in_cnt, String.Format("{0:HH:mm:ss}", startDate), 1000*get_val);
                                filetxt.WriteLine(String.Format("{0:HH:mm:ss:fff}", startDate) + ";" + 1000*get_val);
                                filetxt.Flush();
                                value_data.Add(get_val);
                                value_date.Add(new XDate(startDate));
                                break;
                            }
                            catch
                            {
                                dGV1.Rows.Add(in_cnt, String.Format("{0:HH:mm:ss}", 0));
                                filetxt.WriteLine(String.Format("{0:HH:mm:ss:fff}" + ";" + 0));
                                value_data.Add(0);
                                richTextBox1.Text += "Неверный формат полученных данных в измерении" + in_cnt + ". \r";
                                break;
                            }

                        default: //DCV, ACV, ACA,DCA                          
                            try
                            {
                                dGV1.Rows.Add(in_cnt, String.Format("{0:HH:mm:ss}",startDate), get_val);
                                filetxt.WriteLine(String.Format("{0:HH:mm:ss:fff}", startDate) + ";" + get_val);
                                filetxt.Flush();
                                value_data.Add(get_val);                                
                                value_date.Add(new XDate(startDate));
                                break;
                            }
                            catch
                            {
                                dGV1.Rows.Add(in_cnt, String.Format("{0:HH:mm:ss}", 0));
                                filetxt.WriteLine(String.Format("{0:HH:mm:ss:fff}" + ";" + 0));
                                value_data.Add(0);
                                richTextBox1.Text += "Неверный формат полученных данных в измерении" + in_cnt + ". \r";
                                break;
                            }
                    }

                    //--При достижения емкости графика выкидываем первое значение
                    if (value_data.Count > _capacity)
                    {
                        value_data.RemoveAt(0);
                        value_date.RemoveAt(0);
                    }
                    //--Ограничение на частоту обноления графика
                    if (in_cnt > 2000)
                    {
                        if (in_cnt % max_limit == 0)
                        {
                            DrawGraph();
                        }
                    }
                    else
                    {

                        if (in_cnt % small_limit == 0)
                        {
                            DrawGraph();
                        }
                    }
                    //--Табличка при наведении на график
                    zedGraph.PointValueEvent += new ZedGraphControl.PointValueHandler(zedGraph_PointValueEvent);
                    //--------
                    if (flag_infinite_loop == true || in_cnt < b)      //Если кол-во не дошло до нуля
                    {
                        if (timer2.Enabled == true & timer2_cnt <= 0) //Если таймер досчитал
                        {
                            btnLoop_Click(this, null);
                            cmbHours.Enabled = true;
                            cmbMinutes.Enabled = true;
                            MessageBox.Show("Окончание измерения в цикле", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return;
                        }
                        flag_recieve = true;
                        if (timer1.Enabled == false)
                        {
                            out_cnt++; lblOutCnt.Text = Convert.ToString(out_cnt); btnRead_Click(this, null); //Отправляем ответочку
                        }
                    }
                    else { btnLoop_Click(this, null); MessageBox.Show("Окончание измерения в цикле", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                }
                else { btnLoop_Click(this, null); MessageBox.Show("Окончание измерения в цикле", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            }
        }



        //////////------------- Измерения в цикле ---------------------------------------------------------------- 

        public void btnLoop_Click(object sender, EventArgs e)
        {
            if (loop_flag == false)
            {
                progressBar1.Value = 0;
                flag_recieve = false;
                timer2_cnt = 0;
                progressBar1.Visible = true;

                try
                {
                    _capacity = int.Parse(cmbCapacity.Text);
                }
                catch
                {
                    MessageBox.Show("Неверный формат емкости графика", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                if (rb_iterationCh.Checked == true)//Работа по количеству запросов
                {
                    switch (cmbIteration.SelectedIndex)//Обработка установленного кол-ва итераций
                    {
                            //При бесконечном опросе ставим флаг, убираем прогресс бар
                        case 0: flag_infinite_loop = true; progressBar1.Visible = false; b = 100; break;
                        default: flag_infinite_loop = false;
                            try                                
                            { b = int.Parse(cmbIteration.Text); progressBar1.Maximum = b; progressBar1.Step = 1; }//Устанавливаем кол-во изм-ий
                            catch
                            {
                                MessageBox.Show("Неверный формат интераций.", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            break;
                    }
                }

                else //Работа по времени
                {
                    try
                    {
                        timer2.Interval = 1000;     //установка таймера на 1 сек
                        timer2_cnt = 60 * long.Parse(cmbMinutes.Text) + 3600 * long.Parse(cmbHours.Text); //Установленное время переводится в миллисекунды
                        progressBar1.Maximum = (int)timer2_cnt;     //Установки прогрессбара
                        progressBar1.Step = 1;
                        flag_infinite_loop = true;                  //Для работы по интервалу
                        timer2.Enabled = true;
                        cmbHours.Enabled = false;
                        cmbMinutes.Enabled = false;
                    }
                    catch
                    {
                        MessageBox.Show("Неверный формат времени.", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                switch (cmbInterval.SelectedIndex)  //Обработка установленного интервала
                {
                        //При минимальном интервале ставится ограничение на обновление графика, чтобы не так сильно загружать ПК
                    case 0: timer1.Enabled = false; small_limit = 10; max_limit = 100; break;
                    default: try { timer1.Interval = (int)Math.Round(1000 * float.Parse(cmbInterval.Text, CultureInfo.InvariantCulture.NumberFormat)); small_limit = 1; max_limit = 10; timer1.Enabled = true; }
                        catch { MessageBox.Show("Неверный формат интервала.", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
                        break;
                }

                btnSave.Enabled = true;
                richTextBox1.Clear();
                btnLoad.Enabled = false;
                loop_flag = true;
                dGV1.Rows.Clear();
                btnLoop.Text = "Стоп";
                btnSave.Enabled = false;
                gbWrite.Enabled = false;
                gbCommands.Enabled = false;
                btnStart.Enabled = false;
                cmbCapacity.Enabled = false;
                cmbIteration.Enabled = false;
                cmbInterval.Enabled = false;
                rb_timeCh.Enabled = false;
                rb_iterationCh.Enabled = false;
                value_data.Clear();
                value_date.Clear();
                in_cnt = 0;
                out_cnt = 0;
                lblInCnt.Text = Convert.ToString(in_cnt);
                lblOutCnt.Text = Convert.ToString(out_cnt);
                richTextBox1.Text += "------------------------------------ \r";
                richTextBox1.Text += DateTime.Now + "\r";
                richTextBox1.Text += "Начало измерения в цикле \r";
                richTextBox1.Text += "------------------------------------ \r";

                //Если не установлен интервал, то сразу отправляем запрос
                if (timer1.Enabled == false) { out_cnt++; lblOutCnt.Text = Convert.ToString(out_cnt); btnRead_Click(sender, e); }

                flag_recieve = true; //Требуется для первой отправки при работе по интервалу

                //-Берем путь в папку с программой, создаем запись в CSV файл
                where_file = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\test " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "-" + DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second + ".csv";
                filetxt = new StreamWriter(where_file, false);
                filetxt.AutoFlush = true; //настраиваем на автосброс данных в файл
                //--

                end_flag = false;
                richTextBox1.Text += "Данные измерений сохраняются в файл расположеный по следующему пути:\r";
                richTextBox1.Text += where_file + "\r";
            }



            //Окончание цикла 
            else
            {   //активируем все обратно
                timer1.Enabled = false;
                timer2.Enabled = false;
                loop_flag = false;
                flag_infinite_loop = false;
                flag_recieve = false;
                btnLoop.Text = "Запуск";
                gbWrite.Enabled = true;
                gbCommands.Enabled = true;
                btnStart.Enabled = true;
                btnSave.Enabled = true;
                cmbCapacity.Enabled = true;
                filetxt.Close();                //Закрываем запись в CSV файл
                Open_file(where_file);          //Загружаем данные из этого файла и строим по ним график     
                cmbInterval.Enabled = true;
                textBox2.Clear();
                if (rb_iterationCh.Checked == true) //в зависимости от радиобатанов активируем нужное
                {
                    cmbIteration.Enabled = true;
                    cmbHours.Enabled = false;
                    cmbMinutes.Enabled = false;
                }
                else
                {
                    cmbIteration.Enabled = false;
                    cmbHours.Enabled = true;
                    cmbMinutes.Enabled = true;
                }
                btnSave.Visible = true;
                rb_timeCh.Enabled = true;
                rb_iterationCh.Enabled = true;
                richTextBox1.Text += "------------------------------------ \r";
                richTextBox1.Text += DateTime.Now + "\r";
                richTextBox1.Text += "Окончание измерения в цикле \r";
                richTextBox1.Text += "------------------------------------ \r";

            }
        }

        //Таймер 1 - Для создания интервала опроса
        public void timer1_Tick(object sender, EventArgs e)
        {
            //(по получении ответа и кол-во принятного меньше необходимо), либо (флаг бесонечного измерения установлен)
            if (flag_recieve == true & ((in_cnt <= b) || (flag_infinite_loop == true)))
            {
                flag_recieve = false;                               //Сбрасываем флаг принятой посылки
                if (timer2_cnt >= 0)
                {
                    out_cnt++;                                      //Прибавляем кол-во отправленных посылок
                    lblOutCnt.Text = Convert.ToString(out_cnt);     
                    btnRead_Click(sender, e);                       //Отправляем новый запрос
                }
            }
        }

        //Таймер 2 - для работы по времени
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if (flag_first_time != true)
            {
                progressBar1.PerformStep();                                 //Продвижение прогрессбара
                timer2_cnt--;                                               //Каждый счет убавляем на одно(каждую секунду)
                hour = timer2_cnt / 3600;                                   //Переводим заданное для работы время в понятную форму
                if (hour > 0) minute = (timer2_cnt % 3600) / 60;           
                else minute = timer2_cnt / 60;
                if (minute > 0) second = (timer2_cnt - hour * 3600) % 60;
                else
                {
                    if (hour > 0) second = (timer2_cnt - hour * 3600) % 60;
                    else second = timer2_cnt;
                }
                //выводим данные об оставшемся времени
                lblTime_cnt.Text = "Оставшееся время: " + Convert.ToString(hour) + ":" + Convert.ToString(minute) + ":" + Convert.ToString(second);                
            }
            else if (flag_first_time == true) //таймер используется для проверки связи с ГДМ. 
            {                                  //Если ответ от ГДМ не получен, то флаг останется установлен, таймер досчитает, выведется ошибка
                timer2_cnt--;
                if (timer2_cnt == 0)
                        {
                            MessageBox.Show("Ответ от GDM не получен.", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            disconnect();
                        }
            }
        }

        //-------------Создание файла Excel и выгрузка данных в него-----------------
        public void xL_start(object sender, EventArgs e)
        {
            //--Поток с экраном загрузки
            Thread t = new Thread(new ThreadStart(splash));
            t.Start();
            //---           
            try  //Открывание экселя
            {
                oXL = new Excel1.Application();
                oXL.Visible = true;
            }
            catch
            {
                t.Abort();
                MessageBox.Show("Отсутствует Excel", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            try    //Открытие файла шаблона Excel в папке с ярлыком
            {
                string where_folder = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\ChartExcel.xltm";
                oWB = oXL.Workbooks.Open(where_folder, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch
            {
                t.Abort();
                MessageBox.Show("Невозможно открыть файл ChartExcel", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            
            oSheet = (Excel1._Worksheet)oWB.ActiveSheet;    //Создание книги
            string B1 = null, C1 = null;
            oSheet.Cells[1, 1] = "Время";                   //Создание заголовочных ячеек
            switch (flag_mode)
            {
                case 1: B1 = "Сопротивление(Ом)"; C1 = "Режим: RES"; break;
                case 2: B1 = "Напряжение(В)"; C1 = "Режим: DCV"; break;
                case 3: B1 = "Напряжение(В)"; C1 = "Режим: ACV"; break;
                case 4: B1 = "Напряжение(В)"; C1 = "Режим: DCA"; break;
                case 5: B1 = "Напряжение(В)"; C1 = "Режим: ACA"; break;
            }
            oSheet.Cells[1, 2] = B1;
            oSheet.Cells[1, 3] = C1;
            oSheet.Cells[1, 5] = "Количество значений:";
            oRng = oSheet.get_Range("E1", "F1");
            oRng.EntireColumn.AutoFit();

            oSheet.Cells[1, 6] = in_cnt;    //Запись кол-ва принятых пакетов
            b = in_cnt;                     //(уже не нужно, добавлено в макрос)


            try                             //Запуск макроса на подгрузку файла с данными
            {                               //Автоматически берется путь по которому брать CSV
                oXL.Run("b", "TEXT;"+where_file, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch
            {
                t.Abort();
                MessageBox.Show("Процесс обработки данных Excel прерван", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            try                             //Запуск макроса на создание графиков
            {
                oXL.Run("g", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                oRng = oSheet.get_Range("A1", "E1");
                oRng.EntireColumn.AutoFit();            //Выравнивание диапазона по ширине
            }
            catch
            {
                t.Abort();
                MessageBox.Show("Процесс обработки данных Excel прерван", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            t.Abort();                                 //Убираем табличку загрузки
            MessageBox.Show("Окончание копирования данных в Excel", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);            
        }

////-------------------------ZedGraph---------------------------------------
        private void DrawGraph()
        {
            GraphPane pane = zedGraph.GraphPane;    // Получим панель для рисования

            pane.CurveList.Clear();                 // Очистим список кривых
            pane.XAxis.Title.Text = "Время";
            zedGraph.IsShowPointValues = true;      //Показывать точки при наведении
            switch (flag_mode)                      //Выбор названия осей по флагу режима
            {
                case 1: pane.Title.Text = "Режим: RES"; pane.YAxis.Title.Text = "R, Ом"; break;
                case 2: pane.Title.Text = "Режим: DCV"; pane.YAxis.Title.Text = "U, В"; break;
                case 3: pane.Title.Text = "Режим: ACV"; pane.YAxis.Title.Text = "U, В"; break;
                case 4: pane.Title.Text = "Режим: DCA"; pane.YAxis.Title.Text = "I, А"; break;
                case 5: pane.Title.Text = "Режим: ACA"; pane.YAxis.Title.Text = "I, А"; break;
                default: pane.Title.Text = " "; pane.YAxis.Title.Text = " "; pane.XAxis.Title.Text = " "; break;
            }
            flag_recieve = true;

            int curr_x=0;                               //Вспомогательная переменная для отсчета по оси Х 
            count_number = in_cnt - _capacity;          //Переменная для определения точки отсчета 
            if ((end_flag == true) | (count_number < 0)) count_number = 0;

            PointPairList list = new PointPairList();   //Список точек
            foreach (double val in value_data)          //передача точек графика. для каждого значения в списке
            {               
               list.Add(value_date[curr_x], val);       //Берется значение из списка дат для Х и значения из массива данные для Y
                curr_x++;                               //так как отталкиваемся от списка данных, то список дат всегда начинается сначала
            }
            
            pane.XAxis.Type = AxisType.Date;            //Формат оси Х - дата
            pane.XAxis.Scale.Format = "HH:mm:ss";       //Формат отображения на оси

            LineItem myCurve = pane.AddCurve("", list, Color.Blue, SymbolType.None);// Создадим кривую по списку точек list

            zedGraph.AxisChange();                      // Обновить данные об осях.
            zedGraph.Invalidate();                      // Обновляем график
        }


//-------------Событие:Создание таблички с координатами на графике--------------------------------------
        string zedGraph_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt) 
        {
            PointPair point = curve[iPt];// Получим точку, около которой находимся
            //Берем данные из таблицы с учетом положения на графике и емкости графика
            string result = string.Format("Измерение: {0:F0}\nЗначение: {1:F4}\nВремя: {2:HH:mm:ss}", dGV1.Rows[count_number + iPt].Cells[0].Value, point.Y, dGV1.Rows[count_number + iPt].Cells[1].Value);
            return result;
        }


     
//---------------Загрузка данных из файла----------------------------------------------------------------
        public void Open_file(string where_folder)
        {
            string[] tabletValues = null;
            string[] tablet = null;
            try
            {
                tablet = File.ReadAllLines(where_folder);           //Попытка считать данные из файла в массив
            }
            catch
            {
                MessageBox.Show("Отсутствует файл test.csv", "СОМ порт", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //======               
            Thread t = new Thread(new ThreadStart(splash));         //Создание потока с экраном загрузки
            t.Start();                                              //Запуск потока
            //\======

            dGV1.Rows.Clear();                                      //Очистка таблицы

            for (int i = 0; i < tablet.Length; i++)                                                 //Берем каждый элемент массива
            {
                tabletValues = tablet[i].Split(';');                                                //Делим на части по знаку ";"
                dGV1.Rows.Add(i + 1, tabletValues[0], double.Parse(tabletValues[1]));               //Записываем в таблицу 
            }

            //----Постройка графика Zed по всем данным
            value_data.Clear();         //Сброс списка данных 
            value_date.Clear();         //Сброс списка дат
            end_flag = true;            //Выставляется для сброса curr_x в графике (построения по всем точкам)

            for (int end_graph_cnt = 0; end_graph_cnt < tablet.Length; end_graph_cnt++)             //Загружаем данные в списки
            {
                string[] tableter = ((string)dGV1.Rows[end_graph_cnt].Cells[1].Value).Split(':');   //Берем данные даты из таблицы, делим по ":"
                startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(tableter[0]), Convert.ToInt32(tableter[1]), Convert.ToInt32(tableter[2]), Convert.ToInt32(tableter[3]));
                value_date.Add(new XDate(startDate));                                               //Записываем значение даты в список графика в полном формате
                dGV1.Rows[end_graph_cnt].Cells[1].Value = String.Format("{0:HH:mm:ss}", startDate); //Перезаписываем дату в таблице, т.к. нужно отбросить миллисекунды
                try
                {
                    value_data.Add((double)dGV1.Rows[end_graph_cnt].Cells[2].Value);                //Записываем данные измерений
                }
                catch
                {
                    value_data.Add(0);
                }
            }
            DrawGraph();                                                                                //Рисуем график
            zedGraph.PointValueEvent += new ZedGraphControl.PointValueHandler(zedGraph_PointValueEvent);//Обработчик события наведения на точку на графике
            t.Abort();                                                                                  //Закрываем окно загрузки
        }

//----------------Вызывает загрузочный экран-------------------------
        public void splash()                                        
        {
            Loading_screen loadingScr = new Loading_screen();
            loadingScr.ShowDialog();
        }


 //=-----------------------------------------------------------------------------------------------------
//                                Обработчики нажатий на кнопки
//---------------------------------------------------------------------------------------------------------
        private void btnWrite_Click(object sender, EventArgs e) //Обработчик нажатия на кнопку "Запись"
        {
            SendText();
        }

       
        public void btnRead_Click(object sender, EventArgs e)   //Обработчик нажатия на кнопку "Тест"
        {                                                       //Отправляет команду VAL
            this.textBox2.Text = ":VAL?";
            SendText();
        }


        public void btnStart_Click(object sender, EventArgs e)  //Обработчик нажатия на кнопку "Начать"
        {
            if (port.IsOpen) disconnect();
            else { connect();  }
        }

        private void btn_AllMode(object sender, EventArgs e)    //Обработчик нажатия на кнопки смены режимов измерения один на все
        {                                                       //Прикреплен ко всем кнопкам на событие Click
            Button button = sender as Button;                   //Определяет вызывающющего метода как кнопку
            if (button != null) {                               //
                switch (button.Name) {                          //Смотрит, какое имя у кнопки
                                                                
                    case "btnRES":         //Сопротивление
                        textBox2.Text = ":CONF:RES 0\r";        //Отправляет выбранный режим (мультиметр не посылает ответ на эту команду)
                        SendText();
                        textBox2.Text = ":CONF:FUNC?\r";        //Запрашиваем режим
                        SendText();
                        break;

                    case "btnDCV":         //DCV
                        textBox2.Text = ":CONF:VOLT:DC 0\r";
                        SendText();
                        textBox2.Text = ":CONF:FUNC?\r";
                        SendText();
                        break;

                    case "btnACV":         //ACV
                        textBox2.Text = ":CONF:VOLT:AC 0\r";
                        SendText();
                        textBox2.Text = ":CONF:FUNC?\r";
                        SendText();
                        break;

                    case "btnDCA":         //DCA
                        textBox2.Text = ":CONF:CURR:DC 0\r";
                        SendText();
                        textBox2.Text = ":CONF:FUNC?\r";
                        SendText();
                        break;

                    case "btnACA":         //ACA
                        textBox2.Text = ":CONF:CURR:AC 0\r";
                        SendText();
                        textBox2.Text = ":CONF:FUNC?\r";
                        SendText();
                        break;
                }
            }
        }
//--------------------------------------------------------------------------
        private void rb_timeCh_Click(object sender, EventArgs e) //Нажатие на "по времени"
        {
            cmbHours.Enabled = true;
            cmbMinutes.Enabled = true;
            cmbIteration.Enabled = false;
            label14.Enabled = true;
            label15.Enabled = true;
            lblIteration.Enabled = false;
            lblTime.Enabled = true;
            lblTime_cnt.Visible = true;
        }

        private void rb_iterationCh_Click(object sender, EventArgs e) //Нажатие на "по кол-ву запросов"
        {
            cmbHours.Enabled = false;
            cmbMinutes.Enabled = false;
            cmbIteration.Enabled = true;
            label14.Enabled = false;
            label15.Enabled = false;
            lblIteration.Enabled = true;
            lblTime.Enabled = false;
            lblTime_cnt.Visible = false;
            
        }

        private void btnHelp_Click(object sender, EventArgs e)      //Нажатие на кнопку Справка
        {            
           Help popup = new Help();                                 //Создает объект popup с помощью конструктора окна Хелп
           DialogResult dialogresult = popup.ShowDialog();          //Показывает окно
           if (dialogresult == DialogResult.OK) popup.Dispose();    //При нажатии кнопки ОК окно закрывается
        }

        private void btnLoad_Click(object sender, EventArgs e)      //Нажатие на "Загрузить"
        {
            OpenFileDialog fdlg = new OpenFileDialog();             //Открывает диалог для выбора файла
            fdlg.Title = "Выберите файл";                           //Параметры открываемого окна
            fdlg.InitialDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            fdlg.Filter = "CSV Files(*.csv)|*.csv";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)               //При удачном выборе файла происходит попытка его открытия
            {
                flag_mode = 0;                                      //Сборос флага режим, т.к. в CSV файл не пишется режим
                Open_file(fdlg.FileName);                           //Открытие файла. Передаем путь до него
            }         
        }
        //======================================================================
        
        
    }
}
