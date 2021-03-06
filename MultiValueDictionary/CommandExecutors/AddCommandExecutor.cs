using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.CommandExecutors
{
    public class AddCommandExecutor : CommandUtils, ICommandExecutionService
    {

    
        public string ExecuteCommand(string[] commands)
        {
            var result = ValidateThreeCommand(commands);

            if (!result.Item2)
            {
                WriteData(result.Item1);
                return result.Item1;
            }
            var mvd = MultiValueDictionary.GetDictionary();

            if (mvd.ContainsKey(commands[1]))
            {
                var values = mvd[commands[1]];
                if (values.ContainsKey(commands[2]))
                {
                    var data = "Error, member already exists for key";
                    WriteData(data);
                    return data;
                }
                values.Add(commands[2], "");
            }
            else
            {
                Dictionary<string, string> newValues = new Dictionary<string, string>();
                newValues.Add(commands[2],"");
                mvd.Add(commands[1], newValues);
            }
            var added = "ADDED";
            WriteData(added);
            return added;

        }

      
    }
}
