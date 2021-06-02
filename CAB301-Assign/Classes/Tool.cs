using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    class Tool : iTool
    {
        private int quantity = 0;
        private int numBorrow = 0;
        private List<Member> borrowers= new List<Member>();
        
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int NoBorrowings { get; set; }
        public string Type { get; set; }
        public string Categorie { get; set; }

        public Tool(string toolCat, string toolType, string toolName, int quantity = 1)
        {
            Name = toolName;
            this.quantity += quantity;
            Quantity = this.quantity;
            Type = toolType;
            Categorie = toolCat;
        }
        public iMemberCollection GetBorrowers => (iMemberCollection)borrowers;

        public void addBorrower(Member aMember)
        {
            borrowers.Add(aMember);
            AvailableQuantity = quantity - 1;
            numBorrow++;
            NoBorrowings = numBorrow;
        }

        public void deleteBorrower(Member aMember)
        {
            borrowers.Remove(aMember);
            AvailableQuantity = quantity + 1;
        }
        public override string ToString()
        {
            return (Name + " " + AvailableQuantity.ToString() + "\n");
        }
    }
}
