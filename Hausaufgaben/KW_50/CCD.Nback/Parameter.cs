namespace CCD.Nback
{
    public class Parameter
    {
        public Parameter(string name, int reizDauer, int nummer, int reizAnzahl)
        {
            Proband = name;
            Reizdauer = reizDauer;
            Nummer = nummer;
            ReizeAnzahl = reizAnzahl;
        }

        public string Proband { get; set; }

        public int Reizdauer { get; set; }

        public int Nummer { get; set; }

        public int ReizeAnzahl { get; set; }
    }
}