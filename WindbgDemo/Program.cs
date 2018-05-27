using System;

namespace WindbgDemo
{
    public class Program
    {
        static void Main()
        {
            while (true)
            {
                ShowMenu();
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        new BreakpointsDemo().Run();
                        break;
                    case "2":
                        new ExamineObjects().Run();
                        break;
                    case "3":
                        new ExamineHeap().Run();
                        break;
                    case "4":
                        GC.Collect();
                        break;
                    default:
                        return;
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Choose an option below (any other key exits):");
            Console.WriteLine("1. Setup breakpoints");
            Console.WriteLine("2. Examine objects");
            Console.WriteLine("3. Examine heap");
            Console.WriteLine("4. Perform GC");
        }
    }
}
