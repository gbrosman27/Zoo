using System;
using Animals;
using Zoos;

namespace ZooConsole
{
    /// <summary>
    /// The class used to represent the ZooConsole.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The zoo being created.
        /// </summary>
        private static Zoo zoo;

        /// <summary>
        /// The ZooConsole Main Function.
        /// </summary>
        /// <param name="args">The Zoo Console main arguments.</param>
        public static void Main(string[] args)
        {
            // Changes the window title.
            Console.Title = "Object-Oriented Programming 2: Zoo";

            // Sets the opening/greeting line in the console.
            Console.WriteLine("Welcome to the Como Zoo!");

            // Sets the zoo field to null;
            zoo = Zoo.NewZoo();

            // Creates the command variable.
            string command;

            // Sets the exit variable.
            bool exit = false;

            // The while loop for the console commands.
            while (exit != true)
            {
                // Puts a bracket at the start of each line as a prompt to the user.
                Console.Write("] ");

                // Sets the command variable to make the console read the input from the user.
                command = Console.ReadLine();

                // Converts all input to lower case, and gets rid of extra spacing, so that the switch commands work.
                command = command.ToLower().Trim();

                // Creates the commandWords array.
                string[] commandWords = command.Split();

                switch (commandWords[0])
                {
                    case "exit":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid command entered: " + command);
                        break;

                    case "help":
                        if (commandWords.Length == 2)
                        {
                            ConsoleHelper.ShowHelpDetail(commandWords[1]);
                        }
                        else if (commandWords.Length == 1)
                        {
                            ConsoleHelper.ShowHelp();
                        }
                        else
                        {
                            Console.WriteLine("Too many parameters were entered.");
                        }

                        break;

                    case "restart":
                        zoo = Zoo.NewZoo();
                        zoo.BirthingRoomTemperature = 77;
                        Console.WriteLine("A new Como Zoo has been created.");

                        break;

                    case "save":
                        ConsoleHelper.SaveFile(zoo, commandWords[1]);

                        break;

                    case "load":
                        ConsoleHelper.LoadFile(commandWords[1]);

                        break;

                    case "temp":
                        try
                        {
                            ConsoleHelper.SetTemperature(zoo, commandWords[1]);
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("A number must be submitted as a parameter in order to change the temperature.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("A parameter must be entered in order for the temperature command to work.");
                        }

                        break;

                    case "show":
                        try
                        {
                            switch (commandWords[1])
                            {
                                case "animal":
                                    ConsoleHelper.ProcessShowCommand(zoo, commandWords[1], commandWords[2]);

                                    break;

                                case "guest":
                                    ConsoleHelper.ProcessShowCommand(zoo, commandWords[1], commandWords[2]);

                                    break;

                                case "cage":
                                    ConsoleHelper.ProcessShowCommand(zoo, commandWords[1], commandWords[2]);

                                    break;

                                case "children":
                                    ConsoleHelper.ProcessShowCommand(zoo, commandWords[1], commandWords[2]);
                                    break;

                                default:
                                    Console.WriteLine("Only animals and guests can be written to the console.");
                                    break;
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("A parameter must be entered in order for the show command to initiate.");
                        }

                        break;

                    case "add":
                        try
                        {
                            ConsoleHelper.ProcessAddCommand(zoo, commandWords[1]);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("A parameter must be entered in order for the add command to initiate.");
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("The zoo may be out of tickets.");
                        }

                        break;

                    case "remove":
                        try
                        {
                            ConsoleHelper.ProcessRemoveCommand(zoo, commandWords[1], commandWords[2]);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("A parameter must be entered in order for the remove command to initiate.");
                        }

                        break;

                    case "sort":
                        try
                        {
                            SortResult sortResult = zoo.SortAnimals(commandWords[1], commandWords[2]);
                            Console.WriteLine("SORT TYPE: " + commandWords[1].ToUpper());
                            Console.WriteLine("SORT BY: " + commandWords[2].ToUpper());
                            Console.WriteLine("SWAP COUNT: " + sortResult.SwapCount);
                            Console.WriteLine("COMPARE COUNT: " + sortResult.CompareCount);
                            Console.WriteLine("TIME: " + sortResult.ElapsedMilliseconds);

                            foreach (Animal a in sortResult.Animals)
                            {
                                Console.WriteLine(a.ToString());
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Sort command must be entered as: sort [sort type] [sort by -- weight or name].");
                        }

                        break;

                    case "search":
                        try
                        {
                            if (commandWords[1] == "binary")
                            {
                                int i = 0;

                                string animalName = commandWords[2];

                                SortResult animals = zoo.SortAnimals("bubble", "name");

                                int minPosition = 0;
                                int maxPosition = animals.Animals.Count - 1;

                                while (minPosition <= maxPosition)
                                {
                                    // get middle position by adding min and max and then dividing by 2
                                    int midPosition = (minPosition + maxPosition) / 2;
                                    
                                    // increment loop counter
                                    i++;

                                    // use string.Compare to compare the animal name from the text box to the name of the animal at the middle position
                                    int compareResult = string.Compare(animalName, animals.Animals[midPosition].Name.ToLower());
                                                                        
                                    // if the compare result is greater than zero
                                    if (compareResult > 0)
                                    {
                                        minPosition = midPosition + 1;
                                    }
                                    else if (compareResult < 0)
                                    {
                                        maxPosition = midPosition - 1;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{animalName} found. {i} loops complete.");

                                        break;                                       
                                    }
                                                                                                            
                                    // then the animal is in the "upper" half of the list, so set the minPosition to one more than the middle position
                                    // else if the compare result is less than zero
                                    // then the animal is in the "lower" half of the list, so set the maxPosition to one less than the middle position
                                    // else 
                                    // the middle animal is the animal we're looking for, so show a message box saying the animal was found and how many loops were completed and then break
                                }
                            }
                            else if (commandWords[1] == "linear")
                            {
                                int i = 0;                              

                                string animalName = commandWords[2];

                                foreach (Animal a in zoo.Animals)
                                {
                                    i++;                                    

                                    if (animalName == a.Name.ToLower())
                                    {
                                        Console.WriteLine($"{animalName} found. {i} loops complete.");

                                        break;
                                    }                                                                     
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Search command must be entered as: search [sort type] [animal name].");
                        }

                        break;
                }
            }
        }
    }
}