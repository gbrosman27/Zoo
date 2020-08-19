using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Accounts;
using Animals;
using BirthingRooms;
using BoothItems;
using MoneyCollectors;
using People;
using Reproducers;
using VendingMachines;

namespace Zoos
{
    [Serializable]

    /// <summary>
    /// The class which is used to represent a zoo.
    /// </summary>
    public class Zoo
    {
        /// <summary>
        /// A list of all animals currently residing within the zoo.
        /// </summary>
        private List<Animal> animals;

        /// <summary>
        /// The zoo's vending machine which allows guests to buy snacks for animals.
        /// </summary>
        private VendingMachine animalSnackMachine;

        /// <summary>
        /// The zoo's room for birthing animals.
        /// </summary>
        private BirthingRoom b168;

        /// <summary>
        /// A list of animal cages.
        /// </summary>
        private Dictionary<Type, Cage> cages;

        /// <summary>
        /// The maximum number of guests the zoo can accommodate at a given time.
        /// </summary>
        private int capacity;

        /// <summary>
        /// A list of all guests currently visiting the zoo.
        /// </summary>
        private List<Guest> guests;

        /// <summary>
        /// The zoo's information booth.
        /// </summary>
        private GivingBooth informationBooth;

        /// <summary>
        /// The zoo's ladies' restroom.
        /// </summary>
        private Restroom ladiesRoom;

        /// <summary>
        /// The zoo's men's restroom.
        /// </summary>
        private Restroom mensRoom;

        /// <summary>
        /// The name of the zoo.
        /// </summary>
        private string name;

        /// <summary>
        /// The zoo's money collecting booth.
        /// </summary>
        private MoneyCollectingBooth ticketBooth;

        /// <summary>
        /// Initializes a new instance of the Zoo class.
        /// </summary>
        /// <param name="name">The name of the zoo.</param>
        /// <param name="capacity">The maximum number of guests the zoo can accommodate at a given time.</param>
        /// <param name="restroomCapacity">The capacity of the zoo's restrooms.</param>
        /// <param name="animalFoodPrice">The price of a pound of food from the zoo's animal snack machine.</param>
        /// <param name="ticketPrice">The price of an admission ticket to the zoo.</param>
        /// <param name="waterBottlePrice">The price of the water bottles.</param>
        /// <param name="boothMoneyBalance">The initial money balance of the zoo's ticket booth.</param>
        /// <param name="attendant">The zoo's ticket booth attendant.</param>
        /// <param name="vet">The zoo's birthing room vet.</param>
        public Zoo(string name, int capacity, int restroomCapacity, decimal animalFoodPrice, decimal ticketPrice, decimal waterBottlePrice, decimal boothMoneyBalance, Employee attendant, Employee vet)
        {
            this.animals = new List<Animal>();
            this.animalSnackMachine = new VendingMachine(animalFoodPrice, new Account());
            this.b168 = new BirthingRoom(vet);
            this.capacity = capacity;
            this.guests = new List<Guest>();
            this.ladiesRoom = new Restroom(restroomCapacity, Gender.Female);
            this.mensRoom = new Restroom(restroomCapacity, Gender.Male);
            this.name = name;
            this.ticketBooth = new MoneyCollectingBooth(attendant, ticketPrice, waterBottlePrice, new MoneyBox());

            this.informationBooth = new GivingBooth(attendant);

            // ticketPrice added to boothMoneyBalance 1.2 step 9c.
            this.ticketBooth.AddMoney(boothMoneyBalance + ticketPrice);

            //// Object Initializer. Removed via Zoo 3.2 Step 3A.
            ////this.animals = new List<Animal>();
            ////{
            ////    new Chimpanzee("Bobo", 10, 128.2, Gender.Male);
            ////    new Chimpanzee("Bubbles", 3, 103.8, Gender.Female);
            ////    new Dingo("Spot", 5, 41.3, Gender.Male);
            ////    new Dingo("Maggie", 6, 37.2, Gender.Female);
            ////    new Dingo("Toby", 0, 15.0, Gender.Male);
            ////    new Eagle("Ari", 12, 10.1, Gender.Female);
            ////    new Hummingbird("Buzz", 2, 0.02, Gender.Male);
            ////    new Hummingbird("Bitsy", 1, 0.03, Gender.Female);
            ////    new Kangaroo("Kanga", 8, 72.0, Gender.Female);
            ////    new Kangaroo("Roo", 0, 23.9, Gender.Male);
            ////    new Kangaroo("Jake", 9, 153.5, Gender.Male);
            ////    new Ostrich("Stretch", 26, 231.7, Gender.Male);
            ////    new Ostrich("Speedy", 30, 213.0, Gender.Female);
            ////    new Platypus("Patti", 13, 4.4, Gender.Female);
            ////    new Platypus("Bill", 11, 4.9, Gender.Male);
            ////    new Platypus("Ted", 0, 1.1, Gender.Male);
            ////    new Shark("Bruce", 19, 810.6, Gender.Female);
            ////    new Shark("Anchor", 17, 458.0, Gender.Male);
            ////    new Shark("Chum", 14, 377.3, Gender.Male);
            ////    new Squirrel("Chip", 4, 1.0, Gender.Male);
            ////    new Squirrel("Dale", 4, 0.9, Gender.Male);
            //// }

            Animal brutus = new Dingo("Brutus", 3, 36.0, Gender.Male);
            Animal coco = new Dingo("Coco", 7, 38.3, Gender.Female);
            coco.AddChild(brutus);

            Animal toby = new Dingo("Toby", 4, 42.5, Gender.Male);
            Animal steve = new Dingo("Steve", 4, 41.1, Gender.Male);
            Animal maggie = new Dingo("Maggie", 7, 34.8, Gender.Female);
            maggie.AddChild(toby);
            maggie.AddChild(steve);

            Animal lucy = new Dingo("Lucy", 7, 36.5, Gender.Female);
            Animal ted = new Dingo("Ted", 7, 39.7, Gender.Male);
            Animal bella = new Dingo("Bella", 10, 40.2, Gender.Female);
            bella.AddChild(coco);
            bella.AddChild(maggie);
            bella.AddChild(lucy);
            bella.AddChild(ted);

            List<Animal> tempList = new List<Animal>();
            tempList.Add(bella);
            tempList.Add(new Dingo("Max", 12, 46.9, Gender.Male));
                        
            // Initializes a new Cage Dictionary.
            this.cages = new Dictionary<Type, Cage>();

            // Add new cages to the list for each animal.
            foreach (AnimalType t in Enum.GetValues(typeof(AnimalType)))
            {
                this.cages.Add(Animal.ConvertAnimalTypetoType(t), new Cage(400, 800));
            }

            this.AddAnimalsToZoo(tempList);
        }

