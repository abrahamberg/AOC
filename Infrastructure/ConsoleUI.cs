using System;

namespace AdventOfCode.Infrastructure
{
    public class Console : IUserInterface
    {
        public void ShowWelcome()
        {
            Show(null);
            Show(@"
                   _____   ________  _________  
                  /  _  \  \_      \ \_   ___ \ 
                 /  /_\  \  /       \/    \  \/ 
                /    |    \/         \     \____
                \____|__  /\_________/\______  /
                        \/                   \/ 
            ");

            Show("\t Welcome Back, Jedi!");
            Show("\t May the source be with you!");
            ShowDivider();
            Show($"\t Fun fact: Only {ToChristmas()} to Christmas!");
            ShowDivider();
        }

        public void ShowCurrentPuzzle(string puzzleName, string puzzleVersion)
        {
            Show(@"
                 _____         _               
                |_   _|       | |            _ 
                  | | ___   __| | __ _ _   _(_)
                  | |/ _ \ / _` |/ _` | | | |  
                  | | (_) | (_| | (_| | |_| |_ 
                  \_/\___/ \__,_|\__,_|\__, (_)
                                        __/ |  
                                       |___/   
            ");
            Show($"For {puzzleName}/{puzzleVersion}");
            ShowDivider();
        }

        public void ShowAnswer(string results)
        {
            Show(@"
              /$$$$$$                                                       
             /$$__  $$                                                      
            | $$  \ $$ /$$$$$$$   /$$$$$$$ /$$  /$$  /$$  /$$$$$$   /$$$$$$ 
            | $$$$$$$$| $$__  $$ /$$_____/| $$ | $$ | $$ /$$__  $$ /$$__  $$
            | $$__  $$| $$  \ $$|  $$$$$$ | $$ | $$ | $$| $$$$$$$$| $$  \__/
            | $$  | $$| $$  | $$ \____  $$| $$ | $$ | $$| $$_____/| $$      
            | $$  | $$| $$  | $$ /$$$$$$$/|  $$$$$/$$$$/|  $$$$$$$| $$      
            |__/  |__/|__/  |__/|_______/  \_____/\___/  \_______/|__/      
                                                                
            ");
            Show("\t is");
            Show($"\t\t {results}");


            ShowDivider();
            Show("\t \"Never tell me the odds!\"  _Han Solo");

            ShowDivider();
        }

        public void ShowError(string error)
        {
            Show(null);
            Show(@" 
              _________                           
             /   _____/ __________________ ___.__.
             \_____  \ /  _ \_  __ \_  __ <   |  |
             /        (  <_> )  | \/|  | \/\___  |
            /_______  /\____/|__|   |__|   / ____|
                    \/                     \/     
            ");
            Show(null);
            Show($"{error}");
        }

        public void Dispose()
        {
        }


        private static void Show(string s)
        {
            System.Console.WriteLine(s);
        }

        private static string ToChristmas()
        {
            var totalDays = (DateTime.Parse("25 December") - DateTime.Now).TotalDays;
            var timeSpan = TimeSpan.FromDays(totalDays);

            return
                $"{timeSpan.Days} days, {timeSpan.Hours} hours, {timeSpan.Minutes} minuets, {timeSpan.Seconds} seconds, {timeSpan.Minutes} milliseconds";
        }


        private static void ShowDivider()
        {
            Show(null);
            Show(null);
        }
    }
}