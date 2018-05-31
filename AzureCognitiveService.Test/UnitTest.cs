using System;
using System.Threading.Tasks;
using AzureCognitiveService.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureCognitiveService.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public async Task TestMethod()
        {

            var _testComputerVisionApi = await Services.AzureCognitiveService.GetComputerVisionApi(new Request()
            {
                SubscriptionKey = "YourSubcriptionKey",
                UriBase = "https://eastus.api.cognitive.microsoft.com/vision/v1.0/analyze",
                ContentType = "application/octet-stream",
                ImageFilePath = "C:\\image.jpg",
                RequestParameters = "visualFeatures=Categories,Description,Color"

            });

            var _testFaceApi = await Services.AzureCognitiveService.GetFaceApi(new Request()
            {
                SubscriptionKey = "YourSubcriptionKey",
                UriBase = "https://eastus.api.cognitive.microsoft.com/face/v1.0/detect",
                ContentType = "application/octet-stream",
                ImageFilePath = "C:\\image.jpg",
                RequestParameters = "returnFaceId=true&returnFaceLandmarks=false" +
                "&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses," +
                "emotion,hair,makeup,occlusion,accessories,blur,exposure,noise"
            });
        }
    }
}
