using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputersSampleData.Data;

namespace ComputersSampleData.Importer.Importers
{
    public class StorageDeviceImporter : IImporter
    {
        private const int NumberOfStorageDevices = 30;
        public string Message
        {
            get { return "Import Storage Devices"; }
        }

        public int Order
        {
            get { return 3; }
        }

        public Action<ComputersEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {
                    var currentId = 1;
                    for (int i = 0; i < NumberOfStorageDevices; i++)
                    {
                        var storageDevice = new StorageDevice()
                        {
                            Vendor = RandomGenerator.GetRandomString(5, 13) + "Vendor",
                            Model = RandomGenerator.GetRandomString(5, 13) + "Model",
                            StorageDeviceTypeId = currentId,
                            Size = $"{RandomGenerator.GetRandomNumber(500, 2000)} GB"
                        };

                        if (i == NumberOfStorageDevices / 4 - 1)
                        {
                            currentId = 2;
                        }
                        db.StorageDevices.Add(storageDevice);
                        tr.Write(".");
                    }

                    db.SaveChanges();
                };

            }
        }

        
    }
}
