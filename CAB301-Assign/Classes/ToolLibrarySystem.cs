using System;
using System.Collections.Generic;
using System.Text;


namespace Assignment
{
    class ToolLibrarySystem : iToolLibrarySystem
    {
        private MemberCollection data = new MemberCollection();

        //array to store each categorie seperately
        private ToolCollection[] gardeningTools = new ToolCollection[30];
        private ToolCollection[] flooringTools = new ToolCollection[30];
        private ToolCollection[] fencingTools = new ToolCollection[30];
        private ToolCollection[] measuringTools = new ToolCollection[30];
        private ToolCollection[] cleaningTools = new ToolCollection[30];
        private ToolCollection[] paintingTools = new ToolCollection[30];
        private ToolCollection[] electricityTools = new ToolCollection[30];
        private ToolCollection[] electronicTools = new ToolCollection[30];
        private ToolCollection[] automotiveTools = new ToolCollection[30];

        //arrays holding the type names to access later as indexes to the categorie arrays
        private string[] gardeningTypes = new string[] { "Line Trimmers", "Lawn Mowers", "Hand Tools", "Wheelbarrows", "Garden Power Tools" };
        private string[] flooringTypes = new string[] { "Scrapers", "Floor Lasers", "Floor Levelling Tools", "Floor Levelling Materials", "Floor Hand Tools","Tiling Tools" };
        private string[] fencingTypes = new string[] { "Hand Tools", "Electric Fencing", "Steel Fencing Tools", "Power Tools", "Fencing Accessories" };
        private string[] measuringTypes = new string[] { "Distance Tools", "Laser Measurer", "Measuring Jugs", "Temperature & Humidity Tools", "Levelling Tools", "Markers" };
        private string[] cleaningTypes = new string[] { "Draining", "Car Cleaning", " Vacuum", "Pressure Cleaners", "Pool Cleaning", "Flooring Cleaning" };
        private string[] paintingTypes = new string[] { "Sanding Tools", "Brushes", "Rollers", "Paint Removal Tools", "Paint Scrapers", "Sprayers" };
        private string[] electricityTypes = new string[] { "Voltage Tester", "Oscilloscopes", "Thermal Imaging", "Data Test Tool", "Insulation Testers" };
        private string[] electronicTypes = new string[] { "Test Equipment", "Safety Equipment", "Basic Hand tools", "Circuit Protection", "Cable Tools" };
        private string[] automotiveTypes = new string[] { "Jacks", "Air Compressors", "Battery Chargers", "Socket Tools", "Braking", "Drivetrain" };

        //stores the number of times a tool was borrowed and the name in a parallel array
        private int[] borNum = new int[1000];
        private string[] borName = new string[1000];
        private int borLength = 0;
        public ToolLibrarySystem()
        {

        }
        public void add(iTool aTool)
        {
            var tuple = findCategorie(aTool.Categorie);
            
            ToolCollection[] catArr = tuple.Item1;
            string[] typeArr = tuple.Item2;
            int type = findType(aTool.Type, typeArr);

            ToolCollection toolArr = catArr[type] = new ToolCollection(); ;
            toolArr.add(aTool);
        }

        public void add(iTool aTool, int quantity)
        {
            var tuple = findCategorie(aTool.Categorie);
            ToolCollection[] catArr = tuple.Item1;
            string[] typeArr = tuple.Item2;
            int type = findType(aTool.Type, typeArr);

            aTool.Quantity += quantity;
            catArr[type].add(aTool);
        }

        public void add(Member Member)
        {
            data.add(Member);
        }

        public void borrowTool(Member Member, iTool aTool)
        {
            Member.addTool(aTool);
            for(int i = 0; i < borName.Length; i++)
            {
                if(aTool.Name == borName[i])
                {
                    borNum[i] = borNum[i] + 1;
                } else
                {
                    borName[borLength] = aTool.Name;
                    borNum[borLength] = borNum[borLength] + 1;
                }
            }
        }

        public void delete(iTool aTool)
        {
            var tuple = findCategorie(aTool.Categorie);
            ToolCollection[] catArr = tuple.Item1;
            string[] typeArr = tuple.Item2;
            int type = findType(aTool.Type, typeArr);

            catArr[type].delete(aTool);
        }

        public void delete(iTool aTool, int quantity)
        {
            var tuple = findCategorie(aTool.Categorie);
            ToolCollection[] catArr = tuple.Item1;
            string[] typeArr = tuple.Item2;
            int type = findType(aTool.Type, typeArr);

            ToolCollection coll = catArr[type];
            iTool[] tool = coll.toArray();

            for(int i = 0; i < tool.Length; i++)
            {
                if(tool[i] == aTool)
                {
                    tool[i].Quantity -= quantity;
                }
            }
        }

