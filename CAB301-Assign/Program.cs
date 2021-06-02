using System;
using System.Text.RegularExpressions;

namespace Assignment
{
    class Program
    {
        ToolLibrarySystem toolData;
        MemberCollection memberData;
        string firstName = "";
        string lastName = "";

        //storing the first and last name of current user to find their object later 

        private void Initialise()
        {
            toolData = new ToolLibrarySystem();
            memberData = new MemberCollection();
            
            mainMenu();
            
    }
        static void Main(string[] args)
        {
            //Main menu and two sub-menus
            Program pg = new Program();
            pg.Initialise();   
        }
        private void mainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library " +
                "\n===========Main Menu=========== " +
                "\n1. Staff Login " +
                "\n2. Member Login " +
                "\n0. Exit " +
                "\n=============================== " +
                "\n\nPlease make a selection (1-2, or 0 to exit):");
            string output = Console.ReadLine();
            if (output== "1")
            {
                staffLogin();

            }
            else if (output == "2")
            {
                checkID();
            }
            else
            {
                mainMenu();
            }
        }
        private void createMember()
        {
            Console.Clear();
            Console.WriteLine("===========Create New Member=========== ");
            Console.WriteLine("Please enter the members first name");
            string firstname = Console.ReadLine();

            Console.WriteLine("Please enter the members last name");
            string lastname = Console.ReadLine();

            Console.WriteLine("Please enter your contact number");
            string contactnumber = Console.ReadLine();

            Console.WriteLine("Please enter your PIN");
            string pin = Console.ReadLine();

            memberData.add(new Member(firstname, lastname, contactnumber, pin));

            Console.WriteLine("New member successfully created");

            reDirect();
            
        }
        private void checkID()
        {
            Console.Clear();
            Console.WriteLine("===========Login===========");
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();

            //username is entered as LastnameFirstname so regex is necessary
            string[] split = Regex.Split(username, @"(?<!^)(?=[A-Z])");

            Console.WriteLine("Please enter your PIN:");
            string pin = Console.ReadLine();

            iMember[] memArr = memberData.toArray();
            for(int i = 0; i < memArr.Length; i++)
            {
                if ((memArr[i].FirstName == split[1]) && (memArr[i].LastName == split[0]))
                {
                    bool output = memberData.search(new Member(split[1], split[0], memArr[i].ContactNumber, pin));
                    if (output)
                    {
                        firstName = split[1];
                        lastName = split[0];
                        memberMenu();
                    } else
                    {
                        Console.WriteLine("Incorrect username or password");
                        reDirect();
                    }
                } else
                {
                    Console.WriteLine("Incorrect username or password");
                    reDirect();
                }
            }
            Console.WriteLine("Incorrect username or password");
            reDirect();

        }
        private void staffMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library " +
                "\n ===========Staff Menu===========" +
                "\n1. Add a new tool" +
                "\n2. Add new pieces of an existing tool" +
                "\n3. Remove some pieces of a tool" +
                "\n4. Register a new member" +
                "\n5. Remove a memeber" +
                "\n6. Find the contact number of a member" +
                "\n0. Return to main menu" +
                "\n=============================== " +
                "\n\nPlease make a selection (1-6, or 0 to exit):");
            switch (Console.ReadLine())
            {
                case "1":
                    addTool();
                    break;
                case "2":
                    addPieces();
                    break;
                case "3":
                    deletePieces();
                    break;
                case "4":
                    createMember(); 
                    break;
                case "5":
                    deleteMember();
                    break;
                case "6":
                    conNum();
                    break;
                case "0":
                    mainMenu();
                    break;
            }
        }
        private void memberMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Tool Library " +
                "\n ===========Member Menu===========" +
                "\n1. Display all the tools of a tool type" +
                "\n2. Borrow a tool" +
                "\n3. Return a tool" +
                "\n4. List all the tools that I am renting" +
                "\n5. Display top three (3) most frequently rented tools" +
                "\n0. Return to main menu" +
                "\n=============================== " +
                "\n\nPlease make a selection (1-5, or 0 to exit):");
            switch (Console.ReadLine())
            {
                case "1":
                    displayAllTools();
                    break;
                case "2":
                    borrowTool();
                    break;
                case "3":
                    returnTool();
                    break;
                case "4":
                    currentRent();
                    break;
                case "5":
                    dispTop3();
                    break;
                case "0":
                    mainMenu();
                    break;
            }
        }

        private void staffLogin()
        {
            Console.Clear();
            Console.WriteLine("===========Login===========");
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();
            if ((username == "staff") && (password == "today123")){
                staffMenu();
            }
            else 
            {
                Console.WriteLine("Incorrect username or password");
                reDirect();
            }

        }
        private void addTool()
        {
            Console.Clear();
            Console.WriteLine("===========New Tool===========");
            Console.WriteLine("Provide the tool categorie");
            string cat = Console.ReadLine();
            Console.WriteLine("Provide the tool type");
            string type = Console.ReadLine();
            Console.WriteLine("Provide the tool name");
            string name = Console.ReadLine();

            toolData.add(new Tool(cat, type, name));

            Console.WriteLine("Successfully added new tool");
            reDirect1();

        }
        private void addPieces()
        {
            Console.Clear();
            Console.WriteLine("===========New Pieces of Tool===========");
            Console.WriteLine("Provide the tool categorie");
            string cat = Console.ReadLine();
            Console.WriteLine("Provide the tool type");
            string type = Console.ReadLine();
            Console.WriteLine("Provide the tool name");
            string name = Console.ReadLine();
            Console.WriteLine("Provide the tool quantity");
            string quantity = Console.ReadLine();
            int quan = Int32.Parse(quantity);

            iTool[] toolArr = toolData.findTool(cat, type, name);
            for (int i = 0; i < toolArr.Length; i++)
            {
                if (toolArr[i] != null)
                {
                    if (toolArr[i].Name == name)
                    {
                        toolData.add(toolArr[i], quan);
                    }
                } 
            }
            Console.WriteLine("Successfully added new tool pieces");
            reDirect1();
        }
        private void deletePieces()
        {
            Console.Clear();
            Console.WriteLine("===========Delete Pieces of Tool===========");
            Console.WriteLine("Provide the tool categorie");
            string cat = Console.ReadLine();
            Console.WriteLine("Provide the tool type");
            string type = Console.ReadLine();
            Console.WriteLine("Provide the tool name");
            string name = Console.ReadLine();
            Console.WriteLine("Provide the tool quantity");
            string quantity = Console.ReadLine();
            int quan = Int32.Parse(quantity);

            //bool to stop the for loop once operation is done to avoid null errors
            bool notDone = true;

            iTool[] toolArr = toolData.findTool(cat, type, name);
            for (int i = 0; i < toolArr.Length && notDone; i++)
            {
                if (toolArr[i].Name == name)
                {
                    toolData.delete(toolArr[i],quan);
                    notDone = false;
                }
            }
            Console.WriteLine("Successfully deleted tool");
            reDirect1();
        }
        private void deleteMember()
        {
            Console.Clear();
            Console.WriteLine("===========Delete Member===========");
            Console.WriteLine("Provide the members first name:");
            string firstname = Console.ReadLine();
            Console.WriteLine("Provide the members last name:");
            string lastname = Console.ReadLine();
            Console.WriteLine("Provide the members contact number:");
           
            Member[] memArr = memberData.toArray();

            //bool to stop the for loop once operation is done to avoid null errors
            bool notDone = true;
            for (int i = 0; i < memArr.Length && notDone; i++)
            {
                if ((memArr[i].FirstName == firstname) && (memArr[i].LastName == lastname))
                {
                    memberData.delete(memArr[i]);
                    notDone = false;
                }
            }

            Console.WriteLine("Successfully deleted member");
            reDirect1();

        }
        private void conNum()
        {
            Console.Clear();
            Console.WriteLine("===========Find Contact Number===========");
            Console.WriteLine("Please enter the members first name:");
            string firstname = Console.ReadLine();

            Console.WriteLine("Please enter the members last name:");
            string lastname = Console.ReadLine();

            Member[] memArr = memberData.toArray();

            //bool to stop the for loop once operation is done to avoid null errors
            bool notDone = true;

            for (int i = 0; i < memArr.Length && notDone; i++)
            {
                if ((memArr[i].FirstName == firstname) && (memArr[i].LastName == lastname))
                {
                    Console.WriteLine(memArr[i].ContactNumber);
                    notDone = false;
                }
            }
            reDirect1();
        }
        private void displayAllTools()
        {
            Console.Clear();
            Console.WriteLine("Display all tools of a selected tool type:");
            Console.WriteLine("Please enter the tool type");
            string type = Console.ReadLine();

            toolData.displayTools(type);

            reDirect2();
        }
        private void borrowTool()
        {
            Console.Clear();
            Console.WriteLine("===========Borrow a tool===========");
            Console.WriteLine("Please enter the tool categorie in the format 'Gardening Tools','Automotive Tools' etc..");
            string cat = Console.ReadLine();
            Console.WriteLine("Please enter the tool type in the format 'Line Trimmers','Scrapers' etc..");
            string type = Console.ReadLine();
            Console.WriteLine("Please enter the tool name:");
            string name = Console.ReadLine();

            //bool to stop the for loop once operation is done to avoid null errors
            bool notDone = true;
            Member[] memArr = memberData.toArray();
            for (int i = 0; i < memArr.Length; i++)
            {
                if(memArr[i] == null){
                    if ((memArr[i].FirstName == firstName) && (memArr[i].LastName == lastName))
                    {
                        if (memArr[i].Tools.Length < 3)
                        {
                            iTool[] toolArr = toolData.findTool(cat, type, name);
                            for (int j = 0; j < toolArr.Length; j++)
                            {
                                if (toolArr[j].Name == name)
                                {
                                    toolData.borrowTool(memArr[i], toolArr[j]);
                                    notDone = false;

                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry but it seems you already have 3 borrowed tools");
                            reDirect();
                        }
                    }
                }
            }
            if (notDone)
            {
                Console.WriteLine("Error borrowing tool, make sure that it exists first");
            } else
            {
                Console.WriteLine("Successfully borrowed new tool");
            }
            reDirect2();
        }
        private void returnTool()
        {
            Console.Clear();
            Console.WriteLine("===========Borrow a tool===========");
            Console.WriteLine("Please enter the tool categorie in the format 'Gardening Tools','Automotive Tools' etc..");
            string cat = Console.ReadLine();
            Console.WriteLine("Please enter the tool type in the format 'Line Trimmers','Scrapers' etc..");
            string type = Console.ReadLine();
            Console.WriteLine("Please enter the tool name:");
            string name = Console.ReadLine();

            Member[] memArr = memberData.toArray();
            for (int i = 0; i < memArr.Length; i++)
            {
                    if ((memArr[i].FirstName == firstName) && (memArr[i].LastName == lastName))
                    {
                        if (memArr[i].Tools.Length > 0)
                        {
                            iTool[] toolArr = toolData.findTool(cat, type, name);
                            for (int j = 0; j < toolArr.Length; j++)
                            {
                                if (toolArr[j].Name == name)
                                {
                                    toolData.returnTool(memArr[i], toolArr[j]);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry but it seems you have no tools to return");
                            reDirect();
                        }
                    }
            }
            reDirect2();
        }
        private void currentRent()
        {
            Console.Clear();
            Console.WriteLine("Currently rented tools:");
            Member[] memArr = memberData.toArray();
            for (int i = 0; i < memArr.Length; i++)
            {
                if ((memArr[i].FirstName == firstName) && (memArr[i].LastName == lastName))
                {
                    toolData.displayBorrowingTools(memArr[i]);
                }
            }
            reDirect2();
        }
        private void dispTop3()
        {
            Console.Clear();
            Console.WriteLine("Top 3 Borrowed Tools:");
            toolData.displayTopThree();

            reDirect2();
        }
        private void reDirect()
        {
            Console.WriteLine("\nPress 0 to return to the main menu");
            string output = Console.ReadLine();
            if (output == "0")
            {
                mainMenu();
            }
        }
        private void reDirect1()
        {
            Console.WriteLine("\nPress 0 to return to the staff menu");
            string output = Console.ReadLine();
            if (output == "0")
            {
                staffMenu();
            }
        }
        private void reDirect2()
        {
            Console.WriteLine("\nPress 0 to return to the member menu");
            string output = Console.ReadLine();
            if (output == "0")
            {
                memberMenu();
            }
        }
    }
}
