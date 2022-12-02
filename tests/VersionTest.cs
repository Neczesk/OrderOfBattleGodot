using Xunit;
using Model;


namespace OrderOfBattle.UnitTests.Version
{
    public class VersionTest
    {
        [Fact]
        public void CreateFromInts()
        {
            Model.Version v = new Model.Version(0,1,0);
            Assert.Equal<string>("0.1.0", v.ToString());
        }
        [Fact]
        public void CreateFromString()
        {
            Model.Version v = new Model.Version("0.1.0");
            Assert.Equal<string>("0.1.0", v.ToString());
        }
        [Fact]
        public void Compare()
        {
            Model.Version v = new Model.Version("0.3.0");
            Model.Version t = new Model.Version("0.2.0");
            Assert.True(v.CompareTo(t) > 0);
        }
    }
}