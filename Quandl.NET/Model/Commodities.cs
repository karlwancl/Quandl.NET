namespace Quandl.NET.Model
{
    public class Commodities
    {
        public Commodities(string name, string code, string source, string sector)
        {
            Name = name;
            Code = code;
            Source = source;
            Sector = sector;
        }

        public string Name { get; private set; }

        public string Code { get; private set; }

        public string Source { get; private set; }

        public string Sector { get; private set; }
    }
}