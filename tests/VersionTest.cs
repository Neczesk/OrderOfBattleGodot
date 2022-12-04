using Xunit;
using Newtonsoft.Json;

namespace OrderOfBattle.UnitTests.VersionTest
{
    public class VersionTest
    {
        [Fact]
        public void CreateFromInts()
        {
            Model.Ruleset.Version v = new Model.Ruleset.Version(0,1,0);
            Assert.Equal<string>("0.1.0", v.ToString());
        }
        [Fact]
        public void CreateFromString()
        {
            Model.Ruleset.Version v = new Model.Ruleset.Version("0.1.0");
            Assert.Equal<string>("0.1.0", v.ToString());
        }
        [Fact]
        public void Compare()
        {
            Model.Ruleset.Version v = new Model.Ruleset.Version("0.3.0");
            Model.Ruleset.Version t = new Model.Ruleset.Version("0.2.0");
            Assert.True(v.CompareTo(t) > 0);
        }
        [Fact]
        public void Serialize(){
            Model.Ruleset.Version v = new Model.Ruleset.Version("0.1.1");
            string temp = JsonConvert.SerializeObject(v, Formatting.Indented);
            Model.Ruleset.Version? r = JsonConvert.DeserializeObject<Model.Ruleset.Version>(temp);
            Assert.True(v.CompareTo(r) == 0);
        }
    }
}