using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Timers;
using CagedItems;
using Foods;
using Reproducers;
using Utilities;

namespace Animals
{
    [Serializable]

    /// <summary>
    /// The class which is used to represent an animal.
    /// </summary>
    public abstract class Animal : IEater, IMover, IReproducer, ICageable
    {
        /// <summary>
        /// A random generator.
        /// </summary>
        private static Random random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// The age of the animal.
        /// </summary>
        private int age;

        /// <summary>
        /// The weight of a newborn baby (as a percentage of the parent's weight).
        /// </summary>
        private double babyWeightPercentage;

        /// <summary>
        /// The gender of the animal.
        /// </summary>
        private Gender gender;

        /// <summary>
        /// A value indicating whether or not the animal is pregnant.
        /// </summary>
        private bool isPregnant;

        /// <summary>
        /// The timer to make the animal move on its own.
        /// </summary>
        [NonSerialized]
        private Timer moveTimer;

        /// <summary>
        /// The name of the animal.
        /// </summary>
        private string name;

        /// <summary>
        /// The weight of the animal (in pounds).
        /// </summary>
        private double weight;

        /// <summary>
        /// A list of the animal children.
        /// </summary>
        private List<Animal> children = new List<Animal>();

        /// <summary>
        /// Initializes a new instance of the Animal class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        /// <param name="gender">The animal's gender.</param>
        public Animal(string name, int age, double weight, Gender gender)
        {
            this.age = age;
            this.name = name;
            this.weight = weight;
            this.gender = gender;
            
            // Movement parameters set to random.
            this.XPositionMax = 800;
            this.YPositionMax = 400;
            this.MoveDistance = random.Next(5, 16);
            this.XPosition = random.Next(1, this.XPositionMax + 1);
            this.YPosition = random.Next(1, this.YPositionMax + 1);

            // Set the animal's direction based on random numbers.
            int randomNumber = random.Next(0, 2);
            this.YDirection = (randomNumber == 0) ? VerticalDirection.Up : VerticalDirection.Down;
            this.XDirection = (randomNumber == 0) ? HorizontalDirection.Left : HorizontalDirection.Right;

            this.CreateTimers();
        }

        /// <summary>
        /// Initializes a new instance of the Animal class. Overloaded version. Chained to above constructor.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// /// <param name="weight">The weight of the animal (in pounds).</param>
        /// <param name="gender">The animal's gender.</param>
        public Animal(string name, double weight, Gender gender)
            : this(name, 0, weight, gender)
        {
            this.name = name;
            this.weight = weight;
            this.gender = gender;
        }

        /// <summary>
        /// Gets or sets the age of the animal.
        /// </summary>
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value >= 0 && value <= 100)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Age", "The age must be between 0 and 100.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the weight of a newborn baby (as a percentage of the parent's weight).
        /// </summary>
        public double BabyWeightPercentage
        {
            get
            {
                return this.babyWeightPercentage;
            }

            set
            {
                this.babyWeightPercentage = value;
            }
        }

        /// <summary>
        /// Gets the size of the animal appearance.
        /// </summary>
        public virtual double DisplaySize
        {
            get
            {
                // Determine if the animal should be a baby or an adult.
                double animalSize = (this.Age == 0) ? 0.5 : 1.0;

                return animalSize;
            }
        }

        /// <summary>
        /// Gets or sets the animal's movement behavior.
        /// </summary>
        public IEatBehavior EatBehavior { get; set; }

        /// <summary>
        /// Gets or sets the name of the animal.
        /// </summary>
        public Gender Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not the animal is pregnant.
        /// </summary>
        public bool IsPregnant
        {
            get
            {
                return this.isPregnant;
            }
        }

        /// <summary>
        /// Gets or sets the animal's move behavior.
        /// </summary>
        public IMoveBehavior MoveBehavior { get; set; }

        /// <summary>
        /// Gets or sets the movement of the specified distance.
        /// </summary>
        public int MoveDistance { get; set; }

        /// <summary>
        /// Gets or sets the name of the animal.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Name must only include letters.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the animal's reproduction behavior.
        /// </summary>
        public IReproduceBehavior ReproduceBehavior { get; set; }

        /// <summary>
        /// Gets the animal child.
        /// </summary>
        public IEnumerable<Animal> Children
        {
            get
            {
                return this.children;
            }
        }

        /// <summary>
        /// Gets the animal age type (baby or adult).
        /// </summary>
        public string ResourceKey
        {
            get
            {
                // Get the animals type by name.
                string resourceKey = this.GetType().Name;

                // If the animal's age is 0, set it to "baby", otherwise set it to "adult".
                resourceKey = (this.Age == 0) ? resourceKey + "Baby" : resourceKey + "Adult";

                return resourceKey;
            }
        }

        /// <summary>
        /// Gets or sets the animal's weight (in pounds).
        /// </summary>
        public double Weight
        {
            get
            {
                return this.weight;
            }

            set
            {
                if (value >= 1 && value <= 1000)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Weight", "The weight must be between 0 and 1000.");
                }
            }
        }

