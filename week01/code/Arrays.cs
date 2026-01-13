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
        // PLAN FOR SOLVING MultiplesOf:
        // Step 1: Create a new array of doubles with size 'length'
        // Step 2: Loop through the array from index 0 to length-1
        // Step 3: For each position i, calculate the multiple: number * (i + 1)
        //         - At index 0: number * 1 = number
        //         - At index 1: number * 2 = number * 2
        //         - At index 2: number * 3 = number * 3
        //         - And so on...
        // Step 4: Store each calculated multiple in the array at position i
        // Step 5: Return the completed array
        
        // Example walkthrough with MultiplesOf(7, 5):
        // Index 0: 7 * (0+1) = 7 * 1 = 7
        // Index 1: 7 * (1+1) = 7 * 2 = 14
        // Index 2: 7 * (2+1) = 7 * 3 = 21
        // Index 3: 7 * (3+1) = 7 * 4 = 28
        // Index 4: 7 * (4+1) = 7 * 5 = 35
        // Result: {7, 14, 21, 28, 35}

        // Implementation:
        double[] multiples = new double[length];
        
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        
        return multiples;
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
        // PLAN FOR SOLVING RotateListRight (Using List Slicing Method):
        // 
        // Understanding the problem:
        // - Rotating right by 3 means the last 3 elements move to the front
        // - Example: {1, 2, 3, 4, 5, 6, 7, 8, 9} rotated right by 3
        //   becomes: {7, 8, 9, 1, 2, 3, 4, 5, 6}
        // - The last 3 elements (7, 8, 9) move to the front
        // - The first 6 elements (1, 2, 3, 4, 5, 6) shift to the end
        //
        // Step 1: Calculate the split point
        //         - Split point = data.Count - amount
        //         - This tells us where to "cut" the list
        //         - Example: 9 - 3 = 6 (cut after index 5, before index 6)
        //
        // Step 2: Extract the right portion (elements that will move to front)
        //         - Use GetRange(splitPoint, amount) to get the last 'amount' elements
        //         - Example: GetRange(6, 3) gives us {7, 8, 9}
        //
        // Step 3: Extract the left portion (elements that will move to end)
        //         - Use GetRange(0, splitPoint) to get the first elements
        //         - Example: GetRange(0, 6) gives us {1, 2, 3, 4, 5, 6}
        //
        // Step 4: Clear the original list
        //         - Use Clear() to empty the list
        //
        // Step 5: Add the right portion first (these go to the front)
        //         - Use AddRange(rightPortion)
        //
        // Step 6: Add the left portion second (these go to the end)
        //         - Use AddRange(leftPortion)
        //
        // Visual example with {1, 2, 3, 4, 5, 6, 7, 8, 9}, amount = 3:
        // Original:      [1, 2, 3, 4, 5, 6] [7, 8, 9]
        //                 ← left portion →   ← right →
        // After rotate:  [7, 8, 9] [1, 2, 3, 4, 5, 6]
        //                ← right → ← left portion →

        // Implementation:
        
        // Handle edge case: if amount equals data.Count, no rotation needed
        if (amount == data.Count || data.Count == 0)
        {
            return;
        }
        
        // Step 1: Calculate split point
        int splitPoint = data.Count - amount;
        
        // Step 2: Get the right portion (last 'amount' elements)
        List<int> rightPortion = data.GetRange(splitPoint, amount);
        
        // Step 3: Get the left portion (first 'splitPoint' elements)
        List<int> leftPortion = data.GetRange(0, splitPoint);
        
        // Step 4: Clear the original list
        data.Clear();
        
        // Step 5: Add right portion first (goes to front)
        data.AddRange(rightPortion);
        
        // Step 6: Add left portion second (goes to end)
        data.AddRange(leftPortion);
    }
};