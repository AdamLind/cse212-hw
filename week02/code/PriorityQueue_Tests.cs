using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items to the queue and verify they are added to the back
    // Expected Result: Items should be added in order to the back of the queue
    // Defect(s) Found: Missing Count property... not entirely necessary for this test, but useful for verification
    public void TestPriorityQueue_EnqueueAddsToBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 1);
        priorityQueue.Enqueue("second", 2);
        priorityQueue.Enqueue("third", 3);
        // Verify the count of items in the queue
        Assert.AreEqual(3, priorityQueue.Count);
        // Verify items are in order they were added (back of queue)
        Assert.AreEqual("[first (Pri:1), second (Pri:2), third (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Dequeue items and verify highest priority is returned
    // Expected Result: Items with highest priority should be returned first
    // Defect(s) Found: 
    // 1) Loop condition was "< _queue.Count - 1" which skipped the last element, 
    // 2) Item was not actually removed from queue after dequeue, 
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);
        priorityQueue.Enqueue("medium", 3);
        
        // Should return highest priority first
        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual(2, priorityQueue.Count);
        
        // Next highest
        Assert.AreEqual("medium", priorityQueue.Dequeue());
        Assert.AreEqual(1, priorityQueue.Count);
        
        // Lowest
        Assert.AreEqual("low", priorityQueue.Dequeue());
        Assert.AreEqual(0, priorityQueue.Count);
    }

    [TestMethod]
    // Scenario: Multiple items with same highest priority - should return the one closest to front
    // Expected Result: When priorities are equal, return the item that was added first (closest to front)
    // Defect(s) Found: Priority comparison used ">=" which selected the LAST occurrence of highest priority instead of FIRST (closest to front)
    public void TestPriorityQueue_SamePriorityReturnsFrontItem()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first_high", 5);
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("second_high", 5);
        priorityQueue.Enqueue("third_high", 5);
        
        // Should return the first item with priority 5 (closest to front)
        Assert.AreEqual("first_high", priorityQueue.Dequeue());
        Assert.AreEqual(3, priorityQueue.Count);
        
        // Should return the second item with priority 5
        Assert.AreEqual("second_high", priorityQueue.Dequeue());
        Assert.AreEqual(2, priorityQueue.Count);
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: Should throw InvalidOperationException with appropriate message
    // Defect(s) Found: None
    public void TestPriorityQueue_DequeueEmptyThrowsException()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
    }

    [TestMethod]
    // Scenario: Complex scenario with mixed priorities and over dequeuing
    // Expected Result: Items should be dequeued in correct priority order.
    // Defect(s) Found: Combination of all previous defects
    public void TestPriorityQueue_ComplexTestScenario()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 4);
        priorityQueue.Enqueue("D", 3);
        priorityQueue.Enqueue("E", 4);
        priorityQueue.Enqueue("F", 2);
        
        // Expected order: C(4), E(4), A(3), D(3), F(2), B(1)
        Assert.AreEqual("C", priorityQueue.Dequeue()); // First priority 4
        Assert.AreEqual("E", priorityQueue.Dequeue()); // Second priority 4
        Assert.AreEqual("A", priorityQueue.Dequeue()); // First priority 3
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Second priority 3
        Assert.AreEqual("F", priorityQueue.Dequeue()); // Priority 2
        Assert.AreEqual("B", priorityQueue.Dequeue()); // Priority 1
        
        Assert.AreEqual(0, priorityQueue.Count);

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
    }

}