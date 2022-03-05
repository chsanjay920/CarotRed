using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaratRedUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfirmationSearchCTRL.Instance.OnSearchClick += new EventHandler(searchClick);
            ConfirmationSearchCTRL.Instance.OnSettingClick = new EventHandler(settingclick);
            ConfirmationSearchCTRL.Instance.OnBackClick = new EventHandler(redirecttofirstpage);

            DashboardCTRL.Instance.onForiegnClick = new EventHandler(foreginClick);
            DashboardCTRL.Instance.onPassportClick = new EventHandler(passportClick);
            DashboardCTRL.Instance.onLocalIDClick = new EventHandler(localClick);

            UserMain.Instance.OnSettingClick = new EventHandler(settingclick);
            UserMain.Instance.OnSelectReg = new EventHandler(onselectreg);

            ConfirmationSearchCTRL.Instance.OnScanClick = new EventHandler(onscanclick);

            //GuestCard.Instance.OnScanClick = new EventHandler(onscanclick);

            DashboardCTRL.Instance.BackToMain = new EventHandler(backtomain);

            LocalID.Instance.BackToDashBoard = new EventHandler(backtodashboard);
            LocalID.Instance.BackToConformationSearch = new EventHandler(backtpconformationsearch);

            ForeginCTRL.Instance.BackToDashBoard1 = new EventHandler(backtodashboard);
            ForeginCTRL.Instance.BackToConformationSearch = new EventHandler(backtpconformationsearch);

            IndianPassportCTRL.Instance.BackToDashBoard2 = new EventHandler(backtodashboard);
            IndianPassportCTRL.Instance.BackToConformationSearch = new EventHandler(backtpconformationsearch);

            SettingsForm.Instance.BackToMainBoard = new EventHandler(backtomainboard);
            //DashboardCTRL.Instance.onLocalIDClick = new EventHandler(localClick);
        }
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        //SetDoubleBuffered(“TableLaoutPannel_controlName”)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RootPannel.Controls.Clear();
            SetDoubleBuffered(UserMain.Instance);
            RootPannel.Controls.Add(UserMain.Instance);

        }

        private void onselectreg(object sender, EventArgs e)
        {
            RootPannel.Controls.Clear();
            RootPannel.Controls.Add(ConfirmationSearchCTRL.Instance);
        }
        private void searchClick(Object sender, EventArgs e)
        {
            RootPannel.Controls.Clear();
            RootPannel.Size = DashboardCTRL.Instance.Size;
            SetDoubleBuffered(DashboardCTRL.Instance);
            RootPannel.Controls.Add(DashboardCTRL.Instance);
        }

        public void onscanclick(Object sender, EventArgs e)
        {
            RootPannel.Controls.Clear();
            RootPannel.Size = DashboardCTRL.Instance.Size;
            SetDoubleBuffered(DashboardCTRL.Instance);
            DashboardCTRL.Instance.CurrentGuestCard = (sender as GuestCard).GuestCardInfo;
            RootPannel.Controls.Add(DashboardCTRL.Instance);
        }
        public void redirecttofirstpage(Object sender, EventArgs e)
        {
            RootPannel.Controls.Clear();
            SetDoubleBuffered(UserMain.Instance);
            RootPannel.Controls.Add(UserMain.Instance);
        }
        private void foreginClick(Object sender, EventArgs e)
        {
            RootPannel.Controls.Clear();
            SetDoubleBuffered(ForeginCTRL.Instance);
            RootPannel.Controls.Add(ForeginCTRL.Instance);
        }


        private void passportClick(Object sender, EventArgs e)
        {
            RootPannel.Controls.Clear();
            SetDoubleBuffered(IndianPassportCTRL.Instance);
            RootPannel.Controls.Add(IndianPassportCTRL.Instance);
        }

        private void localClick(Object sender, EventArgs e)
        {
            RootPannel.Controls.Clear();
            SetDoubleBuffered(LocalID.Instance);
            RootPannel.Controls.Add(LocalID.Instance);
        }

        private void backtomain(Object sender, EventArgs e)
        {
            RootPannel.Controls.Clear();
            SetDoubleBuffered(ConfirmationSearchCTRL.Instance);
            RootPannel.Controls.Add(ConfirmationSearchCTRL.Instance);
        }
        private void backtodashboard(Object sender, EventArgs e)
        {
            RootPannel.Controls.Clear();
            SetDoubleBuffered(DashboardCTRL.Instance);
            RootPannel.Controls.Add(DashboardCTRL.Instance);
        }
        private void RootPannel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void settingclick(Object sender, EventArgs e)
        {
            RootPannel.Controls.Clear();
            SetDoubleBuffered(SettingsForm.Instance);
            RootPannel.Controls.Add(SettingsForm.Instance);
        }
        private void backtomainboard(Object sender, EventArgs e)
        {
            RootPannel.Controls.Clear();
            SetDoubleBuffered(UserMain.Instance);
            RootPannel.Controls.Add(UserMain.Instance);
        }
        private void backtpconformationsearch(Object sender, EventArgs e)
        {
            RootPannel.Controls.Clear();
            SetDoubleBuffered(ConfirmationSearchCTRL.Instance);
            RootPannel.Controls.Add(ConfirmationSearchCTRL.Instance);
        }
    }
}
