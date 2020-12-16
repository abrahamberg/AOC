using System;
using AdventOfCode.Application;
using AdventOfCode.Exceptions;
using AdventOfCode.Infrastructure;
using Console = AdventOfCode.Infrastructure.Console;

namespace AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string defaultPuzzleName = "2020-16";
            const string defaultPuzzleVersion = "B";

            IUserInterface ui = new Console();

            try
            {
                var inPuzzleName = args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]) ? args[0] : defaultPuzzleName;
                var inPuzzleVersion = args.Length > 1 && !string.IsNullOrWhiteSpace(args[1])
                    ? args[1]
                    : defaultPuzzleVersion;
                var puzzleName = new PuzzleName(inPuzzleName);
                var puzzleVersion = inPuzzleVersion.ToUpper() == "B" ? VersionEnum.B : VersionEnum.A;
                var config = new AppConfig();
                var inputs = FileParse.GetRows($"{config.BaseRoot}", $"{inPuzzleName}.txt");
                var solution = SolutionFactory.Create(puzzleName, puzzleVersion, inputs);


                ui.ShowWelcome();
                ui.ShowCurrentPuzzle(inPuzzleName, puzzleVersion.ToString() );
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