namespace DoubleD
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.btnDoIt = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.txtOwnerFilter = new System.Windows.Forms.TextBox();
            this.lblOwner = new System.Windows.Forms.Label();
            this.cboControl = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDateRange = new System.Windows.Forms.CheckBox();
            this.txtScheduleFilter = new System.Windows.Forms.TextBox();
            this.lblScheduleFilter = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtStrategicFilter = new System.Windows.Forms.TextBox();
            this.lblStrategicFilter = new System.Windows.Forms.Label();
            this.chkDontIncludeFrom = new System.Windows.Forms.CheckBox();
            this.chkPastDeps = new System.Windows.Forms.CheckBox();
            this.chkRankFix = new System.Windows.Forms.CheckBox();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output:";
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(10, 62);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(246, 21);
            this.txtOutput.TabIndex = 3;
            this.txtOutput.TabStop = false;
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseOutput.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseOutput.Location = new System.Drawing.Point(260, 60);
            this.btnBrowseOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(76, 23);
            this.btnBrowseOutput.TabIndex = 4;
            this.btnBrowseOutput.Text = "Browse...";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            // 
            // btnDoIt
            // 
            this.btnDoIt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoIt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoIt.Location = new System.Drawing.Point(259, 358);
            this.btnDoIt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDoIt.Name = "btnDoIt";
            this.btnDoIt.Size = new System.Drawing.Size(76, 24);
            this.btnDoIt.TabIndex = 9;
            this.btnDoIt.Text = "Do it!";
            this.btnDoIt.UseVisualStyleBackColor = true;
            this.btnDoIt.Click += new System.EventHandler(this.btnDoIt_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblVersion.Location = new System.Drawing.Point(10, 369);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(52, 13);
            this.lblVersion.TabIndex = 10;
            this.lblVersion.Text = "lblVersion";
            this.lblVersion.Visible = false;
            // 
            // txtReport
            // 
            this.txtReport.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReport.Location = new System.Drawing.Point(10, 278);
            this.txtReport.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.ReadOnly = true;
            this.txtReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReport.Size = new System.Drawing.Size(326, 68);
            this.txtReport.TabIndex = 11;
            this.txtReport.TabStop = false;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.txtOwnerFilter);
            this.grpOptions.Controls.Add(this.lblOwner);
            this.grpOptions.Controls.Add(this.cboControl);
            this.grpOptions.Controls.Add(this.label3);
            this.grpOptions.Controls.Add(this.chkDateRange);
            this.grpOptions.Controls.Add(this.txtScheduleFilter);
            this.grpOptions.Controls.Add(this.lblScheduleFilter);
            this.grpOptions.Controls.Add(this.dtpToDate);
            this.grpOptions.Controls.Add(this.label4);
            this.grpOptions.Controls.Add(this.dtpFromDate);
            this.grpOptions.Controls.Add(this.txtStrategicFilter);
            this.grpOptions.Controls.Add(this.lblStrategicFilter);
            this.grpOptions.Controls.Add(this.chkDontIncludeFrom);
            this.grpOptions.Controls.Add(this.chkPastDeps);
            this.grpOptions.Controls.Add(this.chkRankFix);
            this.grpOptions.Location = new System.Drawing.Point(10, 90);
            this.grpOptions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpOptions.Size = new System.Drawing.Size(326, 184);
            this.grpOptions.TabIndex = 14;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // txtOwnerFilter
            // 
            this.txtOwnerFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtOwnerFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOwnerFilter.Location = new System.Drawing.Point(117, 137);
            this.txtOwnerFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOwnerFilter.MaxLength = 70;
            this.txtOwnerFilter.Name = "txtOwnerFilter";
            this.txtOwnerFilter.Size = new System.Drawing.Size(87, 21);
            this.txtOwnerFilter.TabIndex = 28;
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.Location = new System.Drawing.Point(7, 139);
            this.lblOwner.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(85, 13);
            this.lblOwner.TabIndex = 27;
            this.lblOwner.Text = "Filter on Owner:";
            // 
            // cboControl
            // 
            this.cboControl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboControl.FormattingEnabled = true;
            this.cboControl.Location = new System.Drawing.Point(117, 158);
            this.cboControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboControl.Name = "cboControl";
            this.cboControl.Size = new System.Drawing.Size(87, 21);
            this.cboControl.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 161);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Filter on Control:";
            // 
            // chkDateRange
            // 
            this.chkDateRange.AutoSize = true;
            this.chkDateRange.Location = new System.Drawing.Point(10, 73);
            this.chkDateRange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkDateRange.Name = "chkDateRange";
            this.chkDateRange.Size = new System.Drawing.Size(50, 17);
            this.chkDateRange.TabIndex = 25;
            this.chkDateRange.Text = "Filter";
            this.chkDateRange.UseVisualStyleBackColor = true;
            this.chkDateRange.CheckedChanged += new System.EventHandler(this.chkDateRange_CheckedChanged);
            // 
            // txtScheduleFilter
            // 
            this.txtScheduleFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtScheduleFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScheduleFilter.Location = new System.Drawing.Point(117, 115);
            this.txtScheduleFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtScheduleFilter.MaxLength = 70;
            this.txtScheduleFilter.Name = "txtScheduleFilter";
            this.txtScheduleFilter.Size = new System.Drawing.Size(87, 21);
            this.txtScheduleFilter.TabIndex = 24;
            // 
            // lblScheduleFilter
            // 
            this.lblScheduleFilter.AutoSize = true;
            this.lblScheduleFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScheduleFilter.Location = new System.Drawing.Point(7, 118);
            this.lblScheduleFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScheduleFilter.Name = "lblScheduleFilter";
            this.lblScheduleFilter.Size = new System.Drawing.Size(96, 13);
            this.lblScheduleFilter.TabIndex = 23;
            this.lblScheduleFilter.Text = "Filter on Schedule:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpToDate.Location = new System.Drawing.Point(203, 69);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(114, 21);
            this.dtpToDate.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(182, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "to";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpFromDate.Location = new System.Drawing.Point(64, 69);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(114, 21);
            this.dtpFromDate.TabIndex = 20;
            // 
            // txtStrategicFilter
            // 
            this.txtStrategicFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtStrategicFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStrategicFilter.Location = new System.Drawing.Point(117, 94);
            this.txtStrategicFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtStrategicFilter.MaxLength = 70;
            this.txtStrategicFilter.Name = "txtStrategicFilter";
            this.txtStrategicFilter.Size = new System.Drawing.Size(87, 21);
            this.txtStrategicFilter.TabIndex = 8;
            // 
            // lblStrategicFilter
            // 
            this.lblStrategicFilter.AutoSize = true;
            this.lblStrategicFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStrategicFilter.Location = new System.Drawing.Point(7, 96);
            this.lblStrategicFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStrategicFilter.Name = "lblStrategicFilter";
            this.lblStrategicFilter.Size = new System.Drawing.Size(96, 13);
            this.lblStrategicFilter.TabIndex = 18;
            this.lblStrategicFilter.Text = "Filter on Strategic:";
            // 
            // chkDontIncludeFrom
            // 
            this.chkDontIncludeFrom.AutoSize = true;
            this.chkDontIncludeFrom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDontIncludeFrom.Location = new System.Drawing.Point(10, 54);
            this.chkDontIncludeFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkDontIncludeFrom.Name = "chkDontIncludeFrom";
            this.chkDontIncludeFrom.Size = new System.Drawing.Size(189, 17);
            this.chkDontIncludeFrom.TabIndex = 7;
            this.chkDontIncludeFrom.Text = "Don\'t include \"from\" dependencies";
            this.chkDontIncludeFrom.UseVisualStyleBackColor = true;
            // 
            // chkPastDeps
            // 
            this.chkPastDeps.AutoSize = true;
            this.chkPastDeps.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPastDeps.Location = new System.Drawing.Point(10, 35);
            this.chkPastDeps.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkPastDeps.Name = "chkPastDeps";
            this.chkPastDeps.Size = new System.Drawing.Size(154, 17);
            this.chkPastDeps.TabIndex = 6;
            this.chkPastDeps.Text = "Include past dependencies";
            this.chkPastDeps.UseVisualStyleBackColor = true;
            // 
            // chkRankFix
            // 
            this.chkRankFix.AutoSize = true;
            this.chkRankFix.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRankFix.Location = new System.Drawing.Point(10, 16);
            this.chkRankFix.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkRankFix.Name = "chkRankFix";
            this.chkRankFix.Size = new System.Drawing.Size(151, 17);
            this.chkRankFix.TabIndex = 5;
            this.chkRankFix.Text = "Output for Gephi (rankfix)";
            this.chkRankFix.UseVisualStyleBackColor = true;
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseInput.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseInput.Location = new System.Drawing.Point(260, 20);
            this.btnBrowseInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(76, 24);
            this.btnBrowseInput.TabIndex = 2;
            this.btnBrowseInput.Text = "Browse...";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(10, 23);
            this.txtInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(246, 21);
            this.txtInput.TabIndex = 1;
            this.txtInput.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excel file: ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(346, 393);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.txtReport);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnDoIt);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseInput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoubleD";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.Load += new System.EventHandler(this.Main_Load);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.Button btnDoIt;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtReport;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDateRange;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.CheckBox chkDontIncludeFrom;
        private System.Windows.Forms.CheckBox chkPastDeps;
        private System.Windows.Forms.CheckBox chkRankFix;
        private System.Windows.Forms.TextBox txtOwnerFilter;
        private System.Windows.Forms.Label lblOwner;
        private System.Windows.Forms.ComboBox cboControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtScheduleFilter;
        private System.Windows.Forms.Label lblScheduleFilter;
        private System.Windows.Forms.TextBox txtStrategicFilter;
        private System.Windows.Forms.Label lblStrategicFilter;
    }
}

