public class SimpleQueue {
    public static void Run() {
        // Test Cases

        // Test 1
        // Scenario: Enqueue one value and then Dequeue it.
        // Expected Result: It should display 100
        Console.WriteLine("Test 1");
        var queue = new SimpleQueue();
        queue.Enqueue(100);
        var value = queue.Dequeue();
        Console.WriteLine(value);
        // Defect(s) Found: the error was that the Dequeue function was eliminating and returning the 
        // item in the index 1 of the list instead of the item in index 0. This was fixed by changing 
        // the index to 0 in the Dequeue function.

        Console.WriteLine("------------");

        // Test 2
        // Scenario: Enqueue multiple values and then Dequeue all of them
        // Expected Result: It should display 200, then 300, then 400 in that order
        Console.WriteLine("Test 2");
        queue = new SimpleQueue();
        queue.Enqueue(200);
        queue.Enqueue(300);
        queue.Enqueue(400);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);
        value = queue.Dequeue();
        Console.WriteLine(value);
        // Defect(s) Found: the problem was that in each Enqueue the value was inserted 
        // in the index 0, moving every other previous value, so the First value was 
        // the last and last was the first

        Console.WriteLine("------------");

        // Test 3
        // Scenario: Dequeue from an empty Queue
        // Expected Result: An exception should be raised
        Console.WriteLine("Test 3");
        queue = new SimpleQueue();
        try {
            queue.Dequeue();
            Console.WriteLine("Oops ... This shouldn't have worked.");
        }
        catch (IndexOutOfRangeException) {
            Console.WriteLine("I got the exception as expected.");
        }
        // Defect(s) Found: none
    }

    private readonly List<int> _queue = new();

    /// <summary>
    /// Enqueue the value provided into the queue
    /// </summary>
    /// <param name="value">Integer value to add to the queue</param>
    private void Enqueue(int value) {
        int index = 0;
        if (_queue.Count > 0)
        {
            index = _queue.Count;
        }
        _queue.Insert(index, value);
        
        
    }

    /// <summary>
    /// Dequeue the next value and return it
    /// </summary>
    /// <exception cref="IndexOutOfRangeException">If queue is empty</exception>
    /// <returns>First integer in the queue</returns>
    private int Dequeue() {
        if (_queue.Count <= 0)
            throw new IndexOutOfRangeException();

        var value = _queue[0];
        _queue.RemoveAt(0);
        return value;
    }
}