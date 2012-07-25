using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace DoubleD
{
    public partial class Main : Form
    {
        private string _inputFile;
        private string _outputFile;
        private System.Version _version;
        private DateTime _buildDateTime;
        private BackgroundWorker _bw;
        private string _filterStrategic;
        private string _filterSchedule;
        private string _filterOwner;
        private bool _filterDate;
        private DateTime _filterDateFrom;
        private DateTime _filterDateTo;
        private int _filterControl;
        private bool _noFrom, _rankFix, _includePast = false;
        

        public Main()
        {
            InitializeComponent();

            _version = Assembly.GetEntryAssembly().GetName().Version;
            _buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(TimeSpan.TicksPerDay * _version.Build + TimeSpan.TicksPerSecond * 2 * _version.Revision));
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Excel file|*.xlsx;*.xls";
            o.Title = "Choose an Excel file to convert...";
            o.Multiselect = false;
            o.RestoreDirectory = true;

            if (o.ShowDialog() == DialogResult.OK)
            {
                _inputFile = o.FileName;
                _outputFile = SuggestDotFilename(_inputFile);
                txtInput.Text = _inputFile;
                txtOutput.Text = _outputFile;
                txtInput.Select(txtInput.Text.Length - 1, 1);
                txtOutput.Select(txtOutput.Text.Length - 1, 1);
            }
        }

        private string SuggestDotFilename(string input)
        {
            string output;

            if (Path.HasExtension(input))
            {
                output = input.Replace(Path.GetExtension(input), ".dot");
            }
            else
            {
                output = input + ".dot";
            }

            return output;
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            lblVersion.Text= "v" + _version.ToString() + " (" + _buildDateTime.ToShortDateString() + ")";
            lblVersion.Visible = true;
        }

        private void btnDoIt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                MessageBox.Show("You must choose an Excel file to convert.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtOutput.Text))
            {
                MessageBox.Show("You must choose a file to output the results to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtInput.Text == txtOutput.Text)
            {
                MessageBox.Show("The input and output files must be different.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _rankFix = (chkRankFix.Checked == true) ? true : false;
            _noFrom = (chkDontIncludeFrom.Checked == true) ? true : false;
            _includePast = (chkPastDeps.Checked == true) ? true : false;
            _filterDate = (chkDateRange.Checked == true) ? true : false;
            _filterStrategic = txtStrategicFilter.Text;
            _filterSchedule = txtScheduleFilter.Text;
            _filterOwner = txtOwnerFilter.Text;
            _filterDateFrom = dtpFromDate.Value;
            _filterDateTo = dtpToDate.Value;

            if (cboControl.SelectedIndex == cboControl.Items.Count - 1)
            {
                _filterControl = -1;
            }
            else
            {
                _filterControl = cboControl.SelectedIndex;
            }

            Convert();
        }

        private void Convert()
        {
            _bw = new BackgroundWorker();
            _bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            _bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            _bw.WorkerReportsProgress = true;
            btnDoIt.Enabled = false;
            txtReport.Clear();
            _bw.RunWorkerAsync();
        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            txtReport.AppendText(e.UserState as string + Environment.NewLine);
            txtReport.ScrollToCaret();
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnDoIt.Enabled = true;
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            _bw.ReportProgress(0, "Starting...");

            List<DepDot.LineItem> lines;
            StringBuilder sb;

            _bw.ReportProgress(0, "Reading Excel file...");

            try
            {
                lines = DepDot.ExcelReader.Read(_inputFile, _noFrom, _includePast);
            }
            catch (Exception ex)
            {
                _bw.ReportProgress(0, ex.Message);
                return;
            }

            _bw.ReportProgress(0, lines.Count.ToString() + " rows read");

            if (lines.Count == 0)
            {
                _bw.ReportProgress(0, "No rows to convert");
                return;
            }

            _bw.ReportProgress(0, "Converting rows to DOT language...");
            
            try
            {
                //GenerateDot(List<LineItem> lines, bool noFrom, bool rankFix, string filterStrategic, string filterSchedule, int filterControl, string filterOwner, bool filterDate, DateTime filterDateFrom, DateTime filterDateTo)
                sb = DepDot.DotWriter.GenerateDot(lines, _noFrom, _rankFix, _includePast, _filterStrategic, _filterSchedule, _filterControl, _filterOwner, _filterDate, _filterDateFrom, _filterDateTo);
            }
            catch
            {
                _bw.ReportProgress(0, "Conversion failed");
                return;
            }

            _bw.ReportProgress(0, "Conversion complete");

            try
            {
                using (StreamWriter writer = new StreamWriter(_outputFile, false))
                {
                    writer.Write(sb.ToString());
                }
            }
            catch(Exception ex)
            {
                _bw.ReportProgress(0, "ERROR: " + ex.Message);
                return;
            }

            _bw.ReportProgress(0, "All done :)");
        }

        private void Main_Load(object sender, EventArgs e)
        {
            foreach(Enum enumValue in Enum.GetValues(typeof(DepDot.Control)))
            {
                cboControl.Items.Add(enumValue.ToString());
            }

            cboControl.Items.Add("");
            cboControl.SelectedIndex = cboControl.Items.Count - 1;

            dtpToDate.Value = DateTime.Now.AddMonths(6);

            if ((this.AutoScaleDimensions.Height + this.AutoScaleDimensions.Width > 0))
            {
                //RescaleForm();
            }
        }

        private void RescaleForm()
        {
            foreach (Control c in this.Controls)
            {
                switch(c.GetType().ToString())
                {
                    case "System.Windows.Forms.TextBox":
                    case "System.Windows.Forms.Button":
                        break;
                }
                Console.WriteLine(c.Name + " " + c.GetType().ToString());
            }
        }

        private void chkDateRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateRange.Checked)
            {
                chkPastDeps.Enabled = false;
            }
            else
            {
                chkPastDeps.Enabled = true;
            }
        }
    }
}
