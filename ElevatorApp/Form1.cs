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

        public Form1()
        {
            InitializeComponent();
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            label1.Text = $"Current Floor: {currentFloor}, State: {currentState}";
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
                if (currentFloor < 4)
                {
                    MovingUp();
                    currentFloor++;
                    UpdateStatus();
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
                if (currentFloor > 1)
                {
                    MovingDown();
                    currentFloor--;
                    UpdateStatus();
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
    }
}
