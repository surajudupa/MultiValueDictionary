using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.CommandExecutors
{
    public class MembersCommandExecutor :CommandUtils, ICommandExecutionService
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
                var values = mvd[commands[1]].Keys.ToList();
                int i = 1;
                foreach(var value in values)
                {
                    WriteData($"{i}). {value}");
                    i++;
                }
                return "Success";
            }
            else
            {
                var error = "ERROR, Key does not exist";
                WriteData(error);
                return error;
            }

        }

    
    }
}
