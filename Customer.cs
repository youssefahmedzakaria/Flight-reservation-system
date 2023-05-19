using System;
using System.Data.SqlClient;
public class Customer{
    public string PassNo;
    public char gender;
    public string DOB;
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
        DOB = "";
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
        Console.Write("Enter Passport Number: ");
        PassNo = Console.ReadLine();

        Console.Write("Enter Gender (M/F): ");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        gender = char.ToUpper(keyInfo.KeyChar);
        Console.WriteLine();

        Console.Write("Enter Day Of Birth: ");
        DOB = Console.ReadLine();

        Console.Write("Enter Age: ");
        AGE = int.Parse(Console.ReadLine());

        Console.Write("Enter PhoneNumber: ");
        PhoneNumber = Console.ReadLine();

        Console.Write("Enter Email: ");
        Email = Console.ReadLine();

        Console.Write("Enter First Name: ");
        firstName = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        lastName = Console.ReadLine();

        Console.Write("Enter Username: ");
        Username = Console.ReadLine();

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
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();

        Console.Write("Enter PassportNum as password: ");
        string password = Console.ReadLine();

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
        Console.Write("Enter the Flight ID: ");
        int flightId;
        if (!int.TryParse(Console.ReadLine(), out flightId))
        {
            Console.WriteLine("Invalid Flight ID. Please try again.");
            return;
        }

    Console.Write("Enter the flight class: ");
    string flightClass = Console.ReadLine();

    Console.Write("Enter your PASS_NO: ");
    string passNo = Console.ReadLine();

    // Generate random 8-digit ticket number
    Random random = new Random();
    int ticketNumber = random.Next(10000000, 99999999);

    // Generate random 2-digit seat number
    int seatNumber = random.Next(1, 100);

    using (SqlConnection connection = new SqlConnection(connString))
    {
        connection.Open();

        // Check if the flight exists
        string checkFlightQuery = "SELECT COUNT(*) FROM FLIGHT WHERE FLIGHT_ID = @FlightId";
        SqlCommand checkFlightCommand = new SqlCommand(checkFlightQuery, connection);
        checkFlightCommand.Parameters.AddWithValue("@FlightId", flightId);

        int flightCount = (int)checkFlightCommand.ExecuteScalar();
        if (flightCount == 0)
        {
            Console.WriteLine("Flight not found. Please enter a valid Flight ID.");
            return;
        }

        // Check if the PASS_NO exists in the CUSTOMER table
        string checkPassNoQuery = "SELECT COUNT(*) FROM CUSTOMER WHERE PASS_NO = @PassNo";
        SqlCommand checkPassNoCommand = new SqlCommand(checkPassNoQuery, connection);
        checkPassNoCommand.Parameters.AddWithValue("@PassNo", passNo);

        int passNoCount = (int)checkPassNoCommand.ExecuteScalar();
        if (passNoCount == 0)
        {
            Console.WriteLine("Passenger not found. Please enter a valid PASS_NO.");
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
        command.Parameters.AddWithValue("@TicketNo", ticketNumber);
        command.Parameters.AddWithValue("@PassNo", passNo);
        command.Parameters.AddWithValue("@FlightId", flightId);
        command.Parameters.AddWithValue("@Seat", seatNumber);
        command.Parameters.AddWithValue("@Class", flightClass);

        Console.WriteLine($"successfully reserved ticket");    
        Console.WriteLine($"Ticket Number: {ticketNumber}");
        Console.WriteLine($"Seat Number: {seatNumber}");
        Console.WriteLine($"Flight ID: {flightId}");
        Console.WriteLine($"FLight Class: {flightClass}");
        Console.WriteLine($"Payment method: Cash");
        Console.WriteLine();    
        }
    }




    public void CancelFlight(){}
    
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