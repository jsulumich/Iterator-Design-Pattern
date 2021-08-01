using System;
using System.Collections;

namespace IteratorDemo
{
    class IteratorDemo

    {
        static void Main()
        {
            //declare and set variables
            string answer = "Y";
            string stepVal;

            // Build a collection
            Collection collection = new Collection();
            collection[0] = new Item("0");
            collection[1] = new Item("1");
            collection[2] = new Item("2");
            collection[3] = new Item("3");
            collection[4] = new Item("4");
            collection[5] = new Item("5");
            collection[6] = new Item("6");
            collection[7] = new Item("7");
            collection[8] = new Item("8");
            collection[9] = new Item("9");
            collection[10] = new Item("10");

            // Create forward iterator and reverse iterator
            forwardIterator forwardIterator = collection.createForwardIterator();
            reverseIterator reverseIterator = collection.CreateReverseIterator();

            while (answer == "Y")
            {
                // Prompt user for iterator step-value
                Console.Write("Enter iterator step value: ");
                stepVal = Console.ReadLine();
                int stepValInt = Convert.ToInt32(stepVal);

                // set iterator step value
                forwardIterator.Step = stepValInt;
                reverseIterator.Step = stepValInt;
                Console.WriteLine(" ");
                Console.WriteLine("Iterating through collection forward with step values of " + stepVal + ":");

                // iterate forward
                for (Item item = forwardIterator.First();
                    !forwardIterator.IsDone; item = forwardIterator.Next())
                {
                    Console.Write(item.Name + " ");
                }

                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("Iterating through collection backward with step values of " + stepVal + ":");

                // iterate backward
                for (Item item = reverseIterator.First();
                   !reverseIterator.IsDone; item = reverseIterator.Next())
                {
                    Console.Write(item.Name + " ");
                }

                // Wait for user input
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.Write("Run again? (Y/N): ");
                answer = Console.ReadLine();
            }
        }
    }

    //Item Class
    // DESCRIPTION: Defines properties of a collection item
    class Item
    {
        private string itemName;    // variable declaration

        // Constructor
        public Item(string name)
        {
            this.itemName = name;   // sets name
        }

        // Gets name
        public string Name
        {
            get { return itemName; }
        }
    }

    /// The 'Aggregate' Class
    /// DESCRIPTION:defines an interface for creating an Iterator object
    interface IAbstractCollection
    {
        forwardIterator createForwardIterator();
        reverseIterator CreateReverseIterator();
    }


    /// The 'Concrete Aggregate' class
    /// DESCRIPTION: implements the Iterator creation interface to return an instance of the proper ConcreteIterator
    class Collection : IAbstractCollection

    {
        private ArrayList arrayItems = new ArrayList();

        public forwardIterator createForwardIterator()
        {
            return new forwardIterator(this);
        }

        public reverseIterator CreateReverseIterator()
        {
            return new reverseIterator(this);
        }

        // Gets item count
        public int Count
        {
            get { return arrayItems.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return arrayItems[index]; }
            set { arrayItems.Add(value); }
        }
    }

    /// The 'Iterator' interface
    /// DESCRIPTION: defines an interface for accessing and traversing elements.
    interface IAbstractIterator
    {
        Item First();
        Item Next();
        bool IsDone { get; }
        Item CurrentItem { get; }
    }

    /// The 'ConcreteIterator' class for forward iteration
    /// DESCRIPTION: Implements the Iterator interface (forward) and keeps track of the current position in the traversal of the aggregate.
    class forwardIterator : IAbstractIterator
    {
        private Collection itemCollection;
        private int currentItem = 0;
        private int stepVal = 1;


        // Constructor
        public forwardIterator(Collection collection)
        {
            this.itemCollection = collection;
        }

        // Gets first item
        public Item First()
        {
            currentItem = 0;
            return itemCollection[currentItem] as Item;
        }

        // Gets next item
        public Item Next()
        {
            currentItem += stepVal;
            if (!IsDone)
                return itemCollection[currentItem] as Item;
            else

                return null;
        }

        // Gets or sets step size
        public int Step
        {
            get { return stepVal; }
            set { stepVal = value; }
        }

        // Gets current iterator item
        public Item CurrentItem
        {
            get { return itemCollection[currentItem] as Item; }
        }

        // Gets whether iteration is complete
        public bool IsDone
        {
            get { return currentItem >= itemCollection.Count; }
        }
    }

    /// The 'ConcreteIterator' class for reverse iteration
    /// DESCRIPTION: Implements the Iterator interface (reverse) and keeps track of the current position in the traversal of the aggregate.
    class reverseIterator : IAbstractIterator
    {
        private Collection itemCollection;
        private int currentItem = 0;
        private int stepVal = 1;

        // Constructor
        public reverseIterator(Collection collection)
        {
            this.itemCollection = collection;
        }

        // Gets first item
        public Item First()
        {
            currentItem = itemCollection.Count - 1;
            return itemCollection[currentItem] as Item;
        }

        // Gets next item (specific to reversed convention)
        public Item Next()
        {
            currentItem -= stepVal;
            if (!IsDone)
                return itemCollection[currentItem] as Item;
            else

                return null;
        }

        // Gets or sets step size
        public int Step
        {
            get { return stepVal; }
            set { stepVal = value; }
        }

        // Gets current iterator item
        public Item CurrentItem
        {
            get { return itemCollection[currentItem] as Item; }
        }

        // Gets whether iteration is complete
        public bool IsDone
        {
            get { return currentItem < 0; }
        }
    }
}
