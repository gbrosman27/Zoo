using System;
using System.Windows;
using People;
using Reproducers;

namespace ZooScenario
{
    /// <summary>
    /// Interaction logic for GuestWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Event handlers may begin with lower-case letters.")]
    public partial class GuestWindow : Window
    {
        /// <summary>
        /// The guest at the zoo.
        /// </summary>
        private Guest guest;

        /// <summary>
        /// Initializes a new instance of the GuestWindow class.
        /// </summary>
        /// <param name="guest">The guest to be interacted with.</param>
        public GuestWindow(Guest guest)
        {
            this.guest = guest;

            this.InitializeComponent();
        }

        /// <summary>
        /// Adds money to the account's money balance.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void addAccountMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Add money to the guest's wallet money balance via the combo box.
                this.guest.CheckingAccount.AddMoney(decimal.Parse(this.moneyAmountAccountComboBox.Text));

                // Reset the money balance label to the new money balance.
                this.accountBalanceLabel.Content = this.guest.CheckingAccount.MoneyBalance.ToString("C");
            }
            catch (FormatException)
            {
                MessageBox.Show("You must select a value.");
            }
        }

        /// <summary>
        /// Adds money to the wallet's money balance.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void addMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Add money to the guest's wallet money balance via the combo box.
                this.guest.Wallet.AddMoney(decimal.Parse(this.moneyAmountComboBox.Text));

                // Reset the money balance label to the new money balance.
                this.moneyBalanceLabel.Content = this.guest.Wallet.MoneyBalance.ToString("C");
            }
            catch (FormatException)
            {
                MessageBox.Show("You must select a value.");
            }
        }

        /// <summary>
        /// Actions for the age text box in the guest window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void ageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.guest.Age = int.Parse(ageTextBox.Text);
                this.okButton.IsEnabled = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("The guest's age must be between 0 and 120");
                this.okButton.IsEnabled = false;
            }
            catch (FormatException)
            {
                MessageBox.Show("A value must be entered.");
                this.okButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Actions for the gender combo box in the guest window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void genderComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Gender gender = (Gender)this.genderComboBox.SelectedItem;
        }

        /// <summary>
        /// Loads the guest window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void guestWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.nameTextBox.Text = this.guest.Name.ToString();
            this.ageTextBox.Text = this.guest.Age.ToString();

            // Populate the guest gender combo box.
            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));

            // Populate the wallet color combo box.
            this.walletColorComboBox.ItemsSource = Enum.GetValues(typeof(WalletColor));

            // Set the money balance label to the guest's wallet money balance.
            this.moneyBalanceLabel.Content = this.guest.Wallet.MoneyBalance;

            // Add values to the money amount combo box.
            this.moneyAmountComboBox.Items.Add("1");
            this.moneyAmountComboBox.Items.Add("5");
            this.moneyAmountComboBox.Items.Add("10");
            this.moneyAmountComboBox.Items.Add("20");

            // Set the account balance label to the guest's checking account money balance.
            this.accountBalanceLabel.Content = this.guest.CheckingAccount.MoneyBalance;

            // Add values to the account's money combo box.
            this.moneyAmountAccountComboBox.Items.Add("1");
            this.moneyAmountAccountComboBox.Items.Add("5");
            this.moneyAmountAccountComboBox.Items.Add("10");
            this.moneyAmountAccountComboBox.Items.Add("20");
        }

        /// <summary>
        /// Populates the account's money amount combo box and enables it to be selected.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void moneyAmountAccountComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Displays money options to add to or subtract from the guest's account.
        }

        /// <summary>
        /// Populates the wallet's money amount combo box and enables it to be selected.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void moneyAmountComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Displays money options to add to or subtract from the guest's wallet.
        }

        /// <summary>
        /// Actions for the name text box in the guest window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void nameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.guest.Name = nameTextBox.Text;
                this.okButton.IsEnabled = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The guest's name can only consist of letters.");
                this.okButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Actions for the OK button in the guest window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// Subtracts money from the account's money balance.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void subtractAccountMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Remove money from the guest's wallet money balance via the combo box.
                this.guest.CheckingAccount.RemoveMoney(decimal.Parse(this.moneyAmountAccountComboBox.Text));

                // Reset the money balance label to the new money balance.
                this.accountBalanceLabel.Content = this.guest.CheckingAccount.MoneyBalance.ToString("C");
            }
            catch (FormatException)
            {
                MessageBox.Show("You must select a value");
            }
        }

        /// <summary>
        /// Removes money from the wallet's money balance.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void subtractMoneyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Remove money from the guest's wallet money balance via the combo box.
                this.guest.Wallet.RemoveMoney(decimal.Parse(this.moneyAmountComboBox.Text));

                // Reset the money balance label to the new money balance.
                this.moneyBalanceLabel.Content = this.guest.Wallet.MoneyBalance.ToString("C");
            }
            catch (FormatException)
            {
                MessageBox.Show("You must select a value");
            }
        }

        /// <summary>
        /// Actions for the wallet color combo box in the guest window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void walletColorComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            WalletColor walletColor = (WalletColor)this.walletColorComboBox.SelectedItem;
        }
    }
}