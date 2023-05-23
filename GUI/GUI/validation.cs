using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GUI
{
    internal class validation
    {
        public static string IsValidChoice(string inputValue)
        {
            bool isValidChoice = false;

            while (!isValidChoice)
            {
                if (string.IsNullOrEmpty(inputValue))
                {
                    MessageBox.Show("Invalid choice. Please enter a number between 0 and 8.");
                    return null;
                }

                isValidChoice = !string.IsNullOrEmpty(inputValue) && Regex.IsMatch(inputValue, @"^[0-8]$");

                if (!isValidChoice)
                {
                    MessageBox.Show("Invalid choice. Please enter a number between 0 and 8.");
                    return null;
                }
            }

            return inputValue;
        }

        public static string IsValidId(string IDname, string inputValue)
        {
            bool isValidID = false;

            while (!isValidID)
            {
                if (string.IsNullOrEmpty(inputValue))
                {
                    MessageBox.Show(IDname + " ID cannot be empty. Please try again.");
                    return null;
                }
                if (!Regex.IsMatch(inputValue, @"^[0-9]+$"))
                {
                    MessageBox.Show("ID must contain only numbers. Please try again.");
                    return null;
                }

                isValidID = true;
            }

            return inputValue;
        }

        public static string IsValidRole(string inputValue)
        {
            while (string.IsNullOrEmpty(inputValue))
            {
                MessageBox.Show("Role cannot be empty. Please try again.");
                return null;
            }
            if (!Regex.IsMatch(inputValue, @"^[A-Za-z]+$"))
            {
                MessageBox.Show("Role must contain only letters. Please try again.");
                return null;
            }

            return inputValue;
        }

        public static string IsValidPhoneNum(string inputValue)
        {
            while (string.IsNullOrEmpty(inputValue))
            {
                MessageBox.Show("Phone Number cannot be empty. Please try again.");
                return null;
            }
            if (!Regex.IsMatch(inputValue, @"^(010|011|012|015)\d{8}$"))
            {
                MessageBox.Show("Phone Number must start with 010, 011, 012, or 015 and have a total length of 11 digits. Please try again.");
                return null;
            }

            return inputValue;
        }

        public static string IsValidEmail(string inputValue)
        {
            while (string.IsNullOrEmpty(inputValue))
            {
                MessageBox.Show("Email cannot be empty. Please try again.");
                return null;
            }
            if (!Regex.IsMatch(inputValue, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email format is invalid. Please try again.");
                return null;
            }

            return inputValue;
        }

        public static string IsValidPassword(string inputValue)
        {
            while (string.IsNullOrEmpty(inputValue))
            {
                if (string.IsNullOrEmpty(inputValue))
                {
                    MessageBox.Show("Password cannot be empty. Please try again.");
                    return null;
                }
            }

            return inputValue;
        }

        public static string IsValidName(string inputValue, string value)
        {
            while (string.IsNullOrEmpty(inputValue))
            {
                MessageBox.Show(value + "Name cannot be empty. Please try again.");
                return null;
            }
            if (!Regex.IsMatch(inputValue, @"^[A-Za-z ]+$"))
            {
                MessageBox.Show(value + "Name must contain only letters. Please try again.");
                return null;
            }
            return inputValue;
            return value;
        }

        public static string IsValidPassportNumber(string inputValue)
        {
            string passportPattern = "^[a-zA-Z][a-zA-Z0-9]*$";

            while (string.IsNullOrEmpty(inputValue) || !Regex.IsMatch(inputValue, passportPattern))
            {
                if (string.IsNullOrEmpty(inputValue))
                {
                    MessageBox.Show("Passport Number cannot be empty. Please try again.");
                    return null;
                }

                if (!Regex.IsMatch(inputValue, passportPattern))
                {
                    MessageBox.Show("Passport Number must start with a letter and can only contain letters and numbers. Please try again.");
                    return null;
                }

                return inputValue;
            }

            return inputValue;
        }

        public static string IsValidString(string value, string inputValue)
        {
            while (string.IsNullOrEmpty(inputValue))
            {
                MessageBox.Show(value + " cannot be empty. Please try again.");
                return null;
            }

            return inputValue;
        }

        public static int IsValidMaxWeight(string inputValue)
        {
            int maxWeight = 0;
            string numericPattern = @"^\d+$";

            while (maxWeight <= 0)
            {
                if (!Regex.IsMatch(inputValue, numericPattern))
                {
                    MessageBox.Show("Invalid input. Please enter a positive integer without any punctuation or special characters.");
                    return 0;
                }

                if (!int.TryParse(inputValue, out maxWeight) || maxWeight <= 0)
                {
                    MessageBox.Show("Invalid Maximum Weight. Please enter a positive integer.");
                    return 0;
                }
            }

            return maxWeight;
        }

        public static int IsValidCapacity(string inputValue)
        {
            int capacity = 0;
            string numericPattern = @"^\d+$";

            while (capacity <= 0)
            {
                if (!Regex.IsMatch(inputValue, numericPattern))
                {
                    MessageBox.Show("Invalid input. Please enter a positive integer without any punctuation or special characters.");
                    return 0;
                }

                if (!int.TryParse(inputValue, out capacity) || capacity <= 0)
                {
                    MessageBox.Show("Invalid Capacity. Please enter a positive integer.");
                    return 0;
                }
            }

            return capacity;
        }

        public static int IsValidDuration(string inputValue)
        {
            int duration = 0;

            while (duration <= 0)
            {
                if (!int.TryParse(inputValue, out duration) || duration <= 0)
                {
                    MessageBox.Show("Invalid Duration. Please enter a positive integer.");
                    return 0;
                }
            }

            return duration;
        }

        public DateTime IsValidTimestamp(string timestampName, string timestampValue)
        {
            DateTime timestamp;

            if (DateTime.TryParseExact(timestampValue, "yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out timestamp))
            {
                return timestamp;
            }
            else
            {
                MessageBox.Show($"Invalid {timestampName} timestamp format. Please enter a valid timestamp in the format yyyy-MM-dd hh:mm:ss tt.");
                return DateTime.MinValue;
            }
        }



        public static int IsValidFlightNumber(string inputValue)
        {
            int flightNumber = 0;

            while (flightNumber <= 0)
            {
                if (!int.TryParse(inputValue, out flightNumber) || flightNumber <= 0)
                {
                    MessageBox.Show("Invalid Flight Number. Please enter a positive integer.");
                    return 0;
                }
            }

            return flightNumber;
        }

        public static char IsValidGender(string inputValue)
        {
            bool isValidGender = false;

            while (!isValidGender)
            {
                if (!string.IsNullOrEmpty(inputValue) && inputValue.Length == 1 && (inputValue.ToUpper() == "M" || inputValue.ToUpper() == "F"))
                {
                    isValidGender = true;
                    return char.ToUpper(inputValue[0]);
                }
                else
                {
                    MessageBox.Show("Invalid gender. Please select 'M' for Male or 'F' for Female.");
                    return '\0';
                }
            }

            // Unreachable code, but added for completeness
            return '\0';
        }

        public string IsValidDateOfBirth(string input)
        {
            string dateFormat = "yyyy-MM-dd hh:mm:ss tt";
            DateTime dob;

            try
            {
                dob = DateTime.ParseExact(input, dateFormat, CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid date of birth format. Please enter a valid date.");
                return null;
            }

            return dob.ToString();
        }


        public static int IsValidAge(string input)
        {
            int age = 0;
            bool isValidAge = false;

            while (!isValidAge)
            {
                if (int.TryParse(input, out age))
                {
                    if (age > 0 && age <= 120)
                    {
                        isValidAge = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid age. Age must be a positive value and less than or equal to 120.", "Age Validation");
                        return 0;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid age format. Please enter a valid integer value for age.", "Age Validation");
                    return 0;
                }
            }

            return age;
        }

        public static bool IsValidTicketNumber(string input, out int ticketNumber)
        {
            if (int.TryParse(input, out ticketNumber))
            {
                if (ticketNumber > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Invalid ticket number. Ticket number must be a positive value.", "Ticket Number Validation");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Invalid ticket number format. Please enter a valid integer value for the ticket number.", "Ticket Number Validation");
                return false;
            }
        }
    }
}
