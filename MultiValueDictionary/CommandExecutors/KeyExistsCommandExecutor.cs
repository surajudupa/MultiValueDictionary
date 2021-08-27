using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.CommandExecutors
{
    public class KeyExistsCommandExecutor :CommandUtils, ICommandExecutionService
    {
        public string ExecuteCommand(string[] commands)
        {
            var result = ValidateTwoCommand(commands);

            if (!result.Item2)
            {
                WriteData(result.Item1);
                return result.Item1;
            }
            var mvd = MultiValueDictionary.GetDictionary();

            if (mvd.ContainsKey(commands[1]))
            {
                WriteData("true");
                return "true";
            }
            WriteData("false");
            return "false";
        }

     
    }
}