        /// <summary>
        /// Gets the animals in the list and loops through.
        /// </summary>
        public IEnumerable<Animal> Animals
        {
            get
            {
                return this.animals;
            }
        }

        /// <summary>
        /// Gets the zoo's animal snack machine.
        /// </summary>
        public VendingMachine AnimalSnackMachine
        {
            get
            {
                return this.animalSnackMachine;
            }
        }

        /// <summary>
        /// Gets the average weight of all animals in the zoo.
        /// </summary>
        public double AverageAnimalWeight
        {
            get
            {
                return this.TotalAnimalWeight / this.animals.Count;
            }
        }

        /// <summary>
        /// Gets the birthing room.
        /// </summary>
        public BirthingRoom B168
        {
            get
            {
                return this.b168;
            }
        }                       

        /// <summary>
        /// Gets or sets the temperature of the zoo's birthing room.
        /// </summary>
        public double BirthingRoomTemperature
        {
            get
            {
                return this.b168.Temperature;
            }

            set
            {
                this.b168.Temperature = value;
            }
        }

        /// <summary>
        /// Gets the list of guests and loops through.
        /// </summary>
        public IEnumerable<Guest> Guests
        {
            get
            {
                return this.guests;
            }
        }

        /// <summary>
        /// Gets the total weight of all animals in the zoo.
        /// </summary>
        public double TotalAnimalWeight
        {
            get
            {
                // Define accumulator variable.
                double totalWeight = 0;

                // Loop through the list of animals.
                foreach (Animal a in this.animals)
                {
                    // Add current animal's weight to the total.
                    totalWeight += a.Weight;
                }

                return totalWeight;
            }
        }

        /// <summary>
        /// The new zoo.
        /// </summary>
        /// <returns>Returns the new zoo.</returns>
        public static Zoo NewZoo()
        {
            Zoo zoo;

            // Create an instance of the Zoo class.
            zoo = new Zoo("Como Zoo", 1000, 4, 0.75m, 15.00m, 3.00m, 3640.25m, new Employee("Sam", 42), new Employee("Flora", 98));

            // Add money to the animal snack machine.
            zoo.AnimalSnackMachine.AddMoney(42.75m);

            return zoo;
        }

        /// <summary>
        /// Loads the zoo from a saved file.
        /// </summary>
        /// <param name="fileName">The name of the zoo file.</param>
        /// <returns>The zoo to be loaded.</returns>
        public static Zoo LoadFromFile(string fileName)
        {
            Zoo result = null;

            // Create a binary formatter
            BinaryFormatter formatter = new BinaryFormatter();

            // Open and read a file using the passed-in file name
            // Use a using statement to automatically clean up object references
            // and close the file handle when the deserialization process is complete
            using (Stream stream = File.OpenRead(fileName))
            {
                // Deserialize (load) the file as a zoo
                result = formatter.Deserialize(stream) as Zoo;
            }

            return result;
        }

