using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTableGenerator
{
    class Program
    {
        static void Main(string[] args)
        {            
            List<Table> tables = new List<Table>()
            {
                new Table("t1"),
                new Table("t2")
            };

            tables[0].columns = new List<Column>()
            {
                new Column { Name = "c1", Type = "int" },
                new Column { Name = "c2", Type = "varchar(max)" }
            };

            tables[1].columns = new List<Column>()
            {
                new Column { Name = "c3", Type = "int" },
                new Column { Name = "c4", Type = "varchar(max)" }
            };
            Random r = new Random();
            Database db = new Database("test" + r.Next(), tables);
            DbController dbCtrl = new DbController();
            dbCtrl.CreateDb(db);
            foreach(Table t in db.Tables)
            {
                dbCtrl.CreateTable(t);
            }
        }    
    }
}
