using Newtonsoft.Json;
namespace OrderOfBattle.Model.Ruleset {
    public class Ruleset{
        public string GameName;
        public string GameAuthor;
        public string GameDesc;
        public Version Version;
        public string FileAuthor;
        public string RootName;
        public System.Collections.Generic.List<Element> Elements;
        public System.Collections.Generic.List<Constraint> Constraints;
        

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
            this.Elements = new System.Collections.Generic.List<Element>();
            this.Constraints = new System.Collections.Generic.List<Constraint>();
        }
        [JsonConstructor]
        public Ruleset(string gName, string gAuthor, string fAuthor, string gDesc, string gRoot, Version version){
            this.GameName = gName;
            this.GameAuthor = gAuthor;
            this.GameDesc = gDesc;
            this.FileAuthor = fAuthor;
            this.RootName = gRoot;
            this.Version = version;
            this.Elements = new System.Collections.Generic.List<Element>();
            this.Constraints = new System.Collections.Generic.List<Constraint>();
        }

        public string ToJson(){
            string output;
            output = JsonConvert.SerializeObject(this, Formatting.Indented);
            return output;
        }

    }


}