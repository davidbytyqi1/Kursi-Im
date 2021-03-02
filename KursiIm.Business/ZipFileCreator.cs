using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace KursiIm.Business
{
    public static class ZipFileCreator
    {
        public static void CreateZipFile(string fileName, IEnumerable<string> files)
        {
            var zip = ZipFile.Open(fileName, ZipArchiveMode.Create);
            foreach (var file in files)
            {
                zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
            }
            zip.Dispose();
        }
    }
}
