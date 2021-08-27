using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    public interface ICommandExecutionService
    {

        string ExecuteCommand(string[] commands);
    }
}
