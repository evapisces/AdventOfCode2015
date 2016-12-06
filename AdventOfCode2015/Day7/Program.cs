using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../day7input.txt");

            var commandlist = new List<string>();

            foreach (var command in file)
            {
                commandlist.Add(command);
            }

            var wirelist = new List<WireInfo>();

            var w1 = "";
            var w2 = "";
            var res = "";

            for (var i = commandlist.Count - 1; i >= 0; i--)
            {
                var segments = commandlist[i].Split(' ');

                // variable assignment
                if (segments.Length == 3 && Regex.IsMatch(segments[0], @"\d"))
                {
                    wirelist.Add(new WireInfo
                    {
                        WireName = segments[2],
                        WireValue = Convert.ToUInt16(segments[0])
                    });
                    commandlist.RemoveAt(i);
                }
            }

            while (commandlist.Count > 0)
            {
                for (var i = commandlist.Count - 1; i >= 0; i--)
                {
                    var linesegs = commandlist[i].Split(' ');

                    if (commandlist[i].Contains("NOT"))
                    {
                        w1 = linesegs[1];
                        res = linesegs[3];

                        if (wirelist.Any(wl => wl.WireName == w1))
                        {
                            var wire1 = wirelist.Find(wl => wl.WireName == w1).WireValue;
                            ushort result = (ushort)~Convert.ToInt16(wire1);

                            // wire hasn't been set yet
                            if (wirelist.Find(wl => wl.WireName == res) == null)
                            {
                                wirelist.Add(new WireInfo
                                {
                                    WireName = res,
                                    WireValue = result
                                });
                            }
                            else
                            {
                                wirelist.Find(wl => wl.WireName == res).WireValue = result;
                            }

                            commandlist.RemoveAt(i);
                        }
                    }
                    else if (commandlist[i].Contains("AND"))
                    {
                        w1 = linesegs[0];
                        w2 = linesegs[2];
                        res = linesegs[4];

                        // line starts with a 1
                        if (Regex.IsMatch(w1, @"\d") && wirelist.Any(wl => wl.WireName == w2))
                        {
                            var wire2 = wirelist.Find(wl => wl.WireName == w2).WireValue;
                            ushort result = (ushort)(Convert.ToUInt16(w1) & Convert.ToUInt16(wire2));

                            if (wirelist.Find(wl => wl.WireName == res) == null)
                            {
                                wirelist.Add(new WireInfo
                                {
                                    WireName = res,
                                    WireValue = result
                                });
                            }
                            else
                            {
                                wirelist.Find(wl => wl.WireName == res).WireValue = result;
                            }

                            commandlist.RemoveAt(i);
                        }
                        // both wire have been set
                        else if (wirelist.Any(wl => wl.WireName == w1) && wirelist.Any(wl => wl.WireName == w2))
                        {
                            var wire1 = wirelist.Find(wl => wl.WireName == w1).WireValue;
                            var wire2 = wirelist.Find(wl => wl.WireName == w2).WireValue;
                            ushort result = (ushort)(Convert.ToUInt16(wire1) & Convert.ToUInt16(wire2));

                            if (wirelist.Find(wl => wl.WireName == res) == null)
                            {
                                wirelist.Add(new WireInfo
                                {
                                    WireName = res,
                                    WireValue = result
                                });
                            }
                            else
                            {
                                wirelist.Find(wl => wl.WireName == res).WireValue = result;
                            }

                            commandlist.RemoveAt(i);
                        }
                    }
                    else if (commandlist[i].Contains("OR"))
                    {
                        w1 = linesegs[0];
                        w2 = linesegs[2];
                        res = linesegs[4];

                        if (Regex.IsMatch(w1, @"\d") && wirelist.Any(wl => wl.WireName == w2))
                        {
                            var wire2 = wirelist.Find(wl => wl.WireName == w2).WireValue;
                            ushort result = (ushort)(Convert.ToUInt16(w1) | Convert.ToUInt16(wire2));

                            if (wirelist.Find(wl => wl.WireName == res) == null)
                            {
                                wirelist.Add(new WireInfo
                                {
                                    WireName = res,
                                    WireValue = result
                                });
                            }
                            else
                            {
                                wirelist.Find(wl => wl.WireName == res).WireValue = result;
                            }

                            commandlist.RemoveAt(i);
                        }
                        // both wire have been set
                        else if (wirelist.Any(wl => wl.WireName == w1) && wirelist.Any(wl => wl.WireName == w2))
                        {
                            var wire1 = wirelist.Find(wl => wl.WireName == w1).WireValue;
                            var wire2 = wirelist.Find(wl => wl.WireName == w2).WireValue;
                            ushort result = (ushort)(Convert.ToUInt16(wire1) | Convert.ToUInt16(wire2));

                            if (wirelist.Find(wl => wl.WireName == res) == null)
                            {
                                wirelist.Add(new WireInfo
                                {
                                    WireName = res,
                                    WireValue = result
                                });
                            }
                            else
                            {
                                wirelist.Find(wl => wl.WireName == res).WireValue = result;
                            }

                            commandlist.RemoveAt(i);
                        }
                    }
                    else if (commandlist[i].Contains("RSHIFT"))
                    {
                        w1 = linesegs[0];
                        var shift = linesegs[2];
                        res = linesegs[4];

                        if (wirelist.Any(wl => wl.WireName == w1))
                        {
                            var wire1 = wirelist.Find(wl => wl.WireName == w1).WireValue;
                            ushort result = (ushort)(Convert.ToUInt16(wire1) >> Convert.ToUInt16(shift));

                            if (wirelist.Find(wl => wl.WireName == res) == null)
                            {
                                wirelist.Add(new WireInfo
                                {
                                    WireName = res,
                                    WireValue = result
                                });
                            }
                            else
                            {
                                wirelist.Find(wl => wl.WireName == res).WireValue = result;
                            }

                            commandlist.RemoveAt(i);
                        }
                    }
                    else if (commandlist[i].Contains("LSHIFT"))
                    {
                        w1 = linesegs[0];
                        var shift = linesegs[2];
                        res = linesegs[4];

                        if (wirelist.Any(wl => wl.WireName == w1))
                        {
                            var wire1 = wirelist.Find(wl => wl.WireName == w1).WireValue;
                            ushort result = (ushort)(Convert.ToUInt16(wire1) << Convert.ToUInt16(shift));

                            if (wirelist.Find(wl => wl.WireName == res) == null)
                            {
                                wirelist.Add(new WireInfo
                                {
                                    WireName = res,
                                    WireValue = result
                                });
                            }
                            else
                            {
                                wirelist.Find(wl => wl.WireName == res).WireValue = result;
                            }

                            commandlist.RemoveAt(i);
                        }
                    }
                    else
                    {
                        w1 = linesegs[0];
                        res = linesegs[2];

                        if (wirelist.Any(wl => wl.WireName == w1))
                        {
                            var wire1 = Convert.ToUInt16(wirelist.Find(wl => wl.WireName == w1).WireValue);

                            if (wirelist.Find(wl => wl.WireName == res) == null)
                            {
                                wirelist.Add(new WireInfo
                                {
                                    WireName = res,
                                    WireValue = wire1
                                });
                            }
                            else
                            {
                                wirelist.Find(wl => wl.WireName == res).WireValue = wire1;
                            }

                            commandlist.RemoveAt(i);
                        }
                    }
                }
            }

            Console.WriteLine("after - commandlist.length = " + commandlist.Count);

            foreach (var wire in wirelist)
            {


                if (wire.WireName == "a")
                {
                    Console.WriteLine(wire.WireName + " = " + wire.WireValue);
                }
            }

            Console.Read();
        }

        public class WireInfo
        {
            public string WireName { get; set; }
            public ushort WireValue { get; set; }
        }
    }
}
