using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.CommandExecutors
{
    public class ClearCommandExecutor : CommandUtils, ICommandExecutionService
    {
        public string ExecuteCommand(string[] commands)
        {
            var result = ValidateCommand(commands);
            if (!result.Item2)
            {
                WriteData(result.Item1);
                return result.Item1;
            }
            var mvd = MultiValueDictionary.GetDictionary();
            MultiValueDictionary.ClearDictionary();
            var data = "Cleared";

            WriteData(data);

            return data;

        }

        
    }
}
