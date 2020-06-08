using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    public class Ticket

    {
        Passenger passenger;
        private Flight flight;
        private DateTime date;
        private int number;
        private int seat;
        private string type;
        private char seatAlign;

        public Ticket()
        { }

        public Ticket(Flight flight, int number, string type, Passenger passenger, DateTime date, int seat, char alignment)
        {
            this.flight = flight;
            this.number = number;
            this.type = type;
            this.passenger = passenger;
            this.date = date;
            this.seat = seat;
            this.seatAlign = alignment;
        }

        public Flight Flight
        {
            get
            {
                return this.flight;
            }

            set
            {
                this.flight = value;
            }
        }
        public int Number
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
            }
        }
        public string Type
        {
            get
            {
                return this.type;
            }

            set
            {
                type = value;
            }
        }

        public Passenger Passenger
        {
            get
            {
                return this.passenger;
            }

            set
            {
                passenger = value;
            }
        }


        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                date = value;
            }
        }

        public int Seat
        {
            get
            {
                return this.seat;
            }

            set
            {
                seat = value;
            }
        }

        public char SeatAlign
        {
            get
            {
                return this.seatAlign;
            }

            set
            {
                seatAlign = value;
            }
        }

        public string DisplayInfo()
        {
            string info = "Ticket Number: " + this.number + "\n" + "Flight: " + this.flight.TakeOff + "-" + this.flight.Landing
                + "Type: " + this.type + "\n" + "Name: " + this.passenger.FirstName + "\n" + this.passenger.LastName + "\n"
                + "Date: " + this.date.ToString() + "\n" + "Seat: " + this.seat + this.seatAlign;

            return info;
        }

    }

    public class Passenger
    {
        private string firstName;
        private string lastName;

        public Passenger()
        { }

        public Passenger(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
            }

        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
            }
        }

    }
    public class Flight
    {
        private string flightID;
        private string takeOff;
        private string landing;
        private string stopover;
        private string airlineComp;
        private int maxPassengers;
        private int rows;
        private bool meal;
        private DateTime takeOffDate;
        private DateTime landingDate;

        public Flight()
        { }

        public Flight(string ID, string takeOff, string landing, string stopover, string airlineType,
            int passengers, int rows, bool eatingOnBoard, DateTime takeOffDate, DateTime landingDate)
        {
            this.flightID = ID;
            this.takeOff = takeOff;
            this.landing = landing;
            this.stopover = stopover;
            this.airlineComp = airlineType;
            this.maxPassengers = passengers;
            this.rows = rows;
            this.meal = eatingOnBoard;
            this.takeOffDate = takeOffDate;
            this.landingDate = landingDate;
        }

        public string FlightID
        {
            get
            {
                return this.flightID;
            }

            set
            {
                this.flightID = value;
            }
        }

        public string TakeOff
        {
            get
            {
                return this.takeOff;
            }

            set
            {
                this.takeOff = value;
            }
        }

        public string Landing
        {
            get
            {
                return this.landing;
            }

            set
            {
                this.landing = value;
            }
        }

        public string Stopover
        {
            get
            {
                return this.stopover;
            }

            set
            {
                this.stopover = value;
            }
        }

        public string AirlineType
        {
            get
            {
                return this.airlineComp;
            }

            set
            {
                this.airlineComp = value;
            }
        }

        public int Passengers
        {
            get
            {
                return this.maxPassengers;
            }

            set
            {
                this.maxPassengers = value;
            }
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            set
            {
                this.rows = value;
            }
        }

        public bool Meal
        {
            get
            {
                return this.meal;
            }

            set
            {
                this.meal = value;
            }
        }

        public DateTime TakeOffDate
        {
            get
            {
                return this.takeOffDate;
            }

            set
            {
                this.takeOffDate = value;
            }
        }

        public DateTime LandingDate
        {
            get
            {
                return this.landingDate;
            }

            set
            {
                this.landingDate = value;
            }
        }

        public string DisplayInfo()
        {
            string info = "Flight ID: " + this.flightID + "\n" + "Takeoff from: " + this.takeOff + "\n" +
                "Landing to: " + this.landing + "\n" + "Stopover in:  " + this.stopover + "\n" +
                "Airline type: " + this.airlineComp + "\n" + "Maximum number of passengers: " + this.maxPassengers + "\n"
                + "Number of rows: " + this.rows + "\n" + "Takeoff date: " + this.takeOffDate.ToString() + "\n" +
                "Landing date: " + this.landingDate.ToString() + "\n" + "Eating on board: " + this.meal.ToString();

            return info;
        }
    }
}
