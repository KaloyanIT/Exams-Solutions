using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputersSampleData.Data;

namespace ComputersSampleData.Importer.Importers
{
    public class CPUImporter : IImporter
    {
        private const int NumberOfCPUs = 10;
        public string Message
        {
            get { return "Import CPU"; }
        }

        public int Order
        {
            get { return 2; }
        }

        public Action<ComputersEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    for (int i = 0; i < NumberOfCPUs; i++)
                    {
                        var cpu = new CPU()
                        {
                            Vendor = RandomGenerator.GetRandomString(5, 13) + "Vendor",
                            Model = RandomGenerator.GetRandomString(5, 13) + "Model",
                            NumberOfCores = RandomGenerator.GetRandomNumber(2, 16),
                            ClockCycles = $"{RandomGenerator.GetRandomNumber(2, 6)}.{RandomGenerator.GetRandomNumber(0,9)} GHz"
                        };

                        db.CPUs.Add(cpu);

                        tr.Write(".");
                    }

                    db.SaveChanges();
                };
            }
        }
    }
}
