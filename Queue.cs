using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathtasticVoyage {
    class Queue<T> {
        private int _length;
        private bool _isEmpty;
        private Node<T> _head;
        private Node<T> _tail;

        public int Length {
            get { return _length; }
        }//end property     
        public bool IsEmpty {
            get { return _isEmpty; }
            set { _isEmpty = value; }
        }//end property
        public void Enqueue(T data) {
            if (_head == null) {//then
                _head = new Node<T>(data);
                _tail = _head;
            } else {
                _tail.Next = new Node<T>(data);
                _tail = _tail.Next;
            }//end if
            _length += 1;

        }//end method
        public void Dequeue() {
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
        }//end Dequeue
        public void Clear() {
            while (_head != null) {
                Dequeue();
            }//end while
            _isEmpty = true;
        }//end clear
        public T Peek() {
            return _head.Data;
        }//end Peek
        override public string ToString() {
            //initialize string with opening bracket
            string listContents = "";
            //set current node to head
            Node<T> currentNode = _head;
            //walk through the nodes and add to the string
            while (currentNode != null) {
                if (currentNode.Next != null) {
                    listContents += currentNode.Data.ToString() + " ";
                   
                } else {
                    //when last node is reached add it to string without comma
                    listContents += currentNode.Data.ToString();
                }//end if
                currentNode = currentNode.Next;
            }//end while

            //add closing bracket
            //listContents += "]";
            //return a string listing all data in the list
            return listContents;

        }//end ToString
    }//end class
}//end namespace
