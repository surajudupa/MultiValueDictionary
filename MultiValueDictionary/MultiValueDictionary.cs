using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    public static class MultiValueDictionary
    {

        public static Dictionary<string, Dictionary<string, string>> mvd = new Dictionary<string, Dictionary<string, string>>();


        public static Dictionary<string, Dictionary<string, string>> GetDictionary()
        {
            return mvd;
        }

        public static void ClearDictionary()
        {
            mvd= new Dictionary<string, Dictionary<string, string>>();
        }
    }
}
