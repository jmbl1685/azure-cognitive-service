﻿using AzureCognitiveService.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCognitiveService.Services
{
    public static class AzureCognitiveService
    {
        public async static Task<Response> GetComputerVisionApi(Request request)
            => await UtilitiesExtension.MakeAnalysisRequest(request);

        public async static Task<Response> GetFaceApi(Request request)
            => await UtilitiesExtension.MakeAnalysisRequest(request);
    }
}
