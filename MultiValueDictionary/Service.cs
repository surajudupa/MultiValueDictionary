using MultiValueDictionary.CommandExecutors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{

    public interface IService
    {
        void ExecuteCommand();
    }
    public class Service : IService
    {
        private readonly IServiceProvider _serviceProvider;
        public Service(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }
        public void ExecuteCommand()
        {
            bool shutDownApp = false;
            while (!shutDownApp)
            {

                Console.WriteLine("Enter the Command>");
                var command = Console.ReadLine();
                if (command == "exit")
                {
                    shutDownApp = true;
                    continue;
                }

                var splitCommands = command.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (splitCommands.Length == 0)
                {
                    continue;//If there are no commands then we need to ask user again to input the commands.
                }
                try
                {
                    var commandSrevice = GetCommandExecutor(splitCommands[0]);
                    commandSrevice.ExecuteCommand(splitCommands);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Enter a Valid Command");
                }

               
            }

        }

        public ICommandExecutionService GetCommandExecutor(string command)
        {
            switch (command.ToUpper())
            {
                case "ADD":
                    return (ICommandExecutionService)_serviceProvider.GetService(typeof(AddCommandExecutor));
                    
                case "KEYS":
                    return (ICommandExecutionService)_serviceProvider.GetService(typeof(KeysCommandExecutor));
                    
                case "MEMBERS":
                    return (ICommandExecutionService)_serviceProvider.GetService(typeof(MembersCommandExecutor));
                    

                case "REMOVE":
                    return (ICommandExecutionService)_serviceProvider.GetService(typeof(RemoveCommandExecutor));
                    
                case "REMOVEALL":
                    return (ICommandExecutionService)_serviceProvider.GetService(typeof(RemoveAllCommandExecutor));
                    
                case "CLEAR":
                    return (ICommandExecutionService)_serviceProvider.GetService(typeof(ClearCommandExecutor));
                    
                case "KEYEXISTS":
                    return (ICommandExecutionService)_serviceProvider.GetService(typeof(KeyExistsCommandExecutor));
                    
                case "MEMBEREXISTS":
                    return (ICommandExecutionService)_serviceProvider.GetService(typeof(MemberExistsCommandExecutor));
                    
                case "ALLMEMBERS":
                    return (ICommandExecutionService)_serviceProvider.GetService(typeof(AllMembersCommandExecutor));
                    
                case "ITEMS":
                    return (ICommandExecutionService)_serviceProvider.GetService(typeof(ItemCommandExecutor));
                default:
                    throw new Exception();
            }
        }
    }
}
