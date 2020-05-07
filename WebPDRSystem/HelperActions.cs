using WebPDRSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace WebPDRSystem
{
    public static class HelperActions
    {
        private static string FullName;
        public static string FixName(this string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        public static string FirstToUpper(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = text.Trim().ToLower();

                text = text.First().ToString().ToUpper() + text.Substring(1);

                return text;
            }
            else
                return "";
        }

        public static string NameToUpper(this string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                string[] names = name.Split(null);
                string fullname = "";
                foreach (var item in names)
                {
                    fullname += item.FirstToUpper() + " ";
                }
                return fullname;
            }
            else
            {
                return "";
            }
        }
        public static string GetAddress(this Guardian patient)
        {
            string address = patient.ProvinceNavigation.Description + ", " + patient.MuncityNavigation.Description + ", " + patient.BarangayNavigation.Description;

            if (!string.IsNullOrEmpty(patient.Address))
            {
                address += "," + patient.Address;
            }

            return address;
        }

        public static string Checkbool(this bool check)
        {
            return check ? "✓" : "";
        }

        public static string CheckMedParams(this string text, string divider)
        {
            if (!string.IsNullOrEmpty(text))
                return divider + text;
            else
                return "";
        }
        public static DateTime RemoveSeconds(this DateTime dateTime)
        {
            var dt = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0);
            return dt;
        }

        public static string GetAddress(this Patient patient)
        {
            string address = patient.ProvinceNavigation.Description + ", " + patient.MuncityNavigation.Description + ", " + patient.BarangayNavigation.Description;

            if(!string.IsNullOrEmpty(patient.Address))
            {
                address += "," + patient.Address;
            }

            return address;
        }


        public static string ComputeTimeFrame(this double minutes)
        {
            var min = Math.Floor(minutes);
            var minute = min == 0 ? "" : min + "m";
            var sec = Math.Round((minutes - min) * 60);
            var seconds = sec == 0 ? "" : sec + "s";
            var total = minute + " " + seconds;
            return total;
        }

        public static int ComputeAge(this DateTime dob)
        {
            var today = DateTime.Today;

            var age = today.Year - dob.Year;

            if (dob.Date > today.AddYears(-age))
                age--;

            return age;
        }

        public static int ComputeAge(this DateTime? dob)
        {
            var realDob = (DateTime)dob;
            var today = DateTime.Today;

            var age = today.Year - realDob.Year;

            if (realDob.Date > today.AddYears(-age))
                age--;

            return age;
        }

        public static double ArchivedTime(DateTime date)
        {
            return Convert.ToInt32(DateTime.Now.Subtract(date).TotalMinutes);
        }

        public static string GetDate(this DateTime date, string format)
        {
            if (date != default)
            {
                if (!format.Contains("tt"))
                {
                    return date.ToString(format);
                }
                else
                    return date.ToString(format, CultureInfo.InvariantCulture);
            }
            else
                return "";
        }

        public static string GetDate(this DateTime? date, string format)
        {
            if (date != null)
            {
                var realDate = (DateTime)date;
                if (!format.Contains("tt"))
                {
                    return realDate.ToString(format);
                }
                else
                    return realDate.ToString(format, CultureInfo.InvariantCulture);
            }
            else
                return "";
        }

        public static string CheckAddress(this string address)
        {
            return string.IsNullOrEmpty(address) ? "" : address + ", ";
        }

        public static string CheckString(this string text)
        {
            return string.IsNullOrEmpty(text) ? "" : text;
        }

        public static string GetFullName(this Guardian patient)
        {
            if (patient != null)
                return patient.Firstname.CheckName() + " " + patient.Middlename.CheckName() + " " + patient.Lastname.CheckName();
            else
                return "";
        }

        public static string GetFullName(this Patient patient)
        {
            if (patient != null)
                return patient.Firstname.CheckName() + " " + patient.Middlename.CheckName() + " " + patient.Lastname.CheckName();
            else
                return "";
        }

        public static string GetFullLastName(Pdrusers user)
        {
            if (user != null)
                return user.Lastname.CheckName() + ", " + user.Firstname.CheckName() + " " + user.Middlename.CheckName();
            else
                return "";
        }
        public static string GetFullLastName(this Patient patient)
        {
            if (patient != null)
                return patient.Lastname.CheckName() + ", " + patient.Firstname.CheckName() + " " + patient.Middlename.CheckName();
            else
                return "";
        }
        public static string GetFullName(this Pdrusers user)
        {
            if (user != null)
                return user.Firstname.CheckName() + " " + user.Middlename.CheckName() + " " + user.Lastname.CheckName();
            else
                return "";
        }

        public static string GetMDFullName(this Pdrusers doctor)
        {
            if (doctor != null)
                FullName = "Dr. " + doctor.Firstname.CheckName() + " " + doctor.Middlename.CheckName() + " " + doctor.Lastname.CheckName();
            else
                FullName = "";

            return FullName;
        }

        public static string CheckName(this string name)
        {
            return string.IsNullOrEmpty(name) ? "" : name;
        }
    }
}
