using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Await
{
    internal class Await
    {
        public static string text1 = "the file's encrypted", path1 = "file1.txt", path1_ = "file1_.txt", path2 = "file2.txt", path2_ = "file2_.txt", path3 = "file3.txt", path3_ = "file3_.txt", path4 = "file4.txt", path4_ = "file4_.txt", path5 = "file5.txt", path, path_;
        static void Main(string[] args)
        {
            Task task1 = new Task(Double_encryption), task2 = new Task(Double_encryption), task3 = new Task(Double_encryption), task4 = new Task(Double_encryption);
            path = path1;
            path_ = path1_;
            task1.Start();
            path = path2;
            path_ = path2_;
            task2.Start();
            path = path3;
            path_ = path3_;
            task3.Start();
            path = path4;
            path_ = path4_;
            task4.Start();
        }
        public static async void Double_encryption()
        {
            File.WriteAllText(path, text1);
            char[] text2 = text1.ToCharArray(), text3 = new char[text2.Length];
            string text4 = "";
            for (int i = 0; i < text3.Length; i++)
            {
                text3[i] = (char)(text2[i] + 1);
                text4 += text3[i].ToString();
            }
            File.WriteAllText(path_, text4);
            using (Stream stream = File.OpenRead(path_)) using (Stream stream_ = File.Create(path5))
            {
                int block = 1024;
                byte[] buffer = new byte[block], buffer_ = new byte[block];
                for (int i = 0; i < block; i++)
                {
                    if (i == block) buffer_[i] = 0;//предотвращение перехода за границы массива
                    else buffer_[i] = buffer[i + 1];
                }
                int count = await stream.ReadAsync(buffer_, 0, block);
                await stream_.WriteAsync(buffer_, 0, block);
            }
        }
    }
}