using Newtonsoft.Json;
namespace OrderOfBattle.Model.Ruleset
{
    public class Category
    {
        string Name;
        CharacteristicSet Characteristics;
        [JsonConstructor]
        public Category(string name, CharacteristicSet characteristics){
            Name = name;
            Characteristics = characteristics;
        }
        
    }
}