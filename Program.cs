using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Win32;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using System.Net.Mail;
using System.IO;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity​;
using System.Reflection;

namespace TestConsole
{
    public class Program
    {
        public static void Spam()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Сообщение из потока 2");
                Thread.Sleep(1);
            }
            GC.Collect();
            Thread.CurrentThread.Abort();
        }
        public static void MyExample()
        {
            //Thread thread = new Thread(Spam);
            Console.WriteLine("Hello");
            Thread.Sleep(5000);
            for (int i = 0; i < 1000; i++)
            {
                Thread thread2 = new Thread(Spam);
                thread2.Name = "Test";
                thread2.Start();
                thread2 = null;
            }
            Thread.Sleep(3000);
            GC.Collect(0);
            //thread.Start();
            //Console.WriteLine($"{thread.ThreadState}");
            Thread.Sleep(5000);
            
            Console.WriteLine("Main was executed");
            //thread.Abort();
            //Console.WriteLine($"{thread.ThreadState}");

        }

        public static void Main()
        {
            MyExample();
            Console.ReadKey();

        }
    }
}
