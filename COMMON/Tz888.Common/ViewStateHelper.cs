using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Tz888.Common
{
    public class ViewStateHelper
    {
        /// <summary>
        /// —πÀı
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Compress(byte[] data)
        {
            MemoryStream ms = new MemoryStream();
            GZipStream stream = new GZipStream(ms, CompressionMode.Compress);
            stream.Write(data, 0, data.Length);
            stream.Close();
            return ms.ToArray();
        }

        /// <summary>
        /// Ω‚—π
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] data)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(data, 0, data.Length);
            ms.Position = 0;
            GZipStream stream = new GZipStream(ms, CompressionMode.Decompress);
            MemoryStream temp = new MemoryStream();
            byte[] buffer = new byte[1024];
            while (true)
            {
                int read = stream.Read(buffer, 0, buffer.Length);
                if (read <= 0)
                {
                    break;
                }
                else
                {
                    temp.Write(buffer, 0, buffer.Length);
                }
            }
            stream.Close();
            return temp.ToArray();
        }
    }
}
