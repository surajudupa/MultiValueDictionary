using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.CommandExecutors
{
    public class KeysCommandExecutor : CommandUtils, ICommandExecutionService
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
            var keys = mvd.Keys.ToList();

            foreach(var key in keys)
            {
                WriteData(key);
            }
            if (keys.Count() <= 0)
            {
                var data = "(empty set)";
                WriteData(data);
                return data;
            }
            return "Success";

        }
    }
}
