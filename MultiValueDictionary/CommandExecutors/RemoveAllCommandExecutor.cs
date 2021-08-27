using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.CommandExecutors
{
    public class RemoveAllCommandExecutor : CommandUtils, ICommandExecutionService
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
                mvd.Remove(commands[1]);
                WriteData("Removed");
                return "Removed";
            }
            var error = "Error, key does not exist";
            WriteData(error);
            return error;


        }

    }
}
