using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.CommandExecutors
{
    public class RemoveCommandExecutor :CommandUtils, ICommandExecutionService
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
                    values.Remove(commands[2]);
                    WriteData("Removed");
                    if (values.Count == 0)
                    {
                        mvd.Remove(commands[1]);
                    }
                    return "Success";
                }//Called when membr does not exist
                else
                {
                    var error_1 = "Error, member does not exist";
                    WriteData(error_1);
                    return error_1;
                }
                
            }// Called when key does not exist
            else
            {
                var error_2 = "Error, Key does not exist";
                WriteData(error_2);
                return error_2;
            }
          

        }

      
    }
}
