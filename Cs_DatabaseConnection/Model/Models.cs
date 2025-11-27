using System.ComponentModel.DataAnnotations;

namespace Cs_DatabaseConnection.Model;

public class Book
{
    public int Id { get; set; }
    [MaxLength(100)]
    public required string Title { get; set; }
    [MaxLength(100)]
    public required string Author { get; set; }
    public required int AuthorId { get; set; }
}

public class Author
{
    public int Id { get; set; }
    [MaxLength(100)]
    public required string FirstName { get; set; }
    [MaxLength(100)]
    public required string LastName { get; set; }
}