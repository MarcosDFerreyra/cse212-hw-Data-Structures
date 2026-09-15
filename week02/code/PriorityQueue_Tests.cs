using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: test if the highest priority item is dequeued first
    // Expected Result: item2 is dequeued first since it has the highest priority (10)
    // Defect(s) Found: the last item with the highest priority wasn't being dequeued 
    // first because the for loop was omitting the last item in the queue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        var item1 = "item 1";
        var item2 = "item 2";
        var item3 = "item 3";

        priorityQueue.Enqueue(item1, 5);
        priorityQueue.Enqueue(item2, 3);
        priorityQueue.Enqueue(item3, 10);

        var info = priorityQueue.Dequeue();
        Assert.AreEqual("item 3", info);
    }

    [TestMethod]
    // Scenario:test which of two items with the same priority is dequeued first. 
    // Expected Result:  the item3 is dequeue
    // Defect(s) Found: the last item between the two items with the same priority was being dequeued first because the for loop was using >= instead of > when comparing priorities
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        var item1 = "item 1";
        var item2 = "item 2";
        var item3 = "item 3";
        var item4 = "item 4";


        priorityQueue.Enqueue(item1, 1);
        priorityQueue.Enqueue(item2, 3);
        priorityQueue.Enqueue(item3, 10);
        priorityQueue.Enqueue(item4, 10);


        var info = priorityQueue.Dequeue();
        Assert.AreEqual("item 3", info);
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: test if the queue is empty and Dequeue is called 
    // Expected Result: the Dequeue method should throw an InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: no errors found
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();


        var info = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", info.Message);
    }

    [TestMethod]
    // Scenario: dequeue an item without saving its return value, then immediately dequeue again 
    // without any other enqueue in between, to check if the first dequeued item was actually 
    // removed from the queue.
    // Expected Result: item2 should be removed on the first Dequeue, so the second Dequeue 
    // should return item1 (the only item left in the queue).
    // Defect(s) Found: the item2 was not being removed from the queue after the first Dequeue, 
    // so the second Dequeue was returning item2 again instead of item1. this happend because no 
    // item was being removed from the queue at any point of the dequeue method
    //
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        var item1 = "item 1";
        var item2 = "item 2";

        priorityQueue.Enqueue(item1, 1);
        priorityQueue.Enqueue(item2, 2);

        priorityQueue.Dequeue();
        var info2 = priorityQueue.Dequeue();

        Assert.AreEqual("item 1", info2);
    }
}