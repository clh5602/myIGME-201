using System;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        [STAThread]
        static void Main(string[] args)
        {
            double realCoord, imagCoord, realCoordEnd, imageCoordEnd, realCoordStart, imageCoordStart;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;
            
            // Ask user for Real Number boundaries
            while (true)
            {
                bool flag = false;
                
                Console.Write("Enter a two-point decimal for the lower bounds of the real number.\n(normal value: -0.6): ");
                if (double.TryParse(Console.ReadLine(), out realCoordStart))
                {
                    flag = true;
                }

                Console.Write("Enter a two-point decimal for the upper bounds of the real number.\n(needs to be greater than lower bounds, normal value: 1.77): ");
                if (double.TryParse(Console.ReadLine(), out realCoordEnd))
                {
                    if (flag && realCoordStart < realCoordEnd)
                    {
                        Console.WriteLine("Values for the real number boundaries recorded successfully.");
                        break;
                    }
                }

                Console.WriteLine("Values entered for the real number boundaries do not work. Try again.\n");

            }

            // Ask user for Imaginary Number boundaries
            while (true)
            {
                bool flag = false;

                Console.Write("Enter a two-point decimal for the lower bounds of the imaginary number.\n(normal value: -1.2): ");
                if (double.TryParse(Console.ReadLine(), out imageCoordEnd))
                {
                    flag = true;
                }

                Console.Write("Enter a two-point decimal for the upper bounds of the imaginary number.\n(needs to be greater than lower bounds, normal value: 1.2): ");
                if (double.TryParse(Console.ReadLine(), out imageCoordStart))
                {
                    if (flag && imageCoordStart > imageCoordEnd)
                    {
                        Console.WriteLine("Values for the imaginary number boundaries recorded successfully.\nGenerating Mandelbrot image...");
                        break;
                    }
                }

                Console.WriteLine("Values entered for the imaginary number boundaries do not work. Try again.\n");

            }


            for (imagCoord = imageCoordStart; imagCoord >= imageCoordEnd; imagCoord += (imageCoordEnd - imageCoordStart) / 48)
            {
                for (realCoord = realCoordStart; realCoord <= realCoordEnd; realCoord += (realCoordEnd - realCoordStart) / 80)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }

        }
    }
}
