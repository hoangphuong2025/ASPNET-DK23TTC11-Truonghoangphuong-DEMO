using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using NLog;
using web_model.Base;


namespace web_controls.Base
{
    public class BaseController<TInfo>
        where TInfo : class, new()
    {
        #region Private members

        private class DBConverter
        {
            #region Properties
            private bool setPrimaryKey;
            public bool SetPrimaryKey
            {
                get { return setPrimaryKey; }
            }

            private bool isPrimaryKey;
            public bool IsPrimaryKey
            {
                get { return isPrimaryKey; }
            }

            private PropertyInfo property;
            public PropertyInfo Property
            {
                get { return property; }
            }

            private DBColumnConverterAttribute converter;
            public DBColumnConverterAttribute Converter
            {
                get { return converter; }
            }

            private string columnName;
            public string ColumnName
            {
                get { return columnName; }
            }
            #endregion

            #region Consts
            private static readonly Type objectType = typeof(TInfo);

            private const BindingFlags BindingAttributes = BindingFlags.NonPublic
                | BindingFlags.Public
                | BindingFlags.Instance;
            #endregion
            
            /// <summary>
            /// 
            /// </summary>
            /// <remarks>
            /// Parameters order as in asm MOV command
            /// </remarks>
            /// <param name="obj"></param>
            /// <param name="row"></param>
            public void Assign(TInfo obj, SqlDataReader row)
            {
                object columnValue = row[columnName];
                if (converter != null)
                {
                    MethodInfo converterMethod = objectType.GetMethod(converter.Converter, BindingAttributes, null, new Type[] { columnValue.GetType() }, null);
                    if (converterMethod != null)
                        columnValue = converterMethod.Invoke(obj, new object[] { columnValue });
                }

                 property.SetValue(obj, columnValue==DBNull.Value?null:columnValue, null);
                
            }


            public void Assign(ref List<SqlParameter> parms, TInfo obj)
            {
                object propertyValue = property.GetValue(obj, null);

                if (!setPrimaryKey)
                {
                    if (IsPrimaryKey || columnName.Equals("Id")) return;
                }
                if (converter != null)
                {
                    MethodInfo converterMethod = objectType.GetMethod(converter.Converter, BindingAttributes, Type.DefaultBinder, new Type[] { property.PropertyType }, null);
                    if (converterMethod != null)
                        propertyValue = converterMethod.Invoke(obj, new object[] { propertyValue });
                }
                parms.Add(new SqlParameter("@" + columnName, propertyValue == null ? DBNull.Value : propertyValue));
                
            }
            #endregion

            #region Constructors
            public DBConverter(PropertyInfo propInfo, DBColumnConverterAttribute converter,
                    string columnName, bool setPrimaryKey, bool isPrimaryKey)
            {
                this.property = propInfo;
                this.converter = converter;
                this.columnName = columnName;
                this.setPrimaryKey = setPrimaryKey;
                this.isPrimaryKey = isPrimaryKey;
            }
            #endregion
        }

        private static readonly Type objectType = typeof(TInfo);
        protected internal string connectionString;

        public static Logger _logger = LogManager.GetCurrentClassLogger();
        #region Constructors

        internal BaseController(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion


        public TInfo Row2Object(SqlDataReader reader)
        {
            if (reader == null) throw new ArgumentNullException("reader");
            TInfo obj = new TInfo();

            if (reader.Read())
            {
                Dictionary<string, DBConverter> convertDict = PreparePropertiesDictionary(objectType, false, true);
                foreach (String columnName in convertDict.Keys)
                {
                    convertDict[columnName].Assign(obj, reader);
                    continue;
                }
            }
            return obj;
        }

        public void Object2Row(TInfo obj, ref List<SqlParameter> parms, bool setPK)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            

            
            Dictionary<string, DBConverter> convertDict = PreparePropertiesDictionary(objectType, true, setPK);
            foreach (String columnName in convertDict.Keys)
                convertDict[columnName].Assign(ref parms, obj);
        }

        public List<TInfo> Rows2Objects(SqlDataReader reader)
        {
            if (reader == null) throw new ArgumentNullException("reader");
            if (!reader.HasRows) return new List<TInfo>();

            List<TInfo> objects = new List<TInfo>();
            while (reader.Read())
            {

                    TInfo obj = new TInfo();
                    Dictionary<string, DBConverter> convertDict = PreparePropertiesDictionary(objectType, true, true);
                    foreach (String columnName in convertDict.Keys)
                    {
                           //_logger.Info("columnName:" + columnName);
                            convertDict[columnName].Assign(obj, reader);
                     }
                    objects.Add(obj);
            }
            return objects;
        }

        private Dictionary<string, DBConverter> PreparePropertiesDictionary(Type infoType, bool assignFromObject, bool setPrimaryKey)
        {
            Dictionary<string, DBConverter> convertDict = new Dictionary<string, DBConverter>();
            PropertyInfo[] properties = infoType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo propertyInfo in properties)
            {
                try
                {
                if (GetAttribute<NotDBColumnAttribute>(propertyInfo) != null)
                    continue;
                DBColumnNameAttribute dbColumnName = GetAttribute<DBColumnNameAttribute>(propertyInfo);
                string columnName = dbColumnName == null ? propertyInfo.Name : dbColumnName.Name;

                DBColumnConverterAttribute dbColumnConverter = GetAttribute<DBColumnConverterAttribute>(propertyInfo);
                Type propertyType = dbColumnConverter == null ? propertyInfo.PropertyType : dbColumnConverter.TypeDB;

                bool isPrimaryKey = false;
                if (GetAttribute<DBColumnNamePrimaryKey>(propertyInfo) != null) isPrimaryKey = true;


                convertDict[columnName] = new DBConverter(propertyInfo, dbColumnConverter,
                                                          columnName, setPrimaryKey, isPrimaryKey);
                }
                catch(Exception ex)
                {

                    continue;
                }
            }
            return convertDict;
        }

        private T GetAttribute<T>(PropertyInfo property)
        {
            if (property == null) throw new ArgumentNullException("property");

            object[] attributes = property.GetCustomAttributes(typeof(T), false);
            return (T)(attributes == null || attributes.Length == 0 ? null : attributes[0]);
        }

        
    }
}
