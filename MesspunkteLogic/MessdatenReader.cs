using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesspunkteLogic
{
    public class MessdatenReader
    {
        public IList<Messwert> ReadMesswerte(string path, string fileEnding)
        {
            IList<Messwert> messwerte = new List<Messwert>();

            // iterate over all files in the given path with the given file ending
            var messDateien = Directory.GetFiles(path, $"*{fileEnding}");

            foreach (var messDatei in messDateien)
            {
                using (StreamReader sr = File.OpenText(messDatei))
                {
                    string s = string.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s[0] == '!')
                        {
                            continue;
                        }

                        messwerte.Add(new Messwert(s));
                    }
                }
            }

            return messwerte;
        }
    }
}
