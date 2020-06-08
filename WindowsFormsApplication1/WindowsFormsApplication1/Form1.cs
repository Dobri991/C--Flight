using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tickets;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        //Lists
        private StreamReader inFile;
        List<Flight> flightsList = new List<Flight>();
        List<Ticket> ticketsList = new List<Ticket>();
        List<Passenger> passengersList = new List<Passenger>();

        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Textbox Check
            if (textBox1.Text == "")
            {
                MessageBox.Show("Write in Textbox!");
                return;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Textbox Check
            if (textBox2.Text == "")
            {
                MessageBox.Show("Write in Textbox!");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Check cells
            bool ticketInfo = false;
            if (!label17.Visible || textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                ticketInfo = true;
                MessageBox.Show("Please complete all fields\n(Create a new flight first)");
            }
            //Save Information
            if (!ticketInfo)
            {
                Random random = new Random();
                Passenger passenger = new Passenger(textBox1.Text, textBox2.Text);

                Flight flight = new Flight();

                string type = label17.Text.Substring(0, 7);
                string takeOff = label17.Text.Substring(label17.Text.LastIndexOf(" ") + 1, 3);
                string landing = label17.Text.Substring(label17.Text.LastIndexOf("-") + 1);

                foreach (Flight product in flightsList)
                {
                    if (product.TakeOff == takeOff && product.Landing == landing && product.TakeOffDate == monthCalendar1.SelectionRange.Start)
                    {
                        flight.FlightID = product.FlightID;
                        flight.TakeOff = product.TakeOff;
                        flight.Landing = product.Landing;
                        flight.Stopover = product.Stopover;
                        flight.AirlineType = product.AirlineType;
                        flight.Passengers = product.Passengers;
                        flight.Rows = product.Rows;
                        flight.Meal = product.Meal;
                        flight.TakeOffDate = product.TakeOffDate;
                        flight.LandingDate = product.LandingDate;
                    }
                    break;
                }
                //Text Files & Check
                Ticket ticket = new Ticket(flight, random.Next(), type, passenger, monthCalendar1.SelectionRange.Start,
                    int.Parse(comboBox1.SelectedItem.ToString()), char.Parse(comboBox2.SelectedItem.ToString()));

                ticketsList.Add(ticket);
                passengersList.Add(passenger);

                string way = @"../../../Tickets.txt";

                if (!File.Exists(way))
                {
                    //Text File paths & Validation
                    using (StreamWriter sw = File.AppendText(way))
                    {
                        sw.WriteLine("Tickets Information");

                    }
                }
                using (StreamWriter sw = File.AppendText(way))
                {
                    sw.WriteLine(ticket.DisplayInfo() + "\n");

                }

                string path = @"../../../Passengers.txt";

                if (!File.Exists(path))
                {

                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("Passenger Information");

                    }
                }
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("Name: " + passenger.FirstName + "\n" + "Last Name: " + passenger.LastName);

                }
                //Display after validation
                MessageBox.Show("Sent to file!");

                comboBox3.Items.Add(passenger.FirstName + " " + passenger.LastName);
            }

            label19.Text = File.ReadAllText(@"../../../Flights.txt");
        }


        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Label17 display
            if (this.toolStripComboBox2.Selected)this.label17.Text = this.onewayToolStripMenuItem.Text + " " + this.toolStripComboBox2.SelectedItem.ToString();
            this.label17.Visible = true;
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Label17 display
            if (this.toolStripComboBox1.Selected)this.label17.Text = this.twowayToolStripMenuItem.Text + " " + this.toolStripComboBox1.SelectedItem.ToString();
            this.label17.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Read from text files
            string inValue;
            if (File.Exists(@"../../../Passengers.txt"))
            {
                    inFile = new StreamReader(@"../../../Passengers.txt");

                    while ((inValue = inFile.ReadLine()) != null)
                    {
                        listBox1.Items.Add(inValue);
                    }
                    inFile = null;

                    inFile = new StreamReader(@"../../../Flights.txt");

                    while ((inValue = inFile.ReadLine())!=null){
                        label19.Text += inValue;
                        label19.Text += "\n";
                    }
                    inFile.Close();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(2);
        }

        private void passengersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectTab(0);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Check comboboxes
            bool flightInfo = false;
            if (textBox3.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || comboBox6.Text == "" || comboBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || comboBox8.Text == "")
            {
                flightInfo = true;
                MessageBox.Show("Please complete all fields\n(Create a new flight first)");
            }
            //Check Passenger & limit
            if (!flightInfo)
            {
                int display;
                if (!int.TryParse(this.textBox8.Text, out display) || (int.TryParse(this.textBox8.Text, out display) &&
                    int.Parse(this.textBox8.Text) < 1 || int.Parse(this.textBox8.Text) > 300))
                {
                    MessageBox.Show("Enter a number between 1 to 300");
                    textBox8.Text = "";
                }
                //Check row & limit
                int display1;
                if (!int.TryParse(this.textBox9.Text, out display1) || (int.TryParse(this.textBox9.Text, out display1) &&
                    int.Parse(this.textBox9.Text) < 1 || int.Parse(this.textBox9.Text) > 20))
                {
                    MessageBox.Show("Enter a number between 1 to 20");
                    textBox9.Text = "";
                }
                //Check Flight existence
                bool value = false;
                foreach (Flight item in flightsList)
                {
                    if (item.FlightID == textBox3.Text || (item.TakeOff == comboBox4.SelectedItem.ToString()
                        && item.Landing == comboBox5.SelectedItem.ToString() && item.TakeOffDate == monthCalendar2.SelectionRange.Start))
                    {
                        MessageBox.Show("Flight already exists!");
                        textBox3.Text = "";
                        value = true;
                        break;
                    }
                }
                //Choose meal
                bool meals = false;
                if (comboBox8.SelectedItem.ToString() == "YES")
                    meals = true;

                else if (comboBox8.SelectedItem.ToString() == "NO")
                    meals = false;

                //Add to file
                if (!value)
                {
                    Flight flight = new Flight(textBox3.Text, comboBox4.SelectedItem.ToString(), comboBox5.SelectedItem.
                       ToString(), comboBox6.SelectedItem.ToString(), comboBox7.SelectedItem.ToString(), int.Parse(textBox8.Text),
                       int.Parse(textBox9.Text), meals, monthCalendar2.SelectionRange.Start, monthCalendar3.SelectionRange.End);


                    flightsList.Add(flight);

                    string path = @"../../../Flights.txt";
                    if (!File.Exists(path))
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine("Flight Information");

                        }
                    }

                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(flight.DisplayInfo() + "\n");

                    }
                    MessageBox.Show("Sent to file!");

                    //Take Off
                    foreach (Flight item in flightsList)
                    {
                        toolStripComboBox1.Items.Add(item.TakeOff + "-" + item.Landing);

                    }

                    foreach (Flight item in flightsList)
                    {
                        toolStripComboBox2.Items.Add(item.TakeOff + "-" + item.Landing);

                    }
                }
            }
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.monthCalendar2.SelectionRange.Start = DateTime.Now;
        }

        private void monthCalendar3_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.monthCalendar3.SelectionRange.Start = this.monthCalendar2.SelectionRange.Start.AddDays(1);
        }
        private void Form1_Leave(object sender, EventArgs e)
        {

        }

        private void twowayToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
        private void onewayToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {

        }       
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome\n\n" + "How to use application:\n\n" + "1.Create a New Flight.\n" + "2.Create a New Booking.\n" +
            "3.Choose ticket type\n" + "4.Fill in New Booking form.\n" + "5.See flight Tickets on Tickets.\n" + "6.See Flight Information on All Flights.\n"+
            "7.Open again the application to see the passenger and flight list.\n");
        }

        private void button5_Click(object sender, EventArgs e)
        {   
             string message = "By clicking YES you delete all information in files!"+"\n"+"Are you sure that you would like to continue?";
             string caption = "Delete File Content";
             var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            File.WriteAllText(@"../../../Flights.txt", String.Empty);
            File.WriteAllText(@"../../../Tickets.txt", String.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Field Check
            bool ticketInfo = false;
            if (!label17.Visible || textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                ticketInfo = true;
                MessageBox.Show("Please complete all fields\n(Create a new flight first)");
            }

            if (!ticketInfo)
            {
                Flight flight = new Flight();

                string type = label17.Text.Substring(0, 7);
                string takeOff = label17.Text.Substring(label17.Text.LastIndexOf(" ") + 1, 3);
                string landing = label17.Text.Substring(label17.Text.LastIndexOf("-") + 1);

                foreach (Flight item in flightsList)
                {
                    if (item.TakeOff == takeOff && item.Landing == landing && item.TakeOffDate == monthCalendar1.SelectionRange.Start)
                    {
                        flight.FlightID = item.FlightID;
                        flight.TakeOff = item.TakeOff;
                        flight.Landing = item.Landing;
                        flight.Stopover = item.Stopover;
                        flight.AirlineType = item.AirlineType;
                        flight.Passengers = item.Passengers;
                        flight.Rows = item.Rows;
                        flight.Meal = item.Meal;
                        flight.TakeOffDate = item.TakeOffDate;
                        flight.LandingDate = item.LandingDate;
                    }
                    break;
                }
                //Taken Seat check
                bool message = false; 
                foreach (Ticket item in ticketsList)
                {
                    if (item.Flight.FlightID == flight.FlightID && item.Seat == int.Parse(comboBox1.Text) && item.SeatAlign  == char.Parse(comboBox2.Text))
                    {
                        message = true;
                        MessageBox.Show("Seat already taken!");
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                    }
                    break;
                }
                if (!message) MessageBox.Show("Seat is free!");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Ticket item in ticketsList)
            {
                string PassengerName = item.Passenger.FirstName + " " + item.Passenger.LastName;
                if (PassengerName == comboBox3.SelectedItem.ToString())
                {
                    MessageBox.Show(item.DisplayInfo());
                    break;

                }
            }
        }
        private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_DragLeave(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, EventArgs e)
            //Close file
        {
                inFile.Close();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clear cells
            textBox3.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label19.Text = "";
        }
    }
}

