using Accounts;
using Animals;
using BirthingRooms;
using Microsoft.Win32;
using People;
using Reproducers;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Zoos;

namespace ZooScenario
{
    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Event handlers may begin with lower-case letters.")]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Minnesota's Como Zoo.
        /// </summary>
        private Zoo comoZoo;

        /// <summary>
        /// Auto saves the zoo file.
        /// </summary>
        private const string AutoSaveFileName = "Autosave.zoo";

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

#if DEBUG
            this.Title += " [DEBUG]";
#endif
        }

        /// <summary>
        /// Adds an animal to the animal list in the WPF.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void addAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the selected animal from the combo box. Create a new animal using the animal factory's create animal method.
                AnimalType animalType = (AnimalType)this.animalTypeComboBox.SelectedItem;
                Animal animal = AnimalFactory.CreateAnimal(animalType, "Max", 2, 45, Gender.Female);

                AnimalWindow animalWindow = new AnimalWindow(animal);

                animalWindow.ShowDialog();

                if (animalWindow.DialogResult == true)
                {
                    comoZoo.AddAnimal(animal);

                    PopulateAnimalListBox();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("An animal type must be selected before adding an animal to the zoo.");
            }
        }

        /// <summary>
        /// Adds a guest to the guest list in the WPF.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void addGuestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the selected guest from the list box.
                Guest guest = (Guest)this.guestListBox.SelectedItem;
                guest = new Guest("Max", 13, 25, WalletColor.Indigo, Gender.Male, new Account());

                GuestWindow guestWindow = new GuestWindow(guest);

                guestWindow.ShowDialog();

                if (guestWindow.DialogResult == true)
                {
                    comoZoo.AddGuest(guest, comoZoo.SellTicket(guest));

                    PopulateGuestListBox();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("The zoo may be out of tickets.");
            }
        }

        /// <summary>
        /// Admits the guest to the zoo.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void admitGuestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create Ethel, sell her a ticket, and add her to the guest list.
                Guest guest = new Guest("Ethel", 42, 30.00m, WalletColor.Salmon, Gender.Female, new Account());
                this.comoZoo.AddGuest(guest, this.comoZoo.SellTicket(guest));

                // Add Ethel to the list box.
                this.PopulateGuestListBox();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Allows the guest to adopt an animal.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void adoptAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected guest in the list box.
            Guest guest = this.guestListBox.SelectedItem as Guest;

            // Get the selected animal in the list box.
            Animal animal = this.animalListBox.SelectedItem as Animal;

            if (guest != null && animal != null)
            {
                // Set the animal to the guest's adopted animal.
                guest.AdoptedAnimal = animal;

                // Find the animal's cage and add the guest to it.
                Cage cage = comoZoo.FindCage(animal.GetType());
                cage.Add(guest);

                PopulateAnimalListBox();
                PopulateGuestListBox();
            }
            else
            {
                MessageBox.Show("Please choose both a guest and an animal.");
            }

            // Keep both selections active.
            guest = guestListBox.SelectedItem as Guest;
            animal = animalListBox.SelectedItem as Animal;
        }

        /// <summary>
        /// Loads the animal list box.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void animalListBox_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Creates a new animal window to allow for editing a pre-existing animal.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void animalListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Get the selected animal in the list box.
            Animal animal = this.animalListBox.SelectedItem as Animal;

            if (animal != null)
            {
                // Create new animal window.
                AnimalWindow animalWindow = new AnimalWindow(animal);

                // Show the animal window.
                animalWindow.ShowDialog();

                if (animalWindow.DialogResult == true)
                {
                    if (animal.IsPregnant == true)
                    {
                        this.comoZoo.RemoveAnimal(animal);
                        this.comoZoo.AddAnimal(animal);
                    }

                    PopulateAnimalListBox();
                }
            }
        }

        /// <summary>
        /// The animal gives birth.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void birthAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Finds the animal at the beginning of the queue without removing it.
            Animal animal = this.comoZoo.B168.PregnantAnimals.Peek() as Animal;

            this.comoZoo.BirthAnimal(animal);

            PopulateAnimalListBox();


            ////Below: Old code for selecting an animal from the list box to give birth.
            ////Animal animal = this.animalListBox.SelectedItem as Animal;

            //if (animal.IsPregnant == true)
            //{
                //IReproducer baby = animal.Reproduce();

                //comoZoo.AddAnimal(baby as Animal);

                //this.comoZoo.BirthAnimal(animal);
            //}                           
        }

        /// <summary>
        /// Changes the move behavior via the button click.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void changeMoveBehaviorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the selected animal in the list box.
                Animal animal = this.animalListBox.SelectedItem as Animal;
                MoveBehaviorType moveBehaviorType = (MoveBehaviorType)this.changeMoveBehaviorComboBox.SelectedItem;

                if (animal != null)
                {
                    IMoveBehavior animalMove = MoveBehaviorFactory.CreateMoveBehavior(moveBehaviorType);
                    animal.MoveBehavior = animalMove;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("An animal and a behavior both need to be selected.");
            }
        }

        /// <summary>
        /// Change the move behavior of the animal via the combo box.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void changeMoveBehaviorComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
        }

        /// <summary>
        /// Set the XAML temperature elements to certain dimensions on startup.
        /// </summary>
        private void ConfigureBirthingRoomControls()
        {
            double temperature = this.comoZoo.BirthingRoomTemperature;
            temperatureBorder.Height = temperature * 2;

            // Display the temperature with the degree symbol.
            string temperatureInDegrees = string.Format("{0:0.0 °F}", temperature);
            temperatureLabel.Content = temperatureInDegrees;

            // Change the border color depending on temperature.
            double colorLevel = ((this.comoZoo.BirthingRoomTemperature - BirthingRoom.MinTemperature) * 255) / (BirthingRoom.MaxTemperature - BirthingRoom.MinTemperature);

            this.temperatureBorder.Background = new SolidColorBrush(Color.FromRgb(
                Convert.ToByte(colorLevel),
                Convert.ToByte(255 - colorLevel),
                Convert.ToByte(255 - colorLevel)));
        }

        /// <summary>
        /// Decrease the temperature.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void decreaseTemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            this.ConfigureBirthingRoomControls();

            double temperature = this.comoZoo.BirthingRoomTemperature;

            try
            {
                // Decrease the birthing room temperature by 1 degree via button.
                temperature = this.comoZoo.BirthingRoomTemperature--;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("A number must be submitted as a parameter in order to change the temperature");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("A parameter must be entered in order for the temperature command to work.");
            }
        }

        /// <summary>
        /// The guest feeds an animal.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void feedAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Find a guest to feed the animal.
            Guest guest = guestListBox.SelectedItem as Guest;

            // Find an animal to feed.
            Animal animal = animalListBox.SelectedItem as Animal;

            if (guest != null && animal != null)
            {
                // Feed the selected animal.
                guest.FeedAnimal(animal, this.comoZoo.AnimalSnackMachine);

                PopulateAnimalListBox();
                PopulateGuestListBox();
            }
            else
            {
                MessageBox.Show("Please choose both a guest and an animal.");
            }

            // Keep both selections active.
            guest = guestListBox.SelectedItem as Guest;
            animal = animalListBox.SelectedItem as Animal;
        }

        /// <summary>
        /// Loads the guest list box.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void guestListBox_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Creates a new guest window to allow for editing a pre-existing guest.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void guestListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Get the selected guest in the list box.
            Guest guest = this.guestListBox.SelectedItem as Guest;

            if (guest != null)
            {
                // Create new guest window.
                GuestWindow guestWindow = new GuestWindow(guest);

                // Show the guest window.
                guestWindow.ShowDialog();

                if (guestWindow.DialogResult == true)
                {
                    PopulateGuestListBox();
                }
            }
        }

        /// <summary>
        /// Increase the temperature.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void increaseTemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            this.ConfigureBirthingRoomControls();

            double temperature = this.comoZoo.BirthingRoomTemperature;

            try
            {
                // Increase the birthing room temperature by 1 degree via button.
                temperature = this.comoZoo.BirthingRoomTemperature++;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("A number must be submitted as a parameter in order to change the temperature");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("A parameter must be entered in order for the temperature command to work.");
            }
        }

        /// <summary>
        /// Populates the animal list box.
        /// </summary>
        private void PopulateAnimalListBox()
        {
            animalListBox.ItemsSource = null;

            animalListBox.ItemsSource = comoZoo.Animals;
        }

        /// <summary>
        /// Populates the guest list box.
        /// </summary>
        private void PopulateGuestListBox()
        {
            guestListBox.ItemsSource = null;

            guestListBox.ItemsSource = comoZoo.Guests;
        }

        /// <summary>
        /// Removes an animal from the animal list in the WPF.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void removeAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Find the animal in the list box.
            Animal animal = this.animalListBox.SelectedItem as Animal;

            try
            {
                if (MessageBox.Show(string.Format("Are you sure you want to remove animal: {0}?", animal.Name), "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    comoZoo.RemoveAnimal(animal);

                    PopulateAnimalListBox();
                    PopulateGuestListBox();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select an animal to remove from the list.");
            }
        }

        /// <summary>
        /// Removes a guest from the guest list in the WPF.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void removeGuestButton_Click(object sender, RoutedEventArgs e)
        {
            // Find the guest in the list box.
            Guest guest = this.guestListBox.SelectedItem as Guest;

            try
            {
                if (MessageBox.Show(string.Format("Are you sure you want to remove guest: {0}?", guest.Name), "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    comoZoo.RemoveGuest(guest);

                    PopulateGuestListBox();
                }

                if (guest.AdoptedAnimal != null)
                {
                    Cage cage = comoZoo.FindCage(guest.AdoptedAnimal.GetType());
                    cage.Remove(guest);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a guest to remove from the list.");
            }
        }

        /// <summary>
        /// Shows the cage window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void showCageButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the animal selected in the list box.
            Animal animal = this.animalListBox.SelectedItem as Animal;

            if (animal != null)
            {
                // Get the cage of the animal selected.
                Cage cageResult = comoZoo.FindCage(animal.GetType());

                CageWindow cageWindow = new CageWindow(cageResult);
                cageWindow.Show();
            }
            else
            {
                MessageBox.Show("You must select an animal to show.");
            }
        }

        /// <summary>
        /// Allows the guest to unadopt an animal.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void unadoptAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected guest in the list box.
            Guest guest = this.guestListBox.SelectedItem as Guest;

            if (guest != null && guest.AdoptedAnimal != null)
            {
                // Finds the adopted animal's cage and removes the guest from it.
                Cage cage = comoZoo.FindCage(guest.AdoptedAnimal.GetType());
                cage.Remove(guest);

                // The guest string unadopts the animal.
                guest.AdoptedAnimal = null;

                // Repopulates the guest list box.
                PopulateGuestListBox();
            }
            else
            {
                MessageBox.Show("Please create/choose a guest, and be sure the guest has already adopted an animal.");
            }
        }

        /// <summary>
        /// Loads the window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create a new zoo.
           // this.comoZoo = Zoo.NewZoo();

            bool result = this.LoadZoo(AutoSaveFileName);

            if(result == false)
            {
                this.comoZoo = Zoo.NewZoo();

                // Calls the XAML temperature configuration.
                ConfigureBirthingRoomControls();

                // Loads the animal list box.
                this.PopulateAnimalListBox();

                // Loads the guest list box.
                this.PopulateGuestListBox();

                // Populate the animal combo box.
                this.animalTypeComboBox.ItemsSource = Enum.GetValues(typeof(AnimalType));

                // Populate the move behavior combo box.
                this.changeMoveBehaviorComboBox.ItemsSource = Enum.GetValues(typeof(MoveBehaviorType));
            }            
        }

        /// <summary>
        /// Saves the zoo to file.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Zoo save-game files (*.zoo)|*.zoo";

            saveFileDialog.ShowDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                this.SaveZoo(saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// Saves the zoo.
        /// </summary>
        /// <param name="fileName">The file name of the saved zoo.</param>
        private void SaveZoo(string fileName)
        {
            this.comoZoo.SaveToFile(fileName);
            this.SetWindowTitle(fileName);
        }

        /// <summary>
        /// Sets the window title.
        /// </summary>
        /// <param name="fileName">The file name of the zoo.</param>
        private void SetWindowTitle(string fileName)
        {
            // Set the title of the window using the current file name
            this.Title = string.Format("Object-Oriented Programming 2: Zoo [{0}]", Path.GetFileName(fileName));
        }

        /// <summary>
        /// Loads the zoo from a file.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Zoo save-game files (*.zoo)|*.zoo";

            openFileDialog.ShowDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                this.ClearWindow();
                this.LoadZoo(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// Loads the zoo.
        /// </summary>
        /// <param name="fileName">The file from which to load the zoo.</param>
        private bool LoadZoo(string fileName)
        {
            bool result = true;

            try
            {
                this.comoZoo = Zoo.LoadFromFile(fileName);

                this.SetWindowTitle(fileName);

                PopulateAnimalListBox();
                PopulateGuestListBox();
            }
            catch (Exception)
            {
                MessageBox.Show("File could not be loaded.");
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Clears the list box window.
        /// </summary>
        private void ClearWindow()
        {          
            this.animalListBox.ItemsSource = null;
            this.animalListBox.Items.Clear();

            this.guestListBox.ItemsSource = null;
            this.guestListBox.Items.Clear();           
        }

        /// <summary>
        /// Restarts the zoo fresh.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to start over?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.ClearWindow();
                this.comoZoo = Zoo.NewZoo();

                this.Title = string.Format("Object-Oriented Programming 2: Zoo");
            }
        }
                
        /// <summary>
        /// Actions when the window closes.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.SaveZoo(AutoSaveFileName);
        }
    }
}