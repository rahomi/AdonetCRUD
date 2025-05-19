using Microsoft.Data.SqlClient;
using AdoNetCrudDemo.Models;
using Microsoft.Extensions.Configuration;

namespace AdoNetCrudDemo.DAL;

public class BookDAL
{
    private readonly string _connectionString;

    public BookDAL(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public List<Book> GetAll()
    {
        var books = new List<Book>();
        using var con = new SqlConnection(_connectionString);
        var cmd = new SqlCommand("SELECT * FROM Books", con);
        con.Open();
        using var rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            books.Add(new Book
            {
                Id = (int)rdr["Id"],
                Title = rdr["Title"].ToString()!,
                Author = rdr["Author"].ToString()!,
                Price = (decimal)rdr["Price"]
            });
        }
        return books;
    }

    public Book? GetById(int id)
    {
        using var con = new SqlConnection(_connectionString);
        var cmd = new SqlCommand("SELECT * FROM Books WHERE Id = @Id", con);
        cmd.Parameters.AddWithValue("@Id", id);
        con.Open();
        using var rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            return new Book
            {
                Id = (int)rdr["Id"],
                Title = rdr["Title"].ToString()!,
                Author = rdr["Author"].ToString()!,
                Price = (decimal)rdr["Price"]
            };
        }
        return null;
    }

    public void Insert(Book book)
    {
        using var con = new SqlConnection(_connectionString);
        var cmd = new SqlCommand("INSERT INTO Books (Title, Author, Price) VALUES (@Title, @Author, @Price)", con);
        cmd.Parameters.AddWithValue("@Title", book.Title);
        cmd.Parameters.AddWithValue("@Author", book.Author);
        cmd.Parameters.AddWithValue("@Price", book.Price);
        con.Open();
        cmd.ExecuteNonQuery();
    }

    public void Update(Book book)
    {
        using var con = new SqlConnection(_connectionString);
        var cmd = new SqlCommand("UPDATE Books SET Title = @Title, Author = @Author, Price = @Price WHERE Id = @Id", con);
        cmd.Parameters.AddWithValue("@Id", book.Id);
        cmd.Parameters.AddWithValue("@Title", book.Title);
        cmd.Parameters.AddWithValue("@Author", book.Author);
        cmd.Parameters.AddWithValue("@Price", book.Price);
        con.Open();
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var con = new SqlConnection(_connectionString);
        var cmd = new SqlCommand("DELETE FROM Books WHERE Id = @Id", con);
        cmd.Parameters.AddWithValue("@Id", id);
        con.Open();
        cmd.ExecuteNonQuery();
    }
}
