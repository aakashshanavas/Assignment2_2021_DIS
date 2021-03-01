using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2_DIS_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] ar1 = { 2, 5, 1, 3, 4, 7,8 ,10 };
            int n1 = ar1.Length;
            if (n1 % 2 != 0)//Handling corner case
            {
                Console.WriteLine("Count of numbers in array should be multiple of 2");
                goto Question2;
            }
            ShuffleArray(ar1, n1);
            Question2: Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            //int[] ar2 = { 0, 1, 0, 3, 12 };
            int[] ar2 = { 1, 9, 8, 4, 0, 0, 2, 7, 0, 6, 0, 9 };
            MoveZeroes(ar2);
            Console.WriteLine();

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            //int[] ar3 = { 1,1 };
            CoolPairs(ar3);
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
                int[] ar4 = { 2, 7, 11, 15 };
                int target = 9;
            TwoSum(ar4, target);
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Question 5");
            string s5 = "korfsucy";
            int[] indices = { 6, 4, 3, 2, 1, 0, 5, 7 };
            if (s5.Length != indices.Length)//Handling corner case
            {
                Console.WriteLine("We are unable to map as number of characters in string are different from number of digits in array");
                goto Question6;
            }
            RestoreString(s5, indices);
            Question6: Console.WriteLine();

        //Question 6
            Console.WriteLine("Question 6");
            string s61 = "maxc";
            string s62 = "uvtw";
            if (s61.Length != s62.Length)//Handling corner case
            {
                Console.WriteLine("not isomorphic as lengths of strings are varying");
                goto Question7;
            }
            if (Isomorphic(s61, s62))
            {
                Console.WriteLine("Yes the two strings are Isomorphic");
            }
            else
            {
                Console.WriteLine("No, the given strings are not Isomorphic");
            }
            Question7:  Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int n8 = 1881;
            if (n8 < 1)//Handling corner case
            {
                Console.WriteLine("A number less than 1 cannot be a happy number");
                goto Question9;
            }
            if (HappyNumber(n8))
            {
                Console.WriteLine("{0} is a happy number", n8);
            }
            else
            {
                Console.WriteLine("{0} is not a happy number", n8);
            }

            Question9:  Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            //int[] ar9 = { 7, 6, 4, 3, 1 };
            int[] ar9 = { 78,92,162,153 };
            int profit = Stocks(ar9);
            if (profit == 0)
            {
                Console.WriteLine("No Profit is possible");
            }
            else
            {
                Console.WriteLine("Profit is {0}", profit);
            }
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int n10 = 8;
            if (n10 <= 0)//Handling corner case
            {
                Console.WriteLine("Stairs cannot be zero or negative");
                goto skpiThis;
            }
            Stairs(n10);
            skpiThis:  Console.WriteLine();
        }



        //Question 1
        /// <summary>
        /// Shuffle the input array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
        /// Print the array in the form[x1, y1, x2, y2, ..., xn, yn].
        ///Example 1:
        ///Input: nums = [2,5,1,3,4,7], n = 3
        ///Output: [2,3,5,4,1,7]
        ///  Explanation: Since x1 = 2, x2 = 5, x3 = 1, y1 = 3, y2 = 4, y3 = 7 then the answer is [2,3,5,4,1,7].
        ///Example 2:
        ///Input: nums = [1,2,3,4,4,3,2,1], n = 4
        ///Output: [1,4,2,3,3,2,4,1]
        ///Example 3:
        ///Input: nums = [1,1,2,2], n = 2
        ///Output: [1,2,1,2]
        /// </summary>
        private static void ShuffleArray(int[] nums, int n)
        {
            try
            {   
                int[] numsnew = new int[n]; //Initializing a new array to store final result
                for (int i = 0; i < n / 2; i++) //Taking limit less than n/2 as we can shuffle original array into new array in 3 iterations because we are putting 2 elements in one iteration into new array
                {
                    numsnew[2 * i] = nums[i]; //Stores first half of the elements in original array to new array in even index
                    numsnew[2 * i + 1] = nums[(n / 2) + i]; //Stores second half of the elements in original array to new array in odd index
                }

                Console.Write("[");
                foreach (var item in numsnew)//Printing every elemts of new array
                {
                    Console.Write(item + " ");
                }
                Console.Write("]");
                Console.WriteLine();

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 2:
        /// <summary>
        /// Write a method to move all 0's to the end of the given array. You should maintain the relative order of the non-zero elements. 
        /// You must do this in-place without making a copy of the array.
        /// Example:
        ///Input: [0,1,0,3,12]
        /// Output: [1,3,12,0,0]
        /// </summary>

        private static void MoveZeroes(int[] ar2)
        {
            try
            {
                int n = ar2.Length;
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    if (ar2[i] != 0)
                    {
                        ar2[count] = ar2[i]; //If elements is not zero we print those elements one after other in the same array so that we get continuos non zero elements
                        count++;
                    }

                }
                while (count < n)//Once all nonzero elements are print at the start, we print the remaining array indexes with zero until we get array having original size
                {
                    ar2[count++] = 0;
                }
                Console.Write("[");
                foreach (var item in ar2)
                {
                    Console.Write(item + " ");
                }
                Console.Write("]");
                Console.WriteLine();

            }
            catch (Exception)
            {

                throw;
            }
        }


        //Question 3
        /// <summary>
        /// For an array of integers - nums
        ///A pair(i, j) is called cool if nums[i] == nums[j] and i<j
        ///Print the number of cool pairs
        ///Example 1
        ///Input: nums = [1,2,3,1,1,3]
        ///Output: 4
        ///Explanation: There are 4 cool pairs (0,3), (0,4), (3,4), (2,5) 
        ///Example 3:
        ///Input: nums = [1, 2, 3]
        ///Output: 0
        ///Constraints: time complexity should be O(n).
        /// </summary>

        private static void CoolPairs(int[] nums)
        {
            try
            {
                int ArrLength = nums.Length;
                Dictionary<int, int> Numbers = new Dictionary<int, int>();//Initializing a dictionary to store element and the no of times it repeats
                for (int i = 0; i < ArrLength; i++)
                {
                    int count = nums.Count(s => s == nums[i]);// Finding the number of times a number in the array repeats
                    if (!Numbers.ContainsKey(nums[i]))
                    {
                        Numbers.Add(nums[i], count);// Adding the number as key and the number of times it repeats as value
                    }
                }
                var counts = Numbers.Values;// Assigning another distionary only the counts of each number from disctionary numbers
                int sum = 0, output;
                foreach (var val in counts)
                {
                    output = val * (val - 1) / 2; //Formula based on how many times a particular number repeats
                    sum = sum + output;
                }
                Console.WriteLine(sum);

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 4:
        /// <summary>
        /// Given integer target and an array of integers, print indices of the two 
        /// numbers such that they add up to the target.
        ///You may assume that each input would have exactly one solution, and you 
        ///may not use the same element twice.
        /// You can print the answer in any order
        ///Example 1:
        ///Input: nums = [2,7,11,15], target = 9
        /// Output: [0,1]
        ///Output: Because nums[0] + nums[1] == 9, we print [0, 1].
        ///Example 2:
        ///Input: nums = [3,2,4], target = 6
        ///Output: [1,2]
        ///Example 3:
        ///Input: nums = [3,3], target = 6
        ///Output: [0,1]
        ///Constraints: Time complexity should be O(n)
        /// </summary>
        private static void TwoSum(int[] nums, int target)
        {
            try
            {
                int ArrLength = nums.Length;
                for (int i = 0; i < ArrLength; i++)
                {

                    int diff = target - nums[i];//Difference is calculated as we can find the other number in the pair which add to the target
                    if (Array.Exists(nums, element => element == diff)) //Checking if the other number in pair exists in the array
                    {

                        int SecondNoindex = Array.LastIndexOf(nums, diff);//Finding the index value of second number in the pair. Use LastIndexOf instead of IndexOf so that we can handle corner case such as [3,3], or else it will take index vallue of first three for second number of the pair which is incorrect
                        if (diff == nums[i] && SecondNoindex != i) // Handling corner case of [3,3]
                        {
                            Console.WriteLine("{0} {1}", i, SecondNoindex);
                            i = ArrLength;
                        }
                        else if (SecondNoindex != i) // This is for numbers which are not same in the pair eg 2 , 7 to form raget 9
                        {
                            Console.WriteLine("{0} {1}", i, SecondNoindex);
                            i = ArrLength;
                        }
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        //Question 5:
        /// <summary>
        /// Given a string s and an integer array indices of the same length.
        ///The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        ///Print the shuffled string.
        ///Example 1
        ///Input: s = "korfsucy", indices = [6,4,3,2,1,0,5,7]
        ///Output: "usfrocky"
        ///Explanation: As shown in the assignment document, “K” should be at index 6, “O” should be at index 4 and so on. “korfsucy” becomes “usfrocky”
        ///Example 2:
        ///Input: s = "USF", indices = [0,1,2]
        ///Output: "USF"
        ///Explanation: After shuffling, each character remains in its position.
        ///Example 3:
        ///Input: s = "ockry", indices = [1, 2, 3, 0, 4]
        ///Output: "rocky"
        /// </summary>
        private static void RestoreString(string s, int[] indices)
        {
            try
            {
                int ArrLength = indices.Length;
                char[] alphastring = new char[ArrLength];//creating a character array to store reaaranged value of string
                int temp = 0;
                for (int i = 0; i < ArrLength; i++)
                {
                    temp = indices[i]; // Taking values from number array indices and storing it in "temp"
                    char RearrangedAlphabet = s[i]; //Taking each value from string s and storing it in character variable "RearrangedAlphabet"
                    alphastring[temp] = RearrangedAlphabet; //Finally we put the character as per it corresponding index in the number array indices into the new array alphastring
                }
                for (int i = 0; i < ArrLength; i++)
                    Console.Write(alphastring[i]);
                Console.WriteLine();

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 6
        /// <summary>
        /// Determine whether two give strings s1 and s2, are isomorphic.
        ///Two strings are isomorphic if the characters in s1 can be replaced to get s2.
        ///All occurrences of a character must be replaced with another character while preserving the order of characters.
        ///No two characters may map to the same character but a character may map to itself.
        ///Example 1:
        ///Input:s1 = “bulls” s2 = “sunny” 
        ///Output : True
        ///Explanation: ‘b’ can be replaced with ‘s’ and similarly ‘u’ with ‘u’, ‘l’ with ‘n’ and ‘s’ with ‘y’.
        ///Example 2:
        ///Input: s1 = “usf” s2 = “add”
        ///Output : False
        ///Explanation: ‘u’ can be replaced with ‘a’, but ‘s’ and ‘f’ should be replaced with ‘d’ to produce s2, which is not possible. So False.
        ///Example 3:
        ///Input : s1 = “ab” s2 = “aa”
        ///Output: False
        /// </summary>
        private static bool Isomorphic(string s1, string s2)
        {
            try
            {
                Dictionary<char, char> Alphabets = new Dictionary<char, char>();
              
                for (int i = 0; i < s1.Length; i++)
                {
                    if (!Alphabets.ContainsKey(s2[i])) //checking to see whether charactter in s2 is taken as key in previous iterations
                    {
                        Alphabets.Add(s2[i], s1[i]); // Characters in s2 are stored as key, while character in s1 are stored as value
                        
                    }
                    else
                    {
                        if (Alphabets[s2[i]] == s1[i]) //for character in s2 that have already come as key before, its associated value is checked, so that 
                        {
                            
                            continue; 
                        }
                        else
                            return false; //if new value for same key comes it returns false
                    }
                }
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        private static void HighFive(int[,] items)
        {
            try
            {
                List<int> elementList = new List<int>();
                Dictionary<int, List<int>> MaxOfFiveDict = new Dictionary<int, List<int>>(); //Initializing a list to be used later unique key(ids) in int format and cirresponding scores to particular id in list     
                for (int i = 0; i < items.GetLength(0); i++) // We will iterate through the given user array
                {
                    if (MaxOfFiveDict.ContainsKey(items[i, 0]))//Initially check if key that is student id is present 
                    {
                        MaxOfFiveDict[items[i, 0]].Add(items[i, 1]);
                    }
                    else //If not present it will add the new id followed by its corresponding values to the Dictionary
                    {
                        MaxOfFiveDict.Add(items[i, 0], new List<int>()); //Always keep adding only the first column that is student ids
                        MaxOfFiveDict[items[i, 0]].Add(items[i, 1]);
                    }
                }
                for (int i = 0; i < MaxOfFiveDict.Count(); i++)
                {

                    MaxOfFiveDict.ElementAt(i).Value.Sort(); //Using inbuilt sorting 
                    MaxOfFiveDict.ElementAt(i).Value.Reverse(); //Since it sorts in ascemding order and we have to find the first five maximum we reverse the elements so that we get them in descending order
                    var MaxFive = MaxOfFiveDict.ElementAt(i).Value.Take(5); //We will take first five largest elemts
                    if (i == 0)
                    {
                        Console.Write("[");
                        Console.Write("[{0},{1}],", MaxOfFiveDict.ElementAt(i).Key, Convert.ToInt32(MaxFive.Average())); // Printing the id followed by its average
                        Console.WriteLine();
                    }
                    else if (i != MaxOfFiveDict.Count - 1)
                    {
                        Console.Write("[{0},{1}],", MaxOfFiveDict.ElementAt(i).Key, Convert.ToInt32(MaxFive.Average()));
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write("[{0},{1}]", MaxOfFiveDict.ElementAt(i).Key, Convert.ToInt32(MaxFive.Average()));
                        Console.Write("]");
                        Console.WriteLine();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 8
        /// <summary>
        /// Write an algorithm to determine if a number n is happy.
        ///A happy number is a number defined by the following process:
        ///•	Starting with any positive integer, replace the number by the sum of the squares of its digits.
        ///•	Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        ///•	Those numbers for which this process ends in 1 are happy.
        ///Return true if n is a happy number, and false if not.
        ///Example 1:
        ///Input: n = 19
        ///Output: true
        ///Explanation:
        ///12 + 92 = 82
        ///82 + 22 = 68
        ///62 + 82 = 100
        ///12 + 02 + 02 = 1
        ///Example 2:
        ///Input: n = 2
        ///Output: false
        ///Constraints:
        ///1 <= n <= 231 - 1
        /// </summary>

        private static bool HappyNumber(int n)
        {
            try
            {
                int temp = 0;
                int sum = n; 
                for (int i = 0; i < 10000; i++)
                {
                    if (sum == 1 || sum / 10 == 0) //This condition requires sum to be initialized as n initially
                        break; //break id the sum is one(ie sum is Happy number) or break if any other single digit number
                    n = sum;
                    sum = 0;
                    for (int j = 0; j < 10000; j++)
                    {
                        temp = n % 10; //Used to get units place every time
                        sum = sum + temp * temp;
                        n = n / 10; 
                        if (n == 0) // Break if sum comes to be a single digit number
                            break;
                    }

                }
                if (sum == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 9
        /// <summary>
        /// Professor Manish is planning to invest in stocks. He has the data of the price of a stock for the next n days.  
        /// Tell him the maximum profit he can earn from the given stock prices.Choose a single day to buy a stock and choose another day in the future to sell the stock for a profit
        /// If you cannot achieve any profit return 0.
        /// Example 1:
        /// Input: prices = [7,1,5,3,6,4]
        /// Output: 5
        /// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        /// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
        /// Example 2:
        /// Input: prices = [7,6,4,3,1]
        /// Output: 0
        ///Explanation: In this case, no transactions are done and the max profit = 0.
        ///Try to solve it in O(n) time complexity.
        /// </summary>

        private static int Stocks(int[] prices)
        {
            try
            {
                int n = prices.Length;
                int profit, temp = 0, MaxProfit = 0;

                for (int i = 0; i < n - 1; i++)
                {
                    profit = prices[i + 1] - prices[i];
                    if (prices[i + 1] > prices[i])
                    {
                        temp = prices[i]; //This block contains code for exchanging two values if value at lower index postion is less than vakue at higher index position. This is done to take the smallest elemntto to end of the array
                        prices[i] = prices[i + 1];
                        prices[i + 1] = temp;
                    }
                    if (profit > MaxProfit)
                    {
                        MaxProfit = profit; //Profit is stored in maximum profit only if it is greater than the profit calculated in previous iteration
                    }
                    if (MaxProfit <= 0 && i == n - 2) // i == n-2 because we want the value of maximum profit after all iteration are complete
                    {
                        MaxProfit = 0;
                    }
                }
                return MaxProfit;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 10
        /// <summary>
        /// Professor Clinton is climbing the stairs in the Muma College of Business. He generally takes one or two steps at a time.
        /// One day he came across an idea and wanted to find the total number of unique ways that he can climb the stairs. Help Professor Clinton.
        /// Print the number of unique ways. 
        /// Example 1:
        ///Input: n = 2
        ///Output: 2
        ///Explanation: There are two ways to climb to the top.
        ///1. 1 step + 1 step
        ///2. 2 steps
        ///Example 2:
        ///Input: n = 3
        ///Output: 3
        ///Explanation: There are three ways to climb to the top.
        ///1. 1 step + 1 step + 1 step
        ///2. 1 step + 2 steps
        ///3. 2 steps + 1 step
        ///Hint : Use the concept of Fibonacci series.
        /// </summary>

        private static void Stairs(int steps)
        {
            try
            {
                int firstno = 2, secondno = 3, sum = 0; // Assigning static values if 2 or 3 steps present
                if (steps == 1) //Assigning predefined value if 2 steps are present
                {
                    Console.WriteLine("1");
                }
                if (steps == 2) //Assigning predefined value if 2 steps are present
                {
                    Console.WriteLine(firstno);
                }
                else if (steps == 3) //Assigning predefined value if 3 steps are present
                {
                    Console.WriteLine(secondno);
                }
                else if (steps >3)
                {
                    for(int i = 3; i< steps; i++)// Starting from 3 as two answers for step 2 and 3 predefined
                    {
                        sum = firstno + secondno; //fibonacci series logic
                        firstno = secondno; 
                        secondno = sum;
                    }
                    Console.WriteLine(sum);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
