using System;
using System.Text;

namespace MorteTools
{
    public class Stack<T>
    {
        //using a List as the stack
        List<T> stack = new List<T>();

        //constructors, in case of array items are pushed to stack 0 onwards
        public Stack() { }
        public Stack(T inp)
        {
            this.Push(inp);
        }
        public Stack(T[] inp)
        {
            foreach (T a in inp) { Push(a); }
        }

        //adds an item to the top of the stack
        public void Push(T inp)
        {
            stack.Add(inp);
        }

        //gets top item without removing it
        public T Peek()
        {
            T ret = default;
            //checks stack isn't empty
            if (stack.Count() > 0)
            {
                ret = stack[stack.Count() - 1];
            }
            return ret;
        }

        //returns top item on the stack and removes it
        public T Pop()
        {
            T ret = default;
            //checks stack isn't empty
            if (stack.Count() > 0)
            {
                ret = stack.RemoveAt(stack.Count() - 1);
            }
            return ret;
        }

        public bool Contains(T inp)
        {
            //stacks are so similar to lists you can just do stuff like this??
            return stack.Contains(inp);
        }

        //returns number of items in the stack
        public int Count()
        {
            return stack.Count();
        }

        public bool isEmpty()
        {
            bool empty = false;
            if (stack.Count() == 0)
            {
                empty = true;
            }
            return empty;
        }

        public string representation()
        {
            string ret = "";

            for (int x = 0; x < stack.Count(); x++)
            {
                ret = ret + stack[x] + ",";
            }

            return ret;
        }
    }
}
