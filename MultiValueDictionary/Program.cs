using Microsoft.Extensions.DependencyInjection;
using MultiValueDictionary.CommandExecutors;
using System;

namespace MultiValueDictionary
{
    class Program
    {
        static void Main(string[] args)
        {


            //setup our DI
            var serviceProvider = new ServiceCollection()
                    
                .AddTransient<AddCommandExecutor>()
                .AddTransient<AllMembersCommandExecutor>()
                .AddTransient<ClearCommandExecutor>()
                .AddTransient<ItemCommandExecutor>()
                .AddTransient<KeyExistsCommandExecutor>()
                .AddTransient<KeysCommandExecutor>()
                .AddTransient<MemberExistsCommandExecutor>()
                .AddTransient<MembersCommandExecutor>()
                .AddTransient<RemoveAllCommandExecutor>()
                .AddTransient<RemoveCommandExecutor>()
                .AddTransient<IService, Service>()
                
                .BuildServiceProvider();

            //do the actual work here
            var service = serviceProvider.GetService<IService>();
            service.ExecuteCommand();
           

               

            


            
        }
    }
}
