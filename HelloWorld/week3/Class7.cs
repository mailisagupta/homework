// Create a program that determines the number of days for a month using a switch statement. 
// The program should accept the number of the month in question.
using System;

enum eMonthNames
{
    January = 1,
    February,
    March ,
    April,
    May ,
    June ,
    July ,
    August,
    September ,
    October ,
    November,
    December 
}
enum eMonthDays
{
    January = 30,
    February = 29,
    March = 31,
    April = 31,
    May = 30,
    June = 31,
    July = 31,
    August = 31,
    September = 31,
    October = 31,
    November = 31,
    December = 31,

}

class Class7
{

    static void Main()
    {
        while (true)
        {
            //TO DO

            Console.Write("Please enter a Month Number: ");
            string monthNumber = Console.ReadLine();
            eMonthNames eName;
            int nDays = 0;

            switch (monthNumber)
            {
                case "1":
                    eName = eMonthNames.January;
                    nDays = (int)eMonthDays.January;

                    break;
                case "2":
                    eName = eMonthNames.February;
                    nDays = (int)eMonthDays.February;

                    break;
                case "3":
                    // TO DO
                    eName = eMonthNames.March;
                    nDays = (int)eMonthDays.March;

                    break;

                case "4":
                    eName = eMonthNames.April;
                    nDays = (int)eMonthDays.April;

                    break;
                case "5":
                    eName = eMonthNames.May;
                    nDays = (int)eMonthDays.May;

                    break;
                case "6":
                    eName = eMonthNames.June;
                    nDays = (int)eMonthDays.June;

                    break;
                case "7":
                    eName = eMonthNames.July;
                    nDays = (int)eMonthDays.July;

                    break;
                case "8":
                    eName = eMonthNames.August;
                    nDays = (int)eMonthDays.August;

                    break;
                case "9":
                    eName = eMonthNames.September;
                    nDays = (int)eMonthDays.September;

                    break;
                case "10":
                    eName = eMonthNames.October;
                    nDays = (int)eMonthDays.May;

                    break;
                case "11":
                    eName = eMonthNames.November;
                    nDays = (int)eMonthDays.May;

                    break;

                default:
                    eName = eMonthNames.December;
                    nDays = (int)eMonthDays.December;

                    break;
            }
            Console.WriteLine("Month {0} has {1} days\n\n", eName, nDays);
        }
    }
}