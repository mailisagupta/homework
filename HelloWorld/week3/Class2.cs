// Ask user to input a month number 1, or 2, or 3 for (Jan, Feb, and Mar).
// Then check how many days each month has (say 31, 29, 30 days for each).
// Print the month and the number of days to screen.
// Finish the rest of exercise on your own and include all the months of the year.

using System;

class months
{
    static void Main()
    {
        string monthNumber;

        Console.Write("Please enter a month number (1 to 12): ");
        monthNumber = Console.ReadLine();

        string month;
        int daysOfTheMonth = 0;

        switch (monthNumber)
        {
            case "1":
                
                    month = "Jan";
                    daysOfTheMonth = 31;
                    break;
                




            case "2":
                month = "Feb";
                daysOfTheMonth = 29;
                break;

            case "3":

                month = "Mar";
                daysOfTheMonth = 31;
                break;
            case "4":

                month = "Apr";
                daysOfTheMonth = 30;
                break;
            case "5":

                month = "May";
                daysOfTheMonth = 31;
                break;
            case "6":

                month = "june";
                daysOfTheMonth = 30;
                break;
            case "7":

                month = "july";
                daysOfTheMonth = 31;
                break;
            case "8":

                month = "aug";
                daysOfTheMonth = 31;
                break;
            case "9":

                month = "sep";
                daysOfTheMonth = 30;
                break;
            case "10":

                month = "oct";
                daysOfTheMonth = 31;
                break;
            case "11":

                month = "nov";
                daysOfTheMonth = 30;
                break;
            case "12":

                month = "dec";
                daysOfTheMonth = 31;
                break;

            default:
                month = "is not valid";
                daysOfTheMonth = 0;
                break;
                
        }

        Console.WriteLine("The month {0} has {1} days", month, daysOfTheMonth);
        Console.ReadLine();
    }
}