        public void delete(Member Member)
        {
            data.delete(Member);
        }

        public void displayBorrowingTools(Member Member)
        {
            for (int i = 0; i < Member.Tools.Length; i++)
            {
                Console.WriteLine(Member.Tools[i]);
            }
        }

        public void displayTools(string aToolType)
        {
            ToolCollection[] coll = findType(aToolType);
            for (int i =0; i < coll.Length; i++)
            {
                Console.WriteLine(coll[i]);
            }
        }

        public void displayTopThree()
        {
            bubbleSort(borNum, borName);
            for(int i =0; i<3; i++)
            {
                Console.WriteLine(borName + " - " + borName);
            }
        }

        public string[] listTools(Member Member)
        {
            return Member.Tools;
        }

        public void returnTool(Member Member, iTool aTool)
        {
            Member.deleteTool(aTool);
        }

        //required to findTool based on user input in main
        public iTool[] findTool(string cat, string type, string name)
        {
            var tuple = findCategorie(cat);
            ToolCollection[] catArr = tuple.Item1;
            string[] typeArr = tuple.Item2;
            int index = findType(type,typeArr);
            if(catArr[index].toArray() == null)
            {
                return null;
            }else
            {
                return catArr[index].toArray();
            }
        }

        //method to return the correct ToolCollection array
        private Tuple<ToolCollection[],string[]> findCategorie(string cat)
        {
            if (cat == "Gardening Tools")
            {
                return new Tuple<ToolCollection[], string[]>(gardeningTools,gardeningTypes);
            }
            else if (cat == "Flooring Tools")
            {
                return new Tuple<ToolCollection[], string[]>(flooringTools,flooringTypes);
            }
            else if (cat == "Fencing Tools")
            {
                return new Tuple<ToolCollection[], string[]>(fencingTools,fencingTypes);
            }
            else if (cat == "Measuring Tools")
            {
                return new Tuple<ToolCollection[], string[]>(measuringTools,measuringTypes);
            }
            else if (cat == "Cleaning Tools")
            {
                return new Tuple<ToolCollection[], string[]>(cleaningTools, cleaningTypes);
            }
            else if (cat == "Painting Tools")
            {
                return new Tuple<ToolCollection[], string[]>(paintingTools, paintingTypes);
            }
            else if (cat == "Electricity Tools")
            {
                return new Tuple<ToolCollection[], string[]>(electricityTools, electricityTypes);
            }
            else if (cat == "Electronic Tools")
            {
                return new Tuple<ToolCollection[], string[]>(electronicTools, electronicTypes);
            }
            else if (cat == "Automotive Tools")
            {
                return new Tuple<ToolCollection[], string[]>(automotiveTools, automotiveTypes);
            } 
            else
            {
                return null;
            }
        }

        //method to return the index of the toolCollection array the type is held in
        private int findType(string type, string[] cat)
        {
            for(int i = 0; i<cat.Length; i++)
            {
                if(cat[i] == type)
                {
                    return i;
                }
            }
            return -1;
        }

        //method to return the requried ToolCollection array
        private ToolCollection[] findType(string type)
        {
            for (int i = 0; i < gardeningTypes.Length; i++)
            {
                if (type == gardeningTypes[i])
                {
                    return gardeningTools;
                }
            }
            for (int i = 0; i < flooringTypes.Length; i++)
            {
                if (type == flooringTypes[i])
                {
                    return flooringTools;
                }
            }
            for (int i = 0; i < fencingTypes.Length; i++)
            {
                if (type == fencingTypes[i])
                {
                    return fencingTools;
                }
            }
            for (int i = 0; i < measuringTypes.Length; i++)
            {
                if (type == measuringTypes[i])
                {
                    return measuringTools;
                }
            }
            for (int i = 0; i < cleaningTypes.Length; i++)
            {
                if (type == cleaningTypes[i])
                {
                    return cleaningTools;
                }
            }
            for (int i = 0; i < paintingTypes.Length; i++)
            {
                if (type == paintingTypes[i])
                {
                    return paintingTools;
                }
            }
            for (int i = 0; i < electricityTypes.Length; i++)
            {
                if (type == electricityTypes[i])
                {
                    return electricityTools;
                }
            }
            for (int i = 0; i < electronicTypes.Length; i++)
            {
                if (type == electronicTypes[i])
                {
                    return electronicTools;
                }
            }
            for (int i = 0; i < automotiveTypes.Length; i++)
            {
                if (type == automotiveTypes[i])
                {
                    return automotiveTools;
                }
            }
            return null;
        }

        static void bubbleSort(int[] arr, string[] arr1)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        // swap corresponding elements of the names array
                        string temp2 = arr1[j];
                        arr1[j] = arr1[j + 1];
                        arr1[j + 1] = temp2;
                    }
        }
    }
}
