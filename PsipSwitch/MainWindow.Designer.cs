namespace PsipSwitch {
    partial class MainWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.comboBoxDevice1 = new System.Windows.Forms.ComboBox();
            this.comboBoxDevice2 = new System.Windows.Forms.ComboBox();
            this.toggleButton = new System.Windows.Forms.Button();
            this.dataGridViewIn1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewOut1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewIn2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewOut2 = new System.Windows.Forms.DataGridView();
            this.labelIn1 = new System.Windows.Forms.Label();
            this.labelOut1 = new System.Windows.Forms.Label();
            this.labelIn2 = new System.Windows.Forms.Label();
            this.labelOut2 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.dataGridViewMac = new System.Windows.Forms.DataGridView();
            this.clearMacTableButton = new System.Windows.Forms.Button();
            this.numericUpDownTimeout = new System.Windows.Forms.NumericUpDown();
            this.ifStatsResetButton1 = new System.Windows.Forms.Button();
            this.ifStatsResetButton2 = new System.Windows.Forms.Button();
            this.syslogGroupBox = new System.Windows.Forms.GroupBox();
            this.syslogToggleButton = new System.Windows.Forms.Button();
            this.dstAddrLabel = new System.Windows.Forms.Label();
            this.dstAddrTextBox = new System.Windows.Forms.TextBox();
            this.srcAddrLabel = new System.Windows.Forms.Label();
            this.srcAddrTextBox = new System.Windows.Forms.TextBox();
            this.dataGridViewAcl = new System.Windows.Forms.DataGridView();
            this.aclAddButton = new System.Windows.Forms.Button();
            this.aclRemoveButton = new System.Windows.Forms.Button();
            this.aclClearButton = new System.Windows.Forms.Button();
            this.timeoutLabel = new System.Windows.Forms.Label();
            this.interfaceLabel1 = new System.Windows.Forms.Label();
            this.interfaceLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOut1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOut2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).BeginInit();
            this.syslogGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAcl)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDevice1
            // 
            this.comboBoxDevice1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDevice1.FormattingEnabled = true;
            this.comboBoxDevice1.Location = new System.Drawing.Point(12, 27);
            this.comboBoxDevice1.Name = "comboBoxDevice1";
            this.comboBoxDevice1.Size = new System.Drawing.Size(263, 24);
            this.comboBoxDevice1.TabIndex = 0;
            this.comboBoxDevice1.SelectionChangeCommitted += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            // 
            // comboBoxDevice2
            // 
            this.comboBoxDevice2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDevice2.FormattingEnabled = true;
            this.comboBoxDevice2.Location = new System.Drawing.Point(887, 27);
            this.comboBoxDevice2.Name = "comboBoxDevice2";
            this.comboBoxDevice2.Size = new System.Drawing.Size(263, 24);
            this.comboBoxDevice2.TabIndex = 1;
            this.comboBoxDevice2.SelectionChangeCommitted += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            // 
            // toggleButton
            // 
            this.toggleButton.Enabled = false;
            this.toggleButton.Location = new System.Drawing.Point(359, 21);
            this.toggleButton.Name = "toggleButton";
            this.toggleButton.Size = new System.Drawing.Size(214, 34);
            this.toggleButton.TabIndex = 2;
            this.toggleButton.Text = "Start";
            this.toggleButton.UseVisualStyleBackColor = true;
            this.toggleButton.Click += new System.EventHandler(this.toggleButton_Click);
            // 
            // dataGridViewIn1
            // 
            this.dataGridViewIn1.AllowUserToAddRows = false;
            this.dataGridViewIn1.AllowUserToDeleteRows = false;
            this.dataGridViewIn1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewIn1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewIn1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIn1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewIn1.Location = new System.Drawing.Point(12, 70);
            this.dataGridViewIn1.Name = "dataGridViewIn1";
            this.dataGridViewIn1.ReadOnly = true;
            this.dataGridViewIn1.RowHeadersVisible = false;
            this.dataGridViewIn1.RowHeadersWidth = 51;
            this.dataGridViewIn1.RowTemplate.Height = 24;
            this.dataGridViewIn1.Size = new System.Drawing.Size(263, 216);
            this.dataGridViewIn1.TabIndex = 3;
            // 
            // dataGridViewOut1
            // 
            this.dataGridViewOut1.AllowUserToAddRows = false;
            this.dataGridViewOut1.AllowUserToDeleteRows = false;
            this.dataGridViewOut1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOut1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOut1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOut1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewOut1.Location = new System.Drawing.Point(12, 343);
            this.dataGridViewOut1.Name = "dataGridViewOut1";
            this.dataGridViewOut1.ReadOnly = true;
            this.dataGridViewOut1.RowHeadersVisible = false;
            this.dataGridViewOut1.RowHeadersWidth = 51;
            this.dataGridViewOut1.RowTemplate.Height = 24;
            this.dataGridViewOut1.Size = new System.Drawing.Size(263, 216);
            this.dataGridViewOut1.TabIndex = 4;
            // 
            // dataGridViewIn2
            // 
            this.dataGridViewIn2.AllowUserToAddRows = false;
            this.dataGridViewIn2.AllowUserToDeleteRows = false;
            this.dataGridViewIn2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewIn2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewIn2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIn2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewIn2.Location = new System.Drawing.Point(887, 70);
            this.dataGridViewIn2.Name = "dataGridViewIn2";
            this.dataGridViewIn2.ReadOnly = true;
            this.dataGridViewIn2.RowHeadersVisible = false;
            this.dataGridViewIn2.RowHeadersWidth = 51;
            this.dataGridViewIn2.RowTemplate.Height = 24;
            this.dataGridViewIn2.Size = new System.Drawing.Size(263, 216);
            this.dataGridViewIn2.TabIndex = 5;
            // 
            // dataGridViewOut2
            // 
            this.dataGridViewOut2.AllowUserToAddRows = false;
            this.dataGridViewOut2.AllowUserToDeleteRows = false;
            this.dataGridViewOut2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOut2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOut2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOut2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewOut2.Location = new System.Drawing.Point(887, 343);
            this.dataGridViewOut2.Name = "dataGridViewOut2";
            this.dataGridViewOut2.ReadOnly = true;
            this.dataGridViewOut2.RowHeadersVisible = false;
            this.dataGridViewOut2.RowHeadersWidth = 51;
            this.dataGridViewOut2.RowTemplate.Height = 24;
            this.dataGridViewOut2.Size = new System.Drawing.Size(263, 216);
            this.dataGridViewOut2.TabIndex = 6;
            // 
            // labelIn1
            // 
            this.labelIn1.AutoSize = true;
            this.labelIn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIn1.Location = new System.Drawing.Point(101, 289);
            this.labelIn1.Name = "labelIn1";
            this.labelIn1.Size = new System.Drawing.Size(69, 16);
            this.labelIn1.TabIndex = 7;
            this.labelIn1.Text = "Incoming";
            this.labelIn1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelOut1
            // 
            this.labelOut1.AutoSize = true;
            this.labelOut1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOut1.Location = new System.Drawing.Point(101, 562);
            this.labelOut1.Name = "labelOut1";
            this.labelOut1.Size = new System.Drawing.Size(69, 16);
            this.labelOut1.TabIndex = 8;
            this.labelOut1.Text = "Outgoing";
            this.labelOut1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelIn2
            // 
            this.labelIn2.AutoSize = true;
            this.labelIn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIn2.Location = new System.Drawing.Point(987, 289);
            this.labelIn2.Name = "labelIn2";
            this.labelIn2.Size = new System.Drawing.Size(69, 16);
            this.labelIn2.TabIndex = 9;
            this.labelIn2.Text = "Incoming";
            this.labelIn2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelOut2
            // 
            this.labelOut2.AutoSize = true;
            this.labelOut2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOut2.Location = new System.Drawing.Point(987, 562);
            this.labelOut2.Name = "labelOut2";
            this.labelOut2.Size = new System.Drawing.Size(69, 16);
            this.labelOut2.TabIndex = 10;
            this.labelOut2.Text = "Outgoing";
            this.labelOut2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(598, 21);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(214, 34);
            this.refreshButton.TabIndex = 11;
            this.refreshButton.Text = "Refresh Devices";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // dataGridViewMac
            // 
            this.dataGridViewMac.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMac.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewMac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMac.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewMac.Location = new System.Drawing.Point(281, 70);
            this.dataGridViewMac.Name = "dataGridViewMac";
            this.dataGridViewMac.RowHeadersVisible = false;
            this.dataGridViewMac.RowHeadersWidth = 51;
            this.dataGridViewMac.RowTemplate.Height = 24;
            this.dataGridViewMac.Size = new System.Drawing.Size(600, 216);
            this.dataGridViewMac.TabIndex = 12;
            // 
            // clearMacTableButton
            // 
            this.clearMacTableButton.Location = new System.Drawing.Point(359, 292);
            this.clearMacTableButton.Name = "clearMacTableButton";
            this.clearMacTableButton.Size = new System.Drawing.Size(214, 34);
            this.clearMacTableButton.TabIndex = 13;
            this.clearMacTableButton.Text = "Clear Table";
            this.clearMacTableButton.UseVisualStyleBackColor = true;
            this.clearMacTableButton.Click += new System.EventHandler(this.clearMacTableButton_Click);
            // 
            // numericUpDownTimeout
            // 
            this.numericUpDownTimeout.Location = new System.Drawing.Point(651, 299);
            this.numericUpDownTimeout.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.numericUpDownTimeout.Name = "numericUpDownTimeout";
            this.numericUpDownTimeout.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownTimeout.TabIndex = 14;
            this.numericUpDownTimeout.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownTimeout.ValueChanged += new System.EventHandler(this.numericUpDownTimeout_ValueChanged);
            // 
            // ifStatsResetButton1
            // 
            this.ifStatsResetButton1.Location = new System.Drawing.Point(38, 590);
            this.ifStatsResetButton1.Name = "ifStatsResetButton1";
            this.ifStatsResetButton1.Size = new System.Drawing.Size(214, 34);
            this.ifStatsResetButton1.TabIndex = 15;
            this.ifStatsResetButton1.Text = "Reset";
            this.ifStatsResetButton1.UseVisualStyleBackColor = true;
            this.ifStatsResetButton1.Click += new System.EventHandler(this.ifStatsResetButton_Click);
            // 
            // ifStatsResetButton2
            // 
            this.ifStatsResetButton2.Location = new System.Drawing.Point(913, 590);
            this.ifStatsResetButton2.Name = "ifStatsResetButton2";
            this.ifStatsResetButton2.Size = new System.Drawing.Size(214, 34);
            this.ifStatsResetButton2.TabIndex = 16;
            this.ifStatsResetButton2.Text = "Reset";
            this.ifStatsResetButton2.UseVisualStyleBackColor = true;
            this.ifStatsResetButton2.Click += new System.EventHandler(this.ifStatsResetButton_Click);
            // 
            // syslogGroupBox
            // 
            this.syslogGroupBox.Controls.Add(this.syslogToggleButton);
            this.syslogGroupBox.Controls.Add(this.dstAddrLabel);
            this.syslogGroupBox.Controls.Add(this.dstAddrTextBox);
            this.syslogGroupBox.Controls.Add(this.srcAddrLabel);
            this.syslogGroupBox.Controls.Add(this.srcAddrTextBox);
            this.syslogGroupBox.Location = new System.Drawing.Point(281, 343);
            this.syslogGroupBox.Name = "syslogGroupBox";
            this.syslogGroupBox.Size = new System.Drawing.Size(600, 216);
            this.syslogGroupBox.TabIndex = 17;
            this.syslogGroupBox.TabStop = false;
            this.syslogGroupBox.Text = "Syslog";
            // 
            // syslogToggleButton
            // 
            this.syslogToggleButton.Enabled = false;
            this.syslogToggleButton.Location = new System.Drawing.Point(187, 128);
            this.syslogToggleButton.Name = "syslogToggleButton";
            this.syslogToggleButton.Size = new System.Drawing.Size(214, 34);
            this.syslogToggleButton.TabIndex = 4;
            this.syslogToggleButton.Text = "Start";
            this.syslogToggleButton.UseVisualStyleBackColor = true;
            this.syslogToggleButton.Click += new System.EventHandler(this.syslogToggleButton_Click);
            // 
            // dstAddrLabel
            // 
            this.dstAddrLabel.AutoSize = true;
            this.dstAddrLabel.Location = new System.Drawing.Point(132, 87);
            this.dstAddrLabel.Name = "dstAddrLabel";
            this.dstAddrLabel.Size = new System.Drawing.Size(115, 16);
            this.dstAddrLabel.TabIndex = 3;
            this.dstAddrLabel.Text = "Server IP address";
            // 
            // dstAddrTextBox
            // 
            this.dstAddrTextBox.Location = new System.Drawing.Point(253, 84);
            this.dstAddrTextBox.Name = "dstAddrTextBox";
            this.dstAddrTextBox.Size = new System.Drawing.Size(171, 22);
            this.dstAddrTextBox.TabIndex = 2;
            this.dstAddrTextBox.TextChanged += new System.EventHandler(this.ipAddrTextBox_TextChanged);
            // 
            // srcAddrLabel
            // 
            this.srcAddrLabel.AutoSize = true;
            this.srcAddrLabel.Location = new System.Drawing.Point(139, 59);
            this.srcAddrLabel.Name = "srcAddrLabel";
            this.srcAddrLabel.Size = new System.Drawing.Size(108, 16);
            this.srcAddrLabel.TabIndex = 1;
            this.srcAddrLabel.Text = "Client IP address";
            // 
            // srcAddrTextBox
            // 
            this.srcAddrTextBox.Location = new System.Drawing.Point(253, 56);
            this.srcAddrTextBox.Name = "srcAddrTextBox";
            this.srcAddrTextBox.Size = new System.Drawing.Size(171, 22);
            this.srcAddrTextBox.TabIndex = 0;
            this.srcAddrTextBox.TextChanged += new System.EventHandler(this.ipAddrTextBox_TextChanged);
            // 
            // dataGridViewAcl
            // 
            this.dataGridViewAcl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAcl.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewAcl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAcl.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewAcl.Location = new System.Drawing.Point(12, 646);
            this.dataGridViewAcl.Name = "dataGridViewAcl";
            this.dataGridViewAcl.RowHeadersWidth = 51;
            this.dataGridViewAcl.RowTemplate.Height = 24;
            this.dataGridViewAcl.Size = new System.Drawing.Size(1138, 164);
            this.dataGridViewAcl.TabIndex = 18;
            this.dataGridViewAcl.SelectionChanged += new System.EventHandler(this.dataGridViewAcl_SelectionChanged);
            // 
            // aclAddButton
            // 
            this.aclAddButton.Location = new System.Drawing.Point(248, 816);
            this.aclAddButton.Name = "aclAddButton";
            this.aclAddButton.Size = new System.Drawing.Size(214, 34);
            this.aclAddButton.TabIndex = 19;
            this.aclAddButton.Text = "Add";
            this.aclAddButton.UseVisualStyleBackColor = true;
            this.aclAddButton.Click += new System.EventHandler(this.aclAddButton_Click);
            // 
            // aclRemoveButton
            // 
            this.aclRemoveButton.Enabled = false;
            this.aclRemoveButton.Location = new System.Drawing.Point(468, 816);
            this.aclRemoveButton.Name = "aclRemoveButton";
            this.aclRemoveButton.Size = new System.Drawing.Size(214, 34);
            this.aclRemoveButton.TabIndex = 20;
            this.aclRemoveButton.Text = "Remove";
            this.aclRemoveButton.UseVisualStyleBackColor = true;
            this.aclRemoveButton.Click += new System.EventHandler(this.aclRemoveButton_Click);
            // 
            // aclClearButton
            // 
            this.aclClearButton.Location = new System.Drawing.Point(688, 816);
            this.aclClearButton.Name = "aclClearButton";
            this.aclClearButton.Size = new System.Drawing.Size(214, 34);
            this.aclClearButton.TabIndex = 21;
            this.aclClearButton.Text = "Clear";
            this.aclClearButton.UseVisualStyleBackColor = true;
            this.aclClearButton.Click += new System.EventHandler(this.aclClearButton_Click);
            // 
            // timeoutLabel
            // 
            this.timeoutLabel.AutoSize = true;
            this.timeoutLabel.Location = new System.Drawing.Point(585, 301);
            this.timeoutLabel.Name = "timeoutLabel";
            this.timeoutLabel.Size = new System.Drawing.Size(60, 16);
            this.timeoutLabel.TabIndex = 22;
            this.timeoutLabel.Text = "Timer (s)";
            // 
            // interfaceLabel1
            // 
            this.interfaceLabel1.AutoSize = true;
            this.interfaceLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfaceLabel1.Location = new System.Drawing.Point(101, 9);
            this.interfaceLabel1.Name = "interfaceLabel1";
            this.interfaceLabel1.Size = new System.Drawing.Size(79, 16);
            this.interfaceLabel1.TabIndex = 23;
            this.interfaceLabel1.Text = "Interface 1";
            this.interfaceLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // interfaceLabel2
            // 
            this.interfaceLabel2.AutoSize = true;
            this.interfaceLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfaceLabel2.Location = new System.Drawing.Point(987, 9);
            this.interfaceLabel2.Name = "interfaceLabel2";
            this.interfaceLabel2.Size = new System.Drawing.Size(79, 16);
            this.interfaceLabel2.TabIndex = 24;
            this.interfaceLabel2.Text = "Interface 2";
            this.interfaceLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1162, 862);
            this.Controls.Add(this.interfaceLabel2);
            this.Controls.Add(this.interfaceLabel1);
            this.Controls.Add(this.timeoutLabel);
            this.Controls.Add(this.aclClearButton);
            this.Controls.Add(this.aclRemoveButton);
            this.Controls.Add(this.aclAddButton);
            this.Controls.Add(this.dataGridViewAcl);
            this.Controls.Add(this.syslogGroupBox);
            this.Controls.Add(this.ifStatsResetButton2);
            this.Controls.Add(this.ifStatsResetButton1);
            this.Controls.Add(this.numericUpDownTimeout);
            this.Controls.Add(this.clearMacTableButton);
            this.Controls.Add(this.dataGridViewMac);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.labelOut2);
            this.Controls.Add(this.labelIn2);
            this.Controls.Add(this.labelOut1);
            this.Controls.Add(this.labelIn1);
            this.Controls.Add(this.dataGridViewOut2);
            this.Controls.Add(this.dataGridViewIn2);
            this.Controls.Add(this.dataGridViewOut1);
            this.Controls.Add(this.dataGridViewIn1);
            this.Controls.Add(this.toggleButton);
            this.Controls.Add(this.comboBoxDevice2);
            this.Controls.Add(this.comboBoxDevice1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "PSIP L2 Switch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOut1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOut2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimeout)).EndInit();
            this.syslogGroupBox.ResumeLayout(false);
            this.syslogGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAcl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDevice1;
        private System.Windows.Forms.ComboBox comboBoxDevice2;
        private System.Windows.Forms.Button toggleButton;
        private System.Windows.Forms.DataGridView dataGridViewIn1;
        private System.Windows.Forms.DataGridView dataGridViewOut1;
        private System.Windows.Forms.DataGridView dataGridViewIn2;
        private System.Windows.Forms.DataGridView dataGridViewOut2;
        private System.Windows.Forms.Label labelIn1;
        private System.Windows.Forms.Label labelOut1;
        private System.Windows.Forms.Label labelIn2;
        private System.Windows.Forms.Label labelOut2;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.DataGridView dataGridViewMac;
        private System.Windows.Forms.Button clearMacTableButton;
        private System.Windows.Forms.NumericUpDown numericUpDownTimeout;
        private System.Windows.Forms.Button ifStatsResetButton1;
        private System.Windows.Forms.Button ifStatsResetButton2;
        private System.Windows.Forms.GroupBox syslogGroupBox;
        private System.Windows.Forms.Label srcAddrLabel;
        private System.Windows.Forms.TextBox srcAddrTextBox;
        private System.Windows.Forms.Label dstAddrLabel;
        private System.Windows.Forms.TextBox dstAddrTextBox;
        private System.Windows.Forms.Button syslogToggleButton;
        private System.Windows.Forms.DataGridView dataGridViewAcl;
        private System.Windows.Forms.Button aclAddButton;
        private System.Windows.Forms.Button aclRemoveButton;
        private System.Windows.Forms.Button aclClearButton;
        private System.Windows.Forms.Label timeoutLabel;
        private System.Windows.Forms.Label interfaceLabel1;
        private System.Windows.Forms.Label interfaceLabel2;
    }
}

