using System.Collections.Generic;
using Newtonsoft.Json;
namespace OrderOfBattle.Model.Ruleset{
    public class Element {
        public string Name;
        public string Description;
        public int Id;
        public List<Relation> Relations;
        public OrderOfBattle.Model.Ruleset.Category Category;

        [JsonConstructor]
        public Element(string name, string description, int id, List<Relation> relations, Category category){
            this.Name = name;
            this.Description = description;
            this.Id = id;
            this.Relations = relations;
            this.Category = category;
        }
        
    }
}