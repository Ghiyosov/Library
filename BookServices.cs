using Dapper;
using Npgsql;
namespace ClassTask._1;

public class BookServices
{
    private string _conectionString = "Server=localhost;Port=5432;Database=Bookho;User Id=postgres;Password=832111";


    public List<Books> GetBooks()
    {
        using var connect = new NpgsqlConnection(_conectionString);
        var result = connect.Query<Books>("select * from books").ToList();
        return result;
    }

    public void AddBooks(Books book)
    {
        using var connect = new NpgsqlConnection(_conectionString);
        connect.Execute("insert into books (title,description) values (@title,@author,@description)", book);
    }

    public void UpdateBooks(Books book)
    {
        using var connect = new NpgsqlConnection(_conectionString);
        connect.Execute("update books set title=@title,description=@description where id = @id", book);
    }

    public void DeleteTBooks(int id)
    {
        using var connect = new NpgsqlConnection(_conectionString);
        connect.Execute(
            "delete from books where id = @id; dalete from authorbook where bookid=books.id; dalete from genrebook where bookid=books.id;", new { Id = id }
            );
    }

    public void AddBookAuthor(AuthorBook authorBook)
    {
        using var connect = new NpgsqlConnection(_conectionString);
        connect.Execute("insert into authorbook(authorid,bookid) values(@authorid,bookid)",authorBook);
    }
    public void AddBookGenre(GenreBook genreBook)
    {
        using var connect = new NpgsqlConnection(_conectionString);
        connect.Execute("insert into genrebook(genreid,bookid) values(@genreid,bookid)",genreBook);
    }

    public List<string> GetBookGenre(int id)
    {
        using var connect = new NpgsqlConnection(_conectionString);
        var result = connect.Query<string>("select g.name from genrebook as gb join genre as g on gb.genreid=g.id join books as b on gb.bookid=b.id where b.id=@id", new{Id = id}).ToList();
        return result;
    }
    public List<string> GetBookAuthor(int id)
    {
        using var connect = new NpgsqlConnection(_conectionString);
        var result = connect.Query<string>("select a.fullname from authorbook as ab join authors as a on ab.authorid=a.id join books as b on ab.bookid=b.id where b.id=@id", new{Id = id}).ToList();
        return result;
    }
}
