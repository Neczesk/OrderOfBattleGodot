internal class Version{
    private int Major;
    private int Minor;
    private int Release;
    internal Version(int m, int mm, int r){
        Major = m;
        Minor = mm;
        Release = r;
    }
    internal Version(string v){
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
}