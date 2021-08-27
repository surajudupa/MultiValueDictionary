using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.CommandExecutors
{
    public class MemberExistsCommandExecutor : CommandUtils,ICommandExecutionService
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

                    WriteData("true");
                    return "true";
                }//Called when membr does not exist
            }
            WriteData("false");
            return "false";

        }

       
    }
}
