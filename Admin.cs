using System;
using System.Data.SqlClient;
using System.Globalization;


public class Admin
{
    public int AdminId;
    public string Role;
    public string PhoneNo;
    public string Email;
    public string Password;
    public string FirstName;
    public string LastName;
    public string Username;
    public string connString;

    bool loggedIn = false;

    public Admin(){}

    public Admin(string CString)
    {
        connString = CString;
        AdminId = 0;
        Role = "";
        PhoneNo = "";
        Email = "";
        Password = "";
        FirstName = "";
        LastName = "";
        Username = "";
    }

    public void SignUp()
    {
        Console.Write("Enter Admin ID: ");
        AdminId = int.Parse(Console.ReadLine());

        Console.Write("Enter Role: ");
        Role = Console.ReadLine();

        Console.Write("Enter Phone Number: ");
        PhoneNo = Console.ReadLine();

        Console.Write("Enter Email: ");
        Email = Console.ReadLine();

        Console.Write("Enter Password: ");
        Password = Console.ReadLine();

        Console.Write("Enter First Name: ");
        FirstName = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        LastName = Console.ReadLine();

        Console.Write("Enter Username: ");
        Username = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();

            string insertQuery = "INSERT INTO ADMIN (ADMIN_ID ,ROLE, PHONE_NO, EMAIL, PASSWORD, F_NAME, L_NAME, USERNAME) VALUES (@AdminID ,@Role, @PhoneNo, @Email, @Password, @FirstName, @LastName, @Username)";

            SqlCommand command = new SqlCommand(insertQuery, connection);

            // Set parameter values
            command.Parameters.AddWithValue("@AdminID", AdminId);
            command.Parameters.AddWithValue("@Role", Role);
            command.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Username", Username);

            // Execute the insert query
            int rowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"{rowsAffected} row(s) inserted.");
            loggedIn = true;
        }
    }
    
    
    public void LogIn()
    {
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();

        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();

            string selectQuery = "SELECT COUNT(*) FROM ADMIN WHERE USERNAME = @Username AND PASSWORD = @Password";

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
    public void UpdatingCustomerDetails(){
        Console.Write("Enter Passport number: ");
        string PassNum = Console.ReadLine();
        Console.Write("Enter Phone number: ");
        string PhoneNum = Console.ReadLine();
        Console.Write("Enter Email: ");
        string Email = Console.ReadLine();
        Console.Write("Enter Username: ");
        string Username = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();

            string updateQuery = "UPDATE CUSTOMER SET PHONE_NO = @PhoneNum, EMAIL = @Email, USERNAME = @Username WHERE PASS_NO = @PassNum";

            SqlCommand command = new SqlCommand(updateQuery, connection);

            // Set parameter values
            command.Parameters.AddWithValue("@PhoneNum", PhoneNum);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@PassNum", PassNum);

            // Execute the update query
            int rowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"{rowsAffected} row(s) updated.");
        }
    }
    public void AddAirCraft()
    {
        Console.Write("Enter Aircraft ID: ");
        int aircraftId = int.Parse(Console.ReadLine());

        Console.Write("Enter Admin ID: ");
        int adminId = int.Parse(Console.ReadLine());

        Console.Write("Enter Airline Name: ");
        string airlineName = Console.ReadLine();

        Console.Write("Enter Flight ID: ");
        int flightId = int.Parse(Console.ReadLine());

        Console.Write("Enter Make: ");
        string make = Console.ReadLine();

        Console.Write("Enter Model: ");
        string model = Console.ReadLine();

        Console.Write("Enter Max Weight: ");
        int maxWeight = int.Parse(Console.ReadLine());

        Console.Write("Enter Capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();

            string insertQuery = "INSERT INTO AIRCRAFT (CRAFT_ID, ADMIN_ID, AIRLINE_NAME, FLIGHT_ID, MAKE, MODEL, MAX_WEIGHT, CAPACITY) VALUES (@AircraftId, @AdminId, @AirlineName, @FlightId, @Make, @Model, @MaxWeight, @Capacity)";

            SqlCommand command = new SqlCommand(insertQuery, connection);

            // Set parameter values
            command.Parameters.AddWithValue("@AircraftId", aircraftId);
            command.Parameters.AddWithValue("@AdminId", adminId);
            command.Parameters.AddWithValue("@AirlineName", airlineName);
            command.Parameters.AddWithValue("@FlightId", flightId);
            command.Parameters.AddWithValue("@Make", make);
            command.Parameters.AddWithValue("@Model", model);
            command.Parameters.AddWithValue("@MaxWeight", maxWeight);
            command.Parameters.AddWithValue("@Capacity", capacity);

            // Execute the insert query
            int rowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"{rowsAffected} row(s) inserted.");
        }
    }

    public void UpdateAirCraftDetails()
    {
        Console.Write("Enter Aircraft ID: ");
        int aircraftId = int.Parse(Console.ReadLine());

        Console.Write("Enter Make: ");
        string make = Console.ReadLine();

        Console.Write("Enter Model: ");
        string model = Console.ReadLine();

        Console.Write("Enter Max Weight: ");
        int maxWeight = int.Parse(Console.ReadLine());

        Console.Write("Enter Capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();

            string updateQuery = "UPDATE AIRCRAFT SET MAKE = @Make, MODEL = @Model, MAX_WEIGHT = @MaxWeight, CAPACITY = @Capacity WHERE CRAFT_ID = @AircraftId";

            SqlCommand command = new SqlCommand(updateQuery, connection);

            // Set parameter values
            command.Parameters.AddWithValue("@Make", make);
            command.Parameters.AddWithValue("@Model", model);
            command.Parameters.AddWithValue("@MaxWeight", maxWeight);
            command.Parameters.AddWithValue("@Capacity", capacity);
            command.Parameters.AddWithValue("@AircraftId", aircraftId);

            // Execute the update query
            int rowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"{rowsAffected} row(s) updated.");
        }
    }
    public void AddFlight()
    {
        Console.Write("Enter Flight ID: ");
        int flightId = int.Parse(Console.ReadLine());

        Console.Write("Enter Aircraft ID: ");
        int aircraftId = int.Parse(Console.ReadLine());

        Console.Write("Enter Admin ID: ");
        int adminId = int.Parse(Console.ReadLine());

        Console.Write("Enter Duration: ");
        int duration = int.Parse(Console.ReadLine());

        Console.Write("Enter Destination: ");
        string destination = Console.ReadLine();

        Console.Write("Enter Arrival Timestamp (yyyy-MM-dd HH:mm:ss): ");
        DateTime arrivalTimestamp = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

        Console.Write("Enter Departure Timestamp (yyyy-MM-dd HH:mm:ss): ");
        DateTime departureTimestamp = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

        Console.Write("Enter Flight Number: ");
        int flightNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter Source: ");
        string source = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();

            string insertQuery = "INSERT INTO FLIGHT (FLIGHT_ID, CRAFT_ID, ADMIN_ID, DURATION, DESTINATION, ARR_TIMESTAMP, DEP_TIMESTAMP, FLIGHT_NO, SOURCE) VALUES (@FlightId, @AircraftId, @AdminId, @Duration, @Destination, @ArrivalTimestamp, @DepartureTimestamp, @FlightNumber, @Source)";

            SqlCommand command = new SqlCommand(insertQuery, connection);

            // Set parameter values
            command.Parameters.AddWithValue("@FlightId", flightId);
            command.Parameters.AddWithValue("@AircraftId", aircraftId);
            command.Parameters.AddWithValue("@AdminId", adminId);
            command.Parameters.AddWithValue("@Duration", duration);
            command.Parameters.AddWithValue("@Destination", destination);
            command.Parameters.AddWithValue("@ArrivalTimestamp", arrivalTimestamp);
            command.Parameters.AddWithValue("@DepartureTimestamp", departureTimestamp);
            command.Parameters.AddWithValue("@FlightNumber", flightNumber);
            command.Parameters.AddWithValue("@Source", source);

            // Execute the insert query
            int rowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"{rowsAffected} row(s) inserted.");
        }
    }
    public void UpdateFlightDetails(){
        Console.Write("Enter Flight ID: ");
        int flightId = int.Parse(Console.ReadLine());

        Console.Write("Enter Duration: ");
        string Duration = Console.ReadLine();

        Console.Write("Enter Destination: ");
        string Destination = Console.ReadLine();

        Console.Write("Enter Arrival Timestamp (yyyy-MM-dd HH:mm:ss): ");
        DateTime arrivalTimestamp = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

        Console.Write("Enter Departure Timestamp (yyyy-MM-dd HH:mm:ss): ");
        DateTime departureTimestamp = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

        using (SqlConnection connection = new SqlConnection(connString))
        {
            connection.Open();

            string updateQuery = "UPDATE FLIGHT SET DURATION = @Duration, DESTINATION = @Destination, ARR_TIMESTAMP = @ArrivalTime, DEP_TIMESTAMP = @DepartureTime WHERE FLIGHT_ID = @FlightId";

            SqlCommand command = new SqlCommand(updateQuery, connection);

            // Set parameter values
            command.Parameters.AddWithValue("@FlightId", flightId);
            command.Parameters.AddWithValue("@Duration", Duration);
            command.Parameters.AddWithValue("@Destination", Destination);
            command.Parameters.AddWithValue("@ArrivalTime", arrivalTimestamp);
            command.Parameters.AddWithValue("@DepartureTime", departureTimestamp);

            // Execute the update query
            int rowsAffected = command.ExecuteNonQuery();

            Console.WriteLine($"{rowsAffected} row(s) updated.");
        }
    }
    public void LogOut(){
        Console.WriteLine("Logged out!");
        loggedIn = false;
    }

    public void AdminMenu()
    {
        bool back = false;

        while (!back)
        {
            Console.WriteLine("=== Admin Menu ===");
            if (!loggedIn)
            {
                Console.WriteLine("1. Admin Sign Up");
                Console.WriteLine("2. Admin Login");
            }
            else
            {
                Console.WriteLine("3. Add Aircraft");
                Console.WriteLine("4. Update Aircraft Details");
                Console.WriteLine("5. Add Flight");
                Console.WriteLine("6. Update Flight Details");
                Console.WriteLine("7. Update Customer Details");
                Console.WriteLine("8. Logout");
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
                    LogIn();
                    break;
                case "3":
                    AddAirCraft();
                    break;
                case "4":
                    UpdateAirCraftDetails();
                    break;
                case "5":
                    AddFlight();
                    break;
                case "6":
                    UpdateFlightDetails();
                    break;
                case "7":
                    UpdatingCustomerDetails();
                    break;
                case "8":
                    LogOut();
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
