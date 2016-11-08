using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlTableGenerator
{
    public interface IDbController
    {
        String DbName { get; set; }
        void CreateDb(Database db);
        void CreateTable(Table table);
        String GetConnectionString();
    }
}
