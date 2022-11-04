﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace newsread.ViewModel
{
    public class SocketSingleton
    {
        private static SocketSingleton instance = new SocketSingleton();
        private static string server = "news.sunsite.dk";
        private static int port = 119;
        private static TcpClient socket;
        private static NetworkStream ns;
        private StreamReader sr;
        private static StreamWriter sw;
        string message = "";
        public ObservableCollection<string> list;

        private SocketSingleton()
        {
            
        }

        public void setupConnection()
        {
            socket = new TcpClient(server, port);
            ns = socket.GetStream();
            sw = new StreamWriter(ns);
            sr = new StreamReader(ns, System.Text.Encoding.Default);
            sw.AutoFlush = true;
            ns.Flush();
            
        }

        public string Reader()
        {
            message = sr.ReadLine();
            return message;
        }
        public void Writer(string input)
        {
            sw.WriteLine(input);
            Console.WriteLine("input: "+input);
        }

        public ObservableCollection<string> listFiller(string input)
        {
            //just a simple boolean to break the loop if the end of the stream is found
            bool loopbreaker = true;
            var removeOkLine = sr?.ReadLine();

            //creating a new instance of the list that we esnd the read lines into
            list = new ObservableCollection<string>();

            //sending the input to the writer method, which writes to the client
            Writer(input);

            while (loopbreaker)
            {
                //each loop we assign the read line from the stream to the string streamline
               string streamline = sr.ReadLine();
               if (streamline is ".")
                {
                    loopbreaker = false;
                }
               //this string then gets added to the list
                list.Add(streamline);
            }   
            return list;

        }



        public static SocketSingleton getInstance()
        {
            return instance;  
        }

    }
}