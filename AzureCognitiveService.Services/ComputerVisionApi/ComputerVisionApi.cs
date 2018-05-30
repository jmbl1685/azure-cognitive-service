using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AzureCognitiveService.Services
{
    public class ComputerVisionApi
    {
        private const string subscriptionKey = "YourSubscriptionKey";
        private const string uriBase = "https://eastus.api.cognitive.microsoft.com/vision/v1.0/analyze";
        public static string contentString = null;
        public ComputerVisionApi(string imageFilePath)
        {
            if (File.Exists(imageFilePath))
                MakeAnalysisRequest(imageFilePath).Wait();
        }

        private static async Task MakeAnalysisRequest(string imageFilePath)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

                string requestParameters = "visualFeatures=Categories,Description,Color";

                string uri = $"{uriBase}?{requestParameters}";

                HttpResponseMessage response;

                byte[] byteData = GetImageAsByteArray(imageFilePath);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    response = await client.PostAsync(uri, content);
                }

                contentString = await response.Content.ReadAsStringAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (var fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                var binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }

    }
}

