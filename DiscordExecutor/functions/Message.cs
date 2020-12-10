using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DiscordExecutor.functions
{
    class Message
    {
        Program p = new Program();
        ////////////////////
        //  SEND MESSAGE  //
        ////////////////////
        public async Task SendMessage()
        {
            ulong guild = 0;
            ulong channel = 0;
            string message = "";
            Console.Write("Guild ID: ");
            try
            {
                guild = ulong.Parse(Console.ReadLine());
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid guild ID.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            Console.Write("Channel ID: ");
            try
            {
                channel = ulong.Parse(Console.ReadLine());
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid channel ID.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            Console.Write("Message: ");
            message = Console.ReadLine();
            try
            {
                await Program.client.GetGuild(guild).GetTextChannel(channel).SendMessageAsync(message);
                await p.WhatToDo();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Invalid data.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
        }
    }
}
