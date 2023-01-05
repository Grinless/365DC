// See https://aka.ms/new-console-template for more information

//-----------Daily Challenge 1-----------
//int[] unsorted = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 4, 3, 3, 4, 4, 6 };
//_365Challenge.DC1_ArrayData data = new _365Challenge.DC1_ArrayData(unsorted);
//Console.WriteLine("-----Majority Elements-----");
//if (data.extractSucceeded)
//{
//    Console.WriteLine(String.Format("The majority number is {0}, with an instance count of {1}", data.majorityNum, data.majorityCount));
//}
//else
//{
//    Console.WriteLine("Array could not be processed!"); 
//}
//-----------END----------

//----------Weekly Challenge 5----------


while (true)
{
    Console.WriteLine("Please enter an integer to convert to roman numerals:\n");
    string s = Console.ReadLine().ToString();
    string output; 
    int input = 0; 
    Int32.TryParse(s, out input);
    output = _365Challenge.DailyChallenge5.ConvertToRoman(input);
    Console.WriteLine(output);
}


//-----------END----------

////----------Weekly Challenge 1----------


//while (true)
//{
//    Console.WriteLine("Please enter string to search for palindrome:\n");
//    string s = Console.ReadLine().ToString();
//    _365Challenge.WeeklyChallenge1.GetLargestPlaindrome(s);
//}


////-----------END----------