using System;

namespace LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode MiddleNode(ListNode head)
        {
            if (head == null)
                throw new ArgumentException("List is empty");

            int count = 0;
            ListNode countNode = head;
            while (countNode != null && count <= 100)
            {
                count++;
                countNode = countNode.next;
            }

            if (count < 1 || count > 100)
                throw new ArgumentException("Number of nodes must be between 1 and 100");

            ListNode slow = head;
            ListNode fast = head;
            
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            
            return slow;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            // Test case 1: Odd number of nodes
            Console.WriteLine("Test case 1: Odd number of nodes");
            ListNode head1 = CreateLinkedList(new int[] { 1, 2, 3, 4, 5 });
            TestMiddleNode(solution, head1);

            // Test case 2: Even number of nodes
            Console.WriteLine("\nTest case 2: Even number of nodes");
            ListNode head2 = CreateLinkedList(new int[] { 1, 2, 3, 4, 5, 6 });
            TestMiddleNode(solution, head2);

            // Test case 3: Single node
            Console.WriteLine("\nTest case 3: Single node");
            ListNode head3 = CreateLinkedList(new int[] { 1 });
            TestMiddleNode(solution, head3);

            // Test case 4: 100 nodes (maximum allowed)
            Console.WriteLine("\nTest case 4: 100 nodes");
            int[] hundredNodes = new int[100];
            for (int i = 0; i < 100; i++) hundredNodes[i] = i + 1;
            ListNode head4 = CreateLinkedList(hundredNodes);
            TestMiddleNode(solution, head4);

            // Uncomment to test error case:
            // Test case 5: More than 100 nodes (should throw an exception)
            // Console.WriteLine("\nTest case 5: More than 100 nodes (should throw an exception)");
            // int[] tooManyNodes = new int[101];
            // for (int i = 0; i < 101; i++) tooManyNodes[i] = i + 1;
            // ListNode head5 = CreateLinkedList(tooManyNodes);
            // TestMiddleNode(solution, head5);
        }

        static ListNode CreateLinkedList(int[] values)
        {
            if (values.Length == 0) return null;

            ListNode head = new ListNode(values[0]);
            ListNode current = head;
            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }
            return head;
        }

        static void TestMiddleNode(Solution solution, ListNode head)
        {
            try
            {
                ListNode middle = solution.MiddleNode(head);
                Console.WriteLine($"The middle node value is: {middle.val}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}