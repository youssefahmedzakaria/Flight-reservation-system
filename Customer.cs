using System;
using System.Data.SqlClient;
public class Customer{
    public string PassNo;
    public char gender;
    public DateTime DOB;
    public int AGE;
    public string PhoneNumber;
    public string Email;
    public string firstName;
    public string lastName;
    public string Username;
    public string connString;
    bool loggedIn = false;

    public Customer(string conString){
        PassNo ="";
        gender =' ';
        DOB = DateTime.MinValue;
        AGE = 0;
        PhoneNumber = "";
        Email = "";
        firstName = "";
        lastName = "";
        Username = "";
        connString = conString;
    }
     public void SignUp()
    {
        PassNo = Validate.IsValidPassportNumber();

        gender = Validate.IsValidGender();

        DOB = Validate.IsValidDateOfBirth();

        AGE = Validate.IsValidAge();

        PhoneNumber = Validate.IsValidPhoneNum();

        Email = Validate.IsValidEmail();

        firstName = Validate.IsValidName("First Name");

        lastName = Validate.IsValidName("Last Name");

        Username = Validate.IsValidName("UserName");

        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();

            string insertQuery = "INSERT INTO CUSTOMER (PASS_NO ,GENDER, DOB, AGE, PHONE_NO,EMAIL, F_NAME, L_NAME, USERNAME) VALUES (@PassNo ,@gender, @DOB, @AGE,@PhoneNumber,@Email, @FirstName, @LastName, @Username)";

            SqlCommand command = new SqlCommand(insertQuery, connection);

            // Set parameter values
            command.Parameters.AddWithValue("@PassNo ",PassNo);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@DOB", DOB);
            command.Parameters.AddWithValue("@AGE", AGE);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Username", Username);

            // Execute the insert query
            int rowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"{rowsAffected} row(s) inserted.");
        }
    }
    public void LogIn(){

        string username = Validate.IsValidName("UserName");


        string password = Validate.IsValidPassportNumber();

        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();

            string selectQuery = "SELECT COUNT(*) FROM CUSTOMER WHERE USERNAME = @Username AND PASS_NO = @Password";

            SqlCommand command = new SqlCommand(selectQuery, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            int matchingRecordsCount = (int)command.ExecuteScalar();

            if (matchingRecordsCount > 0)
            {
                Console.WriteLine("Login successful!");
                loggedIn = true;
            }
            else
            {
                Console.WriteLine("Invalid username or password. Login failed.");
            }
        }
    }
    public void BookFlight()
    {
    int FlightId = Validate.IsValidId("Flight");

    string flightClass = Validate.IsValidString("Class");

    string PassNo = Validate.IsValidPassportNumber();

    // Generate random 8-digit ticket number
    Random random = new Random();
    int TicketNo = random.Next(10000000, 99999999);

    // Generate random 2-digit seat number
    int Seatnum = random.Next(1, 100);
    string Seat = Seatnum.ToString();

    using (SqlConnection connection = new SqlConnection(connString))
    {
        connection.Open();

        // Check if the flight exists
        string checkFlightQuery = "SELECT COUNT(*) FROM FLIGHT WHERE FLIGHT_ID = @FlightId";
        SqlCommand checkFlightCommand = new SqlCommand(checkFlightQuery, connection);
        checkFlightCommand.Parameters.AddWithValue("@FlightId", FlightId);

        int flightCount = (int)checkFlightCommand.ExecuteScalar();
        if (flightCount == 0)
        {
            Console.WriteLine("Flight not found. Please enter a valid Flight ID.");
            return;
        }

        // Check if the TRANSACTION already exists in the TICKET or PAYMENT tables
        string checkTransactionQuery = "SELECT COUNT(*) FROM TICKET WHERE [TRANSACTION] = 'cash' OR EXISTS " +
                                       "(SELECT 1 FROM PAYMENT WHERE [TRANSACTION] = 'cash')";
        SqlCommand checkTransactionCommand = new SqlCommand(checkTransactionQuery, connection);

        int transactionCount = (int)checkTransactionCommand.ExecuteScalar();
        if (transactionCount < 0)
        {
            Console.WriteLine("Method dont exist. Please try again later.");
            return;
        }

        string insertQuery = "INSERT INTO TICKET (TICKET_NO, PASS_NO, FLIGHT_ID, SEAT, CLASS, [TRANSACTION]) " +
                             "VALUES (@TicketNo, @PassNo, @FlightId, @Seat, @Class, 'cash')";

        SqlCommand command = new SqlCommand(insertQuery, connection);

        // Set parameter values
        command.Parameters.AddWithValue("@TicketNo", TicketNo);
        command.Parameters.AddWithValue("@PassNo", PassNo);
        command.Parameters.AddWithValue("@FlightId", FlightId);
        command.Parameters.AddWithValue("@Seat", Seat);
        command.Parameters.AddWithValue("@Class", flightClass);

        int rowsAffected = command.ExecuteNonQuery();

        Console.WriteLine();    
        Console.WriteLine($"successfully reserved ticket");    
        Console.WriteLine($"Ticket Number: {TicketNo}");
        Console.WriteLine($"Seat Number: {Seat}");
        Console.WriteLine($"Flight ID: {FlightId}");
        Console.WriteLine($"FLight Class: {flightClass}");
        Console.WriteLine($"Payment method: Cash");
        Console.WriteLine($"{rowsAffected} row(s) updated.");
        Console.WriteLine();    
        }

        //int rowsAffected = command.ExecuteNonQuery();
    }

