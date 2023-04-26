namespace Pudelko
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pudelko p1 = new Pudelko(2.5, 9.321, 0.1);
            Console.WriteLine(p1.ToString());
            Console.WriteLine(p1.ToString("m"));
            Console.WriteLine(p1.ToString("cm"));
            Console.WriteLine(p1.ToString("mm"));

        }
    }
    enum UnitOfMeasure
    {
        milimeter,
        centimeter,
        meter
    }
    class Pudelko
    {
        private double a, b, c;
        private UnitOfMeasure unit;

        public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if(a <= 0 || b<=0 || c <= 0) throw new ArgumentOutOfRangeException("Wymiary pudełka muszą być dodatnie");

            if (a > 10 || b > 10 || c > 10) throw new ArgumentOutOfRangeException("Wymiary pudełka nie mogą przekroczyć 10 m");

            this.a = a;
            this.b = b;
            this.c = c;
            this.unit = unit;
        }
        public double A
        {
            get { return a / 100.0; }
        }
        public double B
        {
            get { return b / 100.0; }
        }
        public double C
        {
            get { return C / 100.0; }
        }
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
                default:
                    throw new FormatException("Nieznany format.");
            }
           
        
        }

    }
}