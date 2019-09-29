using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AadhaarEnroller.Forms;
using AadhaarFramework.Code.Data.Entity.People;
using AadhaarFramework.Code.Data.Providers.People;
using DevExpress.XtraEditors;
using AadhaarFramework.Code.Utilities.Image;
using System.IO;
// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace AadhaarEnroller
{
    public partial class xfrmPerson : DevExpress.XtraEditors.XtraForm
    {
        private Person Person { get; set; } = null;
        private List<CountryZone> CountryZones = new List<CountryZone>();
        private List<Gender> Genders = new List<Gender>();
        private List<Language> Languages = new List<Language>();
        private List<Religion> Religions = new List<Religion>();
        private List<State> States = new List<State>();
        public xfrmPerson()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void xfrmPerson_Load(object sender, EventArgs e)
        {
            xfrmLogin xfrmLogin = new xfrmLogin();
            if (xfrmLogin.ShowDialog() != DialogResult.OK)
            {
                System.Windows.Forms.Application.Exit();
            }
            Person = new Person();
            AllCatalogs();
            BirthDateDateEdit.EditValue = DateTime.Today;
            Person.GenerateRandomPerson();
            BindPerson();
        }

        private void xtraTabControlPerson_CustomHeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
        {
            switch (e.Button.Tag.ToString())
            {
                case "NEW":
                    New();
                    break;
                case "SAVE":
                    Save();
                    break;
                case "SEARCH":
                    Search();
                    break;
                case "CLEAR":
                    Clear(true);
                    break;
                default:
                    break;
            }
        }
        private void New()
        {
            IdTextEdit.Focus();
            Clear(true);
            BirthDateDateEdit.EditValue = DateTime.Today;
        }
        private void LoadImageToPerson()
        {
            if (PhotographyPictureEdit.Image == null)
                return;
            string tmpFileName = Guid.NewGuid().ToString();
            string tmpPath = Path.GetTempPath();
            string FullPathName = String.Concat(tmpPath, tmpFileName);
            PhotographyPictureEdit.Image.Save(FullPathName);
            Photography photography = new Photography();
            photography.Photo=ImageUtil.ConvertImageFiletoBytes(FullPathName);
            Person.Photography = photography;

        }
        private void LoadMyEnrollerIDToPerson()
        {
            Person.IdEnroller = Properties.Settings.Default.IdEnroller;
        }
        private void Save()
        {

            LoadImageToPerson();
            LoadMyEnrollerIDToPerson();
            Person tmp = this.Person;
            PersonProvider PersonProvider = new PersonProvider();
            try
            {

                PersonProvider.Save(tmp);
                MessageBox.Show(string.Format("Printin Aadhaar Card {0}",tmp.Id.ToString()),"", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Clear(false);
        }
        private void Search()
        {
            xfrmSearch xfrmSearch = new xfrmSearch();
            if (xfrmSearch.ShowDialog() != DialogResult.OK) { return; }
            long UID = xfrmSearch.UID;
            PersonProvider personProvider = new PersonProvider();
            this.Person = personProvider.GetById(UID);
            if (Person == null) { MessageBox.Show("The UID doesn't exist", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            BindPerson();
        }
        private void Clear(bool ShouldConfirm)
        {
            if (ShouldConfirm) { if (MessageBox.Show("The current input will be loss, are you sure?") != DialogResult.OK) { return; } }
            Person = new Person();
            BindPerson();
        }
        private void BindPerson()
        {
            personBindingSource.DataSource = Person;
            if (Person.Photography != null)
                PhotographyPictureEdit.Image = ImageUtil.ConvertBytesToImage(Person.Photography.Photo);

        }
        private void AllCatalogs(){
            CountryZoneProvider CountryZoneProvider = new CountryZoneProvider();
            GenderProvider GenderProvider = new GenderProvider();
            LanguageProvider LanguageProvider = new LanguageProvider();
            ReligionProvider ReligionProvider = new ReligionProvider();
            StateProvider StateProvider = new StateProvider();
            CountryZones = CountryZoneProvider.GetAll().ToList();
            Genders = GenderProvider.GetAll().ToList();
            Languages = LanguageProvider.GetAll().ToList();
            Religions = ReligionProvider.GetAll().ToList();
            States = StateProvider.GetAll().ToList();
            CountryZoneProvider = null;
            GenderProvider = null;
            LanguageProvider = null;
            ReligionProvider = null;
            StateProvider = null;
            genderBindingSource.DataSource = Genders;
            religionBindingSource.DataSource = Religions;
            languageBindingSource.DataSource = Languages;
            stateBindingSource.DataSource = States;

        }

        private void BiometricButtonHandler(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit btn = sender as DevExpress.XtraEditors.ButtonEdit;
           
            if (e.Button.Tag.ToString().Equals("CLEAR"))
            {
                btn.Text ="0";
                btn.Tag = String.Empty;
                switch (btn.Name.ToString())
                {
                    case "IdIrisLeftEyeButtonEdit":
                        Person.IrisLeftEye = null;
                        break;
                    case "IdFingerPrintLeftHandThumbButtonEdit":
                        Person.FingerPrintLeftHandThumb = null;

                        break;
                    case "IdFingerPrintLeftHandIndexButtonEdit":
                        Person.FingerPrintLeftHandIndex = null;
                        break;
                    case "IdFingerPrintLeftHandMiddleButtonEdit":
                        Person.FingerPrintLeftHandMiddle = null;
                        break;
                    case "IdFingerPrintLeftHandRingButtonEdit":
                        Person.FingerPrintLeftHandRing = null;
                        break;
                    case "IdFingerPrintLeftHandPinkyButtonEdit":
                        Person.FingerPrintLeftHandPinky = null;
                        break;

                    case "IdIrisRightEyeButtonEdit":
                        Person.FingerPrintRightHandThumb = null; 
                        break;
                    case "IdFingerPrintRightHandThumbButtonEdit":
                        Person.FingerPrintRightHandThumb = null;
                        break;
                    case "IdFingerPrintRightHandIndexButtonEdit":
                        Person.FingerPrintRightHandThumb = null;
                        break;
                    case "IdFingerPrintRightHandMiddleButtonEdit":
                        Person.FingerPrintRightHandThumb = null;
                        break;
                    case "IdFingerPrintRightHandRingButtonEdit":
                        Person.FingerPrintRightHandThumb = null;
                        break;
                    case "IdFingerPrintRightHandPinkyButtonEdit":
                        Person.FingerPrintRightHandThumb = null;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                xFingerPrintCapture xFingerPrintCapture = new xFingerPrintCapture();
                xFingerPrintCapture.ShowDialog();

                btn.Text = "1";
                switch (btn.Name.ToString())
                {
                    case "IdIrisLeftEyeButtonEdit":
                        Person.IrisLeftEye = new Eye(true);
                        break;
                    case "IdFingerPrintLeftHandThumbButtonEdit":
                        Person.FingerPrintLeftHandThumb = new FingerPrint(true);

                        break;
                    case "IdFingerPrintLeftHandIndexButtonEdit":
                        Person.FingerPrintLeftHandIndex= new FingerPrint(true);
                        break;
                    case "IdFingerPrintLeftHandMiddleButtonEdit":
                        Person.FingerPrintLeftHandMiddle = new FingerPrint(true);
                        break;
                    case "IdFingerPrintLeftHandRingButtonEdit":
                        Person.FingerPrintLeftHandRing = new FingerPrint(true);
                        break;
                    case "IdFingerPrintLeftHandPinkyButtonEdit":
                        Person.FingerPrintLeftHandPinky = new FingerPrint(true);
                        break;

                    case "IdIrisRightEyeButtonEdit":
                        Person.FingerPrintRightHandThumb = new FingerPrint(true);
                        break;
                    case "IdFingerPrintRightHandThumbButtonEdit":
                        Person.FingerPrintRightHandThumb = new FingerPrint(true);
                        break;         
                    case "IdFingerPrintRightHandIndexButtonEdit":
                        Person.FingerPrintRightHandThumb = new FingerPrint(true);
                        break;         
                    case "IdFingerPrintRightHandMiddleButtonEdit":
                        Person.FingerPrintRightHandThumb = new FingerPrint(true);
                        break;         
                    case "IdFingerPrintRightHandRingButtonEdit":
                        Person.FingerPrintRightHandThumb = new FingerPrint(true);
                        break;         
                    case "IdFingerPrintRightHandPinkyButtonEdit":
                        Person.FingerPrintRightHandThumb = new FingerPrint(true);
                        break;

                    default:
                        break;
                }
                //btn.Tag = xFingerPrintCapture.ScannedFingerprint.ToString();
            }
        }

        private void PhotographyPictureEdit_LoadCompleted(object sender, EventArgs e)
        {
            
            
        }
    }
}
