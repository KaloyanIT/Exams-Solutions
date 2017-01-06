using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputersSampleData.Data;

namespace ComputersSampleData.Importer.Importers
{
    public class ComputersImporter : IImporter
    {
        private const int NumberOfComputers = 50;
        public string Message
        {
            get { return "Import Computers"; }
        }

        public int Order
        {
            get { return 4; }
        }

        public Action<ComputersEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var typeId = 1;
                    var cpuIds = db.CPUs.Select(x => x.Id).ToList();
                    var gpus = db.GPUs.ToList();
                    var storageDevices = db.StorageDevices.ToList();

                    for (int i = 0; i < NumberOfComputers; i++)
                    {
                        //var gpuId = gpuIds[RandomGenerator.GetRandomNumber(0, gpuIds.Count - 1)];
                        //var storageDeviceId = gpuIds[RandomGenerator.GetRandomNumber(0, storageDevicesIds.Count - 1)];
                        var cpuId = cpuIds[RandomGenerator.GetRandomNumber(0, cpuIds.Count - 1)];
                        var computer = new Computer()
                        {
                            ComputerTypeId = typeId,
                            Vendor = RandomGenerator.GetRandomString(5, 13) + "Vendor",
                            Model = RandomGenerator.GetRandomString(5, 13) + "Model",
                            CPUId = cpuId,
                            Memory = $"{RandomGenerator.GetRandomNumber(2, 64)} GB"
                        };
                        var numbersOfComponentsToAdd = RandomGenerator.GetRandomNumber(1, 3);
                        for (int j = 0; j < numbersOfComponentsToAdd; j++)
                        {
                            computer.GPUs.Add(gpus[RandomGenerator.GetRandomNumber(0, gpus.Count - 1)]);
                            computer.StorageDevices.Add(storageDevices[RandomGenerator.GetRandomNumber(0, storageDevices.Count - 1)]);
                        }

                        if (i == NumberOfComputers / 3)
                        {
                            typeId = 2;
                        }
                       
                        if (i == NumberOfComputers - NumberOfComputers / 3)
                        {
                            typeId = 3;
                        }
                       
                        tr.Write(".");
                        db.Computers.Add(computer);
                    }

                    db.SaveChanges();
                };
            }
        }

       
    }
}
