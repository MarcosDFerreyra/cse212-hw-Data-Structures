using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        //create the numbers array to insert the multiples of a number
        double[] numbers = new double[length];
        // stablish the index to 0 to access the first space in the array 
        int index = 0;
        // a for loop to go to all the multiples within the lenght given 
        for (int i = 1; i <= length; ++i)
        {
            //use the i value to multiply by the number given to find the multiples of the number and store it in a variable
            double value = i * number;
            //use the indexvalue to add the multiples to the the space available in the array 
            numbers[index] = value;
            //increment the index by 1 to access the next place in the array
            index++;
            
        } 
        // return the array
        return numbers; 
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

        // the idea in general is to divided the list and then putter together in the correct order.
        // get the last index using count - 1;
        var last_index = data.Count - amount;
        // in the first variable use Get Range with the amount 
        // parameter to get the part of the list that will be moved
        var data_a = data.GetRange(last_index, amount);
        // in the second variable user Get Range with the last index 
        // parameter to get the ramaining part of the list that will 
        // be displayed at the end of the list
        var data_b = data.GetRange(0, last_index);
        // using addRange add the second list to the first list, addRange adds it to the end
        // the order would be first side A then side B 
        data_a.AddRange(data_b);
        // clear the original list and add the new list to it
        data.Clear();
        data.AddRange(data_a);
    }
}
