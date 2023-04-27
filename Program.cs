namespace Pudelko
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pudelko p1 = new Pudelko(2.5, 9.321, 0.1, UnitOfMeasure.meter);
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p1.ToString("m"));
            Console.WriteLine(p1.ToString("cm"));
            Console.WriteLine(p1.ToString("mm"));
            Console.WriteLine(p1.ToString("m3"));
            Console.WriteLine(p1.ToString("m2"));
            Console.WriteLine("");
            Pudelko p2 = new Pudelko(2.5, 9.321, 0.1, UnitOfMeasure.meter);
            Console.WriteLine($"Pudelko p2 = {p2}");

            Console.WriteLine($"p1 == p2 ? {p1 == p2}");
            Console.WriteLine($"p1 != p2 ? {p1 != p2}");

            Pudelko p3 = new Pudelko(1, 2.1, 3.05, UnitOfMeasure.meter);
            Console.WriteLine($"Pudelko p3 = {p3}");

            Console.WriteLine($"p1 == p3 ? {p1 == p3}");
            Console.WriteLine($"p1 != p3 ? {p1 != p3}");


        }
    }
    enum UnitOfMeasure
    {
        milimeter,
        centimeter,
        meter
    }
    class Pudelko : IEquatable<Pudelko>
    {
        private double a, b, c;
        private UnitOfMeasure unit;

        public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if (a <= 0 || b <= 0 || c <= 0) throw new ArgumentOutOfRangeException("Wymiary pudełka muszą być dodatnie");

            if (a > 10 || b > 10 || c > 10) throw new ArgumentOutOfRangeException("Wymiary pudełka nie mogą przekroczyć 10 m");

            this.a = a;
            this.b = b;
            this.c = c;
            this.unit = unit;
        }
        public double A => a / 100.0;
        public double B => b / 100.0;
        public double C => c / 100.0;
        public override string ToString()
        {
            string unitString = "";
            switch (unit)
            {
                case UnitOfMeasure.milimeter:
                    unitString = "mm";
                    break;
                case UnitOfMeasure.centimeter:
                    unitString = "cm";
                    break;
                case UnitOfMeasure.meter:
                    unitString = "m";
                    break;
            }
            return $"{a:F3} {unitString} × {b:F3} {unitString} × {c:F3} {unitString}";
        }
        public string ToString(string format)
        {
            string unitString = "";
            double factor = 1;
            switch (format)
            {
                case "m":
                    unitString = "m";
                    factor = 1;
                    return $"{a * factor:F3} {unitString} × {b * factor:F3} {unitString} × {c * factor:F3} {unitString}";
                case "cm":
                    unitString = "cm";
                    factor = 100;
                    return $"{a * factor:F1} {unitString} × {b * factor:F1} {unitString} × {c * factor:F1} {unitString}";
                case "mm":
                    unitString = "mm";
                    factor = 1000;
                    return $"{a * factor:F0} {unitString} × {b * factor:F0} {unitString} × {c * factor:F0} {unitString}";
                case "m3":
                    unitString = "m3";
                    factor = 1;
                    return $"{a * b * c * factor:F9} {unitString}";
                case "m2":
                    unitString = "m2";
                    factor = 1;
                    return $"{a*b * factor:F6} {unitString}";
                default:
                    throw new FormatException("Nieznany format.");
            }
        }
        public double Objetosc => Math.Round(a * b * c);
        public double Pole => Math.Round(a * b);

        public bool Equals(Pudelko other)
        {
            if (other == null) return false;

            var sortedThis = new[] {a,b,c }.OrderBy(x => x).ToArray();
            var sortedOther = new[] {other.a,other.b,other.c }.OrderBy(x => x).ToArray();

            return sortedThis[0] == sortedOther[0] && sortedThis[1] == sortedOther[1] && sortedThis[2] == sortedOther[2];
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Pudelko);
        }
        public override int GetHashCode()
        {
            return $"{a}{b}{c}".GetHashCode();
        }
        public static bool operator ==(Pudelko p1, Pudelko p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (ReferenceEquals(p1, null)) return false;
            if (ReferenceEquals(p2, null)) return false;

            return p1.Equals(p2);
        }

        public static bool operator !=(Pudelko p1, Pudelko p2)
        {
            return !(p1 == p2);
        }
    }

}
