using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevatorApp
{
    public partial class Form1 : Form
    {
        private int currentFloor = 1;
        private string currentState = "Stopped"; // Initial state
        private string imagesPath = @"C:\Users\martin aguila\source\repos\ElevatorApp\assets"; // Path to your images
        private string imageState = "";

        public Form1()
        {
            InitializeComponent();
            UpdateStatus();
            // DisplayDiagram();
        }

        private void UpdateStatus()
        {
            label1.Text = $"Current Floor: {currentFloor}, State: {currentState}";
        }

        private void DisplayDiagram()
        {
            string imagePath = System.IO.Path.Combine(imagesPath, $"{imageState}.jpg");
            if (System.IO.File.Exists(imagePath))
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show($"Diagram image not found: {imagePath}");
            }
        }

        // State: Moving Up
        private void MovingUp()
        {
            currentState = "Moving Up";
            UpdateStatus();
            // Add any actions specific to this state
        }

        // State: Moving Down
        private void MovingDown()
        {
            currentState = "Moving Down";
            UpdateStatus();
            // Add any actions specific to this state
        }

        // State: Stopped
        private void Stopped()
        {
            currentState = "Stopped";
            UpdateStatus();
            // Add any actions specific to this state
        }

        // Handle "Go Up" button click
        private void button1_Click(object sender, EventArgs e)
        {
            if (currentState == "Stopped" || currentState == "Moving Down")
            {
                currentFloor++;
                if (currentFloor < 4)
                {
                    MovingUp();
                    UpdateStatus();

                    if (currentFloor == 2)
                    {
                        imageState = "oneToTwo";
                        DisplayDiagram();
                    } else if (currentFloor == 3)
                    {
                        imageState = "twoToThree";
                        DisplayDiagram();
                    }
                    else if (currentFloor == 4)
                    {
                        imageState = "threeToFour";
                        DisplayDiagram();
                    }
                }
                else if (currentFloor == 4)
                {
                    imageState = "threeToFour";
                    DisplayDiagram();
                }
                else 
                {
                    MessageBox.Show("Already at the top floor.");
                }
            }
            else if (currentState == "Moving Up")
            {
                // MessageBox.Show("Elevator is already moving up.");
            }
        }

        // Handle "Go Down" button click
        private void button2_Click(object sender, EventArgs e)
        {
            if (currentState == "Stopped" || currentState == "Moving Up")
            {
                currentFloor--;
                if (currentFloor > 1)
                {
                    MovingDown();
                    UpdateStatus();

                    if (currentFloor == 3)
                    {
                        imageState = "fourToThree";
                        DisplayDiagram();
                    } else if (currentFloor == 2)
                    {
                        imageState = "threeToTwo";
                        DisplayDiagram();
                    } else if (currentFloor == 1)
                    {
                        imageState = "twoToOne";
                        DisplayDiagram();
                    }
                }
                else if (currentFloor == 1)
                {
                    imageState = "twoToOne";
                    DisplayDiagram();
                }
                else
                {
                    MessageBox.Show("Already at the bottom floor.");
                }
            }
            else if (currentState == "Moving Down")
            {
                // MessageBox.Show("Elevator is already moving down.");
            }
        }

        // Handle "Stop" button click
        private void button3_Click(object sender, EventArgs e)
        {
            Stopped();
            // MessageBox.Show("Elevator stopped.");
        }

        // Handle "Close" button click
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
