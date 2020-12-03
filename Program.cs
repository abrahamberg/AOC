using System;
using AdventOfCode.Exceptions;
using AdventOfCode.Helpers;
using AdventOfCode.Infrastructure;
using AdventOfCode.Solutions;


namespace AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string defaultPuzzleName = "2020-03";
            const string defaultPuzzleVersion = "B";

            IUserInterface ui = new Infrastructure.Console();

            try
            {
                var inPuzzleName = args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]) ? args[0] : defaultPuzzleName;
                var puzzleVersion = args.Length > 1 && !string.IsNullOrWhiteSpace(args[1])
                    ? args[1]
                    : defaultPuzzleVersion;
                var puzzleName = new PuzzleName(inPuzzleName);
                var config = new AppConfig();
                var inputs = FileParse.GetRows($"{config.BaseRoot}", $"{inPuzzleName}.txt");
                var solution = SolutionFactory.Create(puzzleName, puzzleVersion, inputs);


                ui.ShowWelcome();
                ui.ShowCurrentPuzzle(inPuzzleName, puzzleVersion);
                ui.ShowAnswer(solution.Results);
            }
            catch (InputPathDoesNotExistException e)
            {
                ui.ShowError("It seems that Input path does not exits in your system \n" +
                             "There is a setting for the PATH, check appsettings.json \n" +
                             "Both relative ..\\..\\Folder\\Input and absolute patterns C:\\Folder\\Input are acceptable \n" +
                             $"Missing path : {e.Path}");
            }
            catch (InputFileDoesNotExistException e)
            {
                ui.ShowError("It seems that You forgot your Input File  \n " +
                             $"I was Looking for {e.File} \n" +
                             $"at the path : {e.Path}");

            }
            catch (Exception e)
            {
                ui.ShowError(e.Message);

            }
            finally
            {
                ui.Dispose();
            }
           
        }
    }
}