/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: client adds a new customer to the queue. all information is valid. after we remove the customer from the queue, the queue is empty. 
        // Expected Result: the queue is empty.
        Console.WriteLine("Test 1");
        var customer_service = new CustomerService(10);
        customer_service.AddNewCustomer();
        Console.WriteLine(customer_service);
        customer_service.ServeCustomer();
        Console.WriteLine(customer_service);
        // Defect(s) Found: an error occurs when trying to serve a customer from an empty queue.
        // the solution was to save the information of the customer to a variable before removing it from the queue.  

        Console.WriteLine("=================");

        // Test 2
        // Scenario: client attempts to add a new customer to a full queue.
        // Expected Result: an error message is displayed indicating that the queue is full.
        Console.WriteLine("Test 2");
        var customer_service_2 = new CustomerService(1);
        customer_service_2.AddNewCustomer();
        customer_service_2.AddNewCustomer();
        Console.WriteLine(customer_service_2);
        // Defect(s) Found: no error message is displayed when trying to add a new customer to a full queue.
        // solution was to not only check if the size of the queue is greater, but also equal to the max size before adding a new customer to the queue.
        Console.WriteLine("=================");

        // Test 3
        // Scenario: client attempts to add a new customer to a full queue.
        // Expected Result: an error message is displayed indicating that the queue is full.
        Console.WriteLine("Test 3");
        var customer_service_3 = new CustomerService(4);
        customer_service_3.ServeCustomer();
        // Defect(s) Found: no error message is displayed when trying to add a new customer to a full queue.
        // solution was to not only check if the size of the queue is greater, but also equal to the max size before adding a new customer to the queue.
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers to serve");
            return;
        }
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}