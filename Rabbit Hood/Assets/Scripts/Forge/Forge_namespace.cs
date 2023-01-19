namespace forgechoice
{
    public class Forge
    {
        public string name;
        public string title;
        public string description;
        public string png_path;

        public Forge() { }
        public Forge(string _name, string _title, string _description, string _png_path)
        {
            name = _name;
            title = _title;
            description = _description;
            png_path = _png_path;
        }
    }
}