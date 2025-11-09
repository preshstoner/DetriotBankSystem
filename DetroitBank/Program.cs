using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetroitBank
{
    internal class Program
    {
        public class BankAccount
        {
            public string AccountHolder { get; set; }
            public decimal Balance { get; private set; }
            public int TransactionCount { get; private set; }

            public BankAccount(string name)
            {
                AccountHolder = name;
                Balance = 0;
                TransactionCount = 0;
            }

            public void Deposit(decimal amount)
            {

                Balance += amount;
                TransactionCount++;
            }

            public void Withdraw(decimal amount)
            {

                if (amount <= Balance)
                {
                    Balance -= amount;
                    TransactionCount++;
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }

            public void changeName(string newName)
            {
                AccountHolder = newName;
            }

            public void DisplaySummary()
            {
                Console.WriteLine($"Account Holder: {AccountHolder}");
                Console.WriteLine($"Balance: {Balance:C}");
                Console.WriteLine($"Total Transactions: {TransactionCount}");
            }
        }
        static void Main(string[] args)
        {
            BankAccount account = null;
            string command;

            do
            {
                Console.WriteLine("\nCommands: open | transact | exit");
                command = Console.ReadLine()?.ToLower();

                switch (command)
                {
                    case "open":
                        Console.Write("Enter account holder name: ");
                        string name = Console.ReadLine();
                        account = new BankAccount(name);
                        Console.WriteLine("Account opened successfully.");
                        break;

                    case "transact":
                        if (account == null)
                        {
                            Console.WriteLine("No account found. Please open an account first.");
                            break;
                        }
                        HandleTransactions(account);
                        break;

                    case "exit":
                        Console.WriteLine("Exiting the Application.");
                        break;

                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            } while (command != "exit");
        }

        static void HandleTransactions(BankAccount account)
        {
            string command;
            do
            {
                Console.WriteLine("\nTransaction Commands: deposit | withdraw | change | display | exit");
                command = Console.ReadLine()?.ToLower();

                switch (command)
                {
                    case "deposit":
                        Console.Write("Enter amount to deposit: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount)) account.Deposit(depositAmount);
                        else
                            Console.WriteLine("Invalid amount.");
                        break;

                    case "withdraw":
                        Console.Write("Enter amount to withdraw: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount)) account.Withdraw(withdrawAmount);
                        else
                            Console.WriteLine("Invalid amount.");
                        break;

                    case "change":
                        Console.Write("Enter the new account holder name: ");
                        account.changeName(Console.ReadLine());
                        break;

                    case "display":
                        account.DisplaySummary();
                        break;

                    case "exit":
                        Console.WriteLine("Exiting transaction menu.");
                        break;

                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            } while (command != "exit");
        }
    }
}

     
