using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGeneratingExtensions
{

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
    }

    public class BookDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
    }
    

    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource src);
        TSource MapBack(TDestination dest);
    }


    public class BookMapper : IMapper<Book, BookDetailDTO>
    {
        public BookDetailDTO Map(Book src)
        {
            return new BookDetailDTO()
            {
                Id = src.Id,
                Title = src.Title,
                Year = src.Year,
                Price = src.Price,
                AuthorName = src.Author.Name,
                Genre = src.Genre
            };
        }

        public Book MapBack(BookDetailDTO dest)
        {
            return new Book()
            {
                Id = dest.Id,
                Title = dest.Title,
                Year = dest.Year,
                Price = dest.Price,
                Genre = dest.Genre
            };
        }
    }







    public class BookDetailMapper : IMapper<Book, BookDTO>
    {
        public BookDTO Map(Book src)
        {
            return new BookDTO()
            {
                Id = src.Id,
                Title = src.Title,
                AuthorName = src.Author.Name
            };
        }

        public Book MapBack(BookDTO dest)
        {
            return new Book()
            {
                Id = dest.Id,
                Title = dest.Title
            };
        }
    }


    class Program
    {


        BookDetailDTO Convert(Book book)
        {
            return new BookDetailDTO()
            {
                Id = book.Id,
                Title = book.Title,
                Year = book.Year,
                Price = book.Price,
                AuthorName = book.Author.Name,
                Genre = book.Genre
            };
        }

        Book ConvertBack(BookDetailDTO bookDetailDto)
        {
            return new Book()
            {
                Id = bookDetailDto.Id,
                Title = bookDetailDto.Title,
                Year = bookDetailDto.Year,
                Price = bookDetailDto.Price,
                Genre = bookDetailDto.Genre
            };
        }



        static void Main(string[] args)
        {




        }




    }
}
