using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TrackerLibrary.Models;
using TrackerLibrary;

namespace TournamentTrackerUI
{
    /// <summary>
    /// Interaction logic for CreateTeam.xaml
    /// </summary>
    public partial class CreateTeam : Window
    {
        private List<PersonModel> availableMembers = new List<PersonModel>();
        private List<PersonModel> selectedMember = new List<PersonModel>();

        private TeamModel latestTeam;
        public TeamModel setgetLatestTeam 
        { get { return latestTeam; }
          private set { latestTeam = value; }
        }

        public CreateTeam()
        {
            InitializeComponent();

            loadDataToList();

            connectLists();
        }

        private void loadDataToList()
        {
            availableMembers = GlobalConnection.Connection.GetAllPeople();
        }

        private void connectLists()
        {
            comboBox_team_member_selector.ItemsSource = availableMembers;
            comboBox_team_member_selector.DisplayMemberPath = "fullName";

            listBox_selected_team_member.DataContext = selectedMember;
            listBox_selected_team_member.DisplayMemberPath = "fullName";
        }

        private void button_addMember_Click(object sender, RoutedEventArgs e)
        {
            PersonModel p = (PersonModel)comboBox_team_member_selector.SelectedItem;

            listBox_selected_team_member.Items.Add(p);
            selectedMember.Add(p);
            availableMembers.Remove(p);
            comboBox_team_member_selector.Items.Refresh();
        }

        private void button_removeSelected_Click(object sender, RoutedEventArgs e)
        {
            PersonModel p = (PersonModel)listBox_selected_team_member.SelectedItem;

            listBox_selected_team_member.Items.Remove(p);
            selectedMember.Remove(p);
            availableMembers.Add(p);
            comboBox_team_member_selector.Items.Refresh();
        }

        private void button_createMember_Click(object sender, RoutedEventArgs e)
        {
            if (FormIsValid())
            {
                PersonModel model = new PersonModel(firstName.Text, lastName.Text, email.Text, telephone.Text);

                GlobalConnection.Connection.SavePersonModel(model);

                MessageBox.Show("Member created");

                firstName.Text = "";
                lastName.Text = "";
                email.Text = "";
                telephone.Text = "";

                availableMembers.Add(model);
                comboBox_team_member_selector.Items.Refresh();
            }
        }
        private void button_createTeam_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_team_name.Text.Length != 0 && listBox_selected_team_member.Items.Count != 0)
            {
                TeamModel model = new TeamModel();

                model.TeamName = textBox_team_name.Text;
                model.TeamMembers = selectedMember;

                model = GlobalConnection.Connection.SaveTeamModel(model);

                setgetLatestTeam = model;

                MessageBox.Show("Team created!");

                this.Close();
            }
        }

        private bool FormIsValid()
        {
            bool output = true;

            if (firstName.Text.Length == 0)
            {
                MessageBox.Show("Introduce a valid name");
                output = false;
            }

            if (lastName.Text.Length == 0)
            {
                MessageBox.Show("Introduce a valid last name");
                output = false;
            }

            if (email.Text.Length == 0)
            {
                MessageBox.Show("Introduce a valid email");
                output = false;
            }

            if (!email.Text.Contains('@'))
            {
                MessageBox.Show("Introduce a valid email");
                output = false;
            }

            if (telephone.Text.Length == 0)
            {
                MessageBox.Show("Introduce a valid telephone");
                output = false;
            }


            return output;
        }
    }
}
