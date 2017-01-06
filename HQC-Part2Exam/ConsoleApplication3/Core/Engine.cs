using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using ConsoleApplication3.Models;

namespace ConsoleApplication3.Core
{
    public class Engine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader readed, IWriter writer)
        {
            this.reader = readed;
            this.writer = writer;
        }

        public static Dictionary<int, Teacher> Teachers { get; set; } = new Dictionary<int, Teacher>();

        public static Dictionary<int, Student> Students { get; set; } = new Dictionary<int, Student>();

        public void StartEngine()
        {
            while (true)
            {
                try
                {
                    var input = this.reader.ReadLine();
                    if (input == "End")
                    {
                        break;
                    }

                    var command = input.Split(' ')[0];

                    // When I wrote this, only God and I understood what it was doing
                    // Now, only God knows
                    var assembli = this.GetType().GetTypeInfo().Assembly;
                    var typeInfo = assembli.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(command.ToLower()))
                        .FirstOrDefault();
                    if (typeInfo == null)
                    {
                        // throw exception when typeinfo is null
                        throw new ArgumentException("The passed command is not found!");
                    }

                    var instanceCreator = Activator.CreateInstance(typeInfo) as ICommand;
                    var parameters = input.Split(' ').ToList();
                    parameters.RemoveAt(0);
                    this.writer.WriteLine(instanceCreator.Execute(parameters));
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        public void WriteLine(string message)
        {
            // Bottleneck 1
            // var p = message.Split();
            // var s = string.Join(" ", p);
            // var c = 0d;
            // for (double i = 0; i < 0x105; i++)
            // {
            //    try
            //    {
            //        Console.Write(s[int.Parse(i.ToString())]);
            //    }
            //    catch (Exception)
            //    {
            //        //who cares?
            //    }
            // }
            Console.WriteLine(message);
            Console.Write("\n");
            Thread.Sleep(350);
        }
    }
}