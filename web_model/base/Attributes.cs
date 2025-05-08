using System;

namespace web_model.Base
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DBColumnNameAttribute : Attribute
    {
        #region Properties

        private string name;
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public DBColumnNameAttribute(string name)
        {
            Name = name;
        }

        #endregion
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NotDBColumnAttribute : Attribute
    {
        #region Properties

        private bool isDbColumn;
        public bool IsDbColumn
        {
            get { return isDbColumn; }
            private set { isDbColumn = value; }
        }

        #endregion

        #region Constructors

        public NotDBColumnAttribute()
            : this(false)
        {
        }

        public NotDBColumnAttribute(bool isDbColumn)
        {
            IsDbColumn = isDbColumn;
        }

        #endregion
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DBColumnNamePrimaryKey : Attribute
    {
        #region Properties

        private string name;
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public DBColumnNamePrimaryKey(string name)
        {
            Name = name;
        }

        #endregion
    }

    public delegate object Converter(object from);

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DBColumnConverterAttribute : Attribute
    {
        #region Properties

        private string converter;
        public string Converter
        {
            get { return converter; }
        }

        private Type typeDB;
        public Type TypeDB
        {
            get { return typeDB; }
            set { typeDB = value; }
        }

        #endregion

        #region Constructors

        public DBColumnConverterAttribute(string converter, Type typeDB)
        {
            this.converter = converter;
            this.typeDB = typeDB;
        }

        #endregion
    }

}
