using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using OrderOfBattle.Model.Ruleset;

namespace OrderOfBattle.UnitTests.RulesetTest
{
    public class RulesetTest
    {
        [Fact]
        public void Serialize()
        {
            Ruleset r = new Ruleset("gfdgs", "fdsfsdf", "fdsfdsfds", "fdsfsdfds", "fdsfdsfs", "0.1.1");
            string temp = JsonConvert.SerializeObject(r);
            Ruleset? t = JsonConvert.DeserializeObject<Ruleset>(temp);
        }
    }
}