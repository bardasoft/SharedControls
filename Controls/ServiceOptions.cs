using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using SieraDelta.Languages;
using SieraDelta.Shared;

namespace SieraDelta.Controls
{
    public partial class ServiceOptions : BaseSettings
    {
        #region Private Members

        private string SERVICE_NAME = "WebDefender";
        private string _applicationName;

        #endregion Private Members

        #region Constructors

        public ServiceOptions()
        {
            InitializeComponent();
            CalculateUpTime();
            ResetUI();
            lblNotRunning.Top = lblUptimeDesc.Top;
            timer1.Enabled = true;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Name of the service to be controlled
        /// </summary>
        public string ServiceName
        {
            get
            {
                return (SERVICE_NAME);
            }

            set
            {
                SERVICE_NAME = value;
                ResetUI();
            }
        }

        /// <summary>
        /// Name of the application
        /// </summary>
        public string ApplicationName 
        {
            get
            {
                return (_applicationName);
            }

            set
            {
                _applicationName = value;
                ResetUI();
                CalculateUpTime();
            }
        }

        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            btnRestart.Text = LanguageStrings.ButtonRestart;
            btnStart.Text = LanguageStrings.ButtonStart;
            btnStop.Text = LanguageStrings.ButtonStop;

            lblUptimeDesc.Text = LanguageStrings.ServiceUptime;
            lblUptime.Text = LanguageStrings.ServiceUptimeCalculating;
            lblNotRunning.Text = String.Format(LanguageStrings.ServiceNotRunning, "WebDefender");

            CalculateUpTime();
        }

        #endregion Overridden Methods

        #region Private Methods

        /// <summary>
        /// Updates service buttons to current state of service
        /// </summary>
        private void ResetUI()
        {
            if (!Utilities.ServiceInstalled(SERVICE_NAME))
            {
                btnStop.Enabled = false;
                btnStart.Enabled = false;
                btnRestart.Enabled = false;
                lblNotRunning.Text = String.Format(LanguageStrings.ServiceNotInstalled, ApplicationName);
                lblNotRunning.Visible = true;
            }
            else
            {
                bool running = Utilities.ServiceRunning(SERVICE_NAME);

                btnStart.Enabled = !running;
                btnStop.Enabled = running;
                btnRestart.Enabled = running;
                lblNotRunning.Visible = !running;
                lblUptime.Visible = running;
                lblUptimeDesc.Visible = running;

                if (btnStart.Enabled)
                    btnStart.Select();
                else
                    btnStop.Select();
            }
        }

        private void CalculateUpTime()
        {
            if (Utilities.ServiceRunning(SERVICE_NAME))
            {
                DateTime started = SieraDelta.Shared.XML.GetXMLValue("Uptime", "ServiceStart", DateTime.Now);
                TimeSpan span = DateTime.Now - started;
                lblUptimeDesc.Visible = true;
                lblUptime.Visible = true;

                if (span.Days > 0)
                {
                    lblUptime.Text = String.Format(LanguageStrings.ServiceUptimeDays, 
                        span.Days, span.Hours, span.Minutes,
                        span.Minutes == 1 ? String.Empty : LanguageStrings.ServiceUptimeMultiple,
                        span.Hours == 1 ? String.Empty : LanguageStrings.ServiceUptimeMultiple);
                }
                else if (span.Hours > 0)
                {
                    lblUptime.Text = String.Format(LanguageStrings.ServiceUptimeHours, span.Hours, span.Minutes,
                        span.Minutes == 1 ? String.Empty : LanguageStrings.ServiceUptimeMultiple,
                        span.Hours == 1 ? String.Empty : LanguageStrings.ServiceUptimeMultiple);
                }
                else if (span.TotalSeconds > 0)
                {
                    if (span.Minutes == 0)
                        lblUptime.Text = LanguageStrings.ServiceUptimeSeconds;
                    else
                        lblUptime.Text = String.Format(LanguageStrings.ServiceUptimeMinutes, 
                            span.Minutes, span.Minutes == 1 ? String.Empty : LanguageStrings.ServiceUptimeMultiple);
                }
                else
                    lblUptime.Text = LanguageStrings.ServiceUptimeUnknown;
            }
            else
            {
                lblUptime.Visible = false;
                lblUptimeDesc.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CalculateUpTime();
            ResetUI();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                btnStop.Enabled = false;

                if (Utilities.ServiceInstalled(SERVICE_NAME) && Utilities.ServiceRunning(SERVICE_NAME) && Utilities.ServiceCanBeStopped(SERVICE_NAME))
                    Utilities.ServiceStop(SERVICE_NAME);

                while (!Utilities.ServiceCanBeStarted(SERVICE_NAME))
                    Thread.Sleep(200);

                ResetUI();
                CalculateUpTime();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                btnStop.Enabled = false;
                btnRestart.Enabled = false;

                if (Utilities.ServiceInstalled(SERVICE_NAME) && !Utilities.ServiceRunning(SERVICE_NAME) && Utilities.ServiceCanBeStarted(SERVICE_NAME))
                    Utilities.ServiceStart(SERVICE_NAME);

                while (!Utilities.ServiceCanBeStopped(SERVICE_NAME))
                    Thread.Sleep(200);

                ServiceIsRunning(300, 100);

                ResetUI();
                CalculateUpTime();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                btnStop.Enabled = false;
                btnStart.Enabled = false;
                btnRestart.Enabled = false;

                if (Utilities.ServiceInstalled(SERVICE_NAME) && Utilities.ServiceCanBeStopped(SERVICE_NAME) && Utilities.ServiceRunning(SERVICE_NAME))
                    Utilities.ServiceStop(SERVICE_NAME);

                while (!Utilities.ServiceCanBeStarted(SERVICE_NAME))
                    Thread.Sleep(200);

                if (Utilities.ServiceInstalled(SERVICE_NAME) && Utilities.ServiceCanBeStarted(SERVICE_NAME) && !Utilities.ServiceRunning(SERVICE_NAME))
                    Utilities.ServiceStart(SERVICE_NAME);

                ServiceIsRunning(300, 100);

                ResetUI();
                CalculateUpTime();
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        private void ServiceIsRunning(int iterations, int sleepValue)
        {
            int i = 0;

            while (!Utilities.ServiceRunning(SERVICE_NAME))
            {
                i++;
                Thread.Sleep(sleepValue);

                if (i > iterations)
                    break;
            }
        }

        #endregion Private Methods
    }
}
