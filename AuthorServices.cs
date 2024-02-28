using Dapper;
using Npgsql;
namespace ClassTask._1;

public class AuthorServices
{
        private string _conectionString = "Server=localhost;Port=5432;Database=Bookho;User Id=postgres;Password=832111";


        public List<Authors> GetAuthors()
    {
        using var connect = new NpgsqlConnection(_conectionString);
        var result = connect.Query<Authors>("select * from authors").ToList();
        return result;
    }

    public void AddAuthors(Authors author)
    {
        using var connect = new NpgsqlConnection(_conectionString);
        connect.Execute("insert into books (fullname,age) values (@fullname,@age)",author);
    }

     public void UpdateAuthors(Authors author)
    {
        using var connect = new NpgsqlConnection(_conectionString);
        connect.Execute("update authors set fullname=@fullname,age=@age where id = @id",author);
    }

     public void DeleteAuthors(int id)
    {
        using var connect = new NpgsqlConnection(_conectionString);
        connect.Execute(" delete from authorbook as ab where ab.authorid=@id;", new {Id = id});
        connect.Execute("delete from authors where id = @id;", new {Id = id});
    }

}
