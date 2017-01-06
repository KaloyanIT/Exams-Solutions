using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputersSampleData.Data;

namespace ComputersSampleData.Importer.Importers
{
    public class GPUImporter : IImporter
    {
        private const int NumberOfGPUs = 15;
        public string Message
        {
            get { return "Import GPU"; }
        }

        public int Order
        {
            get { return 1; }
        }

        public Action<ComputersEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    int typeId = 1;
                    for (int i = 0; i < NumberOfGPUs; i++)
                    {
                        var gpu = new GPU()
                        {
                            GPUTypeId = typeId,
                            Vendor = RandomGenerator.GetRandomString(3, 13) + "Vendor",
                            Model = RandomGenerator.GetRandomString(3, 13) + "Model",
                            Memory = $"{RandomGenerator.GetRandomNumber(2, 64)} GB"
                        };

                        if (i == NumberOfGPUs/3 - 1)
                        {
                            typeId = 2;
                        }

                        db.GPUs.Add(gpu);

                        if (i%5 == 0)
                        {
                            tr.Write(".");
                        }
                    }

                    db.SaveChanges();
                };
            }
        }
    }
}
