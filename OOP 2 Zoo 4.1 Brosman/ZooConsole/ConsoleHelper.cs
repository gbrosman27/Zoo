using System;
using System.Collections.Generic;
using Accounts;
using Animals;
using People;
using Reproducers;
using Zoos;

namespace ZooConsole
{
    /// <summary>
    /// The class used to represent the console helper.
    /// </summary>
    internal static class ConsoleHelper
    {
        /// <summary>
        /// Directs the add command according to its parameter.
        /// </summary>
        /// <param name="zoo">The zoo in which to add something.</param>
        /// <param name="type">The type of what is being added to the zoo.</param>
        public static void ProcessAddCommand(Zoo zoo, string type)
        {
            switch (type)
            {
                case "animal":
                    AddAnimal(zoo);

                    break;

                case "guest":
                    AddGuest(zoo);

                    break;

                default:
                    Console.WriteLine("Command only supports adding an animal or guest.");
                    break;
            }
        }

        /// <summary>
        /// Directs the remove command according to its parameter.
        /// </summary>
        /// <param name="zoo">The zoo in which to remove something.</param>
        /// <param name="type">The type of what is being removed to the zoo.</param>
        /// <param name="name">The name of what is to be removed.</param>
        public static void ProcessRemoveCommand(Zoo zoo, string type, string name)
        {
            string animalName = ConsoleUtil.InitialUpper(name);
            string guestName = ConsoleUtil.InitialUpper(name);

            switch (type)
            {
                case "animal":
                    RemoveAnimal(zoo, animalName);

                    break;

                case "guest":
                    RemoveGuest(zoo, guestName);

                    break;

                default:
                    Console.WriteLine("Command only supports removing an animal.");
                    break;
            }
        }

        /// <summary>
        /// Directs the show command according to its parameter.
        /// </summary>
        /// <param name="zoo">The zoo created.</param>
        /// <param name="type">The type of parameter via commandWords[1]: animal or guest.</param>
        /// <param name="name">The name of the animal or guest to find.</param>
        public static void ProcessShowCommand(Zoo zoo, string type, string name)
        {
            string animalName = ConsoleUtil.InitialUpper(name);
            string guestName = ConsoleUtil.InitialUpper(name);

            switch (type)
            {
                case "animal":
                    ShowAnimal(zoo, animalName);

                    break;

                case "guest":
                    ShowGuest(zoo, guestName);

                    break;

                case "cage":
                    ShowCage(zoo, animalName);

                    break;

                case "children":
                    ShowChildren(zoo, animalName);
                    break;
            }
        }

        /// <summary>
        /// Sets the birthing room temperature.
        /// </summary>
        /// <param name="zoo">The zoo created.</param>
        /// <param name="temperature">The temperature parameter via commandWords[1].</param>
        public static void SetTemperature(Zoo zoo, string temperature)
        {
            double currentTemperature = zoo.BirthingRoomTemperature;

            zoo.BirthingRoomTemperature = double.Parse(temperature);

            string previousTemperature = $"Previous temperature: {currentTemperature}  °F";
            Console.WriteLine(previousTemperature);

            string newTemperature = $"New temperature: {temperature} °F.";
            Console.WriteLine(newTemperature);
        }

        /// <summary>
        /// Shows the help details.
        /// </summary>
        /// <param name="command">The command passed in.</param>
        public static void ShowHelpDetail(string command)
        {
            Dictionary<string, string> arguments = new Dictionary<string, string>();
            string overview = null;
            
            switch (command)
            {              
                case "show":
                    arguments = new Dictionary<string, string>();                    
                    overview = "Shows details of the object referenced.";
                    
                    arguments.Add("objectType", "The type of the object to show (ANIMAL, GUEST, or CAGE).");
                    arguments.Add("objectName", "The name of the object to show (use an animal name for CAGE).");
                    ConsoleUtil.WriteHelpDetail(command, overview, arguments);
                    break;

                case "remove":
                    arguments = new Dictionary<string, string>();
                    overview = "Removes an animal from the zoo.";
                    
                    arguments.Add("objectType", "The type of the object to remove (ANIMAL or GUEST).");
                    arguments.Add("objectName", "The name of the object to remove.");
                    ConsoleUtil.WriteHelpDetail(command, overview, arguments);
                    break;

                case "temp":
                    ConsoleUtil.WriteHelpDetail(command, "Sets the temperature of the birthing room.", "int", "Temperature in Fahrenheit.");
                    break;

                case "add":
                    ConsoleUtil.WriteHelpDetail(command, "Adds an object to the zoo.", "objectType", "The type of the object to add (ANIMAL or GUEST).");
                    break;

                case "restart":
                    ConsoleUtil.WriteHelpDetail(command, "Creates a new zoo.");
                    break;

                case "exit":
                    ConsoleUtil.WriteHelpDetail(command, "Exits the application.");
                    break;
            }            
        }

