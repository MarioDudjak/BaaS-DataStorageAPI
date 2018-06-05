using System;
using System.Collections.Generic;
using System.Text;

namespace DataStorage.Repository.DatabaseSettings
{
    public static class MongoDatabaseConfiguration
    {
        #region Properties

        public static string ConnectionString { get; private set; } = "";

        public static string DatabaseName { get; private set; } = "";

        #endregion Properties

        #region Methods
        public static void ChangeConnectionString(string con)
        {
            //Type checking
            ConnectionString = con;
        }

        public static void ChangeDatabase(string databaseName)
        {
            //Type checking
            DatabaseName = databaseName;
        }

        //Encryption and decryption methods...
        #endregion Methods


    }
}
