using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DiscordExecutor.functions
{
    class Embed
    {
        Program p = new Program();
        /////////////////////
        //  EMBED MESSAGE  //
        /////////////////////
        public async Task SendEmbed()
        {
            ulong guildId = 0;
            ulong userId = 0;
            ulong channelId = 0;
            string title = "Example title";
            string text = "Example title";
            string footer = "Example footer";
            int r = 0;
            int g = 0;
            int b = 0;
            string description = "Example description";
            string url = "https://example.com";
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
                Console.WriteLine("Error! Type valid role ID.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            Console.Write("Author ID (type 'null' if you don't want to show author): ");
            try
            {
                string get = Console.ReadLine();
                if (get == "null")
                {
                    userId = 0;
                }
                else
                {
                    userId = ulong.Parse(get);
                }
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
            Console.Write("Title: ");
            try
            {
                title = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid title.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            Console.Write("Text: ");
            try
            {
                text = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid text.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            Console.Write("Footer: ");
            try
            {
                footer = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid footer.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            Console.Write("Color R: ");
            try
            {
                r = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid R value.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            Console.Write("Color G: ");
            try
            {
                g = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid G value.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            Console.Write("Color B: ");
            try
            {
                b = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid B value.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            Color rgb = new Color(r,g,b);
            Console.Write("Description: ");
            try
            {
                description = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid description.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            Console.Write("Url: ");
            try
            {
                url = Console.ReadLine();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type valid url.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await p.WhatToDo();
            }
            try
            {
                IGuild guild = Program.client.GetGuild(guildId);
                await guild.DownloadUsersAsync();
                var embed = new EmbedBuilder();
                // Or with methods
                embed.AddField(title, text);
                if (userId != 0)
                {
                    IGuildUser guildUser = guild.GetUserAsync(userId).Result;
                    embed.WithAuthor(guildUser);
                }
                embed.WithFooter(footer);
                embed.WithColor(rgb);
                embed.WithTitle(title);
                embed.WithDescription(description);
                embed.WithUrl(url);
                embed.WithCurrentTimestamp();

                await Program.client.GetGuild(guildId).GetTextChannel(channelId).SendMessageAsync("", false, embed.Build());
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
