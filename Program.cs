using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // missing_numbers list to store the missing numbers
                List<int> missing_numbers  = new List<int>();
                
                // Traverse from 1 to length of nums and check if the number is in the array
                for (int i = 1; i <= nums.Length; i++)
                {
                    if (Array.IndexOf(nums, i) == -1)
                    {
                        // If the number is not found, add it to the result list
                        missing_numbers.Add(i);
                    }
                }
                
                return missing_numbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // missing_numbers list to store the missing numbers
                List<int> sorted_array  = new List<int>();

                // First pass: Add all even numbers to the result list
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 == 0)
                    {
                        sorted_array.Add(nums[i]);
                    }
                }

                // Second pass: Add all odd numbers to the result list
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] % 2 != 0)
                    {
                        sorted_array.Add(nums[i]);
                    }
                }

                // Return the result list
                return sorted_array.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Dictionary to store the value and its corresponding index
                Dictionary<int, int> map = new Dictionary<int, int>();

                // Traverse the array
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];

                    // Check if the complement exists in the dictionary
                    if (map.ContainsKey(complement))
                    {
                        // If found, return the indices
                        return new int[] { map[complement], i };
                    }

                    // Otherwise, add the current number and its index to the dictionary
                    if (!map.ContainsKey(nums[i]))
                    {
                        map.Add(nums[i], i);
                    }
                }

                // Return an empty array if no solution is found (shouldn't happen with valid inputs)
                return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {

                List<int> MaximumProduct  = new List<int>();
                if (nums.Length < 3)
                {
                    return 0;
                }
                else if (nums.Length == 3)
                {
                    return (nums[0]*nums[1]*nums[2]);
                }
                else{
                    // Step 1: Sort the array
                    Array.Sort(nums);

                    int n = nums.Length;

                    // Compute the maximum product of:
                    // (1) The last three numbers in the sorted array
                    int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3];

                    // (2) The first two numbers (could be negative) and the last number (largest)
                    int product2 = nums[0] * nums[1] * nums[n - 1];

                    // Step 3: Return the maximum of these two products
                    return Math.Max(product1, product2);

                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // If the number is zero, return "0"
                if (decimalNumber == 0)
                {
                    return "0";
                }

                string binary = "";

                // Continue dividing the number by 2 and store the remainder
                while (decimalNumber > 0)
                {
                    int remainder = decimalNumber % 2;
                    binary = remainder + binary;  // Append remainder to the left
                    decimalNumber /= 2;
                }
                //Returning results
                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Here we are using binary search cause sorted array is rotaed to get result in O(log(n))
                int left = 0;
                int right = nums.Length - 1;

                // Binary search to find the minimum element
                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    // If mid element is greater than the rightmost element, minimum is on the right side
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    // Otherwise, the minimum is on the left side or could be the mid itself
                    else
                    {
                        right = mid;
                    }
                }

                // When the loop ends, left == right and points to the minimum element
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Negative numbers are not palindromes
                if (x < 0)
                {
                    return false;
                }

                // Initialize variables to store the reversed number and the original number
                int original = x;
                int reversed = 0;

                // Reverse the number
                while (x > 0)
                {
                    int digit = x % 10;           // Get the last digit
                    reversed = reversed * 10 + digit;  // Append the last digit to reversed number
                    x /= 10;                      // Remove the last digit from x
                }

                // If the reversed number is equal to the original, it's a palindrome
                return reversed == original;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Special cases for F(0) and F(1)
                if (n == 0) return 0;
                if (n == 1) return 1;

                // Initialize variables to store F(0) and F(1)
                int a = 0; // F(0)
                int b = 1; // F(1)
                int fib = 0;

                // Loop from 2 to n to calculate F(n)
                for (int i = 2; i <= n; i++)
                {
                    fib = a + b;  // Calculate the next Fibonacci number
                    a = b;        // Update a to the previous number
                    b = fib;      // Update b to the current Fibonacci number
                }

                return fib;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
