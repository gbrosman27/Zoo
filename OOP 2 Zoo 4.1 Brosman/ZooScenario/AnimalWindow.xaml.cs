using System;
using System.Windows;
using Animals;
using Reproducers;

namespace ZooScenario
{
    /// <summary>
    /// Contains interaction logic for AnimalWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Event handlers may begin with lower-case letters.")]
    public partial class AnimalWindow : Window
    {
        /// <summary>
        /// An animal in the zoo.
        /// </summary>
        private Animal animal;

        /// <summary>
        /// Initializes a new instance of the AnimalWindow class.
        /// </summary>
        /// <param name="animal">The animal to be interacted with.</param>
        public AnimalWindow(Animal animal)
        {
            this.animal = animal;

            this.InitializeComponent();
        }

        /// <summary>
        /// Makes the age text box editable.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void ageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.animal.Age = int.Parse(ageTextBox.Text);
                this.okButton.IsEnabled = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("The animal's age must be between 0 and 120");
                this.okButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Loads the animal window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void animalWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.nameTextBox.Text = this.animal.Name.ToString();
            this.ageTextBox.Text = this.animal.Age.ToString();
            this.weightTextBox.Text = this.animal.Weight.ToString();

            // Populate the animal gender combo box.
            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
            this.genderComboBox.Text = this.animal.Gender.ToString();

            // Ternary operator to find if animal is pregnant or not.
            string isAnimalPregnant = (this.animal.IsPregnant == true) ? "Yes" : "No";
            this.pregnanceStatusLabel.Content = isAnimalPregnant;
        }

        /// <summary>
        /// Changes the gender selection in the combo box.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void genderComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.animal.Gender = (Gender)this.genderComboBox.SelectedItem;

            if (this.animal.Gender == Gender.Female)
            {
                makePregnantButton.IsEnabled = true;
            }
            else
            {
                makePregnantButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Makes the animal pregnant.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void makePregnantButton_Click(object sender, RoutedEventArgs e)
        {
            // Make the animal pregnant, change the label, then disable the make pregnant button.
            this.animal.MakePregnant();
            pregnanceStatusLabel.Content = "Yes";
            makePregnantButton.IsEnabled = false;
        }

        /// <summary>
        /// Makes the name text box editable.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void nameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.animal.Name = nameTextBox.Text;
                this.okButton.IsEnabled = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The animal's name can only consist of letters.");
                this.okButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Actions for the OK button in the animal window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// Makes the weight text box editable.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void weightTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.animal.Weight = double.Parse(weightTextBox.Text);
                this.okButton.IsEnabled = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("The animal's weight must be between 0 and 1000");
                this.okButton.IsEnabled = false;
            }
        }
    }
}