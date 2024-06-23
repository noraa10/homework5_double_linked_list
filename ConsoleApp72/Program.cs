using System;
public class Node
{
    public int data;
    public Node prev;
    public Node next;

    public Node(int data)
    {
        this.data = data;
        this.prev = null;
        this.next = null;
    }
}

public class DoubleLinkedList
{
    private Node head;
    private Node tail;
    public DoubleLinkedList()
    {
        this.head = null;
        this.tail = null;
    }

    // write fun for display 
    public void DisplayList()
    {
        Node current = head;
        while (current != null)
        {
            Console.WriteLine(current.data + " ");
            current = current.next;

        }
        Console.WriteLine();
    }

    // display in reverse
    public void DisplayListInReverse()
    {
        Node current = tail;
        while (current != null)
        {
            Console.WriteLine(current.data + " ");
            current = current.prev;

        }
        Console.WriteLine();
    }

    // num of node in double linked list
    public int CountNodes()
    {
        int count = 0;
        Node current = head;
        while (current != null)
        {
            count++;
            current = current.next;
        }
        return count;
    }

    // insert node at any pos
    public void InsertAtPosition(int data,int position)
    {
        Node newNode = new Node(data);
        if (position == 1)
        {
            InsertAtBeginnning(data);
            return;
        }
        Node current = head;
        int count = 1;
        while (current !=null && count <position - 1)
        {
            current = current.next;
            count++;
        }
        if(current == null)
        {
            return;
        }
        newNode.prev = current;
        newNode.next = current.next;
        if (current.next != null)
        {
            current.next.prev = newNode;
        }
        current.next = newNode;

        if(newNode .next == null)
        {
           tail= tail.newNode;
        }
    }

    // insert at the beginning
    public void InsertAtBeginnning(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.next = head;
            head.prev = newNode;
            head = newNode;
        }
    }

    // insert a node at end
    public void InsertAtEnd(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.prev = tail;
            tail.next = newNode;
            tail = newNode;
        }
    }

    // get a node from the linked list
    public Node GetNode(int index)
    {
        Node current = head;
        int count = 0;
        while(current !=null&& count < index)
        {
            current = current.next;
            count++;
        }
        if(current == null)
        {
            Console.WriteLine("Error: current node is null.");
            return;
        }
        return current;
       
    }

    //  program to find the first index that matches a given element. Return -1 for no matching
    public int FindFirstIndex(int data)
    {
        Node current = head;
        int index = 0;
        while(current != null)
        {
            if(current .data ==data)
            {
                return index;
            }
            current = current.next;
            index++;
        }
        return -1;
    }

    //  is empty or not
    public void ISEmptyList()
    {
        Console.WriteLine( head == null);
    }


    // to make the double linked list empty
     public void EmptyList()
    {
        head = null;
        tail = null;

    }


    // remove a node in any pos 
    public void RemoveAtIndex(int index)
    {
        if(index == 0)
        {
            RemoveFirst();
            return;
        }

        Node current = head;
        int count = 0;
        while(current!=null&&count<index - 1)
        {
            current = current.next;
            count++;
        }
        if (current ==null||current .next ==null)
        {
            return;
        }

        Node nodetoremove = current.next;
        current.next = nodetoremove.next;
        if (nodetoremove.next != null)
        {
            nodetoremove.next.prev = current;
        }
        else
        {
            tail = current;
        }

    }

    // the size of the doublee linked list
    public int size()
    {
        return CountNodes();
    }

    // remove the first node
    public void RemoveFirst()
    {
        if(head == null)
        {
            return;
        }
        head = head.next;
        if (head != null)
        {
            head.prev = null;
        }
        else
        {
            tail = null;
        }
    }

    // remove at the end

    public void RemveLast()
    {
        if (tail == null)
        {
            return;
        }
        tail = tail.prev;
        if (tail != null)
        {
            tail.next = null;
        }
        else
        {
            head = null;
        }

    }

    // convert a doule linked  list to array
    public int[] ToArray()
    {
        int[] array = new int[CountNodes()];
        Node curreny = head;
        int index = 0;
        while(curreny!=null)
        {
            array[index++] = curreny.data;
            curreny = curreny.next;


        }
        return array;
    }
    // convert a dounle linked list to string 
      public string ToString()
    {
        string result = "";
        Node current = head;
        while (current !=null)
        {
            result += current.data + " ";
            current = current.next;
        }
        return result;
    }

    //get the index of the element or node 
    public int IndexOf(int data)
    {
        Node current = head;
        int index = 0;
        while (current != null)
        {
            if (current.data == data)
            {
                return index;
            }
            current = current.next;
            index++;
        }
        return -1;
    }


    // 

    public static void Main()
    {
        // Create a new DoubleLinkedList
        DoubleLinkedList list = new DoubleLinkedList();

        // Insert nodes at the beginning
        list.InsertAtBeginnning(1);
        list.InsertAtBeginnning(2);
        list.InsertAtBeginnning(3);

        // Display the list
        Console.WriteLine("Displaying the list:");
        list.DisplayList();

        // Display the list in reverse
        Console.WriteLine("Displaying the list in reverse:");
        list.DisplayListInReverse();

        // Insert a node at a specific position
        list.InsertAtPosition(4, 2);

        // Display the list after insertion
        Console.WriteLine("Displaying the list after insertion:");
        list.DisplayList();

        // Insert a node at the end
        list.InsertAtEnd(5);

        // Display the list after insertion
        Console.WriteLine("Displaying the list after insertion at the end:");
        list.DisplayList();

        // Get the first index of a given element
        int firstIndex = list.FindFirstIndex(3);
        Console.WriteLine($"First index of 3: {firstIndex}");

        // Remove a node at a specific index
        list.RemoveAtIndex(2);

        // Display the list after removal
        Console.WriteLine("Displaying the list after removal:");
        list.DisplayList();

        // Convert the list to an array
        int[] array = list.ToArray();
        Console.WriteLine("Displaying the list as an array:");
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        // Convert the list to a string
        string listString = list.ToString();
        Console.WriteLine("Displaying the list as a string:");
        Console.WriteLine(listString);

        // Get the index of an element
        int index = list.IndexOf(4);
        Console.WriteLine($"Index of 4: {index}");
    }
}
