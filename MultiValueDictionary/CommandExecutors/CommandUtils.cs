using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.CommandExecutors
{
    public class CommandUtils
    {
        public void WriteData(string data)
        {
            Console.WriteLine(data);
        }
        public (string, bool) ValidateCommand(string[] commands)
        {
            if (commands.Length < 1)
            {
                return ("Please specify a Command", false);

            }

            return ("", true);
        }
        public (string, bool) ValidateTwoCommand(string[] commands)
        {
            if (commands.Length < 2)
            {
                return ("Please specify a member to add to a key", false);

            }
            if (commands.Length > 2)
            {
                return ("Please specify only one member per key", false);
            }
            return ("", true);
        }
        public (string, bool) ValidateThreeCommand(string[] commands)
        {
            if (commands.Length < 3)
            {
                return ("Please specify a key and a member to remove", false);

            }
            if (commands.Length > 3)
            {
                return ("Please specify only one Key and One member to Remove", false);
            }
            return ("", true);
        }
    }
}
