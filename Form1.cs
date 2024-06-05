using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI_Automated_Computing_cs4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            myObj.Name = txtName.Text;
            Console.WriteLine(myObj.Name);
            inhe.greetings();
            poly.give_advice();
            inhe.give_thanks();
        }


        // Encapsulation / the value is access through form1 load
        class Person 
        {
            private string name; // access modifier private
            public string Name   // property
            {
                get { return name; } //getmethod
                set { name = value; } //setmethod
            }
        }
        Person myObj = new Person(); // Object


        // Inheritance & Polymorphism
        public class Reminder //Parent Class
        {
            public Reminder()
            {

            }

            public void greetings()
            {
                Console.WriteLine("Magandang Umaga Kapatid! \n");
            }

            public virtual void give_advice() //using virtual
            {
                Console.WriteLine("Your so beautiful!");
            }
            public  void give_thanks()
            {
                Console.WriteLine("Maraming Salamat po! \n \n \n");
            }
        }
        public class Poly : Reminder // this is a example of polymorphism using Poly as child class
        {
            public override void give_advice() //using override
            {
                Console.WriteLine("     Mahalagang Paalala! Ang pagkain ng vegetable at frutas ay makakatulong upang magkaroon ng malusog na pangangatawan. " +
                    "Sabayan mo pa ito ng ehersisyo para sa katibayan ng buto-buto \n");
            }
        }
        public class Inhe : Reminder // this is a example of inheritance using Inhe as child class
        {
           
        }
        Poly poly = new Poly(); // Object for polymorphism
        Inhe inhe = new Inhe(); // Object for inheritance


        //Abstraction
        abstract class Classifieds
        {
            public abstract void value();
        }
        class Normal : Classifieds //Normal is a child class
        {
            public override void value()
            {
                Console.WriteLine("Reminder:   Congrats! you made it, Maintain your health and be more productive fighting \n");
            }
        }
        class Underwieght : Classifieds //Underwieght is a child class
        {
            public override void value()
            {
                Console.WriteLine("Reminder:   Kindly, do eating healthy foods with perfect exercise for you to become healthy \n");
            }
        }
        class Overwieght : Classifieds //Overwieght is a child class
        {
            public override void value()
            {
                Console.WriteLine("Reminder:   You Can Do It, Exercise for the better ..Goodluck \n");
            }
        }
        class Obese : Classifieds //Obese is a child class
        {
            public override void value()
            {
                Console.WriteLine("Reminder:   Get out the bet and Go to the Gym King \n");
            }
        }
        Classifieds normal = new Normal(); // Object
        Classifieds underwieght = new Underwieght(); // Object
        Classifieds overwieght = new Overwieght(); // Object
        Classifieds obese = new Obese(); // Object


        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtAge_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtHeight.Text = "";
            txtWeight.Text = "";
            txtResult.Text = "";
        }

        public void btnCalculate_Click(object sender, EventArgs e)
        {   
            //using if else statement to validate the value of textbox
            if(txtName.Text != " " & txtAge.Text != "" & txtHeight.Text != "" )
            {
                double height = (Convert.ToDouble(txtHeight.Text)); // fields
                double weight = (Convert.ToDouble(txtWeight.Text)); // fields

                Classification myObj = new Classification(" Classification: Underweigth", " Classification: Normalweight", " Classification: Overweight", " Classification: Obese");// Create an object of the Classification Class (this will call the constructor)
                
                txtResult.Text += "BMI: ";
                txtResult.Text += Calculate(height, weight);

                if (Calculate(height, weight) <= 18)
                {
                    txtResult.Text += "\n" + myObj.Uw;
                    underwieght.value();
                }
                else if (Calculate(height, weight) <= 24.9)
                {
                    txtResult.Text += "\n" + myObj.N;
                    normal.value();
                }
                else if (Calculate(height, weight) <= 30)
                {
                    txtResult.Text += "\n" + myObj.Ov;
                    overwieght.value();
                }
                else if(Calculate(height, weight) >= 31)
                {
                    txtResult.Text += "\n" + myObj.Ob;
                    obese.value();
                }
            }
            else
            {
                MessageBox.Show("Please Fill up the Form", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // method with return value
        public double Calculate(double height, double weight) 
        {
            double result = weight / (height * height);
            return result;
        }

        // class
        class Classification 
        {
            // class members using "public" access modifiers
            public String Uw; // class fields
            public String N; // class fields
            public String Ov; // class fields
            public String Ob;

            // Create a class constructor with multiple parameters
            public Classification(String setUw, String setN, String setOv, String setOb)
            {
                Uw = setUw;
                N = setN;
                Ov = setOv;
                Ob = setOb;
            }
        }       
    }
}

