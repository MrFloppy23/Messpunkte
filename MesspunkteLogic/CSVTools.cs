using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace MesspunkteLogic
{
    public class CSVTools
    {
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