        /// <summary>
        /// Adds an animal to the zoo.
        /// </summary>
        /// <param name="animal">The animal to add.</param>
        public void AddAnimal(Animal animal)
        {
            // Find the animal's cage.            
            Cage cage = this.FindCage(animal.GetType());

            // Add an animal to the zoo list.
            this.animals.Add(animal);

            if (animal.IsPregnant == true)
            {
                this.b168.PregnantAnimals.Enqueue(animal);
            }

            // Add the animal to the cage.
            cage.Add(animal);
        }

        /// <summary>
        /// Adds a guest to the zoo.
        /// </summary>
        /// <param name="guest">The guest to add.</param>
        /// <param name="ticket">The guest's ticket.</param>
        public void AddGuest(Guest guest, Ticket ticket)
        {
            if (ticket != null && ticket.IsRedeemed != true)
            {
                this.guests.Add(guest);

                // Redeem the ticket.
                ticket.Redeem();
            }
            else
            {
                throw new NullReferenceException("The guest could not be admitted because they did not have a ticket.");
            }
        }

        /// <summary>
        /// Aids a reproducer in giving birth.
        /// </summary>
        /// <param name="reproducer">The reproducer that is to give birth.</param>
        public void BirthAnimal(IReproducer reproducer)
        {
            // Birth animal.
            IReproducer baby = this.b168.BirthAnimal(reproducer);

            // If the baby is an animal...
            if (baby is Animal)
            {
                // Add the baby to the zoo's list of animals.
                this.AddAnimal(baby as Animal);
            }
        }

        /// <summary>
        /// Finds an animal based on type.
        /// </summary>
        /// <param name="type">The type of the animal to find.</param>
        /// <returns>The first matching animal.</returns>
        public Animal FindAnimal(Type type)
        {
            // Define variable to hold matching animal.
            Animal animal = null;

            // Loop through the list of animals.
            foreach (Animal a in this.animals)
            {
                // If the current animal matches...
                if (a.GetType() == type)
                {
                    // Set the current animal to the variable.
                    animal = a;

                    // Break out of the loop.
                    break;
                }
            }

            // Return the matching animal.
            return animal;
        }

        /// <summary>
        /// Finds an animal based on type and pregnancy status.
        /// </summary>
        /// <param name="type">The type of the animal to find.</param>
        /// <param name="isPregnant">The pregnancy status of the animal to find.</param>
        /// <returns>The first matching animal.</returns>
        public Animal FindAnimal(Type type, bool isPregnant)
        {
            // Define variable to hold matching animal.
            Animal animal = null;

            // Loop through the list of animals.
            foreach (Animal a in this.animals)
            {
                // If the current animal matches...
                if (a.GetType() == type && a.IsPregnant == isPregnant)
                {
                    // Store the current animal in the variable.
                    animal = a;

                    // Break out of the loop.
                    break;
                }
            }

            // Return the matching animal.
            return animal;
        }

        /// <summary>
        /// Finds the animal with the specified name.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <returns>Returns the desired animal.</returns>
        public Animal FindAnimal(string name)
        {
            // Define variable to hold matching animal.
            Animal animal = null;

            // Loop through the list of animals.
            foreach (Animal a in this.animals)
            {
                // If the current animal matches...
                if (a.Name == name)
                {
                    // Set the current animal to the variable.
                    animal = a;

                    // Break out of the loop.
                    break;
                }
            }

            // Return the matching animal.
            return animal;
        }

        /// <summary>
        /// Finds the correct animal cage.
        /// </summary>
        /// <param name="animalType">The type of animal.</param>
        /// <returns>Returns the animal cage.</returns>
        public Cage FindCage(Type animalType)
        {
            Cage result = null;

            this.cages.TryGetValue(animalType, out result);

            return result;
        }

        /// <summary>
        /// Finds a guest based on name.
        /// </summary>
        /// <param name="name">The name of the guest to find.</param>
        /// <returns>The first matching guest.</returns>
        public Guest FindGuest(string name)
        {
            // Define a variable to hold matching guest.
            Guest guest = null;

            // Loop through the list of guests.
            foreach (Guest g in this.guests)
            {
                // If the current guest matches...
                if (g.Name == name)
                {
                    // Store the current guest in the variable
                    guest = g;

                    // Break out of the loop
                    break;
                }
            }

            // Return the matching guest.
            return guest;
        }

        /// <summary>
        /// Gets an animal from the zoo list and adds it to another animal list.
        /// </summary>
        /// <param name="type">The type of animal.</param>
        /// <returns>Returns the entire animal list.</returns>
        public IEnumerable<Animal> GetAnimals(Type type)
        {
            List<Animal> animalList = new List<Animal>();

            foreach (Animal a in this.animals)
            {
                if (a.GetType() == type)
                {
                    animalList.Add(a);
                }
            }

            return animalList;
        }

