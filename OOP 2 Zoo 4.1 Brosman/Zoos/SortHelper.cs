using System.Collections.Generic;
using System.Diagnostics;
using Animals;

namespace Zoos
{
    /// <summary>
    /// Represents the Sort Helper Class.
    /// </summary>
    public static class SortHelper
    {
        /// <summary>
        /// Bubble sorts the animal by weight.
        /// </summary>
        /// <param name="animals">The animals in the list.</param>
        /// <returns>Returns the bubble sort result.</returns>
        public static SortResult BubbleSortByWeight(List<Animal> animals)
        {
            SortResult sortResult = null;

            // initialize a swap counter variable.
            int swapCounter = 0;

            // initializes a compare counter variable.
            int compareCounter = 0;

            // initializes a stopwatch variable.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // use a for loop to loop backward through the list.
            // e.g. initialize the loop variable to one less than the length of the list and decrement the variable instead of increment.
            for (int i = animals.Count - 1; i > 0; i--)
            {
                // loop forward as long as the loop variable is less than the outer loop variable.
                for (int j = 0; j < i; j++)
                {
                    // Tracks how many times the animals are compared.
                    compareCounter++;

                    // if the weight of the current animal is more than the weight of the next animal, swap the two animals and increment the swap count.
                    if (animals[j].Weight > animals[j + 1].Weight)
                    {
                        Swap(animals, j, j + 1);
                        swapCounter++;                        
                    }
                }
            }

            // Stops the stopwatch.
            stopwatch.Stop();

            // return the SortResult.
            return sortResult = new SortResult { SwapCount = swapCounter, Animals = animals, CompareCount = compareCounter, ElapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds };
        }

        /// <summary>
        /// Bubble sorts the animal by name.
        /// </summary>
        /// <param name="animals">The animals in the list.</param>
        /// <returns>Returns the bubble sort result.</returns>
        public static SortResult BubbleSortByName(List<Animal> animals)
        {
            SortResult sortResult = null;

            // initialize a swap counter variable.
            int swapCounter = 0;

            // initializes a compare counter variable.
            int compareCounter = 0;

            // initializes a stopwatch variable.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // use a for loop to loop backward through the list.
            // e.g. initialize the loop variable to one less than the length of the list and decrement the variable instead of increment.
            for (int i = animals.Count - 1; i > 0; i--)
            {
                // loop forward as long as the loop variable is less than the outer loop variable.
                for (int j = 0; j < i; j++)
                {
                    // Tracks how many times the animals are compared.
                    compareCounter++;

                    // if the name of the current animal is more than the name of the next animal, swap the two animals and increment the swap count. If the first string is less than the second, a negative number is returned.  If the first string is greater, a positive number is returned.  If the strings are equal, the return value is zero.
                    int compareResult = string.Compare(animals[j].ToString(), animals[j + 1].ToString());

                    if (compareResult == 1)
                    {
                        Swap(animals, j, j + 1);
                        swapCounter++;
                    }
                }
            }

            // Stops the stopwatch.
            stopwatch.Stop();

            // return the SortResult
            return sortResult = new SortResult { SwapCount = swapCounter, Animals = animals, CompareCount = compareCounter, ElapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds };
        }

        /// <summary>
        /// Selection sorts the animal by weight.
        /// </summary>
        /// <param name="animals">The animals in the list.</param>
        /// <returns>Returns the selection sort result.</returns>
        public static SortResult SelectionSortByWeight(List<Animal> animals)
        {
            SortResult sortResult = null;

            // initialize a swap counter variable.
            int swapCounter = 0;

            // initializes a compare counter variable.
            int compareCounter = 0;

            // initializes a stopwatch variable.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // loop forward through the list.
            for (int i = 0; i < animals.Count - 1; i++)
            {
                // declare a variable to hold the animal with the current minimum weight.
                Animal minWeightAnimal;

                // set the variable to the current animal.
                minWeightAnimal = animals[i];

                // loop through the remaining animals in the list to find the animal with the lowest weight.
                for (int j = i + 1; j < animals.Count; j++)
                {
                    // Tracks how many times the animals are compared.
                    compareCounter++;

                    // if the weight of the current animal is less than the weight of the animal with the minimum weight, set the variable holding the animal with the current minimum weight to the current animal.
                    if (animals[j].Weight < minWeightAnimal.Weight)
                    {
                        minWeightAnimal = animals[j];                        
                    }                    
                }
                
                ////after finding the animal with the lowest weight
                //// if the current animal's weight does not equal the weight of the animal with current minimum weight, 
                ////swap the two animals and increment the swap count
                if (animals[i].Weight != minWeightAnimal.Weight)
                {
                    Swap(animals, i, animals.IndexOf(minWeightAnimal));
                    swapCounter++;
                }
            }

            // Stops the stopwatch.
            stopwatch.Stop();

            // return the SortResult
            return sortResult = new SortResult { SwapCount = swapCounter, Animals = animals, CompareCount = compareCounter, ElapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds };
        }

