using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Assignment
{
    class MemberCollection : iMemberCollection
    {
        private BSTree tree = new BSTree();
        private List<Member> memList = new List<Member>();


        private int num;
        public int Number => num;

        public void add(Member Member)
        {
            tree.Insert(Member);
            memList.Add(Member);
            num++;
        }
   
        public void delete(Member Member)
        {
            tree.Delete(Member);
            memList.Remove(Member);
            num--;
        }

        public bool search(Member Member)
        {
            return tree.Search(Member);
        }

        public Member[] toArray()
        { 
            return memList.ToArray();
        }
    }
}
