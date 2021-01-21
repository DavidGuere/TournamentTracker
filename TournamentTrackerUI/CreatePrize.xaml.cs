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
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TournamentTrackerUI
{
    /// <summary>
    /// Interaction logic for CreatePrize.xaml
    /// </summary>
    public partial class CreatePrize : Window
    {
        public CreatePrize()
        {
            InitializeComponent();

        }

        private void button_createPrize_Click(object sender, RoutedEventArgs e)
        {
            if (FormIsValid())
            {
                PrizeModel model = new PrizeModel(textBox_placeNumber.Text, textBox_placeName.Text, textBox_prizeAmount.Text, textBox_prizePercentage.Text);

                GlobalConnection.Connection.SavePrizeModel(model);
                

                MessageBox.Show("Prize created");

                this.Close();
            }
        }

        private bool FormIsValid()
        {
            bool output = true;

            int placeNumber = 0;
            bool placeNumberIsValid = int.TryParse(textBox_placeNumber.Text, out placeNumber);

            decimal prizeAmount = 0;
            bool prizeAmountIsvalid = decimal.TryParse(textBox_prizeAmount.Text, out prizeAmount);

            double prizePercentage = 0;
            bool prizePercentageIsValid = double.TryParse(textBox_prizePercentage.Text, out prizePercentage);

            if (placeNumber < 1)
            {
                MessageBox.Show("The place must be greater than 1");
                output = false;
            }

            if (placeNumberIsValid == false)
            {
                MessageBox.Show("Enter a valid place");
                output = false;
            }

            if (textBox_placeName.Text.Length == 0)
            {
                MessageBox.Show("Enter a valid name");
                output = false;
            }

            if (prizeAmountIsvalid == false && prizePercentageIsValid == false)
            {
                MessageBox.Show("Enter a valid prize");
                output = false;
            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                MessageBox.Show("Enter a valid prize");
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                MessageBox.Show("the prize percentage must be between 0 and 100");
                output = false;
            }
            return output;
        }
    }
}
