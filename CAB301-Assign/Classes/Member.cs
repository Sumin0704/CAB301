using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Assignment
{
    class Member : iMember, IComparable<Member>
    {
        private string firstName, lastName, contactNumber, pin;
        private List<string> toolList = new List<string>();

        public Member(string fName, string lName, string conNumber, string pinCode)
        {
            this.firstName = fName;
            this.lastName = lName;
            this.contactNumber = conNumber;
            this.pin = pinCode;
        }

        public string FirstName { 
            get {
                return firstName;
            } set {
                firstName = value;
            }
        }
        public string LastName {
            get {
                return lastName;
            } set {
                lastName = value;
            } 
        }
        public string ContactNumber { 
            get {
                return contactNumber;
            } set {
                contactNumber = value;
            }
        }
        public string PIN { get {
                return pin;
            } set {
                pin = value;
            }
        }
        public string[] Tools => toolList.ToArray();

        public void addTool(iTool aTool)
        {
            toolList.Add(aTool.Name);
        }
        public override string ToString()
        {
            return (FirstName + " " + LastName + " " + ContactNumber + "\n");
        }

        public void deleteTool(iTool aTool)
        {
            toolList.Remove(aTool.Name);
        }

        public int CompareTo(Member other)
        {
            if (this.lastName.CompareTo(other.LastName) < 0)
                return -1;
            else
        if (this.lastName.CompareTo(other.LastName) == 0)
                return this.firstName.CompareTo(other.FirstName);
            else
                return 1;

        }
    }
}
