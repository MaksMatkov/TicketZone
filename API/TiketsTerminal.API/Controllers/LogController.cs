using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TiketsTerminal.API.Infrastructure;

namespace TiketsTerminal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogController : ControllerBase
    {
        private readonly LogPath _LogPath;
        public LogController(LogPath LogPath)
        {
            _LogPath = LogPath;
        }

        [HttpGet("download")]
        public FileResult Download()
        {
            var filePath = _LogPath.logFilePath.Replace(".log", $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}.log");
            var pdfFileBytes = GetBytesFromFile(filePath);
            return File(pdfFileBytes, "text/plain", System.IO.Path.GetFileName(filePath));
        }

        private byte[] GetBytesFromFile(string fullFilePath)
        {

            FileStream fs = null;

            try
            {
                using (fs = System.IO.File.Open(fullFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                    return bytes;
                }
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }

        }
    }
}
