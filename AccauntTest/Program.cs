using AccountLib;
using AccountServiceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccauntTest
{
    
        class Program
        {
            static void Main(string[] args)
            {
                List<Account> accounts = new List<Account>();

                AccountService accountService = new AccountService();
            accountService.CreateAccount(new Account(111, "Alexandra", "Arkhipenko", 100m, 5, AccountType.Base));
            accountService.CreateAccount(new Account(112, "Andrey", "Petrov", 1250m, 40, AccountType.Gold));
            accountService.CreateAccount(new Account(113, "Galina", "Vizovik", 10245m, 120, AccountType.Premium));

            Print(accountService.GetAllAccounts());
            //Console.WriteLine(accountService.FindAccount(111));
            accountService.AddAmount(115, 500);
            Print(accountService.GetAllAccounts());

            //accountService.CloseAccount(112);
            //Print(accountService.GetAllAccounts());

            //accountService.DivAmount(113, 100m);
            //Print(accountService.GetAllAccounts());

            Console.ReadKey();

            }

            private static void Print(IEnumerable<Account> accounts)
            {
                foreach (var acc in accounts)
                {
                    Console.WriteLine(acc.ToString());
                }
                Console.WriteLine();
            }
        }
    }

