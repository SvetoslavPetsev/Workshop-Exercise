namespace CustomDoublyLinkedList
{
    using System;

    public class DoublyLinkedList
    {
        private ListNode head;
        private ListNode tail;
        private class ListNode
        {
            public ListNode(int value)
            {
                this.Value = value;
            }
            public int Value { get; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }
        }
        public int Count { get; private set; }

        public void AddFirst(int value)
        {
            if (this.Count == 0)
            {
                CreateList(value);
            }
            else
            {
                ListNode newHead = new ListNode(value);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }
            this.Count++;
        }
        public void AddLast(int value)
        {
            if (this.Count == 0)
            {
                CreateList(value);
            }
            else
            {
                ListNode newHead = new ListNode(value);
                newHead.PreviousNode = this.tail;
                this.tail.NextNode = newHead;
                this.tail = newHead;
            }
            this.Count++;
        }
        public int RemoveFirst()
        {
            if (this.Count == 0)
            {
                ThrowEmptyListException();
            }

            var firstElement = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }

            this.Count--;
            return firstElement;
        }
        public int RemoveLast()
        {
            int lastElement = this.tail.Value;

            if (this.Count == 0)
            {
                ThrowEmptyListException();
            }

            this.tail = this.tail.PreviousNode;

            if (this.tail != null)
            {
                this.tail.NextNode = null;
            }
            else
            {
                this.head = null;
            }

            this.Count--;
            return lastElement;
        }
        public void ForEach(Action<int> action)
        {
            ListNode currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }
        public int[] ToArray()
        {
            int[] newArr = new int[this.Count];
            int index = 0;

            ListNode currentNode = this.head;

            while (currentNode != null)
            {
                newArr[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }

            return newArr;
        }
        private static void ThrowEmptyListException()
        {
            throw new InvalidOperationException("The LinkedList is empty.");
        }
        private void CreateList(int value)
        {
            ListNode newHead = new ListNode(value);
            this.head = this.tail = newHead;
        }
    }
}
