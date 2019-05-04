using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesspunkteLogic
{
    public class MesswertKey : IComparable<MesswertKey>
    {
        public int Objekt { get; private set; }

        public int Nr { get; private set; }

        public MesswertKey(int objekt, int nr)
        {
            Objekt = objekt;
            Nr = nr;
        }

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

        /// <summary>
        /// String representation of MesswertKey.
        /// </summary>
        /// <returns>Objekt and Nr are concatenated, where Objekt is formatted with leading zeros for 6 digits and Nr with leading zeros for 2 digits. </returns>
        public override string ToString()
        {
            return $"{Objekt:000000}{Nr:00}";
        }

        public override bool Equals(object obj)
        {
            MesswertKey other = (MesswertKey)obj;

            return Objekt == other.Objekt && Nr == other.Nr;
        }

        public override int GetHashCode()
        {
            return Objekt.GetHashCode() ^ Nr.GetHashCode();
        }
    }
}
