using System;

namespace AdventOfCode.Infrastructure
{
    public interface IUserInterface : IDisposable
    {
        void ShowWelcome();

        void ShowCurrentPuzzle(string puzzleName, string puzzleVersion);
        void ShowAnswer(string results);

        void ShowError(string error);
    }
}