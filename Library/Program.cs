using System;
using System.Collections.Generic;

// Book class
public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
    public bool Available { get; set; }

    public Book(string isbn, string title, string author, int publicationYear)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
        PublicationYear = publicationYear;
        Available = true;
    }
}

// Borrower class
public class Borrower
{
    public string BorrowerID { get; set; }
    public string Name { get; set; }
    public List<Book> BooksBorrowed { get; set; }

    public Borrower(string borrowerID, string name)
    {
        BorrowerID = borrowerID;
        Name = name;
        BooksBorrowed = new List<Book>();
    }

    public void BorrowBook(Book book)
    {
        if (book != null && book.Available)
        {
            BooksBorrowed.Add(book);
            book.Available = false;
            Console.WriteLine($"{Name} borrowed '{book.Title}'.");
        }
        else
        {
            Console.WriteLine("Book is not available for borrowing.");
        }
    }

    public void ReturnBook(Book book)
    {
        if (BooksBorrowed.Contains(book))
        {
            BooksBorrowed.Remove(book);
            book.Available = true;
            Console.WriteLine($"{Name} returned '{book.Title}'.");
        }
        else
        {
            Console.WriteLine($"{Name} did not borrow '{book.Title}'.");
        }
    }
}

// Library class
public class Library
{
    public string LibraryName { get; set; }
    public string Address { get; set; }
    public List<Book> Books { get; set; }
    public List<Borrower> Borrowers { get; set; }

    public Library(string libraryName, string address)
    {
        LibraryName = libraryName;
        Address = address;
        Books = new List<Book>();
        Borrowers = new List<Borrower>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
        Console.WriteLine($"Added '{book.Title}' to the library.");
    }

    public void RemoveBook(Book book)
    {
        Books.Remove(book);
        Console.WriteLine($"Removed '{book.Title}' from the library.");
    }

    public void RegisterBorrower(Borrower borrower)
    {
        Borrowers.Add(borrower);
        Console.WriteLine($"Registered borrower: {borrower.Name}.");
    }

    public void UnregisterBorrower(Borrower borrower)
    {
        Borrowers.Remove(borrower);
        Console.WriteLine($"Unregistered borrower: {borrower.Name}.");
    }
}

// Employee class
public class Employee
{
    public string EmployeeID { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public Library Library { get; set; }

    public Employee(string employeeID, string name, string position, Library library)
    {
        EmployeeID = employeeID;
        Name = name;
        Position = position;
        Library = library;
    }
}