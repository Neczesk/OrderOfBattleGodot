using System.Collections.Generic;
using System;
namespace Model {
    public class Ruleset{
        public string GameName;
        public string GameAuthor;
        public string GameDesc;
        public Version Version;
        public string FileAuthor;
        public string RootName;

        public override string ToString()
        {
            return "Name: " + GameName;
        }

        public Ruleset(string gName, string gAuthor, string fAuthor, string gDesc, string gRoot, string version){
            this.GameName = gName;
            this.GameAuthor = gAuthor;
            this.GameDesc = gDesc;
            this.FileAuthor = fAuthor;
            this.RootName = gRoot;
            this.Version = new Version(version);
        }
    }


}