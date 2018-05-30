using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureCognitiveService.Services
{
    public static class AzureCognitiveService
    {
        public static ComputerVisionApi GetComputerVisionApi(string imageFilePath)
            => new ComputerVisionApi(imageFilePath);        
    }
}
