using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTableGenerator
{
    public class Database
    {
        private String name;
        public String Name {
            get
            {
                return name;
            }
        }
        private List<Table> tables;
        public List<Table> Tables {
            get
            {
                return tables;
            }
        }

        public Database(String name)
        {
            this.name = name;
        }

        public Database(String name, List<Table> tables)
        {
            this.name = name;
            this.tables = tables;
        }

        public String GetCreateDDL()
        {
            return $"CREATE DATABASE {name};";
        }
    }
}
