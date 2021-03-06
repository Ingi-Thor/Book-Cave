using System.Collections.Generic;
using BookCave.Data;
using BookCave.Models.ViewModels;
using System.Linq;
using BookCave.Data.EntityModels;

namespace BookCave.Repositories
{
    public class AspNetUsersRepo
    {
        private DataContext _db;

        public AspNetUsersRepo()
        {
            _db = new DataContext();
        }

        public List<AspNetUserViewModel> GetList()
        {
            var users = (
                    from U in _db.AspNetUsers
                    select new AspNetUserViewModel
                    {
                        Image = U.Image,
                        Name = U.Name,
                        FavoriteBook =
                            (from Up in _db.Books
                            where U.BooksId == Up.Id          
                            select new BookViewModel
                            {
                                Id = Up.Id,
                                Title = Up.Title,
                                Authors =  
                                    (from BoAu in _db.BooksAuthors
                                    join Au in _db.Authors on BoAu.AuthorId equals Au.Id
                                    where BoAu.BookId == Up.Id
                                    select new AuthorViewModel
                                    {
                                        Id = Au.Id,
                                        Name = Au.Name
                                    }).ToList(),
                                Genre = 
                                    (from BoGe in _db.BookGenres
                                    join Ge in _db.Genres on BoGe.GenreId equals Ge.Id
                                    where BoGe.BookId == Up.Id
                                    select new GenreViewModel
                                    {
                                        Id = Ge.Id,
                                        Name = Ge.Name
                                    }).ToList(),
                                Image = Up.Image,
                                Price = Up.Price,
                                ISBN10 = Up.ISBN10,
                                ISBN13 = Up.ISBN13 }).FirstOrDefault(),
                        FavoriteAuthor = 
                            (from Au in _db.Authors
                            where U.AuthorsId == Au.Id
                            select new AuthorViewModel
                            {
                                Id = Au.Id,
                                Name = Au.Name
                            }).FirstOrDefault(),
                        RegistrationDate = U.RegistrationDate,
                        LastLoginDate = U.LastLoggedInDate,
                        BookSuggestionsEmail = U.BookSuggestionsEmail,
                        TotalReports = U.TotalReports,
                        TotalBans = U.TotalBans
                        }).ToList();
            return users;
        }

        public void Write(AspNetUsers aspNetUsers)
        {
            _db.Add(aspNetUsers);
            _db.SaveChanges();
        }

        public void ChangeEmail(string Id, string NewEmail)
        {
            var user =
                from Us in _db.AspNetUsers
                where Us.Id == Id
                select Us;

                foreach(AspNetUsers usr in user)
                {
                    usr.Email = NewEmail.ToLower();
                    usr.NormalizedEmail = NewEmail.ToUpper();
                    usr.NormalizedUserName = NewEmail.ToUpper();
                    usr.UserName = NewEmail.ToLower();
                }

                _db.SaveChanges();
        }

        public void ChangeImage(string userId, string newImage)
        {
            var image =
                from Us in _db.AspNetUsers
                where Us.Id == userId
                select Us;

                foreach(AspNetUsers usr in image)
                {
                    usr.Image = newImage;
                }
                _db.SaveChanges();
        }

        public void ChangeName(string userId, string newName)
        {
            var name =
            from Us in _db.AspNetUsers
                where Us.Id == userId
                select Us;

                foreach(AspNetUsers usr in name)
                {
                    usr.Name = newName;
                }
                _db.SaveChanges();
        }

        public void ChangeBookSuggestionEmail(string userId, bool newEmailSetting)
        {
            var email =
                from Us in _db.AspNetUsers
                where Us.Id == userId
                select Us;

                foreach(AspNetUsers usr in email)
                {
                    usr.BookSuggestionsEmail = newEmailSetting;
                }
                _db.SaveChanges();
        }

        public void ChangeFavoriteAuthor(string userId, int newAuthorId)
        {
            var author =
                from Us in _db.AspNetUsers
                where Us.Id == userId
                select Us;

                foreach(AspNetUsers usr in author)
                {
                    usr.AuthorsId = newAuthorId;
                }

            _db.SaveChanges();
        }

        public void ChangeFavoriteBook(string userId, int newBookId)
        {
            var author =
                from Us in _db.AspNetUsers
                where Us.Id == userId
                select Us;

                foreach(AspNetUsers usr in author)
                {
                    usr.AuthorsId = newBookId;
                }

            _db.SaveChanges();
        }
        
        
        public AspNetUserViewModel GetById(string userId)
        {
            var user = (from U in _db.AspNetUsers
                        where U.Id == userId
                        select new AspNetUserViewModel
                        {
                            Image = U.Image,
                            Name = U.Name,
                            FavoriteBook = 
                                (from Up in _db.Books
                                where U.BooksId == Up.Id          
                                select new BookViewModel
                                {
                                    Id = Up.Id,
                                    Title = Up.Title,
                                    Authors =  
                                        (from Bok in _db.Books
                                        join BoAu in _db.BooksAuthors on Bok.Id equals BoAu.Id
                                        join Au in _db.Authors on BoAu.AuthorId equals Au.Id
                                        select new AuthorViewModel
                                        {
                                            Id = Au.Id,
                                            Name = Au.Name
                                        }).ToList(),
                                    Genre = 
                                        (from Bk in _db.Books
                                        join BoGe in _db.BookGenres on Bk.Id equals BoGe.BookId
                                        join Ge in _db.Genres on BoGe.GenreId equals Ge.Id
                                        select new GenreViewModel
                                        {
                                            Id = Ge.Id,
                                            Name = Ge.Name
                                        }).ToList(),
                                    Image = Up.Image,
                                    Price = Up.Price,
                                    ISBN10 = Up.ISBN10,
                                    ISBN13 = Up.ISBN13 }).FirstOrDefault(),
                            FavoriteAuthor = (from Us in _db.AspNetUsers
                                    join Au in _db.Authors on Us.AuthorsId equals Au.Id
                                    select new AuthorViewModel
                                    {
                                        Id = Au.Id,
                                        Name = Au.Name
                                    }).FirstOrDefault(),
                            RegistrationDate = U.RegistrationDate,
                            LastLoginDate = U.LastLoggedInDate,
                            BookSuggestionsEmail = U.BookSuggestionsEmail,
                            TotalReports = U.TotalReports,
                            TotalBans = U.TotalBans
                        }
                        ).SingleOrDefault();
                        return user;
        }
    }
}