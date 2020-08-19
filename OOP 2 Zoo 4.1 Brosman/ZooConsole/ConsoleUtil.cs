using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Animals;
using People;
using Reproducers;
using Utilities;

namespace ZooConsole
{
    /// <summary>
    /// The class used to represent the console utility.
    /// </summary>
    internal static class ConsoleUtil
    {
        /// <summary>
        /// Capitalizes the first letter of the command.
        /// </summary>
        /// <param name="value">The command to be capitalized.</param>
        /// <returns>Returns the capitalized value.</returns>
        public static string InitialUpper(string value)
        {
            string initialUpper = null;

            if (value != null && value.Length > 0)
            {
                initialUpper = char.ToUpper(value[0]) + value.Substring(1);
            }

            return initialUpper;
        }

        /// <summary>
        /// Prompts the user for an alphabetic value (i.e. a value containing only letters and/or spaces).
        /// </summary>
        /// <param name="prompt">The input prompt.</param>
        /// <returns>Returns the alphabetic value.</returns>
        public static string ReadAlphabeticValue(string prompt)
        {
            string result = null;

            bool found = false;

            while (!found)
            {
                result = ConsoleUtil.ReadStringValue(prompt);

                if (Regex.IsMatch(result, @"^[a-zA-Z ]+$"))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine(prompt + " must contain only letters or spaces.");
                }
            }

            return result;
        }

        /// <summary>
        /// Prompts the user for an animal type value and attempts to convert it to an enumeration value.
        /// </summary>
        /// <returns>Returns the animal type.</returns>
        public static AnimalType ReadAnimalType()
        {
            AnimalType result = AnimalType.Dingo;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadAlphabeticValue("AnimalType");

                stringValue = ConsoleUtil.InitialUpper(stringValue);

                // If a matching enumerated value can be found...
                if (Enum.TryParse<AnimalType>(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine("Invalid animal type.");
                }
            }

            return result;
        }

        /// <summary>
        /// Prompts the user for a decimal value.
        /// </summary>
        /// <param name="prompt">The input prompt.</param>
        /// <returns>Returns the double value.</returns>
        public static decimal ReadDecimalValue(string prompt)
        {
            decimal result = 0;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadStringValue(prompt);

                if (decimal.TryParse(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine(prompt + " must be either a whole number or a decimal number.");
                }
            }

            return result;
        }

        /// <summary>
        /// Prompts the user for a double or decimal value.
        /// </summary>
        /// <param name="prompt">The input prompt.</param>
        /// <returns>Returns the double value.</returns>
        public static double ReadDoubleValue(string prompt)
        {
            double result = 0;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadStringValue(prompt);

                if (double.TryParse(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine(prompt + " must be either a whole number or a decimal number.");
                }
            }

            return result;
        }

        /// <summary>
        /// Prompts the user for a gender value and attempts to convert it to an enumeration value.
        /// </summary>
        /// <returns>Returns the gender.</returns>
        public static Gender ReadGender()
        {
            Gender result = Gender.Female;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadAlphabeticValue("Gender");

                stringValue = ConsoleUtil.InitialUpper(stringValue);

                // If a matching enumerated value can be found...
                if (Enum.TryParse<Gender>(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine("Invalid gender.");
                }
            }

            return result;
        }

        /// <summary>
        /// Prompts the user for an integer value.
        /// </summary>
        /// <param name="prompt">The input prompt.</param>
        /// <returns>Returns the integer value.</returns>
        public static int ReadIntValue(string prompt)
        {
            int result = 0;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadStringValue(prompt);

                if (int.TryParse(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine(prompt + " must be a whole number.");
                }
            }

            return result;
        }

        /// <summary>
        /// Prompts the user for a value and ensures that the value exists.
        /// </summary>
        /// <param name="prompt">The input prompt.</param>
        /// <returns>Returns the string value.</returns>
        public static string ReadStringValue(string prompt)
        {
            string result = null;

            bool found = false;

            while (!found)
            {
                Console.Write(prompt + "] ");

                string stringValue = Console.ReadLine().ToLower().Trim();

                Console.WriteLine();

                if (stringValue != string.Empty)
                {
                    result = stringValue;

                    found = true;
                }
                else
                {
                    Console.WriteLine(prompt + " must have a value.");
                }
            }

            return result;
        }

        /// <summary>
        /// Prompts the user for a wallet color value and attempts to convert it to an enumeration value.
        /// </summary>
        /// <returns>Returns the wallet color.</returns>
        public static WalletColor ReadWalletColor()
        {
            WalletColor result = WalletColor.Brown;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadAlphabeticValue("WalletColor");

                stringValue = ConsoleUtil.InitialUpper(stringValue);

                // If a matching enumerated value can be found...
                if (Enum.TryParse<WalletColor>(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine("Invalid wallet color.");
                }
            }

            return result;
        }

        /// <summary>
        /// Write help details.
        /// </summary>
        /// <param name="command">The command passed in.</param>
        /// <param name="overview">The details of the command.</param>
        /// <param name="arguments">The arguments from the dictionary.</param>
        public static void WriteHelpDetail(string command, string overview, Dictionary<string, string> arguments)
        {            
            // Displays the command.
            Console.WriteLine($"Command Name: {command}");

            // Displays the description of the command.
            Console.WriteLine($"Overview: {overview}");

            // Get the keys of the arguments dictionary.
            string argumentsKeys = ListUtil.Flatten(arguments.Keys, " ");

            // Display the usage of the command.
            Console.Write($"Usage: {command} {argumentsKeys}");

            Console.WriteLine("\n" + "Parameters: ");

            foreach (KeyValuePair<string, string> kvp in arguments)
            {                
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");                
            }
        }

        /// <summary>
        /// The details for the help inquiry.
        /// </summary>
        /// <param name="command">The command word to seek help on.</param>
        /// <param name="overview">A description of the command word's function.</param>
        /// <param name="argument">The arguments for the command word.</param>
        /// <param name="argumentUsage">The usage fir the command word.</param>
        public static void WriteHelpDetail(string command, string overview, string argument, string argumentUsage)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add(argument, argumentUsage);
            WriteHelpDetail(command, overview, dictionary);
        }

        /// <summary>
        /// The details for the command needed help on.
        /// </summary>
        /// <param name="command">The command to seek help on.</param>
        /// <param name="overview">The description of the command.</param>
        public static void WriteHelpDetail(string command, string overview)
        {
            WriteHelpDetail(command, overview, null);
        }
    }
}
