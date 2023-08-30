using BankAccount.Model;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account account = LoadAccount();

            if (account == null)
            {
                Console.WriteLine("Welcome to the Account Application!");
                Console.Write("Enter your Account Number: ");
                int accountNumber;
                while (!int.TryParse(Console.ReadLine(), out accountNumber))
                {
                    Console.WriteLine("Invalid Account Number. Please enter a valid number.");
                }

                Console.Write("Enter your Account Holder Name: ");
                string accountHolderName = Console.ReadLine();

                Console.Write("Enter your Bank Name: ");
                string bankName = Console.ReadLine();

                double openingBalance;
                do
                {
                    Console.Write("Enter Opening Balance (minimum 500 rupees): ");
                } while (!double.TryParse(Console.ReadLine(), out openingBalance) || openingBalance < 500);

                account = new Account(accountNumber, accountHolderName, bankName, openingBalance);
                SaveAccount(account);

                Console.WriteLine("Account created successfully!");
            }
            else
            {
                Console.WriteLine($"Welcome, {account.AccountHolderName}!");
                Console.WriteLine($"Account Balance: {account.Balance}");
            }

            int choice;
            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Display Balance");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter deposit amount: ");
                            if (double.TryParse(Console.ReadLine(), out double depositAmount))
                            {
                                account.Deposit(depositAmount);
                                SaveAccount(account);
                                Console.WriteLine($"Deposited {depositAmount} rupees.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount entered.");
                            }
                            break;
                        case 2:
                            Console.Write("Enter withdrawal amount: ");
                            if (double.TryParse(Console.ReadLine(), out double withdrawalAmount))
                            {
                                if (account.CheckBalance() - withdrawalAmount >= 500)
                                {
                                    account.Withdraw(withdrawalAmount);
                                    SaveAccount(account);
                                    Console.WriteLine($"Withdrawn {withdrawalAmount} rupees.");
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient balance.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount entered.");
                            }
                            break;
                        case 3:
                            Console.WriteLine($"Account balance: {account.CheckBalance()} rupees.");
                            break;
                        case 4:
                            Console.WriteLine("Exiting the application.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

            } while (choice != 4);
        }

        static void SaveAccount(Account account)
        {
            try
            {
                //string filename = $"{account.AccountNo}.dat";
                using (FileStream fs = new FileStream("accountDetails.dat", FileMode.Create))
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

        static Account LoadAccount()
        {
            try
            {
                //string filename = $"{accountNo}.dat";
                using (FileStream fs = new FileStream("accountDetails.dat", FileMode.Open))
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