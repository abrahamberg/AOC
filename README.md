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

``ex . .\2020\01.cs``

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
        public string Puzzle1(IReadOnlyList<string> inputs)
        {
            throw new System.NotImplementedException();
        }

        public string Puzzle2(IReadOnlyList<string> inputs)
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
 $ dotnet run "2020-15" "A"
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
                 /  /_\  \  /  /\   \/    \  \/
                /    |    \/   \/    \     \____
                \____|__  /\_________/\______  /
                        \/                   \/

         Welcome Back, Jedi!
         May the source be with you!


         Fun fact: Only 7 days, 13 hours, 16 minuets, 47 seconds, 16 milliseconds to Christmas!


          For 2020-15/A


                        ********
                        | 1009 |
                        ********


         "Never tell me the odds!"  _Han Solo

```