        /// <summary>
        /// Gets the percentage of weight gained for each pound of food eaten.
        /// </summary>
        public abstract double WeightGainPercentage { get; }

        /// <summary>
        /// Gets or sets the specified horizontal direction.
        /// </summary>
        public HorizontalDirection XDirection { get; set; }

        /// <summary>
        /// Gets or sets the specified horizontal position.
        /// </summary>
        public int XPosition { get; set; }

        /// <summary>
        /// Gets or sets the maximum horizontal position.
        /// </summary>
        public int XPositionMax { get; set; }

        /// <summary>
        /// Gets or sets the specified vertical direction.
        /// </summary>
        public VerticalDirection YDirection { get; set; }

        /// <summary>
        /// Gets or sets the specified vertical position.
        /// </summary>
        public int YPosition { get; set; }

        /// <summary>
        /// Gets or sets the maximum vertical position.
        /// </summary>
        public int YPositionMax { get; set; }

        /// <summary>
        /// Converts the animal types to Types.
        /// </summary>
        /// <param name="animalType">The animal type.</param>
        /// <returns>Returns the animal Type.</returns>
        public static Type ConvertAnimalTypetoType(AnimalType animalType)
        {
            Type animalTypeSelected = null;

            switch (animalType)
            {
                case AnimalType.Chimpanzee:
                    animalTypeSelected = typeof(Chimpanzee);
                    break;

                case AnimalType.Dingo:
                    animalTypeSelected = typeof(Dingo);
                    break;

                case AnimalType.Eagle:
                    animalTypeSelected = typeof(Eagle);
                    break;

                case AnimalType.Hummingbird:
                    animalTypeSelected = typeof(Hummingbird);
                    break;

                case AnimalType.Kangaroo:
                    animalTypeSelected = typeof(Kangaroo);
                    break;

                case AnimalType.Ostrich:
                    animalTypeSelected = typeof(Ostrich);
                    break;

                case AnimalType.Platypus:
                    animalTypeSelected = typeof(Platypus);
                    break;

                case AnimalType.Shark:
                    animalTypeSelected = typeof(Shark);
                    break;

                case AnimalType.Squirrel:
                    animalTypeSelected = typeof(Squirrel);
                    break;
            }

            return animalTypeSelected;
        }

        /// <summary>
        /// Eats the specified food.
        /// </summary>
        /// <param name="food">The food to eat.</param>
        public virtual void Eat(Food food)
        {
            this.EatBehavior.Eat(this, food);
        }

        /// <summary>
        /// Makes the animal pregnant.
        /// </summary>
        public void MakePregnant()
        {
            this.isPregnant = true;
            this.MoveBehavior = new NoMoveBehavior();
        }

        /// <summary>
        /// Moves about.
        /// </summary>
        public void Move()
        {
            this.MoveBehavior.Move(this);
        }

        /// <summary>
        /// Creates another reproducer of its own type.
        /// </summary>
        /// <returns>The resulting baby reproducer.</returns>
        public virtual IReproducer Reproduce()
        {
            IReproducer baby = null;

            baby = this.ReproduceBehavior.Reproduce(this);

            int randomGender = random.Next(0, 2);
            (baby as Animal).Gender = (randomGender == 0) ? Gender.Male : Gender.Female;
            this.children.Add(baby as Animal);

            // Make mother not pregnant after giving birth.
            this.isPregnant = false;

            return baby;
        }

        /// <summary>
        /// Adds an animal child.
        /// </summary>
        /// <param name="animal">The animal the child belongs to.</param>
        public void AddChild(Animal animal)
        { 
            this.children.Add(animal);
        }

        /// <summary>
        /// Generates a string representation of the animal.
        /// </summary>
        /// <returns>A string representation of the animal.</returns>
        public override string ToString()
        {
            string value = this.isPregnant == true ? (this.name + ": " + this.GetType().Name + " (" + this.age + ", " + this.Weight + ", " + this.gender + ") P") : (this.name + ": " + this.GetType().Name + " (" + this.age + ", " + this.Weight + ", " + this.gender + ")");

            return value;
        }

        /// <summary>
        /// Creates the timers.
        /// </summary>
        private void CreateTimers()
        {
            // Initialize a new timer. **Changed from 1000.
            this.moveTimer = new Timer(100);

            // Connect the timer with the event handler.
            this.moveTimer.Elapsed += this.MoveHandler;

            // Start the timer.
            this.moveTimer.Start();
        }

        /// <summary>
        /// Actions on deserialization.
        /// </summary>
        /// <param name="context">Context for deserialization.</param>
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            this.CreateTimers();
        }

        /// <summary>
        /// Timer event handler.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void MoveHandler(object sender, ElapsedEventArgs e)
        {
#if DEBUG
            this.moveTimer.Enabled = false;
#endif

            this.Move();

#if DEBUG
            this.moveTimer.Enabled = true;
#endif
        }
    }
}