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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOut1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOut2)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxDevice1
            // 
            this.comboBoxDevice1.FormattingEnabled = true;
            this.comboBoxDevice1.Location = new System.Drawing.Point(12, 27);
            this.comboBoxDevice1.Name = "comboBoxDevice1";
            this.comboBoxDevice1.Size = new System.Drawing.Size(263, 24);
            this.comboBoxDevice1.TabIndex = 0;
            this.comboBoxDevice1.SelectionChangeCommitted += new System.EventHandler(this.comboBox_SelectionChangeCommitted);
            // 
            // comboBoxDevice2
            // 
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
            this.dataGridViewIn1.Location = new System.Drawing.Point(12, 70);
            this.dataGridViewIn1.Name = "dataGridViewIn1";
            this.dataGridViewIn1.ReadOnly = true;
            this.dataGridViewIn1.RowHeadersVisible = false;
            this.dataGridViewIn1.RowHeadersWidth = 51;
            this.dataGridViewIn1.RowTemplate.Height = 24;
            this.dataGridViewIn1.Size = new System.Drawing.Size(263, 195);
            this.dataGridViewIn1.TabIndex = 3;
            // 
            // dataGridViewOut1
            // 
            this.dataGridViewOut1.AllowUserToAddRows = false;
            this.dataGridViewOut1.AllowUserToDeleteRows = false;
            this.dataGridViewOut1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOut1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOut1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOut1.Location = new System.Drawing.Point(12, 309);
            this.dataGridViewOut1.Name = "dataGridViewOut1";
            this.dataGridViewOut1.ReadOnly = true;
            this.dataGridViewOut1.RowHeadersVisible = false;
            this.dataGridViewOut1.RowHeadersWidth = 51;
            this.dataGridViewOut1.RowTemplate.Height = 24;
            this.dataGridViewOut1.Size = new System.Drawing.Size(263, 195);
            this.dataGridViewOut1.TabIndex = 4;
            // 
            // dataGridViewIn2
            // 
            this.dataGridViewIn2.AllowUserToAddRows = false;
            this.dataGridViewIn2.AllowUserToDeleteRows = false;
            this.dataGridViewIn2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewIn2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewIn2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIn2.Location = new System.Drawing.Point(887, 70);
            this.dataGridViewIn2.Name = "dataGridViewIn2";
            this.dataGridViewIn2.ReadOnly = true;
            this.dataGridViewIn2.RowHeadersVisible = false;
            this.dataGridViewIn2.RowHeadersWidth = 51;
            this.dataGridViewIn2.RowTemplate.Height = 24;
            this.dataGridViewIn2.Size = new System.Drawing.Size(263, 195);
            this.dataGridViewIn2.TabIndex = 5;
            // 
            // dataGridViewOut2
            // 
            this.dataGridViewOut2.AllowUserToAddRows = false;
            this.dataGridViewOut2.AllowUserToDeleteRows = false;
            this.dataGridViewOut2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOut2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOut2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOut2.Location = new System.Drawing.Point(887, 309);
            this.dataGridViewOut2.Name = "dataGridViewOut2";
            this.dataGridViewOut2.ReadOnly = true;
            this.dataGridViewOut2.RowHeadersVisible = false;
            this.dataGridViewOut2.RowHeadersWidth = 51;
            this.dataGridViewOut2.RowTemplate.Height = 24;
            this.dataGridViewOut2.Size = new System.Drawing.Size(263, 195);
            this.dataGridViewOut2.TabIndex = 6;
            // 
            // labelIn1
            // 
            this.labelIn1.AutoSize = true;
            this.labelIn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIn1.Location = new System.Drawing.Point(68, 268);
            this.labelIn1.Name = "labelIn1";
            this.labelIn1.Size = new System.Drawing.Size(155, 16);
            this.labelIn1.TabIndex = 7;
            this.labelIn1.Text = "Incoming (Interface 1)";
            this.labelIn1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelOut1
            // 
            this.labelOut1.AutoSize = true;
            this.labelOut1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOut1.Location = new System.Drawing.Point(68, 507);
            this.labelOut1.Name = "labelOut1";
            this.labelOut1.Size = new System.Drawing.Size(155, 16);
            this.labelOut1.TabIndex = 8;
            this.labelOut1.Text = "Outgoing (Interface 1)";
            this.labelOut1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelIn2
            // 
            this.labelIn2.AutoSize = true;
            this.labelIn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIn2.Location = new System.Drawing.Point(950, 268);
            this.labelIn2.Name = "labelIn2";
            this.labelIn2.Size = new System.Drawing.Size(155, 16);
            this.labelIn2.TabIndex = 9;
            this.labelIn2.Text = "Incoming (Interface 2)";
            this.labelIn2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelOut2
            // 
            this.labelOut2.AutoSize = true;
            this.labelOut2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOut2.Location = new System.Drawing.Point(950, 507);
            this.labelOut2.Name = "labelOut2";
            this.labelOut2.Size = new System.Drawing.Size(155, 16);
            this.labelOut2.TabIndex = 10;
            this.labelOut2.Text = "Outgoing (Interface 2)";
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
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1162, 715);
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
    }
}

