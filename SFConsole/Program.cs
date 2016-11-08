using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SF;
using SqlTableGenerator;

namespace SFConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SfComunicator comm = new SfComunicator();
            comm.Login();
            SF.SF.DescribeSObjectResult[] objs = comm.GetAllObjects();
            List<Table> tables = new List<Table>();
            foreach (SF.SF.DescribeSObjectResult dsor in objs)
            {
                Table t = new Table(dsor.name);
                foreach(SF.SF.Field f in dsor.fields)
                {
                    t.columns.Add(new Column { Name = f.name, Type = FieldTypeMapper.GetMsSqlFieldType(f.type.ToString()) });
                }
                tables.Add(t);
            }
            Database db = new Database("SF" + new Random().Next(), tables);
            DbController dbCtrl = new DbController();
            dbCtrl.CreateDb(db);
            foreach (Table t in db.Tables)
            {
                dbCtrl.CreateTable(t);
            }
            Console.WriteLine("fdsafa");
            Console.ReadLine();
        }
    }
}
