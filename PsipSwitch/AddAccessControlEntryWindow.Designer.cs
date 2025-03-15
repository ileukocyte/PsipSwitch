namespace PsipSwitch {
    partial class AddAccessControlEntryWindow {
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
            this.saveEntryButton = new System.Windows.Forms.Button();
            this.basicConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.interfaceLabel = new System.Windows.Forms.Label();
            this.interfaceComboBox = new System.Windows.Forms.ComboBox();
            this.protocolLabel = new System.Windows.Forms.Label();
            this.directionLabel = new System.Windows.Forms.Label();
            this.actionLabel = new System.Windows.Forms.Label();
            this.protocolComboBox = new System.Windows.Forms.ComboBox();
            this.directionComboBox = new System.Windows.Forms.ComboBox();
            this.actionComboBox = new System.Windows.Forms.ComboBox();
            this.ipConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.srcIpTextBox = new System.Windows.Forms.TextBox();
            this.dstIpTextBox = new System.Windows.Forms.TextBox();
            this.dstIpLabel = new System.Windows.Forms.Label();
            this.srcIpLabel = new System.Windows.Forms.Label();
            this.macConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.srcMacTextBox = new System.Windows.Forms.TextBox();
            this.srcMacLabel = new System.Windows.Forms.Label();
            this.dstMacTextBox = new System.Windows.Forms.TextBox();
            this.dstMacLabel = new System.Windows.Forms.Label();
            this.miscGroupBox = new System.Windows.Forms.GroupBox();
            this.icmpComboBox = new System.Windows.Forms.ComboBox();
            this.icmpLabel = new System.Windows.Forms.Label();
            this.srcPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dstPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dstPortLabel = new System.Windows.Forms.Label();
            this.srcPortLabel = new System.Windows.Forms.Label();
            this.basicConfigGroupBox.SuspendLayout();
            this.ipConfigGroupBox.SuspendLayout();
            this.macConfigGroupBox.SuspendLayout();
            this.miscGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcPortNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstPortNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // saveEntryButton
            // 
            this.saveEntryButton.Enabled = false;
            this.saveEntryButton.Location = new System.Drawing.Point(269, 319);
            this.saveEntryButton.Name = "saveEntryButton";
            this.saveEntryButton.Size = new System.Drawing.Size(133, 36);
            this.saveEntryButton.TabIndex = 0;
            this.saveEntryButton.Text = "Add";
            this.saveEntryButton.UseVisualStyleBackColor = true;
            this.saveEntryButton.Click += new System.EventHandler(this.saveEntryButton_Click);
            // 
            // basicConfigGroupBox
            // 
            this.basicConfigGroupBox.Controls.Add(this.interfaceLabel);
            this.basicConfigGroupBox.Controls.Add(this.interfaceComboBox);
            this.basicConfigGroupBox.Controls.Add(this.protocolLabel);
            this.basicConfigGroupBox.Controls.Add(this.directionLabel);
            this.basicConfigGroupBox.Controls.Add(this.actionLabel);
            this.basicConfigGroupBox.Controls.Add(this.protocolComboBox);
            this.basicConfigGroupBox.Controls.Add(this.directionComboBox);
            this.basicConfigGroupBox.Controls.Add(this.actionComboBox);
            this.basicConfigGroupBox.Location = new System.Drawing.Point(12, 12);
            this.basicConfigGroupBox.Name = "basicConfigGroupBox";
            this.basicConfigGroupBox.Size = new System.Drawing.Size(321, 146);
            this.basicConfigGroupBox.TabIndex = 1;
            this.basicConfigGroupBox.TabStop = false;
            this.basicConfigGroupBox.Text = "Basic Configuration";
            // 
            // interfaceLabel
            // 
            this.interfaceLabel.AutoSize = true;
            this.interfaceLabel.Location = new System.Drawing.Point(6, 114);
            this.interfaceLabel.Name = "interfaceLabel";
            this.interfaceLabel.Size = new System.Drawing.Size(58, 16);
            this.interfaceLabel.TabIndex = 7;
            this.interfaceLabel.Text = "Interface";
            // 
            // interfaceComboBox
            // 
            this.interfaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interfaceComboBox.FormattingEnabled = true;
            this.interfaceComboBox.Location = new System.Drawing.Point(72, 111);
            this.interfaceComboBox.Name = "interfaceComboBox";
            this.interfaceComboBox.Size = new System.Drawing.Size(191, 24);
            this.interfaceComboBox.TabIndex = 6;
            this.interfaceComboBox.SelectionChangeCommitted += new System.EventHandler(this.InputValidation);
            // 
            // protocolLabel
            // 
            this.protocolLabel.AutoSize = true;
            this.protocolLabel.Location = new System.Drawing.Point(6, 84);
            this.protocolLabel.Name = "protocolLabel";
            this.protocolLabel.Size = new System.Drawing.Size(57, 16);
            this.protocolLabel.TabIndex = 5;
            this.protocolLabel.Text = "Protocol";
            // 
            // directionLabel
            // 
            this.directionLabel.AutoSize = true;
            this.directionLabel.Location = new System.Drawing.Point(6, 54);
            this.directionLabel.Name = "directionLabel";
            this.directionLabel.Size = new System.Drawing.Size(60, 16);
            this.directionLabel.TabIndex = 4;
            this.directionLabel.Text = "Direction";
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(6, 24);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(44, 16);
            this.actionLabel.TabIndex = 3;
            this.actionLabel.Text = "Action";
            // 
            // protocolComboBox
            // 
            this.protocolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.protocolComboBox.FormattingEnabled = true;
            this.protocolComboBox.Location = new System.Drawing.Point(72, 81);
            this.protocolComboBox.Name = "protocolComboBox";
            this.protocolComboBox.Size = new System.Drawing.Size(191, 24);
            this.protocolComboBox.TabIndex = 2;
            this.protocolComboBox.SelectionChangeCommitted += new System.EventHandler(this.InputValidation);
            // 
            // directionComboBox
            // 
            this.directionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directionComboBox.FormattingEnabled = true;
            this.directionComboBox.Location = new System.Drawing.Point(72, 51);
            this.directionComboBox.Name = "directionComboBox";
            this.directionComboBox.Size = new System.Drawing.Size(191, 24);
            this.directionComboBox.TabIndex = 1;
            this.directionComboBox.SelectionChangeCommitted += new System.EventHandler(this.InputValidation);
            // 
            // actionComboBox
            // 
            this.actionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.Location = new System.Drawing.Point(72, 21);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(191, 24);
            this.actionComboBox.TabIndex = 0;
            this.actionComboBox.SelectionChangeCommitted += new System.EventHandler(this.InputValidation);
            // 
            // ipConfigGroupBox
            // 
            this.ipConfigGroupBox.Controls.Add(this.srcIpTextBox);
            this.ipConfigGroupBox.Controls.Add(this.dstIpTextBox);
            this.ipConfigGroupBox.Controls.Add(this.dstIpLabel);
            this.ipConfigGroupBox.Controls.Add(this.srcIpLabel);
            this.ipConfigGroupBox.Location = new System.Drawing.Point(339, 12);
            this.ipConfigGroupBox.Name = "ipConfigGroupBox";
            this.ipConfigGroupBox.Size = new System.Drawing.Size(321, 146);
            this.ipConfigGroupBox.TabIndex = 2;
            this.ipConfigGroupBox.TabStop = false;
            this.ipConfigGroupBox.Text = "IPv4 Configuration";
            // 
            // srcIpTextBox
            // 
            this.srcIpTextBox.Location = new System.Drawing.Point(140, 21);
            this.srcIpTextBox.Name = "srcIpTextBox";
            this.srcIpTextBox.Size = new System.Drawing.Size(168, 22);
            this.srcIpTextBox.TabIndex = 13;
            this.srcIpTextBox.TextChanged += new System.EventHandler(this.InputValidation);
            // 
            // dstIpTextBox
            // 
            this.dstIpTextBox.Location = new System.Drawing.Point(140, 51);
            this.dstIpTextBox.Name = "dstIpTextBox";
            this.dstIpTextBox.Size = new System.Drawing.Size(168, 22);
            this.dstIpTextBox.TabIndex = 12;
            this.dstIpTextBox.TextChanged += new System.EventHandler(this.InputValidation);
            // 
            // dstIpLabel
            // 
            this.dstIpLabel.AutoSize = true;
            this.dstIpLabel.Location = new System.Drawing.Point(6, 54);
            this.dstIpLabel.Name = "dstIpLabel";
            this.dstIpLabel.Size = new System.Drawing.Size(128, 16);
            this.dstIpLabel.TabIndex = 11;
            this.dstIpLabel.Text = "Destination Address";
            // 
            // srcIpLabel
            // 
            this.srcIpLabel.AutoSize = true;
            this.srcIpLabel.Location = new System.Drawing.Point(6, 24);
            this.srcIpLabel.Name = "srcIpLabel";
            this.srcIpLabel.Size = new System.Drawing.Size(104, 16);
            this.srcIpLabel.TabIndex = 10;
            this.srcIpLabel.Text = "Source Address";
            // 
            // macConfigGroupBox
            // 
            this.macConfigGroupBox.Controls.Add(this.srcMacTextBox);
            this.macConfigGroupBox.Controls.Add(this.srcMacLabel);
            this.macConfigGroupBox.Controls.Add(this.dstMacTextBox);
            this.macConfigGroupBox.Controls.Add(this.dstMacLabel);
            this.macConfigGroupBox.Location = new System.Drawing.Point(12, 164);
            this.macConfigGroupBox.Name = "macConfigGroupBox";
            this.macConfigGroupBox.Size = new System.Drawing.Size(321, 146);
            this.macConfigGroupBox.TabIndex = 3;
            this.macConfigGroupBox.TabStop = false;
            this.macConfigGroupBox.Text = "MAC Configuration";
            // 
            // srcMacTextBox
            // 
            this.srcMacTextBox.Location = new System.Drawing.Point(140, 24);
            this.srcMacTextBox.Name = "srcMacTextBox";
            this.srcMacTextBox.Size = new System.Drawing.Size(168, 22);
            this.srcMacTextBox.TabIndex = 17;
            this.srcMacTextBox.TextChanged += new System.EventHandler(this.InputValidation);
            // 
            // srcMacLabel
            // 
            this.srcMacLabel.AutoSize = true;
            this.srcMacLabel.Location = new System.Drawing.Point(6, 27);
            this.srcMacLabel.Name = "srcMacLabel";
            this.srcMacLabel.Size = new System.Drawing.Size(104, 16);
            this.srcMacLabel.TabIndex = 14;
            this.srcMacLabel.Text = "Source Address";
            // 
            // dstMacTextBox
            // 
            this.dstMacTextBox.Location = new System.Drawing.Point(140, 54);
            this.dstMacTextBox.Name = "dstMacTextBox";
            this.dstMacTextBox.Size = new System.Drawing.Size(168, 22);
            this.dstMacTextBox.TabIndex = 16;
            this.dstMacTextBox.TextChanged += new System.EventHandler(this.InputValidation);
            // 
            // dstMacLabel
            // 
            this.dstMacLabel.AutoSize = true;
            this.dstMacLabel.Location = new System.Drawing.Point(6, 57);
            this.dstMacLabel.Name = "dstMacLabel";
            this.dstMacLabel.Size = new System.Drawing.Size(128, 16);
            this.dstMacLabel.TabIndex = 15;
            this.dstMacLabel.Text = "Destination Address";
            // 
            // miscGroupBox
            // 
            this.miscGroupBox.Controls.Add(this.icmpComboBox);
            this.miscGroupBox.Controls.Add(this.icmpLabel);
            this.miscGroupBox.Controls.Add(this.srcPortNumericUpDown);
            this.miscGroupBox.Controls.Add(this.dstPortNumericUpDown);
            this.miscGroupBox.Controls.Add(this.dstPortLabel);
            this.miscGroupBox.Controls.Add(this.srcPortLabel);
            this.miscGroupBox.Location = new System.Drawing.Point(339, 164);
            this.miscGroupBox.Name = "miscGroupBox";
            this.miscGroupBox.Size = new System.Drawing.Size(321, 146);
            this.miscGroupBox.TabIndex = 4;
            this.miscGroupBox.TabStop = false;
            this.miscGroupBox.Text = "Miscellaneous";
            // 
            // icmpComboBox
            // 
            this.icmpComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icmpComboBox.FormattingEnabled = true;
            this.icmpComboBox.Location = new System.Drawing.Point(113, 76);
            this.icmpComboBox.Name = "icmpComboBox";
            this.icmpComboBox.Size = new System.Drawing.Size(121, 24);
            this.icmpComboBox.TabIndex = 19;
            this.icmpComboBox.SelectionChangeCommitted += new System.EventHandler(this.InputValidation);
            // 
            // icmpLabel
            // 
            this.icmpLabel.AutoSize = true;
            this.icmpLabel.Location = new System.Drawing.Point(6, 79);
            this.icmpLabel.Name = "icmpLabel";
            this.icmpLabel.Size = new System.Drawing.Size(74, 16);
            this.icmpLabel.TabIndex = 18;
            this.icmpLabel.Text = "ICMP Type";
            // 
            // srcPortNumericUpDown
            // 
            this.srcPortNumericUpDown.Location = new System.Drawing.Point(113, 21);
            this.srcPortNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.srcPortNumericUpDown.Name = "srcPortNumericUpDown";
            this.srcPortNumericUpDown.Size = new System.Drawing.Size(96, 22);
            this.srcPortNumericUpDown.TabIndex = 17;
            this.srcPortNumericUpDown.ValueChanged += new System.EventHandler(this.InputValidation);
            // 
            // dstPortNumericUpDown
            // 
            this.dstPortNumericUpDown.Location = new System.Drawing.Point(113, 49);
            this.dstPortNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.dstPortNumericUpDown.Name = "dstPortNumericUpDown";
            this.dstPortNumericUpDown.Size = new System.Drawing.Size(96, 22);
            this.dstPortNumericUpDown.TabIndex = 16;
            this.dstPortNumericUpDown.ValueChanged += new System.EventHandler(this.InputValidation);
            // 
            // dstPortLabel
            // 
            this.dstPortLabel.AutoSize = true;
            this.dstPortLabel.Location = new System.Drawing.Point(6, 51);
            this.dstPortLabel.Name = "dstPortLabel";
            this.dstPortLabel.Size = new System.Drawing.Size(101, 16);
            this.dstPortLabel.TabIndex = 15;
            this.dstPortLabel.Text = "Destination Port";
            // 
            // srcPortLabel
            // 
            this.srcPortLabel.AutoSize = true;
            this.srcPortLabel.Location = new System.Drawing.Point(6, 23);
            this.srcPortLabel.Name = "srcPortLabel";
            this.srcPortLabel.Size = new System.Drawing.Size(77, 16);
            this.srcPortLabel.TabIndex = 14;
            this.srcPortLabel.Text = "Source Port";
            // 
            // AddAccessControlEntryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 367);
            this.Controls.Add(this.miscGroupBox);
            this.Controls.Add(this.macConfigGroupBox);
            this.Controls.Add(this.ipConfigGroupBox);
            this.Controls.Add(this.basicConfigGroupBox);
            this.Controls.Add(this.saveEntryButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAccessControlEntryWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "New Access Control Entry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddAccessControlEntryWindow_FormClosing);
            this.Load += new System.EventHandler(this.AddAccessControlEntryWindow_Load);
            this.basicConfigGroupBox.ResumeLayout(false);
            this.basicConfigGroupBox.PerformLayout();
            this.ipConfigGroupBox.ResumeLayout(false);
            this.ipConfigGroupBox.PerformLayout();
            this.macConfigGroupBox.ResumeLayout(false);
            this.macConfigGroupBox.PerformLayout();
            this.miscGroupBox.ResumeLayout(false);
            this.miscGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.srcPortNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstPortNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveEntryButton;
        private System.Windows.Forms.GroupBox basicConfigGroupBox;
        private System.Windows.Forms.ComboBox directionComboBox;
        private System.Windows.Forms.ComboBox actionComboBox;
        private System.Windows.Forms.ComboBox protocolComboBox;
        private System.Windows.Forms.Label protocolLabel;
        private System.Windows.Forms.Label directionLabel;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.GroupBox ipConfigGroupBox;
        private System.Windows.Forms.Label interfaceLabel;
        private System.Windows.Forms.ComboBox interfaceComboBox;
        private System.Windows.Forms.GroupBox macConfigGroupBox;
        private System.Windows.Forms.GroupBox miscGroupBox;
        private System.Windows.Forms.Label dstIpLabel;
        private System.Windows.Forms.Label srcIpLabel;
        private System.Windows.Forms.Label dstPortLabel;
        private System.Windows.Forms.Label srcPortLabel;
        private System.Windows.Forms.NumericUpDown srcPortNumericUpDown;
        private System.Windows.Forms.NumericUpDown dstPortNumericUpDown;
        private System.Windows.Forms.Label icmpLabel;
        private System.Windows.Forms.ComboBox icmpComboBox;
        private System.Windows.Forms.TextBox srcIpTextBox;
        private System.Windows.Forms.TextBox dstIpTextBox;
        private System.Windows.Forms.TextBox srcMacTextBox;
        private System.Windows.Forms.Label srcMacLabel;
        private System.Windows.Forms.TextBox dstMacTextBox;
        private System.Windows.Forms.Label dstMacLabel;
    }
}