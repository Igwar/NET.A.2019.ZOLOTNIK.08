using AccountLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountStorage
{
    public class AccountStorage
    {
       
        /// <summary>
        /// Field path is the way of file
        /// </summary>
        private const string Path = @"D:\Курсы епам\SaveBank.bin";
        

        

        /// <summary>
        /// Read account from file
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Account> ReadAccountFromFile()
        {
            var accounts = new List<Account>();
            using (var br = new BinaryReader(File.Open(Path, FileMode.OpenOrCreate,
                FileAccess.Read, FileShare.Read)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    var account = Reader(br);
                    accounts.Add(account);
                }
            }

            return accounts;
        }

        /// <summary>
        /// Write account to file
        /// </summary>
        /// <param name="account"></param>
        public void AppendAccountToFile(Account account)
        {
            using (var bw = new BinaryWriter(File.Open(Path, FileMode.Append,
                FileAccess.Write, FileShare.None)))
            {
                Writer(bw, account);
            }
        }

        /// <summary>
        /// Overwrite file
        /// </summary>
        /// <param name="accounts"></param>
        public void OverWriteFile(IEnumerable<Account> accounts)
        {
            using (var bw = new BinaryWriter(File.Open(Path, FileMode.Create,
                FileAccess.Write, FileShare.None)))
            {
                foreach (var account in accounts)
                    Writer(bw, account);
            }
        }
    

   
        private static void Writer(BinaryWriter binary, Account account)
        {
            binary.Write(account.Id);
            binary.Write(account.OwnerFirstName);
            binary.Write(account.OwnerLastName);
            binary.Write(account.Amount);
            binary.Write(account.Points);
            binary.Write(account.Status.ToString());
            binary.Write(account.Type.ToString());

        }

        private static Account Reader(BinaryReader binary)
        {
            var id = binary.ReadInt32();
            var ownerFirstName = binary.ReadString();
            var ownerLastName = binary.ReadString();
            var amount = binary.ReadDecimal();
            var points = binary.ReadInt32();
            var status = binary.ReadString();
            var type = binary.ReadString();

            return new Account()
            {
                Id = id,
                OwnerFirstName = ownerFirstName,
                OwnerLastName = ownerLastName,
                Amount = amount,
                Points = points,
                Status = (StatusAccount)Enum.Parse(typeof(StatusAccount), status),
                Type = (AccountType)Enum.Parse(typeof(AccountType), type)
            };

        }


    }
}
