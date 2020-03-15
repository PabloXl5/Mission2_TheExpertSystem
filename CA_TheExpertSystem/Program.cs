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

            //double roomDimensionsAll;
            //double validDimensions;

            double totalCost;

            bool validResponse;

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
                Console.WriteLine("\t\tFlooring Detials");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine("Great, let's get started!");
                Console.WriteLine();
                Console.WriteLine("We just need some measurements and floor type to calculate your costs.");

                Console.WriteLine();
                Console.Write("Press any key to begin.");
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
                    Console.WriteLine("Length and Width of rooms");
                    Console.WriteLine();

                    Console.WriteLine();
                    Console.WriteLine("\tEnter Length of 1st room.");
                    Console.Write("Width: ");
                    userResponse = Console.ReadLine();
                    roomOneWidth = double.Parse(userResponse);

                    Console.WriteLine();
                    Console.WriteLine("\tEnter Width of 1st room.");
                    Console.Write("Length: ");
                    userResponse = Console.ReadLine();
                    roomOneLength = double.Parse(userResponse);

                    Console.WriteLine();
                    Console.WriteLine("\tEnter Length of 2nd room.");
                    Console.Write("Width: ");
                    userResponse = Console.ReadLine();
                    roomTwoWidth = double.Parse(userResponse);

                    Console.WriteLine();
                    Console.WriteLine("\tEnter Width of 2nd room.");
                    Console.Write("Length: ");
                    userResponse = Console.ReadLine();
                    roomTwoLength = double.Parse(userResponse);

                    // calculate square footage

                    SquareFootagRoomOne = (roomOneLength * roomOneWidth);
                    SquareFootagRoomTwo = (roomTwoLength * roomTwoWidth);

                    if (SquareFootagRoomOne <= 0 || SquareFootagRoomTwo <= 0)
                    {
                        validResponse = false;

                        Console.WriteLine();
                        Console.WriteLine("It looks like you've entered invalid numbers.  Please enter positive numbers.");

                        //
                        // pause the app for the user
                        //
                        Console.WriteLine();
                        Console.WriteLine("\tPress any key to continue.");
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
                    Console.WriteLine("\t\tFlooring Type");
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

                Console.WriteLine();
                Console.WriteLine("\tPress any key to Finish.");
                Console.ReadKey();

                Console.BackgroundColor = openingClosingScreenBG;
                Console.ForegroundColor = openingClosingScreenFG;

                Console.CursorVisible = false;
                Console.Clear();

                Console.WriteLine($"\n\n\n\tThank you for using the Flooring Cost application.  Have a nice day!");
                Console.WriteLine();
                Console.WriteLine("\n\n\n\t\t\tPress any key to exit.");
                Console.ReadKey();
            }

            else
            {
                Console.BackgroundColor = openingClosingScreenBG;
                Console.ForegroundColor = openingClosingScreenFG;

                Console.CursorVisible = false;
                Console.Clear();

                Console.WriteLine($"\n\n\n\tThank you for using the Flooring Cost application.  Have a nice day!");
                Console.WriteLine();
                Console.WriteLine("\n\n\n\t\t\tPress any key to exit.");
                Console.ReadKey();
            }
        }
    }
}