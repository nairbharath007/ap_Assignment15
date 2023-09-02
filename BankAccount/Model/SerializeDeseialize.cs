using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Model
{
    internal class SerializeDeseialize
    {
        public static void SaveAccount(Account account)
        {
            try
            {
                using (FileStream fs = new FileStream("account.dat", FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, account);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving account data: {ex.Message}");
            }
        }

        public static Account LoadAccount()
        {
            try
            {
                using (FileStream fs = new FileStream("account.dat", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (Account)formatter.Deserialize(fs);
                }
            }
            catch (FileNotFoundException)
            {
                return null; // Account file does not exist.
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading account data: {ex.Message}");
                return null;
            }
        }
    }
}
