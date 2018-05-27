using System;

namespace WindbgDemo
{
    public class BreakpointsDemo
    {
        public void Run()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);

                if (i == 84)
                {
                    throw new InvalidOperationException("This is an exception !");
                }
            }
        }
    }
}
