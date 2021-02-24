namespace ClassLibrary1
{
    public interface IChecksum
    {
        string Calculate(string input);
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
