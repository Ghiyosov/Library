

using System.Data.Common;
using ClassTask._1;

var author = new AuthorServices();
var genre = new GenreServices();
var book = new BookServices();


while (true)
{
    System.Console.WriteLine();
    System.Console.WriteLine();
    System.Console.WriteLine("***************************************************************************");
    System.Console.WriteLine();
    System.Console.WriteLine("b - Log in to the books");
    System.Console.WriteLine("a - Log in to the authors");
    System.Console.WriteLine("g - Log in to the genres");
    string command = Console.ReadLine();
    command = command.ToLower();
    if (command == "b")
    {
        while (true)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("g - get books");
            System.Console.WriteLine("a - add book");
            System.Console.WriteLine("u - update book");
            System.Console.WriteLine("d - delete book");
            System.Console.WriteLine("ba - add author for book");
            System.Console.WriteLine("bg - add genre for book");
            System.Console.WriteLine("info - info about book");
            System.Console.WriteLine("x - exite");
            command = Console.ReadLine();
            command = command.ToLower();
            if (command == "g")
            {
                foreach (var item in book.GetBooks())
                {
                    System.Console.WriteLine($"{item.Id} {item.Title}");
                    System.Console.WriteLine($"{item.Description}");
                    System.Console.WriteLine("--------------------------------------------------------------------");
                }
            }
            else if (command == "a")
            {
                System.Console.Write("Title : ");
                string tl = Console.ReadLine();
                System.Console.Write("Description : ");
                string ds = Console.ReadLine();
                var newBook = new Books();
                newBook.Title = tl;
                newBook.Description = ds;
                book.AddBooks(newBook);
            }
            else if (command == "u")
            {
                System.Console.Write("Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Title : ");
                string tl = Console.ReadLine();
                System.Console.Write("Description : ");
                string ds = Console.ReadLine();
                var newBook = new Books();
                newBook.Id = id;
                newBook.Title = tl;
                newBook.Description = ds;
                book.UpdateBooks(newBook);
            }
            else if (command == "d")
            {
                System.Console.WriteLine("Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                book.DeleteTBooks(id);
            }
            else if (command == "ba")
            {
                System.Console.Write("Book id : ");
                int bid = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Author id : ");
                int aid = Convert.ToInt32(Console.ReadLine());
                var ba = new AuthorBook();
                ba.AuthorId = aid;
                ba.BookId = bid;
                book.AddBookAuthor(ba);
            }
            else if (command == "bg")
            {
                System.Console.Write("Book id : ");
                int bid = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Genre id : ");
                int gid = Convert.ToInt32(Console.ReadLine());
                var bg = new GenreBook();
                bg.GenreId = gid;
                bg.BookId = bid;
                book.AddBookGenre(bg);
            }
            else if (command == "info")
            {
                while (true)
                {
                    System.Console.WriteLine("g - genre");
                    System.Console.WriteLine("a - author");
                    System.Console.WriteLine("x - exite");
                    command = Console.ReadLine();
                    command = command.ToLower();
                    if (command == "g")
                    {
                        System.Console.Write("book's id : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        foreach (var item in book.GetBookGenre(id))
                        {
                            System.Console.Write($"{item}, ");
                        }
                        System.Console.WriteLine();
                    }
                    else if (command == "a")
                    {
                        System.Console.Write("book's id : ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        foreach (var item in book.GetBookAuthor(id))
                        {
                            System.Console.Write($"{item}, ");
                        }
                        System.Console.WriteLine();
                    }
                    else if (command=="x") break;
                }
            }
            else if (command == "x") break;
        }

    }
    if (command == "a")
    {
        while (true)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("g - get authors");
            System.Console.WriteLine("a - add author");
            System.Console.WriteLine("u - update author");
            System.Console.WriteLine("d - delete author");
            System.Console.WriteLine("x - exite");
            command = Console.ReadLine();
            command = command.ToLower();
            if (command == "g")
            {
                foreach (var item in author.GetAuthors())
                {
                    System.Console.WriteLine($"{item.Id}. {item.FullName} - {item.Age}");
                    System.Console.WriteLine("--------------------------------------------------------------------");
                }
            }
            else if (command == "a")
            {
                System.Console.Write("fullname : ");
                string tl = Console.ReadLine();
                System.Console.Write("Age : ");
                int ds = Convert.ToInt32(Console.ReadLine());
                var newAuthor = new Authors();
                newAuthor.FullName = tl;
                newAuthor.Age = ds;
                author.AddAuthors(newAuthor);
            }
            else if (command == "u")
            {
                System.Console.Write("Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("fullname : ");
                string tl = Console.ReadLine();
                System.Console.Write("Age : ");
                int ds = Convert.ToInt32(Console.ReadLine());
                var newAuthor = new Authors();
                newAuthor.Id = id;
                newAuthor.FullName = tl;
                newAuthor.Age = ds;
                author.UpdateAuthors(newAuthor);
            }
            else if (command == "d")
            {
                System.Console.WriteLine("Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                author.DeleteAuthors(id);
            }
            else if (command == "x") break;
        }

    }
    if (command == "g")
    {
        while (true)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("g - get genres");
            System.Console.WriteLine("a - add genre");
            System.Console.WriteLine("u - update genre");
            System.Console.WriteLine("d - delete genre");
            System.Console.WriteLine("x - exite");
            command = Console.ReadLine();
            command = command.ToLower();
            if (command == "g")
            {
                foreach (var item in genre.GetGenre())
                {
                    System.Console.WriteLine($"{item.Id}. {item.Name}");
                    System.Console.WriteLine("--------------------------------------------------------------------");
                }
            }
            else if (command == "a")
            {
                System.Console.Write("Name : ");
                string tl = Console.ReadLine();
                var newGenre = new Genre();
                newGenre.Name = tl;
                genre.AddGenre(newGenre);
            }
            else if (command == "u")
            {
                System.Console.Write("Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                System.Console.Write("Name : ");
                string tl = Console.ReadLine();
                var newGenre = new Genre();
                newGenre.Id = id;
                newGenre.Name = tl;
                genre.UpdateGenre(newGenre);
            }
            else if (command == "d")
            {
                System.Console.WriteLine("Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                genre.DeleteGenre(id);
            }
            else if (command == "x") break;
        }

    }
}