        /// <summary>
        /// Shows help for a single command word.
        /// </summary>
        public static void ShowHelp()
        {
            ConsoleUtil.WriteHelpDetail("Help", "Show help detail", "[command]", "The command for which to show help details.");
            Console.WriteLine("Known Commands: ");
            Console.WriteLine("RESTART: Creates a new zoo.");
            Console.WriteLine("EXIT: Exits the application.");
            Console.WriteLine("TEMP: Sets the temperature of the birthing room.");
            Console.WriteLine("SHOW: Shows details of the object referenced.");
            Console.WriteLine("ADD: Adds an object to the zoo.");
            Console.WriteLine("REMOVE: Removes an animal from the zoo.");
        }

        /// <summary>
        /// Saves the zoo file.
        /// </summary>
        /// <param name="zoo">The zoo to be saved.</param>
        /// <param name="fileName">The name of the zoo file.</param>
        public static void SaveFile(Zoo zoo, string fileName)
        {
            try
            {
                zoo.SaveToFile(fileName);

                Console.WriteLine("Your zoo has been successfully saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Your attempt to save has been unsuccessful.", ex);
            }
        }

        /// <summary>
        /// Loads the zoo file.
        /// </summary>
        /// <param name="fileName">The zoo file to be loaded.</param>
        /// <returns>The zoo that is loaded.</returns>
        public static Zoo LoadFile(string fileName)
        {
            Zoo loadedZoo = null;

            try
            {
                loadedZoo = Zoo.LoadFromFile(fileName);

                Console.WriteLine("Your zoo has been loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Your attempt to load the zoo has been unsuccessful.", ex);
            }

            return loadedZoo;
        }

