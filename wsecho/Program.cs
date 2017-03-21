using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using SuperSocket.ClientEngine;
using WebSocket4Net;

namespace wsecho
{
    internal static class Program
    {
        private static WebSocket client;
        private static Options options;
        private static bool shouldRun = true;

        public static void Main(string[] args)
        {
            options = new Options();
            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine("The arguments you have supplied are invalid.");
                return;
            }

            options.Message = PrepareMessage(options.Message, options.ReplaceSingleQuotes);
            SendMessage();

            while (shouldRun)
            {
                ;
            }
        }

        private static string PrepareMessage(string message, bool replaceQuotes)
        {
            if (replaceQuotes)
            {
                message = message.Replace("'", "\"");
            }
            return message;
        }

        private static void SendMessage()
        {
            Console.WriteLine($"Tying to connect to host {options.Hostname}.");
            client = new WebSocket(options.Hostname);
            client.Opened += ClientOnOpened;
            client.Closed += ClientOnClosed;
            client.Error += ClientOnError;
            client.Open();
        }

        private static void ClientOnError(object sender, ErrorEventArgs errorEventArgs)
        {
            Console.WriteLine("An error has occured, please check the parameters.");
            Console.WriteLine(errorEventArgs.Exception);
        }

        private static void ClientOnClosed(object sender, EventArgs eventArgs)
        {
            shouldRun = false;
            Console.WriteLine("Connection closed, terminating program.");
        }

        private static void ClientOnOpened(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Connection to the host established.");
            client.Send(options.Message);
            Console.WriteLine("Message sent, disconnecting.");
            client.Close();
        }
    }
}