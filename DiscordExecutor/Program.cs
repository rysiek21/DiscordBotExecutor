using System;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;


namespace DiscordExecutor
{
    public class Program
    {
        public static DiscordSocketClient client;
        static void Main(string[] args) => new Program().Connect().GetAwaiter().GetResult();

        public async Task Connect()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Discord Bot Executor by rysiek21");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Bot Token: ");
            string token = Console.ReadLine();

            try
            {
                client = new DiscordSocketClient(new DiscordSocketConfig
                {
                    LogLevel = LogSeverity.Info
                });

                await client.LoginAsync(TokenType.Bot, token);

                await client.StartAsync();

            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Invalid Token.");
                Console.WriteLine("Click Enter to type token again.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                Console.Clear();
                await Connect();
            }
            while (client.ConnectionState != ConnectionState.Connected) { }
            await WhatToDo();
        }
        public async Task WhatToDo()
        {
            Console.Write("Type what do you want to do: ");
            string what = Console.ReadLine().ToLower();
            if (what == "help")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("message - Send message on the specific channel");
                Console.WriteLine("give role - Give specific role to the user");
                Console.WriteLine("remove role - Remove specific role to the user");
                Console.WriteLine("change name - Change nickname for specific user");
                Console.WriteLine("ban - Ban specific user");
                Console.WriteLine("kick -  Kick specific user");
                Console.ForegroundColor = ConsoleColor.White;
                await WhatToDo();
            }
            else if (what == "message")
            {
                functions.Message e = new functions.Message();
                await e.SendMessage();
            }
            else if (what == "give role")
            {
                functions.GiveRole e = new functions.GiveRole();
                await e.GiveRoleFunc();
            }
            else if (what == "remove role")
            {
                functions.RemoveRole e = new functions.RemoveRole();
                await e.RemoveRoleFunc();
            }
            else if (what == "change name")
            {
                functions.ChangeName e = new functions.ChangeName();
                await e.ChangeNameFunc();
            }
            else if (what == "ban")
            {
                functions.Ban e = new functions.Ban();
                await e.BanUser();
            }
            else if (what == "kick")
            {
                functions.Kick e = new functions.Kick();
                await e.KickUser();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error! Type 'help' to see all commands.");
                Console.ForegroundColor = ConsoleColor.White;
                await WhatToDo();
            }
        }
    }
}
