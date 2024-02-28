using Dapper;
using Npgsql;
namespace ClassTask._1;

public class GenreServices
{
        private string _conectionString = "Server=localhost;Port=5432;Database=Bookho;User Id=postgres;Password=832111";


        public List<Genre> GetGenre()
    {
        using var connect = new NpgsqlConnection(_conectionString);
        var result = connect.Query<Genre>("select * from genre").ToList();
        return result;
    }

    public void AddGenre(Genre genre)
    {
        using var connect = new NpgsqlConnection(_conectionString);
        connect.Execute("insert into genre (name) values (@name)",genre);
    }

     public void UpdateGenre(Genre genre)
    {
        using var connect = new NpgsqlConnection(_conectionString);
        connect.Execute("update authors set name=@name where id = @id",genre);
    }

     public void DeleteGenre(int id)
    {
        using var connect = new NpgsqlConnection(_conectionString);
        connect.Execute("delete from genrebook as gb where gb.genreid=@id;", new {Id = id});
        connect.Execute("delete from authors where id = @id; ", new {Id = id});
    }
}
