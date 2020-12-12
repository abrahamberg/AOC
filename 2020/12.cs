using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using AdventOfCode.Application;

namespace AdventOfCode._2020
{
    internal class _12 : Solution
    {
        public _12(IEnumerable<string> inputs, VersionEnum version) : base(inputs, version)
        {
        }

        protected override string SolverA(IEnumerable<string> inputs)
        {
            var ship = new Ship(90, 0, 0);
            foreach (var input in inputs) ship.Navigate(input);

            return (Math.Abs(ship.X) + Math.Abs(ship.Y)).ToString();
        }

        protected override string SolverB(IEnumerable<string> inputs)
        {
            var wayPoint = new WayPoint(10, 1);
            var ship = new ShipWithWayPoint(wayPoint, 0, 0);
            foreach (var input in inputs) ship.Navigate(input);

            return (Math.Abs(ship.X) + Math.Abs(ship.Y)).ToString();
        }


        private class WayPoint
        {
            public WayPoint(int x, int y)
            {
                Y = y;
                X = x;
            }

            public int Y { get; set; }
            public int X { get; set; }
        }


        
        private class ShipWithWayPoint
        {
            public ShipWithWayPoint(WayPoint wayPoint, int y, int x)
            {
                WayPoint = wayPoint;
                WayPoint = wayPoint;
                Y = y;
                X = x;
            }

            private WayPoint WayPoint { get; }
            public int Y { get; private set; }
            public int X { get; private set; }


            public void Navigate(string command)
            {
               
              
                var c = command[0];
                var v = int.Parse(command.Remove(0, 1));

                switch (c)
                {
                    case 'L':
                        switch (v)
                        {
                            case 90:
                            {
                                var tempY = WayPoint.X;
                                WayPoint.X = -WayPoint.Y;
                                WayPoint.Y = tempY;
                                break;
                            }
                            case 180:
                            {
                               
                                WayPoint.X = -WayPoint.X;
                                WayPoint.Y = -WayPoint.Y;
                                break;
                            }
                            case 270:
                            {
                                var tempY = -WayPoint.X;
                                WayPoint.X = WayPoint.Y;
                                WayPoint.Y = tempY;
                                break;
                            }
                            default: throw new Exception();
                        }


                        break;
                    case 'R':

                        switch (v)
                        {
                            case 90:
                            {
                                var tempY = -WayPoint.X;
                                WayPoint.X = WayPoint.Y;
                                WayPoint.Y = tempY;
                                break;
                            }
                            case 180:
                            {

                                WayPoint.X = -WayPoint.X;
                                WayPoint.Y = -WayPoint.Y;
                                break;
                            }
                            case 270:
                            {
                                var tempY = WayPoint.X;
                                WayPoint.X = -WayPoint.Y;
                                WayPoint.Y = tempY;
                                break;
                            }
                            default: throw new Exception();
                        }

                        break;
                    case 'F':
                        MoveForward(v);
                        break;
                    case 'N':
                        WayPoint.Y += v;
                        break;
                    case 'S':
                        WayPoint.Y -= v;
                        break;
                    case 'E':
                        WayPoint.X += v;
                        break;
                    case 'W':
                        WayPoint.X -= v;
                        break;
                    default: throw new Exception();
                }

                Console.WriteLine(command);
                Console.WriteLine($"Ship x:{X}, y:{Y}");
                Console.WriteLine($"WayPoint x:{WayPoint.X}, y:{WayPoint.Y}");
            }


            private void MoveForward(int v)
            {
                X += v * WayPoint.X;
                Y += v * WayPoint.Y;
            }
        }


        private class Ship
        {
            public Ship(int head, int y, int x)
            {
                Head = head;
                Y = y;
                X = x;
            }

            public int Head { get; set; }
            public int Y { get; set; }
            public int X { get; set; }


            public void Navigate(string command)
            {
                var c = command[0];
                var v = int.Parse(command.Remove(0, 1));

                switch (c)
                {
                    case 'L':
                        Head -= v;
                        break;
                    case 'R':
                        Head += v;
                        break;
                    case 'F':
                        MoveForward(v);
                        break;
                    case 'N':
                        Y += v;
                        break;
                    case 'S':
                        Y -= v;
                        break;
                    case 'E':
                        X += v;
                        break;
                    case 'W':
                        X -= v;
                        break;
                    default: throw new Exception();
                }

                if (Head >= 360) Head -= 360;
                if (Head < 0) Head += 360;
            }


            private void MoveForward(int v)
            {
                switch (Head)
                {
                    case 0:
                        Y += v;
                        break;
                    case 180:
                        Y -= v;
                        break;
                    case 90:
                        X += v;
                        break;
                    case 270:
                        X -= v;
                        break;
                    default: throw new Exception();
                }
            }
        }
    }
}