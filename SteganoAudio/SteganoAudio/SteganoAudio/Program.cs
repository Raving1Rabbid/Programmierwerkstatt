using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SteganoAudio
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = "In The End (Official Lyric Video) - Linkin Park.wav";
            var bytes = File.ReadAllBytes(fileName);
            var dataSize = 0;
            var dataSizeEnd = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i + 0] == (byte)'d')
                {
                    if ((bytes[i + 1] == (byte)'a') &&
                        (bytes[i + 2] == (byte)'t') &&
                        (bytes[i + 3] == (byte)'a'))
                    {
                        dataSizeEnd = i + 8;
                        for (int j = 0; j < 8; j++)
                        {
                            dataSize += Convert.ToInt32(bytes[i + j].ToString("x"), 16);
                        }
                        Console.WriteLine(dataSize);
                    }
                }
            }
            var count = 0;
            for (int i = dataSizeEnd; i < bytes.Length; i++)
            {
                count++;
            }
            Console.WriteLine(count/8);
            // File.WriteAllBytes("In The End (Official Lyric Video) - Linkin Park (copy).wav", bytes);

            Console.ReadLine();
        }
    }
}