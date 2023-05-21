using System.Globalization;
using System.Text.RegularExpressions;
class Validate{
        public Validate(){}

        public static string IsValidChoice()
        {
            string choice = string.Empty;
            bool isValidChoice = false;

            while (!isValidChoice)
            {
                Console.Write("Enter your choice (0-8): ");
                choice = Console.ReadLine();

                isValidChoice = !string.IsNullOrEmpty(choice) && Regex.IsMatch(choice, @"^[0-8]$");

                if (!isValidChoice)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 0 and 8.");
                }
            }

            return choice;
        }


        public static int IsValidId(string IDname)
        {
            int Id = 0;
            bool isValidID = false;

            while (!isValidID)
            {
                Console.Write("Enter the "+ IDname + " ID :");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(IDname + " ID cannot be empty. Please try again.");
                    continue;
                }
                if (!Regex.IsMatch(input, @"^[0-9]+$"))
                {
                    Console.WriteLine("ID must contain only numbers. Please try again.");
                    continue;
                }
                if (!int.TryParse(input, out Id))
                {
                    Console.WriteLine("Invalid ID. Please try again.");
                    continue;
                }
                isValidID = true;
            }
            return Id;
        }

        public static string IsValidRole()
        {
            string role = null;

            while (string.IsNullOrEmpty(role))
            {
                Console.Write("Enter the Role: ");
                role = Console.ReadLine();

                if (string.IsNullOrEmpty(role))
                {
                    Console.WriteLine("Role cannot be empty. Please try again.");
                    continue;
                }
                if (!Regex.IsMatch(role, @"^[A-Za-z]+$"))
                {
                    Console.WriteLine("Role must contain only letters. Please try again.");
                    role = null;
                    continue;
                }
            }

            return role;
        }

        public static string IsValidPhoneNum()
        {
            string phoneNum = null;

            while (string.IsNullOrEmpty(phoneNum))
            {
                Console.Write("Enter the Phone Number: ");
                phoneNum = Console.ReadLine();
                if (string.IsNullOrEmpty(phoneNum))
                {
                    Console.WriteLine("Phone Number cannot be empty. Please try again.");
                    continue;
                }
                if (!Regex.IsMatch(phoneNum, @"^(010|011|012|015)\d{8}$"))
                {
                    Console.WriteLine("Phone Number must start with 010, 011, 012, or 015 and have a total length of 11 digits. Please try again.");
                    phoneNum = null;
                    continue;
                }
            }

            return phoneNum;
        }

        public static string IsValidEmail()
        {
            string email = null;

            while (string.IsNullOrEmpty(email))
            {
                Console.Write("Enter the Email: ");
                email = Console.ReadLine();

                if (string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Email cannot be empty. Please try again.");
                    continue;
                }
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    Console.WriteLine("Email format is invalid. Please try again.");
                    email = null;
                    continue;
                }
            }

            return email;
        }

        public static string IsValidPassword()
        {
            string password = null;

            while (string.IsNullOrEmpty(password))
            {
                Console.Write("Enter the Password: ");
                password = Console.ReadLine();

                if (string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Password cannot be empty. Please try again.");
                    continue;
                }
                if (password.Length < 8)
                {
                    Console.WriteLine("Password must be at least 8 characters long. Please try again.");
                    password = null;
                    continue;
                }
            }
            return password;
        }

        public static string IsValidName(string n)
        {
            string name = null;
            string namePattern = "^[a-zA-Z]+$";

            while (string.IsNullOrEmpty(name) || !Regex.IsMatch(name, namePattern))
            {
                Console.Write("Enter your"+ n + ":");
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Name cannot be empty. Please try again.");
                    continue;
                }

                if (!Regex.IsMatch(name, namePattern))
                {
                    Console.WriteLine("Name must contain only letters. Please try again.");
                    continue;
                }
            }

            return name;
        }

        public static string IsValidPassportNumber()
        {
            string passportNumber = null;
            string passportPattern = "^[a-zA-Z][a-zA-Z0-9]*$";

            while (string.IsNullOrEmpty(passportNumber) || !Regex.IsMatch(passportNumber, passportPattern))
            {
                Console.Write("Enter the Passport Number: ");
                passportNumber = Console.ReadLine();

                if (string.IsNullOrEmpty(passportNumber))
                {
                    Console.WriteLine("Passport Number cannot be empty. Please try again.");
                    continue;
                }

                if (!Regex.IsMatch(passportNumber, passportPattern))
                {
                    Console.WriteLine("Passport Number must start with a letter and can only contain letters and numbers. Please try again.");
                    continue;
                }
            }

            return passportNumber;
        }


        public static string IsValidString(string value)
        {
            string word = null;

            while (string.IsNullOrEmpty(word))
            {
                Console.Write("Enter the " + value + " : ");
                word = Console.ReadLine();

                if (string.IsNullOrEmpty(word))
                {
                    Console.WriteLine(value + " cannot be empty. Please try again.");
                    continue;
                }
            }

            return word;
        }


        public static int IsValidMaxWeight()
        {
            int maxWeight = 0;
            string numericPattern = @"^\d+$";

            while (maxWeight <= 0)
            {
                Console.Write("Enter the Maximum Weight: ");
                string input = Console.ReadLine();

                if (!Regex.IsMatch(input, numericPattern))
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer without any punctuation or special characters.");
                    continue;
                }

                if (!int.TryParse(input, out maxWeight) || maxWeight <= 0)
                {
                    Console.WriteLine("Invalid Maximum Weight. Please enter a positive integer.");
                }
            }

            return maxWeight;
        }

        public static int IsValidCapacity()
        {
            int capacity = 0;
            string numericPattern = @"^\d+$";

            while (capacity <= 0)
            {
                Console.Write("Enter the Capacity: ");
                string input = Console.ReadLine();

                if (!Regex.IsMatch(input, numericPattern))
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer without any punctuation or special characters.");
                    continue;
                }

                if (!int.TryParse(input, out capacity) || capacity <= 0)
                {
                    Console.WriteLine("Invalid Capacity. Please enter a positive integer.");
                }
            }

            return capacity;
        }

        public static int IsValidDuration()
        {
            int duration = 0;

            while (duration <= 0)
            {
                Console.Write("Enter the Duration: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out duration) || duration <= 0)
                {
                    Console.WriteLine("Invalid Duration. Please enter a positive integer.");
                }
            }

            return duration;
        }

        public static DateTime ISValidTimestamp(string tstamp)
        {
            DateTime arrivalTimestamp;

            while (true)
            {
                Console.Write("Enter " +tstamp + " Timestamp (yyyy-MM-dd HH:mm:ss): ");
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out arrivalTimestamp))
                {
                    return arrivalTimestamp;
                }
                else
                {
                    Console.WriteLine("Invalid input format. Please enter the "+tstamp+" timestamp in the specified format.");
                }
            }
        }

        public static int IsValidFlightNumber()
        {
            int flightNumber = 0;

            while (flightNumber <= 0)
            {
                Console.Write("Enter the Flight Number: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out flightNumber) || flightNumber <= 0)
                {
                    Console.WriteLine("Invalid Flight Number. Please enter a positive integer.");
                }
            }

            return flightNumber;
        }


        public static char IsValidGender()
        {
            char gender = '\0';
            bool isValidGender = false;

            while (!isValidGender)
            {
                Console.Write("Enter your gender (M/F): ");
                string input = Console.ReadLine();

                isValidGender = !string.IsNullOrEmpty(input) && input.Length == 1 && (input.ToUpper() == "M" || input.ToUpper() == "F");

                if (isValidGender)
                {
                    gender = char.ToUpper(input[0]);
                }
                else
                {
                    Console.WriteLine("Invalid gender. Please enter 'M' for Male or 'F' for Female.");
                }
            }

            return gender;
        }


        public static DateTime IsValidDateOfBirth()
        {
            DateTime dateOfBirth = DateTime.MinValue;
            bool isValidDateOfBirth = false;

            while (!isValidDateOfBirth)
            {
                Console.Write("Enter your date of birth (yyyy-MM-dd): ");
                string input = Console.ReadLine();

                isValidDateOfBirth = DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth);

                if (!isValidDateOfBirth)
                {
                    Console.WriteLine("Invalid date of birth format. Please enter a valid date in the format yyyy-MM-dd.");
                }
            }

            return dateOfBirth;
        }


        public static int IsValidAge()
{
    int age = 0;
    bool isValidAge = false;

    while (!isValidAge)
    {
        Console.Write("Enter your age: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out age))
        {
            if (age > 0)
            {
                isValidAge = true;
            }
            else
            {
                Console.WriteLine("Invalid age. Age must be a positive value.");
            }
        }
        else
        {
            Console.WriteLine("Invalid age format. Please enter a valid integer value for age.");
        }
    }

    return age;
}

        public static int IsValidTicketNumber()
        {
            int ticketNumber = 0;
            bool isValidTicketNumber = false;

            while (!isValidTicketNumber)
            {
                Console.Write("Enter the ticket number: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out ticketNumber))
                {
                    if (ticketNumber > 0)
                    {
                        isValidTicketNumber = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ticket number. Ticket number must be a positive value.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ticket number format. Please enter a valid integer value for the ticket number.");
                }
            }

            return ticketNumber;
}

}