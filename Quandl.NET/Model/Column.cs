namespace Quandl.NET.Model
{
    public class Column
    {
        public Column(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; private set; }

        public string Type { get; private set; }
    }
}