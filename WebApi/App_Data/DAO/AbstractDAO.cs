﻿using System;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace si.nkbm.porfu.DAO
{
    public static class ReflectPropertyInfo
    {
        public static TEntity ReflectType<TEntity>(IDataRecord dr) where TEntity : class, new()
        {
            TEntity instanceToPopulate = new TEntity();

            PropertyInfo[] propertyInfos = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            try
            {
                //for each public property on the original
                foreach (PropertyInfo pi in propertyInfos)
                {
                    DataFieldAttribute[] datafieldAttributeArray = pi.GetCustomAttributes(typeof(DataFieldAttribute), false) as DataFieldAttribute[];

                    //this attribute is marked with AllowMultiple=false
                    if (datafieldAttributeArray != null && datafieldAttributeArray.Length == 1)
                    {
                        DataFieldAttribute dfa = datafieldAttributeArray[0];

                        try
                        {
                            //this will blow up if the datareader does not contain the item keyed dfa.Name
                            object dbValue = dr[dfa.ColumnName];

                            if (dbValue != null)
                            {
                                pi.SetValue(instanceToPopulate, Convert.ChangeType
                                (dbValue, pi.PropertyType, CultureInfo.InvariantCulture), null);
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            System.Diagnostics.Trace.WriteLine("Ne najdem polja " + dfa.ColumnName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }

            return instanceToPopulate;
        }

        public static String GetSearchFields(object Object)
        {

            Type objType = Object.GetType();

            StringBuilder sb = new StringBuilder();

            foreach (PropertyInfo p in objType.GetProperties())
            {
                foreach (DataSearchAttribute a in p.GetCustomAttributes(typeof(DataSearchAttribute), false))
                {
                    if (a.ColumnSearch != null)
                    {

                        sb.Append(String.Format("isnull({0},'')+", a.ColumnSearch));

                    }
                }

            }
            //remove last char wich is +
            string response = sb.ToString().Substring(0, sb.Length - 1);
            response = "(" + response + ")";

            return response;

        }
    }
}