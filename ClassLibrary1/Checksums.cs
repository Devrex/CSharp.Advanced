namespace ClassLibrary1
{
    public static class Checksums
    {
        //Factory method
        public static IChecksum GetCheckSum()
        {
            //read app settings make decision
            return new Md5();
        }
    }

    //Abstract factory
    //ADO.NET System.Data
    //IDbDataReader, IDbConnection, IDbCommand

    //System.Data.SqlClient
    //System.Data.MySql

    //var connection = ...
    ///    IDbCommand command = connection.CreateCommand();
    ///    

    //class MyDatabaseProvider : IDbProvider
    //{
    //    public IDbCommand CreateCommand { }
    //    public IDbConnection CreateConnection() { }
    //}
}
