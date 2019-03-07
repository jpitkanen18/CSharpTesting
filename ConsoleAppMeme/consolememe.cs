using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMeme
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Which address to ping?");
            String address = Console.ReadLine();
            Process process = new Process();
            void Ping(String addressMeme){
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.StandardInput.WriteLine("ping " + addressMeme);
                process.StandardInput.Flush();
                process.StandardInput.Close();
                String result = process.StandardOutput.ReadToEnd();
                if (result.Contains("ms"))
                {
                    Console.WriteLine("Online");
                } else
                {
                    Console.WriteLine("Offline, check connection");
                }
                Console.WriteLine("Another one?");
                String yesOrNo = Console.ReadLine();
                if (yesOrNo == "y" || yesOrNo == "yes")
                {
                    Console.WriteLine("Which address?");
                    String addressNew = Console.ReadLine();
                    Ping(addressNew);
                }
                else
                {
                    Console.WriteLine("Splendid");
                }
            }
            Ping(address);
        }
    }
}
