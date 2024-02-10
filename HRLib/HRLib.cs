using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HRLib
{
    public class HRLib
    {
        public struct Employee
        {
            public string Name { get; set; }
            public string HomePhone { get; set; }
            public string MobilePhone { get; set; }
            public DateTime Birthday { get; set; }
            public DateTime HiringDate { get; set; }

            public Employee(string Name, string HomePhone, string MobilePhone, DateTime Birthday, DateTime HiringDate)
            {
                this.Name = Name;
                this.HomePhone = HomePhone;
                this.MobilePhone = MobilePhone;
                this.Birthday = Birthday;
                this.HiringDate = HiringDate;
            }
        }

        // Additional methods
        public bool ValidName(string inputName)
        {
            // Check if the input string is not null or empty
            if (string.IsNullOrEmpty(inputName))
            {
                return false;
            }

            // Use a regular expression to check if the format is valid
            // Assumes a valid full name consists of at least two words, each starting with an uppercase letter, with spaces in between.
            string pattern = @"^[A-Z][a-z]*(\s[A-Z][a-z]*)+$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(inputName);
        }

        public bool ValidPassword(string password)
        {
            // Check if the password is not null or empty
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            // Use a regular expression to check if the format is valid
            // Password needs to have 12 characters, start with an uppercase letter,
            // end with a number, and contain at least one lowercase letter, one uppercase letter,
            // one number, and one symbol.
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{12,}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(password);
        }

        public void EncryptPassword(string password, ref string encryptedPassword)
        {
            // Ολίσθηση κατά 5 θέσεις
            int shift = 5;

            // Κρυπτογραφία με Κώδικα του Καίσαρα
            string result = "";

            foreach (char ch in password)
            {
                if (ch >= 32 && ch <= 126) // Check if it's printable ASCII character
                {
                    char shifted = (char)(32 + (ch - 32 + shift) % 95); // Shift by 5, considering printable characters
                    result += shifted;
                }
                else
                {
                    result += ch; // Keep non-printable characters unchanged
                }
            }

            encryptedPassword = result.ToString();
        }

        public void CheckPhone(string phone, ref int typePhone, ref string infoPhone)
        {
            phone = phone.Trim();

            typePhone = -1;
            infoPhone = "null";

            if (phone.Length != 10)
            {

                return;
            }

            if (phone.StartsWith("2"))
            {
                typePhone = 0;
                infoPhone = GetZone(phone);
                return;
            }

            if (phone.StartsWith("6"))
            {
                typePhone = 1;
                infoPhone = GetCarrier(phone);
                return;
            }
        }

        private string GetZone(string phone)
        {
            switch (phone[1])
            {
                case '1':
                    return "Μητροπολιτική Περιοχή Αθήνας – Πειραιά";

                case '2':
                    return "Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου";

                case '3':
                    return "Κεντρική Μακεδονία";

                case '4':
                    return "Θεσσαλία, Δυτική Μακεδονία";

                case '5':
                    return "Θράκη, Ανατολική Μακεδονία";

                case '6':
                    return "Ήπειρος, Δυτική Στερεά Ελλάδα, Δυτική Πελοπόννησος, Ιόνια Νησιά";

                case '7':
                    return "Ανατολική Πελοπόννησος, Κύθηρα";

                case '8':
                    return "Κρήτη";

                default:
                    return "Άγνωστο";
            }
        }

        static string GetCarrier(string phoneNumber)
        {
            string carrier = "Unknown";

            // Define regex patterns for each carrier based on the starting digit of the phone number
            string regexCosmote = @"^697\d{7}$"; // Verizon starts with 5
            string regexVodafone = @"^695[5-9]\d{6}$"; // AT&T starts with 6
            string regexNova = @"^(69900|(6991|6998)[0-9])\d{5}$"; // T-Mobile starts with 7

            // Match the phone number to the regex patterns
            if (Regex.IsMatch(phoneNumber, regexCosmote))
            {
                carrier = "Cosmote";
            }
            else if (Regex.IsMatch(phoneNumber, regexVodafone))
            {
                carrier = "Vodafone";
            }
            else if (Regex.IsMatch(phoneNumber, regexNova))
            {
                carrier = "Nova";
            }

            return carrier;
        }

        public void InfoEmployee(Employee employee, ref int age, ref int yearsOfExperience)
        {
            // Your logic to calculate age and years of experience
            // For simplicity, assuming that HiringDate represents the start of employment
            age = DateTime.Now.Year - employee.Birthday.Year;
            yearsOfExperience = DateTime.Now.Year - employee.HiringDate.Year;
        }

        public int LiveInAthens(Employee[] employees)
        {
            int count = 0;

            foreach (var employee in employees)
            {
                int typePhone = 0;
                string infoPhone = null;

                // Assuming CheckPhone is implemented properly to check the location
                CheckPhone(employee.HomePhone, ref typePhone, ref infoPhone);

                // For simplicity, assuming typePhone = 0 represents Athens
                if (typePhone == 0 && infoPhone.Equals("Μητροπολιτική Περιοχή Αθήνας – Πειραιά"))
                {
                    count++;
                }
            }

            return count;
        }
    }
}