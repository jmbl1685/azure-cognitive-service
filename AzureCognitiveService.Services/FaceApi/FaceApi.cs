using AzureCognitiveService.Utilities;
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
    public class FaceApi
    {
       public static async Task<Response> GetFaceApi(Request request)
            => await UtilitiesExtension.MakeAnalysisRequest(request);
    }
}

