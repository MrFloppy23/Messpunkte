namespace MesspunkteLogic
{
    public class MessdatenProcessor
    {
        public static void ProcessData(string verzeichnisMessdaten, string verzeichnisCSV)
        {
            var messwerte = MessdatenReader.ReadMesswerte(verzeichnisMessdaten, "*.PRA");
            var messwerteProMesspunkt = MessdatenReader.MesswerteAufbereiten(messwerte);

            CSVTools.ExportToCSV(messwerteProMesspunkt, verzeichnisCSV);
        }
    }
}
