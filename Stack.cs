using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathtasticVoyage {
    class Stack<T> {
        private Node<T> _head;
        private Node<T> _tail;
        private int _length;
        public int Length {
            get { return _length; }
        }//end property       
        public Stack() {
            _head = null;
            _tail = null;
        }//end constructor
        public Stack(T new_data) {
            _head = new Node<T>(new_data);
            _tail = _head;
        }//end constructor        
        override public string ToString() {
            LinkedList<T> tempList = new LinkedList<T>();
            Node<T> currentNode = new Node<T>();
            //set current node to head
            currentNode = _head;

            //initialize new string 
            string listContents = "";

            //for 1 element stack add to list
            if (currentNode.Next == null) {
                tempList.Add(currentNode.Data);
            }//end if

            //for multielement stack walk it and add to list
            while (currentNode.Next != null) {
                tempList.Add(currentNode.Data);
                currentNode = currentNode.Next;

                //add final element to list
                if (currentNode.Next == null) {
                    tempList.Add(currentNode.Data);
                }//end if                  
            }//end while

            //walk the list backwards and add to string
            for (int index = tempList.Length - 1; index >= 0; index--) {
                listContents += tempList[index].ToString() + " ";
            }//end for

            //add pointer
            listContents += "<--Top";

            //return a string listing all data in the list
            return listContents;
        }//end ToString
        public void Push(T new_data) {
            if (_head == null) {//then
                _head = new Node<T>(new_data);
                _tail = _head;
            } else {
                Node<T> new_node = new Node<T>(new_data);
                new_node.Next = _head;
                _head = new_node;
            }//end if
            _length += 1;
        }//end Push
        public T Pop() {
            T popData;
            if (_head == null) {
                throw new Exception("This stack is already empty.");
            } else {
                Node<T> new_node = new Node<T>();
                new_node = _head;
                popData = _head.Data;
                _head = _head.Next;
                new_node = null;

            }//end if
            _length -= 1;
            return popData;
        }//end Pop
        public T Peek() {
            return _head.Data;
        }//end Peek
        public void Clear() {
            while (_head != null) {
                //store reference to original head of list
                Node<T> tempNode = _head;
                //handle cases of small lists
                if (_length == 0) {
                    return;
                } else if (Length == 1) {
                    _head = null;
                    _length -= 1;
                    return;
                }//end if
                 //update head with the next node down from original head
                _head = _head.Next;
                //remove original head
                tempNode = null;
                _length -= 1;
            }//end while                 
        }//end Clear
    }//end class
}//end namespace
