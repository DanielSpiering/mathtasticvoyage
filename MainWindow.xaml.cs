using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace mathtasticVoyage {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            string fileName = "E:\\coding projects\\mathtasticVoyage.txt";
            ReadFile(fileName);            
            QueueProblems();                        
        }
        //initialize a queue of the MathProblem class
        Queue<MathProblem> newQueue = new Queue<MathProblem>();
        

        private void  ReadFile(string fileName) {//read from the file of math problems
            
            StreamReader inFile = new StreamReader(fileName);
            if (inFile.EndOfStream == true) {//if file is empty throw exception
                throw new Exception("this file is empty");
            }//end if

            //send problems from the file to the MathProblem class
            while (inFile.EndOfStream == false) {
                //initialize MathProblem class
                MathProblem newProblem = new MathProblem();
                //send each problem one at a time to the InfixProblem variable in the MathProblem class
                newProblem.InfixProblem=inFile.ReadLine();
                //send this instance of MathProblem class to the queue of math problems
                newQueue.Enqueue(newProblem);                             
            }//end while
            //close file
            inFile.Close();        
        }//end ReadFile

        //initialize a new instance of MathProblem class
        MathProblem newProblem = new MathProblem();
        private void QueueProblems() {//send problems one at a time to the form
                                      
            //peek at the first MathProblem in your queue then save to the new MathProblem instance
            newProblem = newQueue.Peek();
            //add the problem to the form    
            lsbMathProblems.Items.Add(newProblem.InfixProblem);
            //add the problem to the answer label to show which equation is being answered
            lblEquation.Content = newProblem.InfixProblem + " = ";        
        }//end QueuedProblems

        //set up variables to calculate percentage of correct answers
        double correct = 0.0;           
        double total = 0.0;
        private void btnSubmit_Click(object sender, RoutedEventArgs e) {
            //send user answer to MathProblem
            newProblem.UserAnswer = double.Parse(txtAnswer.Text);
            
            
            //compare the user answer to the correct answer then add the equation to either the correct or incorrect box
            if (newProblem.IsCorrect==true) {
                lsbCorrect.Items.Add(newProblem.InfixProblem + " = " + newProblem.UserAnswer);
                correct += 1;
                total += 1;
            } else {
                lsbIncorrect.Items.Add(newProblem.InfixProblem + " = " + newProblem.UserAnswer);             
                total += 1;
            }//end if

            //dequeue the first MathProblem from the queue of MathProblems
            newQueue.Dequeue();

            if (newQueue.Length != 0) {//if the queue of MathProblems is not empty continue queueing the problems into the form
                QueueProblems();
            } else {
                while (lsbMathProblems.Items.Count > 0) {//when the queue of MathProblems is empty remove all problems from the initial form
                    lsbMathProblems.Items.RemoveAt(0);
                }//end while
                //calculate percentage of correct answers and add to the form
                double percent = correct / total;
                lsbMathProblems.Items.Add($"You got {percent:P} of questions correct.");
            }//end if                                                   
        }//end event

    }//end class
}//end namespace
