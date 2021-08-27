using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary.CommandExecutors
{
    public class AllMembersCommandExecutor : CommandUtils, ICommandExecutionService
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

            List<string> keys = mvd.Keys.ToList();
            if (keys.Count == 0)
            {
                var data = "No Member exists";
                WriteData(data);
                return data;
            }
            int i = 1;
            foreach (var key in keys)
            {
                var values = mvd[key].Keys.ToList();
                
                foreach (var value in values)
                {
                    WriteData($"{i}). {value}");
                    i++;
                }
            }
            return "Success";


        }

      
    }
}
