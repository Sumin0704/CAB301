using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{ 
    class ToolCollection : iToolCollection
    {
        private iTool[] tools = new iTool[30];
        private int numTool = 0;
        private int state = 0;
        public int Number => numTool;

        public void add(iTool aTool)
        {
            //check if tool already exists, if true add the quantity

            for(int i = 0; i < 30; i++)
            {
                if (tools[i] != null)
                {
                    if (tools[i].Name == aTool.Name)
                    {
                        tools[i].Quantity += aTool.Quantity;
                        return;
                    }
                } else
                {
                    break;
                }

            }
            tools[numTool] = new Tool(aTool.Categorie,aTool.Type,aTool.Name);
            numTool++;
        }

        public void delete(iTool aTool)
        {
            for (int i = 0; i < tools.Length; i++)
            {
                if(tools[i] == aTool)
                {
                    Resize.resizeDelete(tools,i);
                }
            }
            numTool++;
        }

        public bool search(iTool aTool)
        {
            for (int i = 0; i < tools.Length; i++)
            {
                if (tools[i] == aTool)
                {
                    return true;
                }
            }
            return false;
        }

        public iTool[] toArray()
        {
            return tools;
        }
    }
}
