namespace Distance_Calculator
{
    class MDist
    {
        //public decimal distance;
        //public string distName;

        public MDist(string name, decimal dist)
        {
            DistName = name;
            Distance = dist;
        }

        public string DistName
        {
            get;
            set;
        }

        public decimal Distance
        {
            get;
            set;
        }

        //Format how to return this data structure
        public override string ToString()
        {
            return string.Concat(DistName, ": ", Distance.ToString());
        }

    }
}
