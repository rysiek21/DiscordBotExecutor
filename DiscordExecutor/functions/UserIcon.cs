﻿using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DiscordExecutor.functions
{
    class UserIcon
    {
        Program p = new Program();
        ///////////////////////
        //  Get User Avatar  //
        ///////////////////////
        public async Task GetUserIcon()
        {
            ulong guildId = 0;
            ulong userId = 0;
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
            try
            {
                IGuild guild = Program.client.GetGuild(guildId);
                await guild.DownloadUsersAsync();
                IGuildUser guildUser = guild.GetUserAsync(userId).Result;
                Console.WriteLine(guildUser.GetAvatarUrl(ImageFormat.Gif, 2048));
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
