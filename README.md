# AOC
## Advent of Code  https://adventofcode.com/

> "Advent of Code is an Advent calendar of small programming puzzles for a variety of skill sets and skill levels that can be solved in any programming language you like. People use them as a speed contest, interview prep, company training, university coursework, practice problems, or to challenge each other.." _Eric Wastl

## This
> "This is a framework to write solutions in C# with less effort"  _me
# Write code for a new puzzle 

## The INPUT
Copy the input of the day to the folder Input and name it [year]-[day].txt 

``ex . C:\input\2020-01.txt  ``
## Your Solution
For each day make a file under [year]/[day].cs in the project

``ex . .\2020\01.txt``

## The Code 
Your class 
in going to be named something like ` _01 ` Make it inherit from `Solution` and use visual studio to generate code  OR copy this code and replace xx with the day .

Make sure your namespce matches the folder
```
using System.Collections.Generic;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    class _XX : Solution
    {
        public _XX(IEnumerable<string> inputs, VersionEnum version) : base(inputs, version)
        {
        }

        protected override string SolverA(IEnumerable<string> inputs)
        {
            throw new System.NotImplementedException();
        }

        protected override string SolverB(IEnumerable<string> inputs)
        {
            throw new System.NotImplementedException();
        }
    }
}

```



## The solution 
Write your solution inside  SolverA()  and SolverB() for each task of the day. Arguments **inputs** are the lines of the input file.  And don't forget to return your answer as string of course.

## The Run
### From Command Line 
Pass the puzzle name :"[year]-[day]"  version "A" or "B" as arguments.
```
 $ dotnet run "2020-03" "B"
```
and in appsettings.json 
```
{
  "Input": "c:\\input"
}
```
### From Visual Studio 
Update constants in the Program.cs 

```  
const string defaultPuzzleName = "2020-03";
const string defaultPuzzleVersion = "B";
```
and in appsettings.json 
```
{
  "Input": "..\\..\\..\\Input"
}
```

## The Results 
```


                   _____   ________  _________
                  /  _  \  \_      \ \_   ___ \
                 /  /_\  \  /       \/    \  \/
                /    |    \/         \     \____
                \____|__  /\_________/\______  /
                        \/                   \/

         Welcome Back, Jedi!
         May the source be with you!


         Fun fact: Only 20 days, 23 hours, 32 minuets, 53 seconds, 32 milliseconds to Christmas!



                 _____         _
                |_   _|       | |            _
                  | | ___   __| | __ _ _   _(_)
                  | |/ _ \ / _` |/ _` | | | |
                  | | (_) | (_| | (_| | |_| |_
                  \_/\___/ \__,_|\__,_|\__, (_)
                                        __/ |
                                       |___/

For 2020-03/B



              /$$$$$$
             /$$__  $$
            | $$  \ $$ /$$$$$$$   /$$$$$$$ /$$  /$$  /$$  /$$$$$$   /$$$$$$
            | $$$$$$$$| $$__  $$ /$$_____/| $$ | $$ | $$ /$$__  $$ /$$__  $$
            | $$__  $$| $$  \ $$|  $$$$$$ | $$ | $$ | $$| $$$$$$$$| $$  \__/
            | $$  | $$| $$  | $$ \____  $$| $$ | $$ | $$| $$_____/| $$
            | $$  | $$| $$  | $$ /$$$$$$$/|  $$$$$/$$$$/|  $$$$$$$| $$
            |__/  |__/|__/  |__/|_______/  \_____/\___/  \_______/|__/


         is
                 6818112000


         "Never tell me the odds!"  _Han Solo

```