        /// <summary>
        /// Selection sorts the animal by name.
        /// </summary>
        /// <param name="animals">The animals in the list.</param>
        /// <returns>Returns the selection sort result.</returns>
        public static SortResult SelectionSortByName(List<Animal> animals)
        {
            SortResult sortResult = null;

            // initialize a swap counter variable.
            int swapCounter = 0;

            // initializes a compare counter variable.
            int compareCounter = 0;

            // initializes a stopwatch variable.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // loop forward through the list.
            for (int i = 0; i < animals.Count - 1; i++)
            {
                // declare a variable to hold the animal with the first name on the list.
                Animal firstAnimalName;

                // set the variable to the current animal.
                firstAnimalName = animals[i];

                // loop through the remaining animals in the list to find the animal that should be near the alphabetical top.
                for (int j = i + 1; j < animals.Count; j++)
                {
                    // Tracks how many times the animals are compared.
                    compareCounter++;

                    // if the name of the current animal is less than the name of the animal with the higher alphabetical standing, 
                    // set the variable holding the animal with the current highest standing to the new current animal.
                    if (animals[j].Name.CompareTo(firstAnimalName.Name) < 0)
                    {
                        firstAnimalName = animals[j];
                    }
                }

                ////after finding the animal with the highest alphabetical standing,
                //// if the current animal's name does not equal the name of the animal with current name highest on the list, 
                ////swap the two animals and increment the swap count
                if (animals[i].Name != firstAnimalName.Name)
                {
                    Swap(animals, i, animals.IndexOf(firstAnimalName));
                    swapCounter++;
                }
            }

            // Stops the stopwatch.
            stopwatch.Stop();

            // return the SortResult
            return sortResult = new SortResult { SwapCount = swapCounter, Animals = animals, CompareCount = compareCounter, ElapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds };
        }

        /// <summary>
        /// Insertion sorts the animal by weight.
        /// </summary>
        /// <param name="animals">The animals in the list.</param>
        /// <returns>Returns the insertion sort result.</returns>
        public static SortResult InsertionSortByWeight(List<Animal> animals)
        {
            SortResult sortResult = null;

            // initialize a swap counter variable
            int swapCounter = 0;

            // initializes a compare counter variable.
            int compareCounter = 0;

            // initializes a stopwatch variable.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // loop forward through the list
            for (int i = 1; i < animals.Count; i++)
            {
                // Tracks how many times the animals are compared.
                compareCounter++;

                for (int j = i; j > 0; j--)
                {                   
                    if (animals[j - 1].Weight > animals[j].Weight)
                    {
                        // swap the current animal with the previous animal and increment the swap count
                        Swap(animals, j, j - 1);
                        swapCounter++;
                    }
                }
            }

            // Stops the stopwatch.
            stopwatch.Stop();

            // return the SortResult
            return sortResult = new SortResult { SwapCount = swapCounter, Animals = animals, CompareCount = compareCounter, ElapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds };
        }

        /// <summary>
        /// Insertion sorts the animal by name.
        /// </summary>
        /// <param name="animals">The animals in the list.</param>
        /// <returns>Returns the insertion sort result.</returns>
        public static SortResult InsertionSortByName(List<Animal> animals)
        {
            SortResult sortResult = null;

            // initialize a swap counter variable
            int swapCounter = 0;

            // initializes a compare counter variable.
            int compareCounter = 0;

            // initializes a stopwatch variable.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // loop forward through the list
            for (int i = 1; i < animals.Count; i++)
            {
                // Tracks how many times the animals are compared.
                compareCounter++;

                for (int j = i; j > 0; j--)
                {
                    if (animals[j].Name.CompareTo(animals[j - 1].Name) < 0)
                    {
                        // swap the current animal with the previous animal and increment the swap count
                        Swap(animals, j, j - 1);
                        swapCounter++;
                    }
                }
            }

            // Stops the stopwatch.
            stopwatch.Stop();

            // return the SortResult
            return sortResult = new SortResult { SwapCount = swapCounter, Animals = animals, CompareCount = compareCounter, ElapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds };
        }

