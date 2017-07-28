using Microsoft.Analytics.Interfaces;
using Parquet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquet.Adla.Outputter
{
   class DataSetBuilder
   {
      private List<SchemaElement> _schema;
      private readonly List<Row> _rows = new List<Row>();

      public void Add(IRow row)
      {
         if (_schema == null) BuildSchema(row);

         _rows.Add(ToRow(row));
      }

      private void BuildSchema(IRow row)
      {
         _schema = new List<SchemaElement>();

         foreach(IColumn column in row.Schema)
         {
            var se = new SchemaElement(column.Name, column.Type);
         }
         //kick
      }

      private Row ToRow(IRow row)
      {
         object value = row.Get<object>(0);

         return null;
      }
   }
}
