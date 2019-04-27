using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesspunkteLogic
{
    public class MesswertKey : IComparable<MesswertKey>
    {
        public MesswertKey(int objekt, int nr)
        {
            Objekt = objekt;
            Nr = nr;
        }

        public int Objekt { get; private set; }
        public int Nr { get; private set; }

        public int CompareTo(MesswertKey other)
        {
            if (other == null)
            {
                // other object is not a valid MesswertKey, this object is greater.
                return 1;
            }

            int result;

            result = other.Objekt.CompareTo(Objekt);

            if (result != 0)
            {
                return result;
            }

            return other.Nr.CompareTo(Nr);
        }

        public override string ToString()
        {
            return $"{Objekt}{Nr}";
        }
    }
}
