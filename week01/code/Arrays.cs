public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // The first step here is to create a dynamic array.
        var result = new List<double>();

        // Next, we need to make a loop that will iterate from 0 to length - 1.
        for (int i = 0; i < length; i++)
        {
            // We can move through the array using the index 'i' which will start at 0 and go up to length - 1.
            // In each iteration, we will calculate the multiple of 'number' by multiplying it with (i + 1) because i is starting at 0.
            // This way, the first element will be 'number' itself (i.e., number * 1).
            result.Add(number * (i + 1));
        }
        // Finally, we return the dynamic array which now contains the multiples of the given number using .ToArray().
        return result.ToArray();
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // The first step is to calculate the effective rotation amount.
        // If the amount is greater than the size of the list, we can use the modulo operator
        // to find the equivalent smaller rotation.
        // For example, if the list has 9 elements and the amount is 12, we can rotate it by 3 instead.
        // This is because rotating a list of size 9 by 12 is the same as rotating it by 12 % 9 = 3.
        // So we will calculate the effective amount as follows:
        int effectiveAmount = amount % data.Count;

        // Next, we need to reverse the entire list to prepare for the rotation.
        data.Reverse(); // Step 1
        // So now an array of {1, 2, 3, 4, 5, 6, 7, 8, 9} becomes {9, 8, 7, 6, 5, 4, 3, 2, 1}.
        
        // Now we need to reverse the first 'effectiveAmount' elements to move them to the front.
        data.Reverse(0, effectiveAmount); // Step 2
        // This will reverse the first 'effectiveAmount' elements, so if effectiveAmount is 3,
        // the first three elements will become {7, 8, 9}. Making the whole array look like this:
        // {7, 8, 9, 6, 5, 4, 3, 2, 1}.

        // Finally, we reverse the remaining elements to restore their original order.
        // This will reverse the elements from 'effectiveAmount' to the end of the list.
        // So if we had {7, 8, 9, 6, 5, 4, 3, 2, 1}, reversing the last part will give us:
        // {7, 8, 9, 1, 2, 3, 4, 5, 6}.
        // This is the final step of the rotation.
        data.Reverse(effectiveAmount, data.Count - effectiveAmount); // Step 3

    }
}
