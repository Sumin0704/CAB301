using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{ 
    interface iToolLibrarySystem
    {
        void add(iTool aTool); // add a new tool to the system

        void add(iTool aTool, int quantity); //add new pieces of an existing tool to the system

        void delete(iTool aTool); //delete a given tool from the system

        void delete(iTool aTool, int quantity); //remove some pieces of a tool from the system

        void add(Member Member); //add a new member to the system

        void delete(Member Member); //delete a member from the system

        void displayBorrowingTools(Member Member); //given a member, display all the tools that the member are currently renting


        void displayTools(string aToolType); // display all the tools of a tool type selected by a member

        void borrowTool(Member Member, iTool aTool); //a member borrows a tool from the tool library

        void returnTool(Member Member, iTool aTool); //a member return a tool to the tool library

        string[] listTools(Member Member); //get a list of tools that are currently held by a given member

        void displayTopThree(); //Display top three most frequently borrowed tools by the members in the descending order by the number of times each tool has been borrowed.

        public iTool[] findTool(string cat, string type, string name);

    }
}
