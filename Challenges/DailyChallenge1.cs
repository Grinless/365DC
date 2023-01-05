using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Challenge
{
    //Given an array nums of size n, return the majority element.
    //The majority element is the element that appears more than ⌊n / 2⌋ times.You may assume that the majority element always exists in the array.
    //--Example 1:--
    //Input: nums = [3, 2, 3]
    //Output: 3
    //--Example 2:--
    //Input: nums = [2, 2, 1, 1, 1, 2, 2]
    //Output: 2
    //-- Constraints: --
    //•  n == nums.length
    //•  1 <= n <= 5 * 10^4
    //•  -10^9 <= nums[i] <= 10^9
    //Extra: Solve the problem in linear time and in O(1) space

    public class DC1_ArrayData
    {
        private DC1_ArrayData instance; 
        private int[] _array;
        public bool extractSucceeded;

        public int uniqueElementCount; 
        public int[]? uniqueElementArray;
        public int majorityNum = 0;
        public int majorityCount = 0;

        public int[] InitalArray
        {
            get { return _array; }
        }

        public DC1_ArrayData(int[] array)
        {
            _array = array;
            instance = this;
            DailyChallenge1.GetMajorityElement(ref instance);
        }

        public bool CompareConstraints() => (InitalArray.Length < 1 || InitalArray.Length > 5 * MathF.Pow(10, 4));

        public void CannotExtract() => extractSucceeded = false;
    }

    public static class DailyChallenge1
    {
        public static void GetMajorityElement(ref DC1_ArrayData data)
        {
#if DEBUG
            Console.WriteLine("-----Inital Array-----");
            DailyChallenge1.DebugArrayPrint(data.InitalArray);
#endif

            //Verify inital conditions. 
            if (data.CompareConstraints())
            {
                data.CannotExtract();
                return; //Cancel extraction. 
            } 

            //Define element/result array.
            data.uniqueElementArray = GenerateUniqueElementArray(data.InitalArray, out data.uniqueElementCount);

#if DEBUG
            //Debug output. 
            Console.WriteLine("----Unique Elements + Count Spaces-----");
            DebugArrayPrint(data.uniqueElementArray);
            Console.WriteLine("The number of unique elements: " + data.uniqueElementCount);
#endif

            //Count the elements. 
            GenerateCount(data.InitalArray, data.uniqueElementCount, ref data.uniqueElementArray);
#if DEBUG
            Console.WriteLine("-----Counted Values-----");
            DebugArrayPrint(data.uniqueElementArray);
#endif

            //Extract the majority element & majority element count. 
            ExtractMajorityElement(data.uniqueElementArray, data.uniqueElementCount, out data.majorityNum, out data.majorityCount);
            
            //Flag completion. 
            data.extractSucceeded = true;
        }

        /// <summary>
        /// Create an array with only the unique elements of the inital array.
        /// </summary>
        /// <param name="elements"> The intial integer array to process.</param>
        /// <param name="n"> The count of unique elements within the array. </param>
        /// <returns> An array containing the n unique elements, and n 0 elements.</returns>
        private static int[] GenerateUniqueElementArray(int[] elements, out int n)
        {
            List<int> uniqueElements = elements.Distinct().ToList();
            n = elements.Distinct().ToArray().Length;

            //Insert count spaces. 
            for (int i = 0; i < n; i++)
                uniqueElements.Add(0);

            return uniqueElements.ToArray();
        }

        /// <summary>
        /// Generate the counts of each unique element within the passed array. 
        /// </summary>
        /// <param name="elements"> The integer array to count. </param>
        /// <param name="uniqueCount"> The number of unique elements within the array. </param>
        /// <param name="uniqueElements"> The array to assign the counted variables to. </param>
        private static void GenerateCount(int[] elements, int uniqueCount, ref int[] uniqueElements)
        {
            

            //Iterate the unique elements:
            for (int i = 0; i < uniqueCount; i++)
            {
                //Iterate the inital array: 
                for (int x = 0; x < elements.Length; x++)
                {
                    if (elements[x] == uniqueElements[i])
                        ++uniqueElements[i + uniqueCount];
                }
            }
        }

        /// <summary>
        /// Extract the majority element from the array and its total count within the array. 
        /// </summary>
        /// <param name="uniqueElementArr"> The array to process. </param>
        /// <param name="uniqueElementCount"> The count of the unique elements within the array. </param>
        /// <param name="number"> The majority number to be returned. </param>
        /// <param name="highestValue"> The number of times the number occurs within the array. </param>
        private static void ExtractMajorityElement(int[] uniqueElementArr, int uniqueElementCount, out int number, out int highestValue)
        {
            int currentIntIndex = 0;
            int currentCount = 0;

            for (int i = 0; i < uniqueElementCount; i++)
            {
                if (uniqueElementArr[i + uniqueElementCount] > currentCount)
                {
                    currentIntIndex = i;
                    currentCount = uniqueElementArr[i + uniqueElementCount];
                }
            }

            number = uniqueElementArr[currentIntIndex];
            highestValue = currentCount;
        }

        public static void DebugArrayPrint(int[] array)
        {
            string arrStr = "{";
            for (int i = 0; i < array.Length; i++)
            {
                arrStr += array[i] + ",";
            }
            arrStr += "} \n";

            Console.WriteLine(arrStr);
        }
    }
}
