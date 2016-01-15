using System;
using NUnit.Framework;

namespace BankingSite.FunctionalUITests
{
    [SetUpFixture]
    public class TestFixtureLifecycle : IDisposable
    {        
        public void Dispose()              
        {
            DemoHelperCode.DemoHelper.Wait(5000);

            // Cleanup and close browser
            BrowserHost.Instance.Dispose();
        }
    }
}
