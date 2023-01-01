// See https://aka.ms/new-console-template for more information
int[] unsorted = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 4, 3, 3, 4, 4, 6 };
_365Challenge.DC1_ArrayData data = new _365Challenge.DC1_ArrayData(unsorted);
Console.WriteLine("-----Majority Elements-----");
if (data.extractSucceeded)
{
    Console.WriteLine(String.Format("The majority number is {0}, with an instance count of {1}", data.majorityNum, data.majorityCount));
}
else
{
    Console.WriteLine("Array could not be processed!"); 
}