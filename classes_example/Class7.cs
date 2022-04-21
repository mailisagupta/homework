﻿using System;

class Transaction
{
    // TODO
    public double Amount;
    public string Description;

    public  virtual void Print()
    {
        Console.WriteLine("Amount      : {0}", Amount);
        Console.WriteLine("Description : {0}", Description);
    }
}

class Check : Transaction
{
    // TODO
    public int CheckNumber;
    public string Payee;
    public override void Print()
    {
        Console.WriteLine("-Check-");
        base.Print();
        Console.WriteLine("CheckNumber      : {0}", CheckNumber);
        Console.WriteLine("Payee : {0}", Payee);
    }
}

class Withdrawal : Transaction
{
    public override void Print()
    {
        Console.WriteLine("-Withdrawal-");
        base.Print();
    }
}

class Deposit : Transaction
{
    public string From;

    public override void Print()
    {
        Console.WriteLine("-Deposit-");
        base.Print();
        Console.WriteLine("From      : {0}", From);
    
    }
}

class inheritenceexample
{
    
    static void Main()
    {
        var checkbook = new Transaction[10];
        var maxTransactions = 0;

        while (true)
        {
            Console.Write("B)alance C)heck D)eposit W)ithdrawal L)ist Q)uit:");

            string option = Console.ReadLine();

            switch (option.ToLower())
            {
                case "c":
                    {
                        var check = new Check();

                        Console.Write("Check Number: ");
                        string checkNumber = Console.ReadLine();

                        Console.Write("       Payee: ");
                        string payee = Console.ReadLine();

                        Console.Write("      Amount: ");
                        string amount = Console.ReadLine();

                        Console.Write(" Description: ");
                        string description = Console.ReadLine();

                        check.Payee = payee;
                        check.CheckNumber = int.Parse(checkNumber);
                        check.Amount = -double.Parse(amount);
                        check.Description = description;

                        checkbook[maxTransactions++] = check;
                        
                        break;
                    }
                case "d":
                    {
                        var deposit = new Deposit();

                        Console.Write("Deposit From: ");
                        string from = Console.ReadLine();

                        Console.Write("      Amount: ");
                        string amount = Console.ReadLine();

                        Console.Write(" Description: ");
                        string description = Console.ReadLine();

                        deposit.From = from;
                        deposit.Amount = double.Parse(amount);
                        deposit.Description = description;

                        checkbook[maxTransactions++] = deposit;
                        break;
                    }
                case "w":
                    {
                        var withdrawal = new Withdrawal();

                        Console.Write("Withdrawal Amount: ");
                        string amount = Console.ReadLine();

                        Console.Write("      Description: ");
                        string description = Console.ReadLine();

                        withdrawal.Amount = -double.Parse(amount);
                        withdrawal.Description = description;

                        checkbook[maxTransactions++] = withdrawal;
                        break;
                    }
                case "b":
                    {
                        var balance = 0.0;

                        for (var index = 0; index < maxTransactions; index++)
                        {
                            balance += checkbook[index].Amount;
                        }

                        Console.WriteLine("Balance is {0:C}", balance);
                        break;
                    }
                case "l":
                    {
                        // TODO: RESERVED for Polymorphism
                        for (var index = 0; index < maxTransactions; index++)
                        {
                            checkbook[index].Print();
                        }
                        break;
                    }
                case "q":
                    {
                        return;
                    }
            }
        }
    }
}