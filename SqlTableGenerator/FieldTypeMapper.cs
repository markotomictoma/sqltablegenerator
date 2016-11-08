using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTableGenerator
{
    public class FieldTypeMapper
    {
        public static String GetMsSqlFieldType(String sfFieldType)
        {
            switch (sfFieldType.ToLower())
            {
                case "int":
                    return "int";
                case "string":
                    return "varchar(max)";
                case "picklist":
                    return "varchar(max)";
                case "multipicklist":
                    return "varchar(max)";
                case "reference":
                    return "varchar(max)";
                case "boolean":
                    return "bit";
                case "currency":
                    return "decimal";
                case "textarea":
                    return "varchar(max)";
                case "double":
                    return "decimal";
                case "percent":
                    return "decimal";
                case "phone":
                    return "varchar(max)";
                case "id":
                    return "varchar(18)";
                case "date":
                    return "date";
                case "datetime":
                    return "datetime";
                case "time":
                    return "timestamp";
                case "url":
                    return "varchar(max)";
                case "email":
                    return "varchar(max)";
                case "address":
                    return "varchar(max)";
                case "base64":
                    return "image";
                case "combobox":
                    return "varchar(max)";
                case "encryptedstring":
                case "datacategorygroupreference":
                case "location":
                    throw new Exception("unmapped field type");
                default:
                    return null;                
            }
        }
    }
}