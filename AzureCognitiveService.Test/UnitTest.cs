using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureCognitiveService.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            var _test = Services.AzureCognitiveService.GetComputerVisionApi("C:\\image.jpg");
        }
    }
}