        /// <summary>
        /// Removes an animal from the list of animals in the zoo.
        /// </summary>
        /// <param name="animal">The animal to remove.</param>
        public void RemoveAnimal(Animal animal)
        {
            Guest guest = null;

            // Find the animal's cage.
            Cage cage = this.FindCage(animal.GetType());

            foreach (Guest g in this.Guests)
            {
                guest = g;

                if (guest.AdoptedAnimal == animal)
                {
                    guest.AdoptedAnimal = null;
                    cage.Remove(guest);
                }
            }

            // Remove the animal from the zoo list.
            this.animals.Remove(animal);

            // Remove animal from the cage.
            cage.Remove(animal);
        }

        /// <summary>
        /// Removes a guest from the list of guests in the zoo.
        /// </summary>
        /// <param name="guest">The guest to remove.</param>
        public void RemoveGuest(Guest guest)
        {
            this.guests.Remove(guest);
        }

        /// <summary>
        /// Sells a ticket to the guest.
        /// </summary>
        /// <param name="guest">The guest to sell a ticket to.</param>
        /// <returns>Returns a ticket.</returns>
        public Ticket SellTicket(Guest guest)
        {
            Ticket ticket = null;

            try
            {
                // Guest goes to the ticket booth to buy a ticket.
                ticket = guest.VisitTicketBooth(this.ticketBooth);

                // Guest goes to the information booth.
                guest.VisitInformationBooth(this.informationBooth);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Ticket not found.", ex);
            }

            return ticket;
        }

        /// <summary>
        /// Sort the animals according to command type.
        /// </summary>
        /// <param name="sortType">The sort type to be executed.</param>
        /// <param name="sortValue">The number of times the sort was performed to achieve success.</param>
        /// <returns>Returns the sort result.</returns>
        public SortResult SortAnimals(string sortType, string sortValue)
        {
            SortResult sortResult = null;

            switch (sortType)
            {
                case "bubble":
                    if (sortValue == "weight")
                    {
                        sortResult = SortHelper.BubbleSortByWeight(this.animals);
                    }

                    if (sortValue == "name")
                    {
                        sortResult = SortHelper.BubbleSortByName(this.animals);
                    }

                    break;

                case "selection":
                    if (sortValue == "weight")
                    {
                        sortResult = SortHelper.SelectionSortByWeight(this.animals);
                    }

                    if (sortValue == "name")
                    {
                        sortResult = SortHelper.SelectionSortByName(this.animals);
                    }

                    break;

                case "insertion":
                    if (sortValue == "weight")
                    {
                        sortResult = SortHelper.InsertionSortByWeight(this.animals);
                    }

                    if (sortValue == "name")
                    {
                        sortResult = SortHelper.InsertionSortByName(this.animals);
                    }

                    break;

                case "quick":
                    if (sortValue == "weight")
                    {
                        sortResult = new SortResult();
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        // Call the QuickSortByWeight method.
                        sortResult = SortHelper.QuickSortByWeight(this.animals, this.animals.IndexOf(this.animals[0]), this.animals.LastIndexOf(this.animals[this.animals.Count - 1]), sortResult);
                        stopwatch.Stop();
                        sortResult.ElapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;                    
                    }

                    if (sortValue == "name")
                    {
                        sortResult = new SortResult();
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();

                        // Call the QuickSortByName method.
                        sortResult = SortHelper.QuickSortByName(this.animals, this.animals.IndexOf(this.animals[0]), this.animals.LastIndexOf(this.animals[this.animals.Count - 1]), sortResult);
                        stopwatch.Stop();
                        sortResult.ElapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;
                    }

                    break;
            }

            return sortResult;
        }

        /// <summary>
        /// Saves the zoo to the file.
        /// </summary>
        /// <param name="fileName">The name of the zoo file.</param>
        public void SaveToFile(string fileName)
        {
            // Create a binary formatter
            BinaryFormatter formatter = new BinaryFormatter();

            // Create a file using the passed-in file name
            // Use a using statement to automatically clean up object references
            // and close the file handle when the serialization process is complete
            using (Stream stream = File.Create(fileName))
            {
                // Serialize (save) the current instance of the zoo
                formatter.Serialize(stream, this);
            }
        }

        /// <summary>
        /// Adds animals to the zoo.
        /// </summary>
        /// <param name="animals">An animal from the enum list.</param>
        private void AddAnimalsToZoo(IEnumerable<Animal> animals)
        {
            // loop through passed -in list of animals.
            foreach (Animal a in animals)
            {
                this.AddAnimal(a);
                this.AddAnimalsToZoo(a.Children);                
            }
                       
            //// add the current animal to the list (use AddAnimal).
            //// using recursion, add the current animal's children to the zoo.
        }
    }
}