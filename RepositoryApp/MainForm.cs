using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using Repository;
using Repository.Savers;

namespace RepositoryApp
{
    public partial class MainForm : Form
    {
        private Repo repo;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var dataDirectory = ConfigurationManager.AppSettings["DataDirectory"];
            var absoluteDataDirectory = Path.GetFullPath(dataDirectory);
            AppDomain.CurrentDomain.SetData("DataDirectory", absoluteDataDirectory);
            string txtPath = absoluteDataDirectory + "\\" + ConfigurationManager.AppSettings["EventsTxt"];
            string xmlPath = absoluteDataDirectory + "\\" + ConfigurationManager.AppSettings["EventsXml"];
            string connString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            string providerName = ConfigurationManager.ConnectionStrings["DBConnectionString"].ProviderName;
            repo = new Repo(new KeyValuePair<string, ISaver>("txt", new TxtSaver(txtPath)),
                            new KeyValuePair<string, ISaver>("xml", new XMLSaver(xmlPath)),
                            new KeyValuePair<string, ISaver>("db", new DbSaver(connString,providerName,"[dbo].[Events]")));
            
        }

        #region HelperMethods
        private bool CheckIDTextBox()
        {
            int id;
            if (!int.TryParse(IDTextBox.Text, out id) || id < 0)
            {
                MessageBox.Show("Bad value of ID. It must be integer and greater than of equal to zero. Try again.");
                return false;
            }
            return true;
        }

        private string ConstructOpts()
        {
            string opts = "";
            if (AppConfigCheckBox.Checked)
            {
                opts = ConfigurationManager.AppSettings["WayToSaveEvents"];
            }
            else
            {
                if (txtCheckBox.Checked) opts += "txt;";
                if (XMLCheckBox.Checked) opts += "xml;";
                if (DBCheckBox.Checked) opts += "db;";
            }
            opts = opts.TrimEnd(';');
            return opts;
        }

        private void ClearTextBoxes()
        {
            IDTextBox.Clear();
            NameTextBox.Clear();
            DescriptionTextBox.Clear();
        }
        #endregion

        #region Buttons Handlers
        private void AddEventButton_Click(object sender, EventArgs e)
        {
            if (!CheckIDTextBox()) return;
            repo.AddEvents(overwriteCheckBox.Checked, new Event(int.Parse(IDTextBox.Text),
                                                                NameTextBox.Text,
                                                                (EventType)Enum.Parse(typeof(EventType),
                                                                                      EventTypeComboBox.SelectedItem.ToString()),
                                                                DescriptionTextBox.Text));
            MessageBox.Show("Event Added");
            ClearTextBoxes();
        }

        private void SaveCurrentButton_Click(object sender, EventArgs e)
        {
            if (!CheckIDTextBox()) return;
            string opts = ConstructOpts();
            repo.SaveEvent(overwriteCheckBox.Checked, 
                           new Event(int.Parse(IDTextBox.Text),
                                     NameTextBox.Text,
                                     (EventType) Enum.Parse(typeof(EventType), EventTypeComboBox.SelectedItem.ToString()),
                                     DescriptionTextBox.Text),
                            opts);
            MessageBox.Show("Event Saved");
            ClearTextBoxes();
        }

        private void SaveAllButton_Click(object sender, EventArgs e)
        {
            if (!CheckIDTextBox()) return;
            string opts = ConstructOpts();
            repo.SaveAllEvents(overwriteCheckBox.Checked, DeleteCheckBox.Checked, opts);
            MessageBox.Show("All Events Saved");
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Good Bye!");
            Application.Exit();
        }
        #endregion
    }
}
