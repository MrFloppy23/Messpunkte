using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesspunkteLogic
{
    public class MessdatenReader
    {
        public Tuple<IList<Messwert>, ISet<MesswertKey>, ISet<DateTime>> ReadMesswerte(string path, string fileEnding)
        {
            IList<Messwert> messwerte = new List<Messwert>();
            ISet<MesswertKey> messpunkte = new HashSet<MesswertKey>();
            ISet<DateTime> messtage = new HashSet<DateTime>();

            // iterate over all files in the given path with the given file ending
            var messDateien = Directory.GetFiles(path, $"*{fileEnding}");

            foreach (var messDatei in messDateien)
            {
                using (StreamReader sr = File.OpenText(messDatei))
                {
                    string s = string.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s[0] == '!')
                        {
                            // keine Messdaten, sondern Metadaten -> überspringen
                            continue;
                        }

                        var curMesswert = new Messwert(s);
                        var curMesspunkt = curMesswert.Messpunkt;

                        // messwert hinzufügen
                        messwerte.Add(curMesswert);

                        // messpunkt hinzufügen
                        if (!messpunkte.Contains(curMesspunkt))
                        {
                            messpunkte.Add(curMesspunkt);
                        }

                        // messtag hinzufügen
                        if (!messtage.Contains(curMesswert.Datum))
                        {
                            messtage.Add(curMesswert.Datum);
                        }
                    }
                }
            }

            return new Tuple<IList<Messwert>, ISet<MesswertKey>, ISet<DateTime>>(messwerte, messpunkte, messtage);
        }

        public IDictionary<MesswertKey, SortedSet<Messwert>> MesswerteAufbereiten(Tuple<IList<Messwert>, ISet<MesswertKey>, ISet<DateTime>> messwerte)
        {
            var aufbereitet = new Dictionary<MesswertKey, SortedSet<Messwert>>();
            var messpunkte = new List<string>();

            // über alle Messpunkte iterieren
            foreach (var messpunkt in messwerte.Item2)
            {
                // über alle Messtage iterieren
                foreach (var messtag in messwerte.Item3)
                {
                    // Messdaten holen, oder leere Messdaten für den Messpunkt und Tag hinterlegen
                    var messdatenFuerPunkt = messwerte.Item1.Where(mw => mw.Datum == messtag && mw.Messpunkt.Equals(messpunkt)).FirstOrDefault();

                    if (messdatenFuerPunkt == null)
                    {
                        messdatenFuerPunkt = new Messwert(messpunkt, messtag);
                    }

                    SortedSet<Messwert> messdaten;
                    if (!aufbereitet.TryGetValue(messpunkt, out messdaten))
                    {
                        messdaten = new SortedSet<Messwert>(new MesswertDatumComparer());
                        aufbereitet.Add(messpunkt, messdaten);
                    }

                    messdaten.Add(messdatenFuerPunkt);
                }
            }

            return aufbereitet;
        }
    }
}
