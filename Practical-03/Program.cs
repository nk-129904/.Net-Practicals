using System;
using System.Collections.Generic;

namespace ExpenseTrackingSystem
{
    // Simple console based expense tracker
    // made for mini project
    class Expense
    {
        public string category;
        public double amount;
        public DateTime date;

        public Expense(string cat, double amt, DateTime dt)
        {
            category = cat;
            amount = amt;
            date = dt;
        }

        public void Show()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Category : " + category);
            Console.WriteLine($"Amount : ₹{amount}");
            Console.WriteLine("Date : " + date.ToShortDateString());
        }
    }

    class ExpenseTracker
    {
        List<Expense> expenseList = new List<Expense>();

        public void AddExpense()
        {
            try
            {
                Console.Write("Enter Expense Category: ");
                string cat = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(cat))
                {
                    throw new ArgumentException("Category can't be left empty.");
                }

                Console.Write("Enter Expense Amount: ");
                double amt = Convert.ToDouble(Console.ReadLine());

                if (amt <= 0)
                    throw new ArgumentException("Amount should be more than 0.");

                Console.Write("Enter Date (dd/mm/yyyy): ");
                DateTime dt = Convert.ToDateTime(Console.ReadLine());

                Expense e = new Expense(cat, amt, dt);
                expenseList.Add(e);

                Console.WriteLine("\nExpense added!");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nInvalid input - check the amount/date format.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nSomething went wrong: " + ex.Message);
            }
        }

        public void DisplayExpenses()
        {
            if (expenseList.Count == 0)
            {
                Console.WriteLine("\nNo expenses added yet.");
                return;
            }

            Console.WriteLine("\n===== All Expenses =====");

            foreach (var e in expenseList)
            {
                e.Show();
            }
        }

        public void CalculateTotalExpenses()
        {
            double total = 0;

            for (int i = 0; i < expenseList.Count; i++)
            {
                total += expenseList[i].amount;
            }

            Console.WriteLine("\n===============================");
            Console.WriteLine($"Total Expenses = ₹{total}");
            Console.WriteLine("===============================");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ExpenseTracker tracker = new ExpenseTracker();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n========== Expense Tracker ==========");
                Console.WriteLine("1. Add New Expense");
                Console.WriteLine("2. Display All Expenses");
                Console.WriteLine("3. Calculate Total Expenses");
                Console.WriteLine("4. Exit");
                Console.Write("Enter Your Choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            tracker.AddExpense();
                            break;

                        case 2:
                            tracker.DisplayExpenses();
                            break;

                        case 3:
                            tracker.CalculateTotalExpenses();
                            break;

                        case 4:
                            Console.WriteLine("\nThanks for using Expense Tracker!");
                            running = false;
                            break;

                        default:
                            Console.WriteLine("\nPlease choose between 1 and 4.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nEnter a valid number for your choice.");
                }
            }
        }
    }
}
