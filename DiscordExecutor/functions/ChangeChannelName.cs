using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DiscordExecutor.functions
{
    class ChangeChannelName
    {
        Program p = new Program();
        ///////////////////
        //  Change Name  //
        ///////////////////
        public async Task ChangeChannelNameFunc()
        {
            ulong guildId = 0;
            ulong channelId = 0;
            string name = "";
            Console.Write("Guild ID: ");
            try
            {
                guildId = ulong.Parse(Console.ReadLine());
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
                channelId = ulong.Parse(Console.ReadLine());
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
            Console.Write("New channel name: ");
            try
            {
                name = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid channel name.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            try
            {
                await Program.client.GetGuild(guildId).GetChannel(channelId).ModifyAsync(x => { x.Name = name; });
                await p.WhatToDo();
            }
            catch (Exception ex)
            {
                if (ex.Message == "The server responded with error 403: Forbidden")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Insufficient permissions.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                    await p.WhatToDo();
                }
                else
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
}
