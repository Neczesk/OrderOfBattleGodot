using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderOfBattle.Model.Ruleset
{
    public class Relation
    {
        public int ParentID;
        public int ChildId;
        public int Cost;
        public int Minimum;
        public int Maximum;
    }
}