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
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TournamentTrackerUI
{
    /// <summary>
    /// Interaction logic for CreateTournament.xaml
    /// </summary>
    public partial class CreateTournament : Window
    {
        List<TeamModel> availableTeams = new List<TeamModel>();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        public List<PrizeModel> selectedPrizes = new List<PrizeModel>();
        public CreateTournament()
        {
            InitializeComponent();

            GlobalConnection.InitializeConnection(DatabaseType.TXT);

            loadDataToList();

            connectListToData();
        }

        private void loadDataToList()
        {
            availableTeams = GlobalConnection.Connection.GetAllTeams();
        }

        private void connectListToData()
        {
            comboBox_team_selector.ItemsSource = availableTeams;
            comboBox_team_selector.DisplayMemberPath = "TeamName";

            listBox_tournamentTeams.DataContext = selectedTeams;
            listBox_tournamentTeams.DisplayMemberPath = "TeamName";

            listBox_prizeList.DataContext = selectedPrizes;
            listBox_prizeList.DisplayMemberPath = "PlaceName";
        }

        private void addteam_Click(object sender, RoutedEventArgs e)
        {
            TeamModel team = (TeamModel)comboBox_team_selector.SelectedItem;

            availableTeams.Remove(team);
            selectedTeams.Add(team);
            listBox_tournamentTeams.Items.Add(team);
            comboBox_team_selector.Items.Refresh();
        }

        private void button_createPrize_Click(object sender, RoutedEventArgs e)
        {
            CreatePrize createPrizeWindow = new CreatePrize();

            createPrizeWindow.ShowDialog();

            selectedPrizes.Add(createPrizeWindow.setGetlatestModel);
            listBox_prizeList.Items.Add(createPrizeWindow.setGetlatestModel);
        }

        private void button_createNewTeam_Click(object sender, RoutedEventArgs e)
        {
            CreateTeam createTeamWindow = new CreateTeam();

            createTeamWindow.ShowDialog();

            //availableTeams.Add(createTeamWindow.setgetLatestTeam);
            listBox_tournamentTeams.Items.Add(createTeamWindow.setgetLatestTeam);
        }

        private void button_removeSelected_Click(object sender, RoutedEventArgs e)
        {
            TeamModel teamToRemove = new TeamModel();

            teamToRemove = (TeamModel)listBox_tournamentTeams.SelectedItem;

            selectedTeams.Remove(teamToRemove);
            availableTeams.Add(teamToRemove);
            comboBox_team_selector.Items.Refresh();
            listBox_tournamentTeams.Items.Remove(teamToRemove);
        }

        private void button_removeSelected_Copy_Click(object sender, RoutedEventArgs e)
        {
            PrizeModel prizeToRemove = (PrizeModel)listBox_prizeList.SelectedItem;

            selectedPrizes.Remove(prizeToRemove);
            listBox_prizeList.Items.Remove(prizeToRemove);
        }

        private void button_createTournament_Click(object sender, RoutedEventArgs e)
        {

            // Validate entry fee
            decimal fee = 0;
            bool feeIsValid = decimal.TryParse(entry_fee.Text, out fee);

            if (!feeIsValid)
            {
                MessageBox.Show("Enter a valid Entry fee", "Invalis fee", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            TournamentModel tmodel = new TournamentModel();

            tmodel.TournamentName = Tournament_name.Text;
            tmodel.entryFee = fee;
            tmodel.EnteredTeams = selectedTeams;
            tmodel.Prizes = selectedPrizes;

            // Create tournamnt, create all of the prize entries, create team entries.
            GlobalConnection.Connection.SaveTournamentModel(tmodel);

        }
    }
}
