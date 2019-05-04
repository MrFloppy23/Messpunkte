using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MesspunkteLogic
{
    public class CSVTools
    {
        internal static IList<Messwert> ImportFromCSV(string verzeichnisCSV)
        {
            // get all CSV files
            var csvFiles = Directory.GetFiles(verzeichnisCSV);

            IList<Messwert> messwerte = new List<Messwert>();

            foreach (var curFile in csvFiles)
            {
                using (var sr = new StreamReader(curFile))
                {
                    using (var csvFile = new CsvReader(sr))
                    {
                        csvFile.Configuration.RegisterClassMap<MesswertMap>();
                        var records = csvFile.GetRecords<Messwert>().ToList();
                        messwerte.Concat(records);
                    }
                }
            }

            return messwerte;
        }

        public static void ExportToCSV(IDictionary<MesswertKey, SortedSet<Messwert>> messwerteProMesspunkt, string verzeichnisOutput)
        {
            // Ausgabepfad anlegen, falls er noch nicht existiert
            Directory.CreateDirectory(verzeichnisOutput);

            foreach (var messpunkt in messwerteProMesspunkt)
            {
                using (StreamWriter sr = new StreamWriter($"{verzeichnisOutput}\\{messpunkt.Key}.csv"))
                {
                    using (CsvWriter cw = new CsvWriter(sr))
                    {
                        cw.WriteRecords(messpunkt.Value);
                    }
                }
            }
        }
    }
}
