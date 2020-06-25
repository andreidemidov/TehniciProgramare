using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using tp_project_freelance_platform_api.Repository.Interfaces;
using TP_PROJECT_FreeLancePlatform_Api.Helpers;

namespace tp_project_freelance_platform_api.Repository
{
    public class DetailRepository : IDetail
    {
        private IHostingEnvironment _hostingEnvironment;
        public DetailRepository(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string CreateFile(string fileName, byte[] bytes)
        {
            var path = "D:/files";

            var returningUrl = "";
            var index = fileName.IndexOf(".");
            if (index >= 0)
            {
                var fileWithoutExtension = fileName.Substring(0, index);
                var type = fileName.Substring(index, fileName.Length - index);

                var filePath = Path.Combine(path, $"{fileWithoutExtension}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{type}");

                DirectoryInfo di = new DirectoryInfo(path);
                if (!di.Exists)
                {
                    Directory.CreateDirectory(path);
                }

                File.WriteAllBytes(filePath, bytes);
                returningUrl = filePath;


                return filePath;
            }
            return "";
        }

        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

    }
}
