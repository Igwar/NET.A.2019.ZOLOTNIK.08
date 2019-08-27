using AccountLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServiceLib
{
    public class AccountService 
    {
      
        private readonly AccountStorage.AccountStorage accountStorage;
   
        /// <summary>
        /// Constructor 
        /// </summary>
        public AccountService()
        {
            accountStorage = new AccountStorage.AccountStorage();
        }
     
     
        /// <summary>
        /// GetAllAccounts returns all elements of file 
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Account> GetAllAccounts()
        {
            return accountStorage.ReadAccountFromFile();
        }

        /// <summary>
        /// AddAmount increases amount field
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public void AddAmount(int id, uint amount)
        {
            var account = FindAccount(id);
            if (account.Status == StatusAccount.Close) throw new ArgumentException("Account is closed");
            account.Amount = account.Amount + amount;

            if (account.Type == AccountType.Base)
                account.Points += 10;

            if (account.Type == AccountType.Gold)
                account.Points += 20;

            if (account.Type == AccountType.Premium)
                account.Points += 30;
            CreateAccount(account);
        }

        /// <summary>
        /// DivAmmount decrease amount field
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public void DivAmount(int id, uint amount)
        {
            var account = FindAccount(id);
            if (account.Status == StatusAccount.Close) throw new ArgumentException("Account is closed");
            account.Amount = account.Amount - amount;
            CreateAccount(account);
        }

        /// <summary>
        /// CreateAccount create new account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ownerFirstName"></param>
        /// <param name="ownerLastName"></param>
        /// <param name="amount"></param>
        /// <param name="points"></param>
        /// <param name="type"></param>
        public void CreateAccount(Account account)
        {
            var accounts =  accountStorage.ReadAccountFromFile().ToList();
           for (int i=0;i<accounts.Count();i++) {
                if (accounts[i].Id == account.Id)
                    accounts.Remove(accounts[i]);
            }
            accounts.Add(account);

            accountStorage.OverWriteFile(accounts);
        }

        /// <summary>
        /// CloseAccount assigns account statues fild Close
        /// </summary>
        /// <param name="id"></param>
        public void CloseAccount(int id)
        {
            if (id < 0) throw new ArgumentException();

            var account = FindAccount(id);
            account.Status = StatusAccount.Close;
            CreateAccount(account);
        }

        /// <summary>
        /// Account Search
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Account FindAccount(int id)
        {
            bool flag = false;
            var accounts = accountStorage.ReadAccountFromFile().ToList();
            for (int i = 0; i < accounts.Count(); i++)
            {
                if (accounts[i].Id == id)

                    flag = true;
            }
            if (flag == false)
                throw new ArgumentException("Account doesn't exist");
            return accounts.FirstOrDefault(account => account.Id == id);
            
           
        }
     
    }
}
