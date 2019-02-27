namespace WindowsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnWrite = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnDCV = new System.Windows.Forms.Button();
            this.gbWrite = new System.Windows.Forms.GroupBox();
            this.gbCommands = new System.Windows.Forms.GroupBox();
            this.btnRES = new System.Windows.Forms.Button();
            this.btnACA = new System.Windows.Forms.Button();
            this.btnDCA = new System.Windows.Forms.Button();
            this.btnACV = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.gbSetup = new System.Windows.Forms.GroupBox();
            this.lblStopB = new System.Windows.Forms.Label();
            this.lblDataB = new System.Windows.Forms.Label();
            this.lblParity = new System.Windows.Forms.Label();
            this.lblBaudR = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.gbLoop = new System.Windows.Forms.GroupBox();
            this.lbl_Capacity = new System.Windows.Forms.Label();
            this.cmbCapacity = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbMinutes = new System.Windows.Forms.ComboBox();
            this.cmbHours = new System.Windows.Forms.ComboBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.rb_iterationCh = new System.Windows.Forms.RadioButton();
            this.rb_timeCh = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoop = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lblIteration = new System.Windows.Forms.Label();
            this.cmbInterval = new System.Windows.Forms.ComboBox();
            this.cmbIteration = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.dGV1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblOutCnt = new System.Windows.Forms.Label();
            this.lblInCnt = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.zedGraph = new ZedGraph.ZedGraphControl();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblTime_cnt = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.gbWrite.SuspendLayout();
            this.gbCommands.SuspendLayout();
            this.gbSetup.SuspendLayout();
            this.gbLoop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(90, 45);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(52, 23);
            this.btnWrite.TabIndex = 2;
            this.btnWrite.Text = "Запись";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(136, 20);
            this.textBox2.TabIndex = 3;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(6, 45);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(48, 23);
            this.btnRead.TabIndex = 6;
            this.btnRead.Text = "Тест";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnDCV
            // 
            this.btnDCV.Location = new System.Drawing.Point(6, 48);
            this.btnDCV.Name = "btnDCV";
            this.btnDCV.Size = new System.Drawing.Size(134, 23);
            this.btnDCV.TabIndex = 7;
            this.btnDCV.Tag = "2";
            this.btnDCV.Text = "DCV";
            this.btnDCV.UseVisualStyleBackColor = true;
            this.btnDCV.Click += new System.EventHandler(this.btn_AllMode);
            // 
            // gbWrite
            // 
            this.gbWrite.Controls.Add(this.textBox2);
            this.gbWrite.Controls.Add(this.btnWrite);
            this.gbWrite.Controls.Add(this.btnRead);
            this.gbWrite.Enabled = false;
            this.gbWrite.Location = new System.Drawing.Point(10, 378);
            this.gbWrite.Name = "gbWrite";
            this.gbWrite.Size = new System.Drawing.Size(152, 75);
            this.gbWrite.TabIndex = 8;
            this.gbWrite.TabStop = false;
            this.gbWrite.Text = "Своя команда";
            // 
            // gbCommands
            // 
            this.gbCommands.Controls.Add(this.btnRES);
            this.gbCommands.Controls.Add(this.btnACA);
            this.gbCommands.Controls.Add(this.btnDCA);
            this.gbCommands.Controls.Add(this.btnACV);
            this.gbCommands.Controls.Add(this.btnDCV);
            this.gbCommands.Enabled = false;
            this.gbCommands.Location = new System.Drawing.Point(12, 204);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.Size = new System.Drawing.Size(150, 168);
            this.gbCommands.TabIndex = 9;
            this.gbCommands.TabStop = false;
            this.gbCommands.Text = "Режимы измерения";
            // 
            // btnRES
            // 
            this.btnRES.BackColor = System.Drawing.SystemColors.Control;
            this.btnRES.Location = new System.Drawing.Point(6, 19);
            this.btnRES.Name = "btnRES";
            this.btnRES.Size = new System.Drawing.Size(134, 23);
            this.btnRES.TabIndex = 11;
            this.btnRES.Tag = "1";
            this.btnRES.Text = "Сопротивление";
            this.btnRES.UseVisualStyleBackColor = false;
            this.btnRES.Click += new System.EventHandler(this.btn_AllMode);
            // 
            // btnACA
            // 
            this.btnACA.Location = new System.Drawing.Point(6, 135);
            this.btnACA.Name = "btnACA";
            this.btnACA.Size = new System.Drawing.Size(134, 23);
            this.btnACA.TabIndex = 10;
            this.btnACA.Tag = "5";
            this.btnACA.Text = "ACA";
            this.btnACA.UseVisualStyleBackColor = true;
            this.btnACA.Click += new System.EventHandler(this.btn_AllMode);
            // 
            // btnDCA
            // 
            this.btnDCA.Location = new System.Drawing.Point(6, 106);
            this.btnDCA.Name = "btnDCA";
            this.btnDCA.Size = new System.Drawing.Size(134, 23);
            this.btnDCA.TabIndex = 9;
            this.btnDCA.Tag = "4";
            this.btnDCA.Text = "DCA";
            this.btnDCA.UseVisualStyleBackColor = true;
            this.btnDCA.Click += new System.EventHandler(this.btn_AllMode);
            // 
            // btnACV
            // 
            this.btnACV.Location = new System.Drawing.Point(6, 77);
            this.btnACV.Name = "btnACV";
            this.btnACV.Size = new System.Drawing.Size(134, 23);
            this.btnACV.TabIndex = 8;
            this.btnACV.Tag = "3";
            this.btnACV.Text = "ACV";
            this.btnACV.UseVisualStyleBackColor = true;
            this.btnACV.Click += new System.EventHandler(this.btn_AllMode);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Начать";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(437, 322);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(417, 160);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // gbSetup
            // 
            this.gbSetup.Controls.Add(this.lblStopB);
            this.gbSetup.Controls.Add(this.lblDataB);
            this.gbSetup.Controls.Add(this.lblParity);
            this.gbSetup.Controls.Add(this.lblBaudR);
            this.gbSetup.Controls.Add(this.lblPort);
            this.gbSetup.Controls.Add(this.cmbStopBits);
            this.gbSetup.Controls.Add(this.cmbDataBits);
            this.gbSetup.Controls.Add(this.cmbParity);
            this.gbSetup.Controls.Add(this.cmbBaudRate);
            this.gbSetup.Controls.Add(this.cmbPortName);
            this.gbSetup.Location = new System.Drawing.Point(12, 41);
            this.gbSetup.Name = "gbSetup";
            this.gbSetup.Size = new System.Drawing.Size(150, 157);
            this.gbSetup.TabIndex = 12;
            this.gbSetup.TabStop = false;
            this.gbSetup.Text = "Настройка порта";
            // 
            // lblStopB
            // 
            this.lblStopB.AutoSize = true;
            this.lblStopB.Location = new System.Drawing.Point(4, 133);
            this.lblStopB.Name = "lblStopB";
            this.lblStopB.Size = new System.Drawing.Size(49, 13);
            this.lblStopB.TabIndex = 9;
            this.lblStopB.Text = "Stop Bits";
            // 
            // lblDataB
            // 
            this.lblDataB.AutoSize = true;
            this.lblDataB.Location = new System.Drawing.Point(4, 106);
            this.lblDataB.Name = "lblDataB";
            this.lblDataB.Size = new System.Drawing.Size(50, 13);
            this.lblDataB.TabIndex = 8;
            this.lblDataB.Text = "Data Bits";
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Location = new System.Drawing.Point(4, 79);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(33, 13);
            this.lblParity.TabIndex = 7;
            this.lblParity.Text = "Parity";
            // 
            // lblBaudR
            // 
            this.lblBaudR.AutoSize = true;
            this.lblBaudR.Location = new System.Drawing.Point(4, 52);
            this.lblBaudR.Name = "lblBaudR";
            this.lblBaudR.Size = new System.Drawing.Size(64, 13);
            this.lblBaudR.TabIndex = 6;
            this.lblBaudR.Text = "Baude Rate";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(4, 25);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(57, 13);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "СОМ порт";
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbStopBits.Location = new System.Drawing.Point(71, 130);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(69, 21);
            this.cmbStopBits.TabIndex = 4;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Items.AddRange(new object[] {
            "7",
            "8"});
            this.cmbDataBits.Location = new System.Drawing.Point(71, 103);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(69, 21);
            this.cmbDataBits.TabIndex = 3;
            // 
            // cmbParity
            // 
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Odd"});
            this.cmbParity.Location = new System.Drawing.Point(71, 76);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(69, 21);
            this.cmbParity.TabIndex = 2;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600"});
            this.cmbBaudRate.Location = new System.Drawing.Point(71, 49);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(69, 21);
            this.cmbBaudRate.TabIndex = 1;
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(71, 22);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(69, 21);
            this.cmbPortName.TabIndex = 0;
            // 
            // gbLoop
            // 
            this.gbLoop.Controls.Add(this.lbl_Capacity);
            this.gbLoop.Controls.Add(this.cmbCapacity);
            this.gbLoop.Controls.Add(this.label15);
            this.gbLoop.Controls.Add(this.label14);
            this.gbLoop.Controls.Add(this.cmbMinutes);
            this.gbLoop.Controls.Add(this.cmbHours);
            this.gbLoop.Controls.Add(this.lblTime);
            this.gbLoop.Controls.Add(this.rb_iterationCh);
            this.gbLoop.Controls.Add(this.rb_timeCh);
            this.gbLoop.Controls.Add(this.btnSave);
            this.gbLoop.Controls.Add(this.btnLoop);
            this.gbLoop.Controls.Add(this.label9);
            this.gbLoop.Controls.Add(this.lblIteration);
            this.gbLoop.Controls.Add(this.cmbInterval);
            this.gbLoop.Controls.Add(this.cmbIteration);
            this.gbLoop.Enabled = false;
            this.gbLoop.Location = new System.Drawing.Point(168, 75);
            this.gbLoop.Name = "gbLoop";
            this.gbLoop.Size = new System.Drawing.Size(263, 197);
            this.gbLoop.TabIndex = 13;
            this.gbLoop.TabStop = false;
            this.gbLoop.Text = "Цикл";
            // 
            // lbl_Capacity
            // 
            this.lbl_Capacity.AutoSize = true;
            this.lbl_Capacity.Location = new System.Drawing.Point(3, 132);
            this.lbl_Capacity.Name = "lbl_Capacity";
            this.lbl_Capacity.Size = new System.Drawing.Size(116, 26);
            this.lbl_Capacity.TabIndex = 30;
            this.lbl_Capacity.Text = "Количество значений\r\nна графике";
            // 
            // cmbCapacity
            // 
            this.cmbCapacity.FormattingEnabled = true;
            this.cmbCapacity.Items.AddRange(new object[] {
            "5000",
            "10000"});
            this.cmbCapacity.Location = new System.Drawing.Point(136, 129);
            this.cmbCapacity.Name = "cmbCapacity";
            this.cmbCapacity.Size = new System.Drawing.Size(121, 21);
            this.cmbCapacity.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Enabled = false;
            this.label15.Location = new System.Drawing.Point(183, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "мин:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Location = new System.Drawing.Point(91, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "часов:";
            // 
            // cmbMinutes
            // 
            this.cmbMinutes.Enabled = false;
            this.cmbMinutes.FormattingEnabled = true;
            this.cmbMinutes.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.cmbMinutes.Location = new System.Drawing.Point(219, 69);
            this.cmbMinutes.Name = "cmbMinutes";
            this.cmbMinutes.Size = new System.Drawing.Size(38, 21);
            this.cmbMinutes.TabIndex = 26;
            // 
            // cmbHours
            // 
            this.cmbHours.Enabled = false;
            this.cmbHours.FormattingEnabled = true;
            this.cmbHours.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cmbHours.Location = new System.Drawing.Point(136, 69);
            this.cmbHours.Name = "cmbHours";
            this.cmbHours.Size = new System.Drawing.Size(38, 21);
            this.cmbHours.TabIndex = 25;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Enabled = false;
            this.lblTime.Location = new System.Drawing.Point(3, 72);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(73, 13);
            this.lblTime.TabIndex = 24;
            this.lblTime.Text = "Время цикла";
            // 
            // rb_iterationCh
            // 
            this.rb_iterationCh.AutoSize = true;
            this.rb_iterationCh.Checked = true;
            this.rb_iterationCh.Location = new System.Drawing.Point(132, 19);
            this.rb_iterationCh.Name = "rb_iterationCh";
            this.rb_iterationCh.Size = new System.Drawing.Size(125, 17);
            this.rb_iterationCh.TabIndex = 23;
            this.rb_iterationCh.TabStop = true;
            this.rb_iterationCh.Text = "По кол-ву запросов";
            this.rb_iterationCh.UseVisualStyleBackColor = true;
            this.rb_iterationCh.Click += new System.EventHandler(this.rb_iterationCh_Click);
            // 
            // rb_timeCh
            // 
            this.rb_timeCh.AutoSize = true;
            this.rb_timeCh.Location = new System.Drawing.Point(6, 19);
            this.rb_timeCh.Name = "rb_timeCh";
            this.rb_timeCh.Size = new System.Drawing.Size(86, 17);
            this.rb_timeCh.TabIndex = 22;
            this.rb_timeCh.Text = "По времени";
            this.rb_timeCh.UseVisualStyleBackColor = true;
            this.rb_timeCh.Click += new System.EventHandler(this.rb_timeCh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Передать в Excel";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.xL_start);
            // 
            // btnLoop
            // 
            this.btnLoop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoop.ImageKey = "(none)";
            this.btnLoop.Location = new System.Drawing.Point(151, 168);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(106, 23);
            this.btnLoop.TabIndex = 20;
            this.btnLoop.Text = "Запуск";
            this.btnLoop.UseVisualStyleBackColor = true;
            this.btnLoop.Click += new System.EventHandler(this.btnLoop_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Интервал опроса (сек)";
            // 
            // lblIteration
            // 
            this.lblIteration.AutoSize = true;
            this.lblIteration.Location = new System.Drawing.Point(3, 45);
            this.lblIteration.Name = "lblIteration";
            this.lblIteration.Size = new System.Drawing.Size(92, 13);
            this.lblIteration.TabIndex = 18;
            this.lblIteration.Text = "Кол-во запросов";
            // 
            // cmbInterval
            // 
            this.cmbInterval.FormattingEnabled = true;
            this.cmbInterval.Items.AddRange(new object[] {
            "Минимальный",
            "0.5",
            "1",
            "2",
            "5",
            "10"});
            this.cmbInterval.Location = new System.Drawing.Point(136, 99);
            this.cmbInterval.Name = "cmbInterval";
            this.cmbInterval.Size = new System.Drawing.Size(121, 21);
            this.cmbInterval.TabIndex = 16;
            // 
            // cmbIteration
            // 
            this.cmbIteration.FormattingEnabled = true;
            this.cmbIteration.Items.AddRange(new object[] {
            "Бесконечно",
            "5000",
            "10000",
            "20000",
            "50000",
            "100000"});
            this.cmbIteration.Location = new System.Drawing.Point(136, 42);
            this.cmbIteration.Name = "cmbIteration";
            this.cmbIteration.Size = new System.Drawing.Size(121, 21);
            this.cmbIteration.TabIndex = 15;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(171, 279);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Полученные данные:";
            // 
            // dGV1
            // 
            this.dGV1.AllowUserToAddRows = false;
            this.dGV1.AllowUserToDeleteRows = false;
            this.dGV1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dGV1.Location = new System.Drawing.Point(168, 295);
            this.dGV1.Name = "dGV1";
            this.dGV1.ReadOnly = true;
            this.dGV1.RowHeadersVisible = false;
            this.dGV1.Size = new System.Drawing.Size(262, 187);
            this.dGV1.TabIndex = 15;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 78.08073F;
            this.Column1.HeaderText = "Номер";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 121.8274F;
            this.Column2.HeaderText = "Время";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.ToolTipText = "Часы\\Минуты\\Секунды";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 100.0919F;
            this.Column3.HeaderText = "Данные";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(171, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Отправлено:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(301, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Принято:";
            // 
            // lblOutCnt
            // 
            this.lblOutCnt.AutoSize = true;
            this.lblOutCnt.Location = new System.Drawing.Point(240, 25);
            this.lblOutCnt.Name = "lblOutCnt";
            this.lblOutCnt.Size = new System.Drawing.Size(13, 13);
            this.lblOutCnt.TabIndex = 18;
            this.lblOutCnt.Text = "0";
            // 
            // lblInCnt
            // 
            this.lblInCnt.AutoSize = true;
            this.lblInCnt.Location = new System.Drawing.Point(360, 25);
            this.lblInCnt.Name = "lblInCnt";
            this.lblInCnt.Size = new System.Drawing.Size(13, 13);
            this.lblInCnt.TabIndex = 19;
            this.lblInCnt.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(76, 423);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 13);
            this.label13.TabIndex = 20;
            // 
            // zedGraph
            // 
            this.zedGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraph.Location = new System.Drawing.Point(437, -2);
            this.zedGraph.Name = "zedGraph";
            this.zedGraph.ScrollGrace = 0;
            this.zedGraph.ScrollMaxX = 0;
            this.zedGraph.ScrollMaxY = 0;
            this.zedGraph.ScrollMaxY2 = 0;
            this.zedGraph.ScrollMinX = 0;
            this.zedGraph.ScrollMinY = 0;
            this.zedGraph.ScrollMinY2 = 0;
            this.zedGraph.Size = new System.Drawing.Size(416, 318);
            this.zedGraph.TabIndex = 21;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblTime_cnt
            // 
            this.lblTime_cnt.AutoSize = true;
            this.lblTime_cnt.Location = new System.Drawing.Point(171, 9);
            this.lblTime_cnt.Name = "lblTime_cnt";
            this.lblTime_cnt.Size = new System.Drawing.Size(108, 13);
            this.lblTime_cnt.TabIndex = 22;
            this.lblTime_cnt.Text = "Оставшееся время:";
            this.lblTime_cnt.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(174, 46);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(251, 23);
            this.progressBar1.TabIndex = 23;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 500;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(87, 459);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 25;
            this.btnLoad.Text = "Загрузить из файла";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Image = global::WindowsApplication1.Properties.Resources.HelpIcon_solid;
            this.btnHelp.Location = new System.Drawing.Point(10, 459);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(32, 23);
            this.btnHelp.TabIndex = 24;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 487);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblTime_cnt);
            this.Controls.Add(this.zedGraph);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblInCnt);
            this.Controls.Add(this.lblOutCnt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dGV1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.gbLoop);
            this.Controls.Add(this.gbWrite);
            this.Controls.Add(this.gbSetup);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gbCommands);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Serial Port GDM-8246";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbWrite.ResumeLayout(false);
            this.gbWrite.PerformLayout();
            this.gbCommands.ResumeLayout(false);
            this.gbSetup.ResumeLayout(false);
            this.gbSetup.PerformLayout();
            this.gbLoop.ResumeLayout(false);
            this.gbLoop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnDCV;
        private System.Windows.Forms.GroupBox gbWrite;
        private System.Windows.Forms.GroupBox gbCommands;
        private System.Windows.Forms.Button btnACV;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gbSetup;
        private System.Windows.Forms.Label lblStopB;
        private System.Windows.Forms.Label lblDataB;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.Label lblBaudR;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.GroupBox gbLoop;
        private System.Windows.Forms.Button btnLoop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblIteration;
        private System.Windows.Forms.ComboBox cmbInterval;
        private System.Windows.Forms.ComboBox cmbIteration;
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnACA;
        private System.Windows.Forms.Button btnDCA;
        private System.Windows.Forms.Button btnRES;
        private System.Windows.Forms.DataGridView dGV1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblOutCnt;
        private System.Windows.Forms.Label lblInCnt;
        private System.Windows.Forms.Label label13;
        private ZedGraph.ZedGraphControl zedGraph;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton rb_iterationCh;
        private System.Windows.Forms.RadioButton rb_timeCh;
        private System.Windows.Forms.ComboBox cmbMinutes;
        private System.Windows.Forms.ComboBox cmbHours;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblTime_cnt;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lbl_Capacity;
        private System.Windows.Forms.ComboBox cmbCapacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

