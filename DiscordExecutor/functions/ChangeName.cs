using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DiscordExecutor.functions
{
    class ChangeName
    {
        Program p = new Program();
        ///////////////////
        //  Change Name  //
        ///////////////////
        public async Task ChangeNameFunc()
        {
            ulong guildId = 0;
            ulong userId = 0;
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
            Console.Write("User ID: ");
            try
            {
                userId = ulong.Parse(Console.ReadLine());
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid user ID.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            Console.Write("New nickname: ");
            try
            {
                name = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid nickname.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            try
            {
                IGuild guild = Program.client.GetGuild(guildId);
                await guild.DownloadUsersAsync();
                IGuildUser guildUser = guild.GetUserAsync(userId).Result;
                await guildUser.ModifyAsync(x =>
                {
                    x.Nickname = name;
                });
                await p.WhatToDo();
            }
            catch(Exception ex)
            {
                if(ex.Message == "The server responded with error 403: Forbidden")
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