        /// <summary>
        /// Adds an animal to the zoo.
        /// </summary>
        /// <param name="zoo">The zoo in which to add an animal.</param>
        private static void AddAnimal(Zoo zoo)
        {
            // Reads the animal type from the console.
            AnimalType readAnimal = ConsoleUtil.ReadAnimalType();

            // Creates the entered animal type.
            Animal animal = AnimalFactory.CreateAnimal(readAnimal, "Max", 2, 78, Gender.Female) as Animal;

            // Prompt for animal name.
            bool nameSuccess = false;

            while (!nameSuccess)
            {
                try
                {
                    string animalName = ConsoleUtil.ReadAlphabeticValue("Name");
                    animal.Name = ConsoleUtil.InitialUpper(animalName);

                    nameSuccess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // prompt for animal gender.
            bool genderSuccess = false;

            while (!genderSuccess)
            {
                try
                {
                    animal.Gender = ConsoleUtil.ReadGender();

                    genderSuccess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Prompt for animal age.
            bool ageSuccess = false;

            while (!ageSuccess)
            {
                try
                {
                    animal.Age = ConsoleUtil.ReadIntValue("Age");

                    ageSuccess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Prompt for animal weight.
            bool weightSuccess = false;

            while (!weightSuccess)
            {
                try
                {
                    animal.Weight = ConsoleUtil.ReadDoubleValue("Weight");

                    weightSuccess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Add the newly created animal to the list.
            zoo.AddAnimal(animal);

            // Show the new animal.
            ShowAnimal(zoo, animal.Name);
        }

        /// <summary>
        /// Adds a guest to the zoo.
        /// </summary>
        /// <param name="zoo">The zoo in which to add a guest.</param>
        private static void AddGuest(Zoo zoo)
        {
            // Create a new guest.
            Guest guest = new Guest("Joe", 36, 0, WalletColor.Brown, Gender.Male, new Account());

            // Prompt for guest name.
            bool nameSuccess = false;

            while (!nameSuccess)
            {
                try
                {
                    string guestName = ConsoleUtil.ReadAlphabeticValue("Name");
                    guest.Name = ConsoleUtil.InitialUpper(guestName);

                    nameSuccess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // prompt for guest gender.
            bool genderSuccess = false;

            while (!genderSuccess)
            {
                try
                {
                    guest.Gender = ConsoleUtil.ReadGender();

                    genderSuccess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Prompt for guest age.
            bool ageSuccess = false;

            while (!ageSuccess)
            {
                try
                {
                    guest.Age = ConsoleUtil.ReadIntValue("Age");

                    ageSuccess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Prompt for guest wallet money balance.
            bool walletSuccess = false;

            // CREATED DECIMAL METHOD IN UTIL.
            while (!walletSuccess)
            {
                try
                {
                    guest.Wallet.AddMoney(ConsoleUtil.ReadDecimalValue("Wallet Money Balance"));

                    walletSuccess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Prompt for guest wallet color.
            bool walletColorSuccess = false;

            while (!walletColorSuccess)
            {
                try
                {
                    WalletColor walletColor = ConsoleUtil.ReadWalletColor();

                    walletColorSuccess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Prompt for guest checking account balance.
            bool accountSuccess = false;

            while (!accountSuccess)
            {
                try
                {
                    guest.CheckingAccount.AddMoney(ConsoleUtil.ReadDecimalValue("Account Balance"));

                    accountSuccess = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Add the newly created guest to the list after selling them a ticket and a waterbottle. This will subtract $18.00 from the entered money balance.
            zoo.AddGuest(guest, zoo.SellTicket(guest));

            // Show the new animal.
            ShowGuest(zoo, guest.Name);
        }

        /// <summary>
        /// Removes the animal.
        /// </summary>
        /// <param name="zoo">The zoo from which to remove the animal.</param>
        /// <param name="name">The name of the animal to remove.</param>
        private static void RemoveAnimal(Zoo zoo, string name)
        {
            // Find the desired animal in the list of animals.
            Animal animal = null;

            foreach (Animal a in zoo.Animals)
            {
                if (a.Name == name)
                {
                    animal = a;

                    zoo.RemoveAnimal(animal);

                    Console.WriteLine("The entered animal was removed from the zoo.");

                    break;
                }
            }

            // If animal not found...
            if (animal == null)
            {
                Console.WriteLine("The entered animal could not be found.");
            }
        }

        /// <summary>
        /// Removes the guest.
        /// </summary>
        /// <param name="zoo">The zoo from which to remove the guest.</param>
        /// <param name="name">The name of the guest to remove.</param>
        private static void RemoveGuest(Zoo zoo, string name)
        {
            Guest guest = null;

            foreach (Guest g in zoo.Guests)
            {
                if (g.Name == name)
                {
                    guest = g;

                    zoo.RemoveGuest(guest);

                    Console.WriteLine("The entered guest was removed from the zoo.");

                    break;
                }
            }

            // If guest not found...
            if (guest == null)
            {
                Console.WriteLine("The entered guest could not be found.");
            }
        }

        /// <summary>
        /// Shows the desired animal.
        /// </summary>
        /// <param name="zoo">The zoo created.</param>
        /// <param name="name">The name of the animal to be shown via parameter commandWords[2].</param>
        private static void ShowAnimal(Zoo zoo, string name)
        {
            string animalName = ConsoleUtil.InitialUpper(name);
            Animal animal = zoo.FindAnimal(animalName);

            if (animal != null)
            {
                Console.WriteLine($"The following animal was found: {animal}.");
            }
            else
            {
                Console.WriteLine("The animal could not be found.");
            }
        }

        /// <summary>
        /// Shows the animal's children.
        /// </summary>
        /// <param name="zoo">The Como Zoo.</param>
        /// <param name="name">The name of the animal of which to get the children.</param>
        private static void ShowChildren(Zoo zoo, string name)
        {
            foreach (Animal a in zoo.Animals)
            {
                if (a.Name == name)
                {
                    WalkTree(a, "  ");
                }
            }
        }

        /// <summary>
        /// List the animals in the family tree.
        /// </summary>
        /// <param name="animal">The animal to get the family tree for.</param>
        /// <param name="prefix">The prefix of the animal.</param>
        private static void WalkTree(Animal animal, string prefix)
        {
            Animal animalChild = null;

            Console.WriteLine($"{prefix}{animal.Name}");
            
            foreach (Animal a in animal.Children)
            {
                animalChild = a;
                
                WalkTree(animalChild, prefix + "  ");                        
            }   
        }

        /// <summary>
        /// Shows the animal's cage.
        /// </summary>
        /// <param name="zoo">The zoo with the cage.</param>
        /// <param name="animalName">The intended animal.</param>
        private static void ShowCage(Zoo zoo, string animalName)
        {
            string animal = ConsoleUtil.InitialUpper(animalName);

            Animal animalResult = zoo.FindAnimal(animal);

            Cage cage = zoo.FindCage(animalResult.GetType());

            Console.WriteLine(cage.ToString());
        }

        /// <summary>
        /// Shows the desired guest.
        /// </summary>
        /// <param name="zoo">The zoo created.</param>
        /// <param name="name">The name of the guest to be shown via parameter commandWords[2].</param>
        private static void ShowGuest(Zoo zoo, string name)
        {
            string guestName = ConsoleUtil.InitialUpper(name);
            Guest guest = zoo.FindGuest(guestName);

            if (guest != null)
            {
                Console.WriteLine($"The following guest was found: {guest}.");
            }
            else
            {
                Console.WriteLine("The guest could not be found.");
            }
        }
    }
}