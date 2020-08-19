using Reproducers;

namespace Animals
{
    /// <summary>
    /// The class used to represent an animal factory.
    /// </summary>
    public static class AnimalFactory
    {
        /// <summary>
        /// Creates an animal.
        /// </summary>
        /// <param name="type">The type of animal.</param>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal.</param>
        /// <param name="gender">The gender of the animal.</param>
        /// <returns>Returns an animal.</returns>
        public static Animal CreateAnimal(AnimalType type, string name, int age, double weight, Gender gender)
        {
            Animal animal = null;

            switch (type)
            {
                case AnimalType.Chimpanzee:

                    // Create Chewy the chimpanzee.
                    animal = new Chimpanzee(name, age, weight, gender);

                    break;

                case AnimalType.Dingo:

                    // Create Dolly the dingo.
                    animal = new Dingo(name, age, weight, gender);

                    // Create Dixie the dingo.
                    animal = new Dingo(name, age, weight, gender);

                    break;

                case AnimalType.Eagle:
                    // Create Edgar the eagle..
                    animal = new Eagle(name, age, weight, gender);

                    break;

                case AnimalType.Hummingbird:
                    // Create Harold.
                    animal = new Hummingbird(name, age, weight, gender);

                    break;

                case AnimalType.Kangaroo:
                    // Create Khan the kangaroo.
                    animal = new Kangaroo(name, age, weight, gender);

                    break;

                case AnimalType.Ostrich:
                    // Create Ozzie the ostrich.
                    animal = new Ostrich(name, age, weight, gender);

                    break;

                case AnimalType.Platypus:
                    // Create Patty.
                    animal = new Platypus(name, age, weight, gender);

                    break;

                case AnimalType.Shark:
                    // Creates Sasha the shark.
                    animal = new Shark(name, age, weight, gender);

                    break;

                case AnimalType.Squirrel:
                    // Create Sonny the squirrel.
                    animal = new Squirrel(name, age, weight, gender);

                    break;
            }

            return animal;
        }
    }
}