        /// <summary>
        /// Quick sorts the animals by weight.
        /// </summary>
        /// <param name="animals">The list of animals to sort.</param>
        /// <param name="leftIndex">The left index number.</param>
        /// <param name="rightIndex">The right index number.</param>
        /// <param name="sortResult">The resulting sort.</param>
        /// <returns>The sort result.</returns>
        public static SortResult QuickSortByWeight(List<Animal> animals, int leftIndex, int rightIndex, SortResult sortResult)
        {
            //// initialize a swap counter variable
            ////int swapCounter = 0;

            //// initializes a compare counter variable.
            ////int compareCounter = 0;

            // define variables to keep track of the left and right points in the list
            // initialize them to the passed-in indexes
            int leftPointer = leftIndex;
            int rightPointer = rightIndex;

            // find the animal to pivot on (the middle animal in this case)
            Animal pivotAnimal = animals[(leftIndex + rightIndex) / 2];

            // define and initialize a loop variable
            bool done = false;

            // start looping
            while (!done)
            {
                // while the weight of the animal at the left pointer spot in the list is less than the pivot animal's weight
                // increment the left pointer
                // increment the sort result's compare count
                while (animals[leftPointer].Weight < pivotAnimal.Weight)
                {
                    leftPointer++;
                    sortResult.CompareCount++;
                }

                // while the pivot animal's weight is less than the weight of the animal at the right pointer spot in the list
                // decrement the right pointer
                // increment the sort result's compare count
                while (pivotAnimal.Weight < animals[rightPointer].Weight)
                {
                    rightPointer--;
                    sortResult.CompareCount++;
                }

                //// if the left pointer is less than or equal to the right pointer
                //// swap the animals at the left pointer and right pointer spots
                //// increment the sort result's swap count
                //// then increment the left pointer and decrement the right pointer

                if (leftPointer <= rightPointer)
                {
                    Swap(animals, leftPointer, rightPointer);
                    sortResult.SwapCount++;
                    leftPointer++;
                    rightPointer--;
                }

                // if the left pointer is greater than the right pointer,
                // stop the outer while loop
                if (leftPointer > rightPointer)
                {
                    done = true;
                }
            }

            // if the left index is less than the right pointer
            // use recursion to sort the animals within the left index and right pointer
            if (leftIndex < rightPointer)
            {
                // method call here
                QuickSortByWeight(animals, leftIndex, rightPointer, sortResult);                
            }

            // if the left pointer is less than the right index
            // use recursion to sort the animals within the left pointer and right index
            if (leftPointer < rightIndex)
            {
                // method call here
                QuickSortByWeight(animals, leftPointer, rightIndex, sortResult);
            }

            // Set the animals parameter to the SortResult's Animals property before returning the SortResult variable.
            sortResult.Animals = animals;
                    
            // return the SortResult
            return sortResult;
        }

        /// <summary>
        /// Quick sorts the animals by name.
        /// </summary>
        /// <param name="animals">The list of animals to sort.</param>
        /// <param name="leftIndex">The left index number.</param>
        /// <param name="rightIndex">The right index number.</param>
        /// <param name="sortResult">The resulting sort. </param>
        /// <returns>The sort result.</returns>
        public static SortResult QuickSortByName(List<Animal> animals, int leftIndex, int rightIndex, SortResult sortResult)
        {
            // define variables to keep track of the left and right points in the list
            // initialize them to the passed-in indexes
            int leftPointer = leftIndex;
            int rightPointer = rightIndex;

            // find the animal to pivot on (the middle animal in this case)
            Animal pivotAnimal = animals[(leftIndex + rightIndex) / 2];

            // define and initialize a loop variable
            bool done = false;

            // start looping
            while (!done)
            {
                // while the name of the animal at the left pointer spot in the list is not equal to the pivot animal's name
                // increment the left pointer
                // increment the sort result's compare count
                while (animals[leftPointer].Name.CompareTo(pivotAnimal.Name) < 0)
                {
                    leftPointer++;
                    sortResult.CompareCount++;
                }

                //// while the pivot animal's name is less than the name of the animal at the right pointer spot in the list
                //// decrement the right pointer
                //// increment the sort result's compare count
                while (pivotAnimal.Name.CompareTo(animals[rightPointer].Name) < 0)
                {
                    rightPointer--;
                    sortResult.CompareCount++;
                }

                //// if the left pointer is less than or equal to the right pointer
                //// swap the animals at the left pointer and right pointer spots
                //// increment the sort result's swap count
                //// then increment the left pointer and decrement the right pointer

                if (leftPointer <= rightPointer)
                {
                    Swap(animals, leftPointer, rightPointer);
                    sortResult.SwapCount++;
                    leftPointer++;
                    rightPointer--;
                }

                //// if the left pointer is greater than the right pointer,
                //// stop the outer while loop
                if (leftPointer > rightPointer)
                {
                    done = true;
                }
            }

            // if the left index is less than the right pointer
            // use recursion to sort the animals within the left index and right pointer
            if (leftIndex < rightPointer)
            {
                // method call here
                QuickSortByName(animals, leftIndex, rightPointer, sortResult);
            }

            // if the left pointer is less than the right index
            // use recursion to sort the animals within the left pointer and right index
            if (leftPointer < rightIndex)
            {
                // method call here
                QuickSortByName(animals, leftPointer, rightIndex, sortResult);
            }

            // Set the animals parameter to the SortResult's Animals property before returning the SortResult variable.
            sortResult.Animals = animals;

            // return the SortResult
            return sortResult;
        }
        
        /// <summary>
        /// Swaps the animals using a tempAnimal variable.
        /// </summary>
        /// <param name="animals">The animals to be swapped from the animals array.</param>
        /// <param name="index1">An animal in the index1 position of the array.</param>
        /// <param name="index2">An animal in the index2 position of the array.</param>
        private static void Swap(List<Animal> animals, int index1, int index2)
        {
            Animal tempAnimal = null;

                tempAnimal = animals[index1];

                animals[index1] = animals[index2];

                animals[index2] = tempAnimal;            
        }
    }
}