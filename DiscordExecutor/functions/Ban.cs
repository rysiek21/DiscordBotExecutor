using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DiscordExecutor.functions
{
    class Ban
    {
        Program p = new Program();
        ////////////////
        //  Ban user  //
        ////////////////
        public async Task BanUser()
        {
            ulong guildId = 0;
            ulong userId = 0;
            string reason = "";
            int purgeDays = 0;
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
            Console.Write("Reason: ");
            try
            {
                reason = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid reason.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            Console.Write("Days to purge messages 0-7: ");
            try
            {
                purgeDays = int.Parse(Console.ReadLine());
                if (purgeDays > 7 || purgeDays < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Type valid number of days.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                    await p.WhatToDo();
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid number of days.");
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
                await guildUser.BanAsync(purgeDays, reason);
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
