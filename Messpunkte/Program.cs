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

        static void Main(string[] args)
        {
            MessdatenReader mr = new MessdatenReader();

            var messwerte = mr.ReadMesswerte(PFAD_MESSDATEN, "*.PRA");

            //foreach(var messwert in messwerte)
            //{
            //    Console.WriteLine(messwert.ToString());
            //}

            //var json = JsonConvert.SerializeObject(messwerte);

            //using (var sr = new StreamWriter(@".\messpunkte.json"))
            //{
            //    JsonSerializer js = new JsonSerializer();

            //    js.Serialize(sr, json);
            //}

            using (StreamWriter sr = new StreamWriter(@".\messpunkte.csv"))
            {
                using (CsvWriter cw = new CsvWriter(sr))
                {
                    cw.WriteRecords(messwerte);
                }
            }
        }
    }
}
