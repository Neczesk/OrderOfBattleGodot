using System;
namespace Model {
    public class Version : System.IComparable<Version>{
        private int Major;
        private int Minor;
        private int Release;
        public Version(int m, int mm, int r){
            Major = m;
            Minor = mm;
            Release = r;
        }
        public Version(string v){
            string[] split = v.Split(".");
            if (int.TryParse(split[0], out Major) && int.TryParse(split[1], out Minor) && int.TryParse(split[2], out Release)){

            } else{
                Major = -1;
                Minor = -1;
                Release = -1;
            }
        }
        public override string ToString()
        {
            return Major.ToString() + "." + Minor.ToString() +"." + Release.ToString();
        }

        public int CompareTo(Version other)
        {
            if (this.Major != other.Major){
                return other.Major - this.Major;
            } else if (this.Minor != other.Minor){
                return other.Minor - this.Minor;
            } else if (this.Release != other.Release){
                return other.Release - this.Release;
            }
            return 0;
        }
    }
}
