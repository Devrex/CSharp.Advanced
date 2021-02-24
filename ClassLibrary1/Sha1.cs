namespace ClassLibrary1
{
    public class Sha1 : IChecksum
    {
        public string Calculate(string input)
        {
            return input.ToLower();
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
