using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTableGenerator
{
    public class Table
    {
        private String name;
        public String Name {
            get
            {
                return name;
            }
            set
            {
                name = ReservedWordsChecker.CheckTableName(value);
            }
        }
        public List<Column> columns { get; set; }

        public Table(String name)
        {
            this.Name = name;
            this.columns = new List<Column>();
        }

        public Table(String name, List<Column> columns)
        {
            this.Name = name;
            this.columns = columns;
        }

        public String GetCreateDDL()
        {
            if(columns == null || columns.Count == 0)
            {
                throw new Exception("Must specify at least one column");
            }
            String ddlCmd = $"CREATE TABLE {Name}(";
            foreach (Column c in columns)
            {
                string primaryKey = string.Empty;
                if(c.Name == "Id")
                {
                    primaryKey = " PRIMARY KEY";
                }
                ddlCmd += $"{c.Name} {c.Type} {primaryKey},";
            }
            return ddlCmd.Remove(ddlCmd.Length - 1, 1) + ")";
        }
    }
}
