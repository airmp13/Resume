using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Resume.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Services.Implements
{
    public class UploadService : IUploadService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public UploadService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string UploadFile(IFormFile formFile,string FilePath)
        {
            string UniqueFileName = Guid.NewGuid().ToString() + "-" + formFile.FileName;
            string TargetPath = Path.Combine(_hostingEnvironment.WebRootPath, FilePath, UniqueFileName);
            
            using (var stream = new FileStream(TargetPath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            return FilePath +"/"+ UniqueFileName;
        }

        


    }
}