public void CancelFlight()
{
    Console.Write("Enter the Ticket Number: ");
    int ticketNumber = Validate.IsValidTicketNumber();

    using (SqlConnection connection = new SqlConnection(connString))
    {
        connection.Open();

        // Check if the ticket exists
        string checkTicketQuery = "SELECT COUNT(*) FROM TICKET WHERE TICKET_NO = @TicketNo";
        SqlCommand checkTicketCommand = new SqlCommand(checkTicketQuery, connection);
        checkTicketCommand.Parameters.AddWithValue("@TicketNo", ticketNumber);

        int ticketCount = (int)checkTicketCommand.ExecuteScalar();
        if (ticketCount == 0)
        {
            Console.WriteLine("Ticket not found. Please enter a valid Ticket Number.");
            return;
        }

        // Delete the ticket
        string deleteQuery = "DELETE FROM TICKET WHERE TICKET_NO = @TicketNo";
        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
        deleteCommand.Parameters.AddWithValue("@TicketNo", ticketNumber);

        int rowsAffected = deleteCommand.ExecuteNonQuery();
        Console.WriteLine($"Ticket cancelled");
    }
}
    
    public void AvailableFlights()
    {
    Console.WriteLine("=== Available Flights ===");

    using (SqlConnection connection = new SqlConnection(connString))
    {
        connection.Open();

        string selectQuery = "SELECT DESTINATION, ARR_TIMESTAMP, DEP_TIMESTAMP, SOURCE, FLIGHT_ID FROM FLIGHT";

        SqlCommand command = new SqlCommand(selectQuery, connection);

        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string destination = reader.GetString(0);
                DateTime arrivalTimestamp = reader.GetDateTime(1);
                DateTime departureTimestamp = reader.GetDateTime(2);
                string source = reader.GetString(3);
                int flightId = reader.GetInt32(4);


                Console.WriteLine($"Source: {source}");
                Console.WriteLine($"Destination: {destination}");
                Console.WriteLine($"Departure Time: {departureTimestamp}");
                Console.WriteLine($"Arrival Time: {arrivalTimestamp}");
                Console.WriteLine($"flight ID: {flightId}");
                Console.WriteLine();
                }
            }
        }
    }
    public void UserMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.WriteLine("=== User Menu ===");
            if (!loggedIn)
            {
                Console.WriteLine("1. User Sign Up");
                Console.WriteLine("2. User Login");
            }
            else
            {
                Console.WriteLine("3. Get Available Flights");
                Console.WriteLine("4. Book Flight");
                Console.WriteLine("5. Cancel Flight");
                Console.WriteLine("6. Logout");
            }
            Console.WriteLine("0. Back");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    SignUp();
                    break;
                case "2":
                    if (!loggedIn)
                    {
                        LogIn();
                    }
                    else
                    {
                        Console.WriteLine("You are already logged in.");
                    }
                    break;
                case "3":
                    if (loggedIn)
                    {
                        AvailableFlights();
                    }
                    else
                    {
                        Console.WriteLine("You must log in first.");
                    }
                    break;
                case "4":
                    if (loggedIn)
                    {
                        BookFlight();
                    }
                    else
                    {
                        Console.WriteLine("You must log in first.");
                    }
                    break;
                case "5":
                    if (loggedIn)
                    {
                        CancelFlight();
                    }
                    else
                    {
                        Console.WriteLine("You must log in first.");
                    }
                    break;
                case "6":
                    if (loggedIn)
                    {
                        loggedIn = false;
                        Console.WriteLine("Logged out successfully.");
                    }
                    else
                    {
                        Console.WriteLine("You are not logged in.");
                    }
                    break;
                case "0":
                    back = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }
}