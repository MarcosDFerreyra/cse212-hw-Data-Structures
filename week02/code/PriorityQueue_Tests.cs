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
    // Defect(s) Found: the last item between the two items with the same priority was 
    // being dequeued first because the for loop was using >= instead of > when comparing priorities
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
    // Scenario: test if the item with the highest priority is dequeued and then re-enqueued
    // Expected Result: the item1 is dequeued first and then re-enqueued with a higher priority, 
    // so it should be dequeued again before item2 and item3 to see if the item1 came back correctly to the queue with the new priority
    // Defect(s) Found: no problems found
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        var item1 = "item 1";
        var item2 = "item 2";
        var item3 = "item 3";

        priorityQueue.Enqueue(item1, 1);
        priorityQueue.Enqueue(item2, 1);
        priorityQueue.Enqueue(item3, 1);

        var info = priorityQueue.Dequeue();
        priorityQueue.Enqueue(info, 2);
        var info2 = priorityQueue.Dequeue();


        Assert.AreEqual("item 1", info2);
    }
}