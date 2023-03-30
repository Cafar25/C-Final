using C__Final.AuthorName;
using C__Final.Books;
using C__Final.Enums;
using C__Final.Helper;
using C__Final.Managers;

namespace C__Final
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
              - Author CRUD

                AuthorStructure :
                                    Id             number (++)
                                    Name      text
                                    Surname text
               =========================
                - CREATE    (Add)
                - READ        (GetAll | FindByName | GetById)
                - UPDATE   (Edit)
                - DELETE    (Remove)

             - Book CRUD
               
                   BookStructure :
                                    Id                 number (++)
                                    Name          text
                                    AuthorId      number
                                    Genre          enum
                                    PageCount number
                                    Price            number(decimal)
               =========================
                - CREATE   (Add)
                - READ     (GetAll | FindByName | GetById)
                - UPDATE   (Edit)
                - DELETE   (Remove)
             */
            AuthorManager authormanager = new AuthorManager();
            BookManager bookmanager = new BookManager();
            Author author;
            int Id;
           
         
            MenuTypes sm;
           


          l1:
            Console.WriteLine("Choose one of them");
            sm = EnumHelper.ReadEnum<MenuTypes>("Menu:");
            switch (sm)
            {
                case MenuTypes.AuthorAdd:
                    var Author = new Author();
                    Author.Name = PrimitiveHelper.Readstring("Author Name:");
                    Author.Surname = PrimitiveHelper.Readstring("Author Surname:");
                    authormanager.Add(Author);
                    Console.Clear();
                    goto case MenuTypes.BookAdd;

                case MenuTypes.AuthorEdit:
                    Console.Clear();
                    Console.WriteLine("What you want to edit?");
                    foreach(var item in authormanager)
                    {
                        Console.WriteLine(item);
                    }
                    Id = PrimitiveHelper.ReadInt("Author Id:");

                    if(Id == 0)
                    { 
                        goto l1;
                    }
                    Author = authormanager.GetbyID(Id);

                    if (Author == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Not found");
                        goto case MenuTypes.AuthorEdit;
                    }

                    Author.Name = PrimitiveHelper.Readstring("Author Name:");
                    Author.Surname = PrimitiveHelper.Readstring("Author Surname:");
                    goto case MenuTypes.AuthorGetAll;
                    break;

                case MenuTypes.AuthorRemove:
                    Console.Clear();
                    Console.WriteLine("What you want to remove");
                    foreach(var item in authormanager)
                    {
                        Console.WriteLine(item);
                    }
                    Id = PrimitiveHelper.ReadInt("Author Id:");
                    Author = authormanager.GetbyID(Id);
                    if(Author == null)
                    {
                        Console.Clear();
                        goto case MenuTypes.AuthorRemove;
                    }
                    authormanager.Remove(Author);
                    Console.Clear();
                    goto case MenuTypes.AuthorGetAll;
                    break;

                case MenuTypes.AuthorGetAll:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("=============== Authors ==============");
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (var item in authormanager)          
                    {                                            
                        Console.WriteLine(item);                 
                    }
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("=============== ======= ============");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto l1;
                    break;

                case MenuTypes.AuthorGetById:
                    Id = PrimitiveHelper.ReadInt("Author Id");
                    Author = authormanager.GetbyID(Id);
                    if(Id == 0) 
                    {
                        Console.Clear();
                        goto l1;
                    }
                    Console.WriteLine("Write Author Id want you want");
                    if (Author == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Not found");
                        goto case MenuTypes.AuthorGetById;
                    }

                    Console.WriteLine(Author);
                    break;
                case MenuTypes.AuthorFindByName:
                    string name = PrimitiveHelper.Readstring("Write minimum 3 letter:");
                    var data = authormanager.FindByName(name);

                    if(data.Length == 0) 
                    {
                        Console.WriteLine("Not found");

                        goto l1;
                    }
                    foreach(var item in data)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case MenuTypes.BookAdd:
                    var Book = new Book();
                    Book.Name = PrimitiveHelper.Readstring("Book Name:");
                   
                    Book.AuthorId = Author.Id;
                    bookmanager.Add(Book);
                    Console.Clear();
                    goto l1;


                case MenuTypes.BookEdit: 
                    break;
                case MenuTypes.BookRemove: 
                    break;
                case MenuTypes.BookGetAll: 
                    break;
                case MenuTypes.BookGetById: 
                    break;
                case MenuTypes.BookFindByName: 
                    break;
                case MenuTypes.Exit: 
                    break;

            }
        }
    }
}