using System.Collections.Generic;

namespace MesspunkteLogic
{
    internal class MesswertDatumComparer : IComparer<Messwert>
    {
        public int Compare(Messwert x, Messwert y)
        {
            return x.Datum.CompareTo(y.Datum);
        }
    }
}