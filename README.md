# AOC
Advent of Code

## Add New solution 
### The file 
For each day make a file under Solutions/[year]/[day].cs

ex . Solutions\2020\01.cs for 2020-12-01  

## The Code 
Copy this code and replace xx with the day .

Make sure your namespce matches the folder
```
using System;
using System.Collections.Generic;

namespace AdventOfCode.Solutions._2020
{
    public class _xx_A : Solution
    {
        public _xx_A(IEnumerable<string> inputs) : base(inputs) { }

        protected override string Solver()
        {
            throw new NotImplementedException();
        }
    }

    public class _xx_B : Solution
    {
        public _xx_B(IEnumerable<string> inputs) : base(inputs) { }

        protected override string Solver()
        {
            throw new NotImplementedException();
        }
    }
}
```

## The Input
Copy the input of the day to the folder Input and name it [year]-[day].txt ex. 2020-01.txt

## The solution 
Write your solution in the Solver(), don't forget to return your answer as string.

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
### Visual Studio 
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