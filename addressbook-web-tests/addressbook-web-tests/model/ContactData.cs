using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allEmails;
        private string allPhones;
        private string allInfo;

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName 
                && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() 
                & LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "name =" + FirstName + " " + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            return LastName.CompareTo(other.LastName);
        }

        public string FirstName { get; set; }

        public string LastName { get; set; } 

        public string Id { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
               else
                {
                    return Email + "\r\n" + Email2 + "\r\n" + Email3;
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string AllPhones 
        { 
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllInfo
         {
             get
             {
                 if (allInfo != null)
                 {
                     return allInfo;
                 }
                 else
                 {
                     return FirstName + " " + LastName + "\r\n" 
                         + Address + "\r\n\r\n"
                         + "H: " + HomePhone + "\r\n"
                         + "M: " + MobilePhone + "\r\n"
                         + "W: " + WorkPhone + "\r\n\r\n"
                         + Email + "\r\n"
                         + Email2 + "\r\n"
                         + Email3;
                 }
             }
             set
             {
                 allInfo = value;
             }
         }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";

            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
    }
}
