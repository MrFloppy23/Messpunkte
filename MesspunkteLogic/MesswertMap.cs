using CsvHelper.Configuration;
using System;
using System.Globalization;

namespace MesspunkteLogic
{
    public sealed class MesswertMap : ClassMap<Messwert>
    {
        public MesswertMap()
        {
            Map(m => m.A);
            Map(m => m.Messpunkt).ConvertUsing(row => new MesswertKey(row.GetField<int>("Objekt"), row.GetField<int>("Nr")));
            Map(m => m.Datum).ConvertUsing(row => DateTime.ParseExact(row.GetField("Datum"), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture));
            Map(m => m.QA);
            Map(m => m.TM);
            Map(m => m.HN);
            Map(m => m.S);
        }
    }
}
