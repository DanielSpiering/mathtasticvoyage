using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathtasticVoyage {
    class Node<T> {
        //fields
        private T _data;
        private Node<T> _next;

        //props
        public T Data {
            get { return _data; }
            set { _data = value; }
        }//end property
        public Node<T> Next {
            get { return _next; }
            set { _next = value; }
        }//end property

        //constructors
        public Node(T new_data) {
            _data = new_data;
        }//end constructor

        public Node() {
            _data = default;
        }//end constructor
    }//end class
}//end namespace
