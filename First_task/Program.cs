/*
    REIZ TECH HOMEWORK ASSIGNMENT PROGRAM FOR THE .NET DEVELOPER INTERN POSITION
    1st task
    Gvidas Garadauskas
*/

using System;

namespace First_task
{
    /// <summary>
    /// Class of the program which allows user to input the time of a clock
    /// through console and outputs lesser angle in degrees between arrows
    /// </summary>
    class Program
    {
        /// <summary>
        /// The first method that is invoked
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            InOutUtils.PrintAngle(TaskUtils.CalculateLesserAngle(InOutUtils.ReadHours(), InOutUtils.ReadMinutes()));
        }
    }

    /// <summary>
    /// Class for calculations
    /// </summary>
    static class TaskUtils
    {
        /// <summary>
        /// Method which calculates lesser angle between specified time arrows
        /// </summary>
        /// <param name="hours">hours parameter</param>
        /// <param name="minutes">minutes parameter</param>
        /// <returns>lesser angle in degrees between arrows</returns>
        public static double CalculateLesserAngle(int hours, int minutes)
        {
            double hoursAngle = 360 / 12 * hours + 0.5 * minutes; //angle every hour increases by 30 degrees + 0.5 degrees for each minute
            double minutesAngle = 360 / 60 * minutes; //angle every minute increases by 6 degrees

            double lesserAngle = Math.Abs(hoursAngle - minutesAngle);
            if (Math.Abs(minutesAngle - hoursAngle) < lesserAngle) lesserAngle = Math.Abs(minutesAngle - hoursAngle);
            if (lesserAngle > 180) lesserAngle = 360 - lesserAngle; //prefer lesser angle

            return lesserAngle;
        }
    }

    /// <summary>
    /// Class for inputing and outputing data
    /// </summary>
    static class InOutUtils
    {
        /// <summary>
        /// Method which allows user to enter hours to a console
        /// </summary>
        /// <returns>entered hours</returns>
        public static int ReadHours()
        {
            Console.WriteLine("Enter hours of the analogue clock:");
            int inputHours = int.Parse(Console.ReadLine());

            if (inputHours < 1 || inputHours > 12)
            {
                Console.WriteLine("Incorrect hours of the analogue clock! Hours must be 1 to 12.");
                inputHours = ReadHours();
            }

            return inputHours;
        }

        /// <summary>
        /// Method which allows user to enter minutes to a console
        /// </summary>
        /// <returns>entered minutes</returns>
        public static int ReadMinutes()
        {
            Console.WriteLine("Enter minutes of the analogue clock:");
            int inputMinutes = int.Parse(Console.ReadLine());

            if (inputMinutes < 0 || inputMinutes > 59)
            {
                Console.WriteLine("Incorrect minutes of the analogue clock! Minutes must be from 0 to 59.");
                inputMinutes = ReadMinutes();
            }

            return inputMinutes;
        }

        /// <summary>
        /// Method which outputs results data
        /// </summary>
        /// <param name="angle">lesser angle between specified time arrows</param>
        public static void PrintAngle(double angle)
        {
            Console.WriteLine("Lesser angle in degrees between hours arrow and minutes arrow: " + angle); 
        }
    }
}