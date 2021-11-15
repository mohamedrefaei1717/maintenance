﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;

namespace Association
{
   
    public static class GenLstToDt
    {

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                //table.Columns.Add(prop.Name, prop.PropertyType);
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            //foreach (T item in data)
            //{
            //    for (int i = 0; i < values.Length; i++)
            //    {
            //        values[i] = props[i].GetValue(item);
            //    }
            //    table.Rows.Add(values);
            //}
            return table;
        }





        
    }

}