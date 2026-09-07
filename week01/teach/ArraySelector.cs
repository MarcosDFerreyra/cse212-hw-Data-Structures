public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        List<int> numbers = new();
        int index_a = 0;
        int index_b = 0;
        foreach (int selection in select)
        {
            if (selection == 1)
            {
                int value = list1[index_a];
                numbers.Add(value);
                index_a += 1;
            }
            else
            {
                int value2 = list2[index_b];
                numbers.Add(value2);
                index_b += 1;
            }
        }

        return numbers.ToArray();
    }
}