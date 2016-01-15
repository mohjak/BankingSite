using System.Threading;

namespace BankingSite.FunctionalUITests.DemoHelperCode
{
    static class DemoHelper
    {
        // Slow down browser automation so can see it in recorded Pluralsight video 
        public static void Wait(int ms = 2000)
        {
            Thread.Sleep(ms);
        }
    }
}
