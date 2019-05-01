using MesspunkteLogic;
using System.Configuration;

namespace Messpunkte
{
    class Program
    {
        static void Main(string[] args)
        {
            var verzeichnisMessdaten = ConfigurationManager.AppSettings["VerzeichnisMessdaten"];
            var verzeichnisCSV = ConfigurationManager.AppSettings["VerzeichnisCSV"];

            MessdatenProcessor.ProcessData(verzeichnisMessdaten, verzeichnisCSV);
        }
    }
}
