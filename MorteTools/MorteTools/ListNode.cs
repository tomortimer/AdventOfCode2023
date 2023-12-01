namespace MorteTools
{
    public class ListNode<T>
    {
        private T data;
        public ListNode<T> next = null;

        //constructor
        public ListNode(T inp)
        {
            data = inp;
        }

        //get set methods
        public T GetData() { return data; }
        public void SetData(T inp) { data = inp; }
    }
}
