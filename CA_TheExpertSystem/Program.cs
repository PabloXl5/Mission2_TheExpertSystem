using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlooringCostEstimate
{
    /****************************************************************
     Application:   Flooring Cost Estimate
     Author:        Tonder, Mike
     Description:   An application that calculates the cost of flooring room(s)
                    for the user.
     Date Created:  2/9/2020
    *****************************************************************/

   
    class Program
    {
        static void Main(string[] args)
        {
            //
            //Screen Configuration
            //Set screen colors for the theme
            //

            ConsoleColor openingClosingScreenBG = ConsoleColor.DarkGray;
            ConsoleColor openingClosingScreenFG = ConsoleColor.Green;
            ConsoleColor appScreenBG = ConsoleColor.White;
            ConsoleColor appScreenFG = ConsoleColor.DarkYellow;

            //
            //constants
            //

            const int WOOD_COST_PER_SQUARE_Ft = 15;
            const int CARPET_COST_PER_SQUARE_Ft = 5;
            const int TILE_COST_PER_SQUARE_Ft = 25;

            //
            //variables
            //

            string userName;
            string flooringTypeRoomOne;
            string flooringTypeRoomTwo;
            string userResponse;

            //int numberOfRooms;

            double roomOneLength;
            double roomOneWidth;
            double SquareFootagRoomOne;
            double RoomOneCost = 0;

            double roomTwoLength;
            double roomTwoWidth;
            double SquareFootagRoomTwo;
            double RoomTwoCost = 0;

            const double INTEREST_RATE = 0.035;

            double monthlyInterestRate;
            int loanTermYears;
            int loanTermMonths = 0; // for precompiler check
            double monthlyPayment = 0; // for precompiler check

            //double roomDimensionsAll;
            //double validDimensions;

            double totalCost;

            bool validResponse;
            #region

            /*
                   **********************
                   *   Opening Screen   *
                   **********************
              
              set cursor invisible, BG colors, FG colors and clear screen
            */
            Console.CursorVisible = false;
            Console.BackgroundColor = openingClosingScreenBG;
            Console.ForegroundColor = openingClosingScreenFG;
            Console.Clear();


            //
            // display an opening screen
            //
            

            Console.WriteLine();
            Console.WriteLine("\n\t\t\tThe Flooring Cost Calculator");
            Console.WriteLine();
            Console.WriteLine("\n\n\n\n\n\n\n\t\t\tPress any key to start.");
            Console.ReadKey();

            /*
                   *****************************
                   *    Initial User Screen    *
                   *****************************
              
              set cursor invisible, BG colors, FG colors and clear screen
            */

            Console.CursorVisible = true;
            Console.BackgroundColor = appScreenBG;
            Console.ForegroundColor = appScreenFG;
            Console.Clear();

            //
            //Greet User
            //

            Console.WriteLine();
            Console.WriteLine("\tWelome and Hello!");
            Console.WriteLine("\n\tThis application will help determine the total cost of new flooring");

            //
            //get user's name and echo it back
            //

            Console.WriteLine();
            Console.Write("\n\n\n\tPlease enter your name: ");
            userName = Console.ReadLine();

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("\tHello " + userName + ", it's nice to meet you!");

            //
            // determine if the user wants to continue with Flooring
            //

            //Console.WriteLine();
            Console.Write($"\n\tAre you ready to calculate your flooring costs?");
            userResponse = Console.ReadLine().ToLower();

            //
            // get some specifics for the flooring
            //
            if (userResponse == "yes")
            {
                /*
                      *********************************
                      *    User Information Screen    *
                      *********************************
                 
                   set cursor visible and clear screen
                */
                Console.CursorVisible = false;
                Console.Clear();

                //
                // display header
                //

                Console.WriteLine();
                Console.WriteLine("\t\t\t\tFlooring Detials");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine("\tGreat, let's get started!");
                Console.WriteLine();
                Console.WriteLine("\tWe just need some measurements and floor type to calculate your costs.");

                Console.WriteLine();
                Console.Write("\n\n\n\n\n\t\t\t\tPress any key to begin.");
                Console.ReadLine();

                //
                // get the length and width of room(s)
                //

                do
                {
                    validResponse = true;

                    /*
                           ************************* 
                           *    Room Dimensions    *
                           *************************

                       set cursor visible and clear screen  
                    */

                    Console.CursorVisible = true;
                    Console.Clear();

                    //
                    // display header
                    //

                    Console.WriteLine();
                    Console.WriteLine("\t\t\tLength and Width of rooms");
                    Console.WriteLine();

                    Console.WriteLine();
                    Console.WriteLine("Enter Length of 1st room.");
                    Console.Write("\nWidth: ");
                    userResponse = Console.ReadLine();
                    roomOneWidth = double.Parse(userResponse);

                    Console.WriteLine();
                    Console.WriteLine("Enter Width of 1st room.");
                    Console.Write("\nLength: ");
                    userResponse = Console.ReadLine();
                    roomOneLength = double.Parse(userResponse);

                    Console.WriteLine();
                    Console.WriteLine("Enter Length of 2nd room.");
                    Console.Write("\nWidth: ");
                    userResponse = Console.ReadLine();
                    roomTwoWidth = double.Parse(userResponse);

                    Console.WriteLine();
                    Console.WriteLine("Enter Width of 2nd room.");
                    Console.Write("\nLength: ");
                    userResponse = Console.ReadLine();
                    roomTwoLength = double.Parse(userResponse);

                    // calculate square footage

                    SquareFootagRoomOne = (roomOneLength * roomOneWidth);
                    SquareFootagRoomTwo = (roomTwoLength * roomTwoWidth);

                    if (SquareFootagRoomOne <= 0 || SquareFootagRoomTwo <= 0)
                    {
                        validResponse = false;

                        Console.WriteLine();
                        Console.WriteLine("\tIt looks like you've entered invalid numbers.  Please enter positive numbers.");

                        //
                        // pause the app for the user
                        //
                        Console.WriteLine();
                        Console.WriteLine("\n\n\n\tPress any key to continue.");
                        Console.ReadKey();
                    }

                } while (!validResponse);

                //
                // get flooring type and validate
                //

                do
                {
                    validResponse = true;

                    /*
                           *********************** 
                           *    Flooring Type    *
                           ***********************

                      set cursor visible and clear screen  
                    */

                    Console.CursorVisible = true;
                    Console.Clear();

                    //
                    // display header
                    //

                    Console.WriteLine();
                    Console.WriteLine("\t\t\t\tFlooring Type");
                    Console.WriteLine();

                    Console.WriteLine();
                    Console.WriteLine("What type of flooring are you planning to use?");
                    Console.WriteLine("\t\"Carpet\" \"Wood\" \"Tile\"");
                    Console.Write("Please enter floor type for 1st room: ");
                    flooringTypeRoomOne = Console.ReadLine().ToLower(); // set type of flooring all to lower case to compare in the if statement

                    Console.WriteLine();
                    Console.Write("Please enter floor type for 2nd room: ");
                    flooringTypeRoomTwo = Console.ReadLine().ToLower(); // set type of flooring all to lower case to compare in the if statement

                    Console.CursorVisible = false;
                    Console.Clear();

                    if (flooringTypeRoomOne != "carpet" && flooringTypeRoomOne != "wood" && flooringTypeRoomOne != "tile")
                    {
                        validResponse = false;

                        Console.WriteLine();
                        Console.WriteLine("It looks like you choose an invalid floor type.  Please reenter you floor type.");

                        //
                        // pause the app for the user
                        //
                        Console.WriteLine();
                        Console.WriteLine("\tPress any key to continue.");
                        Console.ReadKey();
                    }

                    else if (flooringTypeRoomTwo != "carpet" && flooringTypeRoomTwo != "wood" && flooringTypeRoomTwo != "tile")
                    {
                        validResponse = false;

                        Console.WriteLine();
                        Console.WriteLine("It looks like you choose an invalid floor type.  Please reenter you floor type.");

                        //
                        // pause the app for the user
                        //
                        Console.WriteLine();
                        Console.WriteLine("\tPress any key to continue.");
                        Console.ReadKey();
                    }

                    else
                    {
                        validResponse = true;

                        Console.WriteLine();
                        Console.WriteLine("Room One is " + SquareFootagRoomOne + " sq_ft with " + flooringTypeRoomOne + ".");

                        Console.WriteLine();
                        Console.WriteLine("Room Two is " + SquareFootagRoomTwo + " sq_ft with " + flooringTypeRoomTwo + ".");

                        Console.WriteLine();
                        Console.WriteLine("\tPress any key to finish calculations.");
                        Console.ReadKey();
                    }
                } while (!validResponse);


                Console.CursorVisible = false;
                Console.Clear();

                Console.WriteLine();
                Console.WriteLine("Calculations for Rooms");
                Console.WriteLine();

                Console.WriteLine($"Flooring costs for {userName}:");
                Console.WriteLine();

                //
                // rooms one and two totals
                //

                if (flooringTypeRoomOne == "carpet" || flooringTypeRoomTwo == "carpet")
                {
                    RoomOneCost = SquareFootagRoomOne * CARPET_COST_PER_SQUARE_Ft;
                    RoomTwoCost = SquareFootagRoomTwo * CARPET_COST_PER_SQUARE_Ft;
                }

                else if (flooringTypeRoomOne == "wood" || flooringTypeRoomTwo == "wood")
                {
                    RoomOneCost = SquareFootagRoomOne * WOOD_COST_PER_SQUARE_Ft;
                    RoomTwoCost = SquareFootagRoomTwo * WOOD_COST_PER_SQUARE_Ft;
                }

                else if (flooringTypeRoomOne == "tile" || flooringTypeRoomTwo == "tile")
                {
                    RoomOneCost = SquareFootagRoomOne * TILE_COST_PER_SQUARE_Ft;
                    RoomTwoCost = SquareFootagRoomTwo * TILE_COST_PER_SQUARE_Ft;
                }

                //
                //Finished calculations
                //

                Console.WriteLine("Room One: $" + RoomOneCost + ".");
                Console.WriteLine("Room Two: $" + RoomTwoCost + ".");

                totalCost = RoomOneCost + RoomTwoCost;

                Console.WriteLine($"Total costs of rooms: ${totalCost}");
                #endregion   

                Console.WriteLine();
                Console.WriteLine("\tWould you like to setup monthly payments?");
                userResponse = Console.ReadLine().ToLower();

                if (userResponse == "yes")
                {
 
                    do
                    {
                        validResponse = true;

                        //
                        //      *******************************
                        //      *      Length of Loan         *
                        //      *******************************
                        //
                        // set cursor visible and clear screen
                        //
                        Console.CursorVisible = true;
                        Console.Clear();

                        //
                        // display header
                        //
                        Console.WriteLine();
                        Console.WriteLine("\t\tLength of Loan");
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.Write(" Please tell me the length of the loan in years.");
                        Console.Write(" Enter loan length:");
                        userResponse = Console.ReadLine();

                        if (!int.TryParse(userResponse, out loanTermYears))
                        {
                            validResponse = false;

                            Console.WriteLine();
                            Console.WriteLine("It appears you entered an invalid number for the years. Please enter a positive number.");

                            //
                            // pause the app for the user
                            //
                            Console.WriteLine();
                            Console.WriteLine("\tPress any key to continue.");
                            Console.ReadKey();
                        }
                        else
                        {
                            loanTermMonths = loanTermYears * 12;
                        }

                    } while (!validResponse);

                    monthlyInterestRate = INTEREST_RATE / 12;

                    if (monthlyInterestRate != 0.0)
                    {
                        //
                        // calculate the monthly payments
                        //
                        double factor = (monthlyInterestRate * (Math.Pow(monthlyInterestRate + 1, loanTermMonths))) / (Math.Pow(monthlyInterestRate + 1, loanTermMonths) - 1);
                        monthlyPayment = totalCost * factor;
                    }

                    //
                    //      *******************************
                    //      *      Monthly Payments       *
                    //      *******************************
                    //
                    // set cursor visible and clear screen
                    //
                    Console.CursorVisible = true;
                    Console.Clear();

                    //
                    // display header
                    //
                    Console.WriteLine();
                    Console.WriteLine("\t\tMonthly Payments");
                    Console.WriteLine();

                    Console.WriteLine($"Loan for {userName}.");
                    Console.WriteLine();
                    //
                    // code to take a single word to proper case
                    //
                    //string typeOfLoanProperCase = typeOfLoan.Substring(0, 1).ToUpper() + typeOfLoan.Substring(1).ToLower();
                    //Console.WriteLine($"Type: {typeOfLoanProperCase}");
                    Console.WriteLine($"Rate: {monthlyInterestRate * 12:p}");
                    Console.WriteLine($"Principle: {totalCost:c}"); // currency format
                    Console.WriteLine($"Years: {loanTermYears}");
                    Console.WriteLine($"Monthly Payments: {monthlyPayment:c}"); // currency format

                    //
                    // pause the app for the user
                    //
                    Console.WriteLine();
                    Console.WriteLine("\tPress any key to continue.");
                    Console.ReadKey();

                    //
                    //      *******************************
                    //      *    Amortization Table       *
                    //      *******************************
                    //
                    // set cursor visible and clear screen
                    //
                    Console.CursorVisible = true;
                    Console.Clear();

                    //
                    // display header
                    //
                    Console.WriteLine();
                    Console.WriteLine("\t\tAmortization Table");
                    Console.WriteLine();

                    //
                    // display table headers
                    //
                    Console.WriteLine(
                        "Month".PadLeft(5) +
                        "Current Balance".PadLeft(20) +
                        "Payment".PadLeft(10) +
                        "Interest".PadLeft(10) +
                        "Principle".PadLeft(10) +
                        "New Balance".PadLeft(20)
                        );

                    //
                    // display table values
                    //
                    double currentBalance = totalCost;
                    double newBalancee;
                    double monthlyPrinciple;
                    double monthlyInterest;

                    for (int month = 1; month <= loanTermMonths; month++)
                    {
                        monthlyInterest = currentBalance * monthlyInterestRate;
                        monthlyPrinciple = monthlyPayment - monthlyInterest;
                        newBalancee = currentBalance - monthlyPrinciple;
                        Console.WriteLine(
                            month.ToString().PadLeft(5) +
                            currentBalance.ToString("C2").PadLeft(20) +
                            monthlyPayment.ToString("C2").PadLeft(10) +
                            monthlyInterest.ToString("C2").PadLeft(10) +
                            monthlyPrinciple.ToString("C2").PadLeft(10) +
                            newBalancee.ToString("C2").PadLeft(20)
                            );
                        currentBalance = newBalancee;
                    }

                    //
                    // pause the app for the user
                    //
                    Console.WriteLine();
                    Console.WriteLine("\tPress any key to continue.");
                    Console.ReadKey();

                }


                Console.BackgroundColor = openingClosingScreenBG;
                Console.ForegroundColor = openingClosingScreenFG;

                Console.CursorVisible = false;
                Console.Clear();

                Console.WriteLine($"\n\n\n\tThank you for using the Flooring Cost application.  Have a nice day!");
                Console.WriteLine();
                Console.WriteLine("\n\n\n\t\t\tPress any key to exit.");
                Console.ReadKey();
            }

            else if(userResponse == "no")
            {
                Console.BackgroundColor = openingClosingScreenBG;
                Console.ForegroundColor = openingClosingScreenFG;

                Console.CursorVisible = false;
                Console.Clear();

                Console.WriteLine($"\n\n\n\tWell {userName}, this app is for those who are purchasing new flooring.");
                Console.WriteLine($"\n\tThank you for your interest in our Flooring Cost application.");
                Console.WriteLine($"\n\t\t\t\tHave a nice day!");
                Console.WriteLine();
                Console.WriteLine("\n\n\n\n\n\n\t\t\tPress any key to exit.");
                Console.ReadKey();
            }

            else
            {
                Console.BackgroundColor = openingClosingScreenBG;
                Console.ForegroundColor = openingClosingScreenFG;

                Console.CursorVisible = false;
                Console.Clear();

                
                Console.WriteLine($"\n\n\n\tThank you for using our Flooring Cost application. Have a nice day!");
                Console.WriteLine();
                Console.WriteLine("\n\n\n\t\t\tPress any key to exit.");
                Console.ReadKey();
            }
        }
    }
}