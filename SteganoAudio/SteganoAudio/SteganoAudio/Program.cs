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
            var dataSizeBegin = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i + 0].ToString("x") == "64")
                {
                    if ((bytes[i + 1].ToString("x") == "61") &&
                        (bytes[i + 2].ToString("x") == "74") &&
                        (bytes[i + 3].ToString("x") == "61"))
                    {
                        dataSizeBegin = i + 8;
                    }
                }
            }
            var dataBegin = dataSizeBegin;
            for (int i = dataBegin; i < bytes.Length; i++)
            {
                if (bytes[i] != 0)
                {
                    dataBegin = i;
                    break;
                }
            }
            for (int i = dataBegin; i < bytes.Length; i++)
            {
                Console.WriteLine(bytes[i].ToString("x") + " = " + (char)bytes[i]);
                Thread.Sleep(125);
            }
            Console.ReadLine();
        }
    }
}