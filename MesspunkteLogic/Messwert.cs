using System;
using System.Globalization;

namespace MesspunkteLogic
{
    public class Messwert
    {
        public Messwert(string messZeile)
        {
            var messwertTeile = messZeile.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            if (messwertTeile.Length < 9)
            {
                throw new ArgumentException("Inputdatenstrom enthält nicht genügend Spalten!");
            }

            if (int.TryParse(messwertTeile[0], out int a))
            {
                A = a;
            }
            else
            {
                throw new ArgumentException($"Spalte 0 entspricht nicht dem Datentyp int! Messzeile: {messZeile}");
            }

            if (int.TryParse(messwertTeile[1], out int objekt))
            {
                Objekt = objekt;
            }
            else
            {
                throw new ArgumentException($"Spalte 1 entspricht nicht dem Datentyp int! Messzeile: {messZeile}");
            }

            if (int.TryParse(messwertTeile[2], out int nr))
            {
                Nr = nr;
            }
            else
            {
                throw new ArgumentException($"Spalte 2 entspricht nicht dem Datentyp int! Messzeile: {messZeile}");
            }

            if (DateTime.TryParseExact($"{messwertTeile[3]}{messwertTeile[4]}", "yyyyMMddhhmm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime datum))
            {
                Datum = datum;
            }
            else
            {
                throw new ArgumentException($"Spalten 3 und 4 entsprechen nicht dem Datentyp DateTime! Messzeile: {messZeile}");
            }

            var styles = NumberStyles.AllowParentheses | NumberStyles.AllowTrailingSign | NumberStyles.Float | NumberStyles.AllowDecimalPoint;

            if (double.TryParse(messwertTeile[5], styles, CultureInfo.InvariantCulture, out double qa))
            {
                QA = qa;
            }
            else
            {
                throw new ArgumentException($"Spalte 5 entspricht nicht dem Datentyp decimal! Messzeile: {messZeile}");
            }

            if (double.TryParse(messwertTeile[6], styles, CultureInfo.InvariantCulture, out double tm))
            {
                TM = tm;
            }
            else
            {
                throw new ArgumentException($"Spalte 6 entspricht nicht dem Datentyp decimal! Messzeile: {messZeile}");
            }

            if (double.TryParse(messwertTeile[7], styles, CultureInfo.InvariantCulture, out double hn))
            {
                HN = hn;
            }
            else
            {
                throw new ArgumentException($"Spalte 7 entspricht nicht dem Datentyp decimal! Messzeile: {messZeile}");
            }

            if (int.TryParse(messwertTeile[8], out int s))
            {
                S = s;
            }
            else
            {
                throw new ArgumentException($"Spalte 8 entspricht nicht dem Datentyp int! Messzeile: {messZeile}");
            }
        }

        public int A { get; set; }

        public int Objekt { get; set; }

        public int Nr { get; set; }

        public DateTime Datum { get; set; }

        public double QA { get; set; }

        public double TM { get; set; }

        public double HN { get; set; }

        public int S { get; set; }

        public override string ToString()
        {
            return $"{A} {Objekt} {Nr} {Datum} {QA} {TM} {HN} {S}";
        }
    }
}
