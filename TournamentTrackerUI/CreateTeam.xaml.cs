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
        public CreateTeam()
        {
            InitializeComponent();


            TrackerLibrary.GlobalConnection.InitializeConnection(DatabaseType.TXT);
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
