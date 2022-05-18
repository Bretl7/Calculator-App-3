// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_HW1
{
    // ====================  CLASS: CALCULATOR  ====================
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation could result in an error

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    if (num2 != 0) // Checks to make sure user did not enter 0 for num2
                    {
                        result = num1 / num2;
                    }
                    break;
                case "3":
                    result = num1 * num2;
                    break;
                default: // Returns if no or incorrect option is entered
                    break;
            }

            return result;
        }
    }

    // ====================  CLASS: PROGRAM  ====================
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;       // variable to end app (the user selects at end of program)

            Console.WriteLine("Console Calculator App\r");
            Console.WriteLine("----------------------\n");

            while (!endApp)            // Lets the app run continuously until user ends it
            {
                string numInput1 = ""; // numInput1 will be the first entry by the user
                string numInput2 = ""; // numInput2 will be second user entry
                double result = 0;     // result will be the final calculation

                Console.WriteLine("Type a number, then press Enter: ");
                numInput1 = Console.ReadLine(); // Return user's input as string

                double cleanNum1 = 0;           // cleanNum1 will be the numeric value of the user-entered string value
                while (!double.TryParse(numInput1, out cleanNum1)) // This loop will check if numInput1 can be converted to numeric value of double type
                {                                                  // ^ if not, then it will re-prompt the user to enter numeric value
                    Console.Write("This is not a valid input. Please enter numeric value: ");
                    numInput1 = Console.ReadLine();
                }

                Console.WriteLine("Type a number, then press Enter: ");
                numInput2 = Console.ReadLine(); // Return user's input as string

                double cleanNum2 = 0;           // cleanNum2 will be the numeric value of the user-entered string value
                while (!double.TryParse(numInput2, out cleanNum2)) // This loop will check if numInput1 can be converted to numeric value of double type
                {                                                  // ^ if not, then it will re-prompt the user to enter numeric value
                    Console.Write("This is not a valid input. Please enter numeric value: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask user to choose operation
                Console.WriteLine("Choose an operation from the following:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\t3 - Divisible by three after multiplied");
                Console.Write("Your option? ");

                string op = Console.ReadLine();

                // The try/catch block will try to calculate the result, if an error occurrs, then it will be caught in the catch block
                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a math error. \n");
                    }
                    else if (op == "3")
                    {
                        if (result % 3 == 0) Console.WriteLine("Your result: " + result + " is divisible by 3");
                        else Console.WriteLine("Your result: " + result + " is NOT divisible by 3");
                    }
                    else Console.WriteLine("Your result: " + result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occurred while trying to calculate:\n" + e.Message);
                }

                Console.WriteLine("-----------------------------\n");

                // Get user's input to decide if keep program running or close
                Console.WriteLine("Press 'n' and Enter to close app, or press any other key to continue");
                if (Console.ReadLine() == "n") endApp = true;
                //Test To the git
                //Work
            }
        }
    }
}
