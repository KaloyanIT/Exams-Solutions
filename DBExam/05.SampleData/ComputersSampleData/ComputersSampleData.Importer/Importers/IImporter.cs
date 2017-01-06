using System;
using System.IO;
using ComputersSampleData.Data;

namespace ComputersSampleData.Importer.Importers
{
    public interface IImporter
    {
        string Message { get; }

        int Order { get; }
        Action<ComputersEntities, TextWriter> Get { get; }
    }
}
