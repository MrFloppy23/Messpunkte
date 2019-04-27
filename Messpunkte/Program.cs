using CsvHelper;
using MesspunkteLogic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messpunkte
{
    class Program
    {
        public const string PFAD_MESSDATEN = @".\Messdaten";
        public const string PFAD_AUSGABE = @".\CSV";

        static void Main(string[] args)
        {
            MessdatenReader mr = new MessdatenReader();

            var messwerte = mr.ReadMesswerte(PFAD_MESSDATEN, "*.PRA");
            var messwerteProMesspunkt = mr.MesswerteAufbereiten(messwerte);

            // Ausgabepfad anlegen, falls er noch nicht existiert
            Directory.CreateDirectory(PFAD_AUSGABE);

            foreach (var messpunkt in messwerteProMesspunkt)
            {
                using (StreamWriter sr = new StreamWriter($"{PFAD_AUSGABE}\\{messpunkt.Key}.csv"))
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
