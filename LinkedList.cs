using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathtasticVoyage {
    class LinkedList<T> {
        private Node<T> _head;
        private Node<T> _tail;
        private int _length;
        //indexer
        public T this[int index] {
            get { return Get(index); }
            set { Set(index, value); }
        }//end indexer
        public int Length {
            get { return _length; }
        }//end property     
        public LinkedList() {
            _head = null;
            _tail = null;
        }//end constructor
        public LinkedList(T new_data) {
            _head = new Node<T>(new_data);
            _tail = _head;
        }//end constructor
        public void Add(T new_data) {
            if (_head == null) {//then
                _head = new Node<T>(new_data);
                _tail = _head;
            } else {
                _tail.Next = new Node<T>(new_data);
                _tail = _tail.Next;
            }//end if
            _length += 1;
        }//end method
        public void Remove(int nodeNumber) {
            //set current node to head
            Node<T> currentNode = _head;

            //step through nodes until we get to the specified node
            for (int index = 0; index < nodeNumber; index++) {
                currentNode = currentNode.Next;
            }//end for

            //set specified node to new variable
            Node<T> deleteNode = currentNode;

            //reset current node to head 
            currentNode = _head;

            //step through nodes until we get to the one before the specified node
            for (int index = 0; index < nodeNumber - 1; index++) {
                currentNode = currentNode.Next;
            }//end for

            //set that node's .Next to the .Next of the node directly after the specified node
            currentNode.Next = currentNode.Next.Next;

            //delete the specified node
            deleteNode = null;
            _length -= 1;
        }//end remove
        public void InsertFront(T new_data) {
            Node<T> new_node = new Node<T>(new_data);
            new_node.Next = _head;
            _head = new_node;
            _length += 1;
        }//end method
        public T Get(int target_index) {
            int current_index = 0;
            //start at head
            Node<T> current_node = _head;
            //traverse list until the end
            while (current_node != null) {
                //if found return
                if (current_index == target_index) {
                    return current_node.Data;
                }//end if
                //go to next node and increment index
                current_node = current_node.Next;
                current_index += 1;
            }//end while
            //if not in list throw exception
            throw new IndexOutOfRangeException("index[" + target_index + "] is not present in this linked list");
        }//end method       
        public void Set(int target_index, T new_data) {
            int current_index = 0;
            bool found = false;
            //start at head of list
            Node<T> current_node = _head;
            //traverse list while not at end and node not yet found
            while (current_node != null && found == false) {
                //if found return
                if (current_index == target_index) {
                    current_node.Data = new_data;
                    found = true;
                }//end if
                //go to next node and increment index
                current_node = current_node.Next;
                current_index += 1;
            }//end while
            //if not in list throw exception
            if (found == false) {//then
                throw new IndexOutOfRangeException("index[" + target_index + "] is not present in this linked list");
            }//end if 

        }//end method
        override public string ToString() {
            //initialize string with opening bracket
            string listContents = "[";
            //set current node to head
            Node<T> currentNode = _head;
            //walk through the nodes and add to the string
            while (currentNode != null) {
                if (currentNode.Next != null) {
                    listContents += currentNode.Data.ToString() + ",";
                } else {
                    //when last node is reached add it to string without comma
                    listContents += currentNode.Data.ToString();
                }//end if
                currentNode = currentNode.Next;
            }//end while

            //add closing bracket
            listContents += "]";
            //return a string listing all data in the list
            return listContents;

        }//end ToString
        public int GetNumberOfNodes() {
            int nodeNumberList = 0;
            //start at rhe head node
            Node<T> currentNode = _head;
            //jump through the nodes and count each one
            while (currentNode.Next != null) {
                currentNode = currentNode.Next;
                nodeNumberList += 1;
            }//end while
            //add one more to count the head node
            nodeNumberList += 1;
            //return the number of nodes in the list
            return nodeNumberList;
        }//end GetNumberOfNodes
        public void RemoveRear(int nodeListLength) {
            //start at head of list
            Node<T> currentNode = _head;
            if (_length == 0) {
                return;
            } else if (_length == 1) {
                _head = null;
                _length -= 1;
                return;
            }//end if
            //find node just before last node
            while (currentNode.Next.Next != null) {
                currentNode = currentNode.Next;
            }//end while
            //remove last node
            currentNode.Next = null;
            _length -= 1;

        }//end RemoveRear
        public void RemoveFront() {
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
        }//end RemoveFront
        public void Clear() {
            while (_head != null) {
                RemoveFront();
            }//end while                   
        }//end clear
        public int IndexOf(object searchData) {//ask about comparing objects
            //start at head of list
            Node<T> currentNode = _head;

            //step through each node until you find what youre looking for and return the index position
            for (int index = 0; index < _length; index++) {
                if (currentNode.Data.ToString() == searchData.ToString()) {
                    return index;
                }//end if
                currentNode = currentNode.Next;
            }//end for
            //if you dont find what youre looking for return -1
            return -1;
        }//end IndexOf
        public void BuildFromArray(T[] buildArray) {
            Clear();
            for (int index = 0; index < buildArray.Length; index++) {
                Add(buildArray[index]);
            }//end for
        }//end BuildFromArray
        public void RemoveObject(object searchData) {
            //set current node to head
            Node<T> currentNode = _head;

            //step through each node until you find what youre looking for
            for (int index = 0; index < _length; index++) {

                if (currentNode.Data.ToString() == searchData.ToString() && index == 0) {
                    RemoveFront();
                    return;
                } else if (currentNode.Data.ToString() == searchData.ToString() && index == _length - 1) {
                    RemoveRear(_length);
                    return;
                } else if (currentNode.Data.ToString() == searchData.ToString()) {
                    Remove(index);
                    return;
                }//end if
                currentNode = currentNode.Next;
            }//end for  
        }//end RemoveObject
        public void Insert(int insertIndex, T element) {
            //exception if list is empty
            if (insertIndex > _length) {
                throw new Exception($"The list is not that long. It has a length of {_length}.");
            }//end if
            //make new node and populate with data
            Node<T> insertNode = new Node<T>();
            insertNode.Data = element;
            //make a new node to hold the node in the position where we will be inserting  
            Node<T> tempHead = new Node<T>();
            Node<T> tempTail = new Node<T>();

            //start at head of list
            Node<T> currentNode = _head;

            if (insertIndex == 0) {
                tempTail = currentNode;
                currentNode = insertNode;
                currentNode.Next = tempTail; ;

            } else {
                //run through until you get to the specified index
                for (int index = 0; index < insertIndex; index++) {
                    if (index == insertIndex - 1) {
                        tempTail = currentNode;
                        //currentNode = currentNode.Next;
                    }//end if
                    currentNode = currentNode.Next;
                }//end for
                 //set the current node to a temp node
                tempHead = currentNode;
                //set current node's next to the new node being inserted
                tempTail.Next = insertNode;
                //set new node's next to the node we are pushing back in the list
                insertNode.Next = tempHead;
            }//end if

            //add 1 to length
            _length += 1;
        }//end Insert
        public bool Contains(object searchData) {
            //start at head of list
            Node<T> currentNode = _head;

            //step through each node until you find what youre looking for and return true
            for (int index = 0; index < _length; index++) {
                if (currentNode.Data.ToString() == searchData.ToString()) {
                    return true;
                }//end if
                currentNode = currentNode.Next;
            }//end for
            //if you dont find what youre looking for return false
            return false;
        }//end Contains
        public object GetFirst() {
            //exception if list is empty
            if (_length == 0) {
                throw new Exception($"This list is currently empty.");
            }//end if
            return _head.Data;
        }//end GetFirst
        public object GetLast() {
            //exception if list is empty
            if (_length == 0) {
                throw new Exception($"This list is currently empty.");
            }//end if
            //step through list until you reach the end
            Node<T> currentNode = _head;
            for (int index = 0; index < _length - 1; index++) {
                currentNode = currentNode.Next;
            }//end for

            return currentNode.Data;
        }//end GetLast
        public int GetCountOf(object searchData) {
            int elementCount = 0;
            //start at head of list
            Node<T> currentNode = _head;

            //step through each node until you find what youre looking for 
            for (int index = 0; index < _length; index++) {
                if (currentNode.Data.ToString() == searchData.ToString()) {
                    elementCount += 1;
                }//end if
                currentNode = currentNode.Next;
            }//end for

            //decide what to return based on element count
            if (elementCount == 0) {
                return -1;
            } else {
                return elementCount;
            }//end if

        }//end GetCountOf
        public object RemoveFirst() {
            //exception if list is empty
            if (_length == 0) {
                throw new Exception($"This list is currently empty.");
            }//end if
            //store reference to original head of list
            Node<T> tempNode = _head;
            object temp = _head.Data;

            //handle cases of small lists            
            if (Length == 1) {
                _head = null;
                _length -= 1;
                return temp;
            }//end if
            //update head with the next node down from original head
            _head = _head.Next;
            //remove original head
            tempNode = null;
            _length -= 1;
            return temp;
        }//end RemoveFirst
        public object RemoveLast() {
            //exception if list is empty
            if (_length == 0) {
                throw new Exception($"This list is currently empty.");
            }//end if
            //start at head of list
            Node<T> currentNode = _head;
            object temp = _head.Data;
            if (_length == 1) {
                _head = null;
                _length -= 1;
                return temp;
            }//end if
            //find node just before last node
            while (currentNode.Next.Next != null) {
                currentNode = currentNode.Next;
            }//end while
            object temp2 = currentNode.Next.Data;
            //remove last node
            currentNode.Next = null;
            _length -= 1;
            return temp2;
        }//end RemoveLast
        public bool RemoveValue(object searchData) {
            //set current node to head
            Node<T> currentNode = _head;

            //step through each node until you find what youre looking for
            for (int index = 0; index < _length; index++) {

                if (currentNode.Data.ToString() == searchData.ToString() && index == 0) {
                    RemoveFront();
                    return true;
                } else if (currentNode.Data.ToString() == searchData.ToString() && index == _length - 1) {
                    RemoveRear(_length);
                    return true;
                } else if (currentNode.Data.ToString() == searchData.ToString()) {
                    Remove(index);
                    return true;
                }//end if
                currentNode = currentNode.Next;
            }//end for
            return false;
        }//end RemoveValue
        public bool RemoveAll(object searchData) {
            int removed = 0;
            //set current node to head
            Node<T> currentNode = _head;
            //step through each node until you find what youre looking for
            for (int index = 0; index < _length; index++) {

                if (currentNode.Data.ToString() == searchData.ToString() && index == 0) {//if front node
                    RemoveFront();
                    removed += 1;
                } else if (currentNode.Data.ToString() == searchData.ToString() && index == _length - 1) {//if rear node
                    RemoveRear(_length);
                    removed += 1;
                } else if (currentNode.Data.ToString() == searchData.ToString()) {//if middle node
                    Remove(index);
                    removed += 1;
                }//end if
                if (removed > 0) {

                } else {
                    currentNode = currentNode.Next;
                }//end if
            }//end for

            //return value based on removed count
            if (removed > 0) {
                return true;
            } else {
                return false;
            }//end if

        }//end RemoveAll
        public object[] ToArray() {
            //set up array
            object[] newArray = new object[_length];
            //set current node to head
            Node<T> currentNode = _head;
            //step through nodes and add to array
            for (int index = 0; index < _length; index++) {
                newArray[index] = currentNode.Data;
                currentNode = currentNode.Next;
            }//end for

            return newArray;
        }//end ToArray
        public static LinkedList<T> operator +(LinkedList<T> l1, LinkedList<T> l2) {
            LinkedList<T> newList = new LinkedList<T>();
            Node<T> headNode = new Node<T>();
            Node<T> tailNode = new Node<T>();
            int newLength = l1.Length + l2.Length;
            headNode = l1._head;
            tailNode = l2._head;

            for (int index = 0; index < newLength; index++) {
                if (headNode != null) {
                    newList.Add(headNode.Data);
                    headNode = headNode.Next;
                } else if (tailNode != null) {
                    newList.Add(tailNode.Data);
                    tailNode = tailNode.Next;
                }//end if
            }//end for
            return newList;
        }//end Operator
        public static bool operator ==(LinkedList<T> l1, LinkedList<T> l2) {
            bool same = l1 == l2;
            return same;
        }//end operator
        public static bool operator !=(LinkedList<T> l1, LinkedList<T> l2) {
            bool same = l1 != l2;
            return same;
        }//end operator

    }//end class
}//end namespace
