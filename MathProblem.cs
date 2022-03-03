using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mathtasticVoyage {
    class MathProblem {
        private string _infixProblem;
        private string _postfixProblem;
        private double _correctAnswer;
        private double _userAnswer;
        private bool _isCorrect;
        
        
        //create new stack
        Stack<string> newStack = new Stack<string>();
        public bool IsCorrect {
            get { return _isCorrect; }
           
        }//end property
        public double CorrectAnswer {
            get { return _correctAnswer; }
            
        }//end property
        public double UserAnswer {
            get { return _userAnswer; }
            set { _userAnswer = value; 
                  _isCorrect= _correctAnswer == _userAnswer;
            }
        }//end property
        public string InfixProblem {//using the infix problem convert to postfix and calculate the correct answer
            get { return _infixProblem; }
            set { _infixProblem = value;
                _postfixProblem = InfixToPostfixConvert(_infixProblem);
                _correctAnswer = SolveProblem(_postfixProblem);
                _isCorrect = _correctAnswer == _userAnswer;
            }//end set
        }//end property
              
        
        private string InfixToPostfixConvert(string infixBuffer) {
            int priority = 0;
            //initialize string to hold postfix equation
            string postfixBuffer = "";     
            //split infix equation on spaces and store to array
            string[] stringArray = infixBuffer.Split(' ');
            //initialize a new stack
            Stack<string> newStack = new Stack<string>();

            //run through each element of the array
            for (int index = 0; index < stringArray.Length; index++) {
                //store the element at the index to a new variable
                string element = stringArray[index];

                if (element == "+" || element == "-" || element == "*" || element == "/") {//check for operator

                    // check the precedence
                    if (newStack.Length <= 0) {//if the stack is empty push on the element
                        newStack.Push(element);
                    } else {//if the stack is not empty check the priority
                        if (newStack.Peek() == "*" || newStack.Peek() == "/") {//multiplication and division have higher priority than addition and subtraction 
                            priority = 1;
                        } else {
                            priority = 0;
                        }//end if

                        if (priority == 1) {
                            if (element == "+" || element == "-") {//if the current element of the array is + or - pop off the top of the stack and add operator to postfix string
                                postfixBuffer += newStack.Pop() + " ";
                                index--;
                            } else { // or if the current element is * or / do the same
                                postfixBuffer += newStack.Pop() + " ";
                                index--;
                            }//end if
                        } else {
                            if (element == "+" || element == "-") {//with a lower priority operator as current element pop the top of the stack and add to postfix string then push current element onto the stack
                                postfixBuffer += newStack.Pop() + " ";
                                newStack.Push(element);
                            } else {//with a higher priority operator as current element push it onto stack
                                newStack.Push(element);
                            }//end if
                        }//end if
                    }//end if
                } else {//if element is not an operator
                    if (postfixBuffer == "") {//if the postfix string is empty add the first operand with a space after
                        postfixBuffer += element + " ";
                    } else {//if postfix string isnt empty 

                        if (index == stringArray.Length) {//if we're at the end of the string array add the operand with no space
                            postfixBuffer += element;
                        } else {//if we're not at the end of the string array add the operand with a space after
                            postfixBuffer += element + " ";
                        }//end if
                    }//end if

                }//end if
            }//end for

            int length = newStack.Length;//check size of stack

            for (int index = 0; index < length; index++) {

                if (newStack.Length == 1) {//if the stack is only 1 tall add the operator to the postfix string
                    postfixBuffer += newStack.Pop();
                } else {//if the stack is taller than 1 add the operator to the postfix string with a space after
                    postfixBuffer += newStack.Pop() + " ";
                }//end if
            }//end for
            return postfixBuffer;
        }//end converter
        private double SolveProblem(string inputString) {
            
            //split string on spaces and store to array
            string[] stringArray = inputString.Split(' ');

            for (int index = 0; index < stringArray.Length; index++) {
                //as we walk the array check to see if the current index is an operator or operand
                if (IsOperator(stringArray[index]) == true) {//if operator perform the required operation
                    Operate(stringArray[index]);

                } else {//if operand add to stack
                    newStack.Push(stringArray[index]);
                    //lsbListBox.Items.Add("After Push: " + newStack.ToString());
                }//end if               
            }//end for
            //return final result
            return double.Parse(newStack.Peek());
        }//end SolveProblem
        private static bool IsOperator(string symbol) {
            if (symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/") {
                return true;
            } else {
                return false;
            }//end if        
        }//end IsOperator
        private void Operate(string symbol) {
            //pop the first 2 operands from the stack and store their values to variables                                 
            double num2 = double.Parse(newStack.Pop());
            double num1 = double.Parse(newStack.Pop());

            //depending on the operator call the required method and push result onto stack
            if (symbol == "+") {

                double result = Add(num1, num2);
                newStack.Push(result.ToString());
                //lsbListBox.Items.Add("After Addition: " + newStack.ToString());

            } else if (symbol == "-") {

                double result = Subtract(num1, num2);
                newStack.Push(result.ToString());
                //lsbListBox.Items.Add("After Subtraction: " + newStack.ToString());

            } else if (symbol == "*") {

                double result = Multiply(num1, num2);
                newStack.Push(result.ToString());
                //lsbListBox.Items.Add("After Multiplication: " + newStack.ToString());

            } else if (symbol == "/") {

                double result = Divide(num1, num2);
                newStack.Push(result.ToString());
                //lsbListBox.Items.Add("After Division: " + newStack.ToString());
            }//end if                               
        }//end Operate
        private double Add(double num1, double num2) {
            return num1 + num2;
        }//end method
        private double Subtract(double num1, double num2) {
            return num1 - num2;
        }//end method
        private double Divide(double num1, double num2) {
            return num1 / num2;
        }//end method
        private double Multiply(double num1, double num2) {
            return num1 * num2;
        }//end method

    }//end class
}//end namespace
