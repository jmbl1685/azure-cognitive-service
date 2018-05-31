using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AzureCognitiveService.Utilities
{
    public static class UtilitiesExtension
    {
        public static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (var fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                var binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }

        public static async Task<Response> MakeAnalysisRequest(Request request)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response;
            Response _response;

            try
            {

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", request.SubscriptionKey);
                string uri = $"{request.UriBase}?{request.RequestParameters}";
                byte[] byteData = GetImageAsByteArray(request.ImageFilePath);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue(request.ContentType);
                    response = await client.PostAsync(uri, content);
                }

                _response = new Response()
                {
                    ContentString = await response.Content.ReadAsStringAsync()
                };

            }
            catch (Exception e)
            {
                throw e;
            }

            return _response;

        }

    }
}
