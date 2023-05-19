using System;
using System.Data.SqlClient;
public class User{
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

    public User(string conString){
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
        char gender = char.ToUpper(keyInfo.KeyChar); 
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
    public void LogIn(){}
    // public List<Flight> GetAvailableFlights(string condition){ return;}
    public void BookFlight(){}
    public void CancelFlight(){}
    public void UserMenu()
{
    bool back = false;
    bool loggedIn = false;

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
                    loggedIn = true;
                    Console.WriteLine("Login successful!");
                }
                else
                {
                    Console.WriteLine("You are already logged in.");
                }
                break;
            // case "3":
            //     if (loggedIn)
            //     {
            //         Console.WriteLine("Enter search condition :");
            //         string condition = Console.ReadLine();
            //         var availableFlights = GetAvailableFlights(condition);
            //         foreach (var flight in availableFlights)
            //         {
            //             Console.WriteLine($"Flight ID: {flight.FlightId}, Source: {flight.Source}, Destination: {flight.Destination}, Departure Time: {flight.DepartureTime}, Available Seats: {flight.AvailableSeats}");
            //         }
            //     }
            //     else
            //     {
            //         Console.WriteLine("You must log in first.");
            //     }
            //     break;
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
