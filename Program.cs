using System.Text.Json;

class Book
{
    public int PublishingHouseId { get; set; }
    public string Title { get; set; }
    public PublishingHouse PublishingHouse { get; set; }

}


class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
}
class Program
{
    public static async Task Main(string[] args)
    {
        string jsonString = File.ReadAllText("tsconfig1.json");
        
        Console.WriteLine("The file"+jsonString);

        var books = JsonSerializer.Deserialize<List<Book>>(jsonString);
        Console.WriteLine("The names of each publishing house");
        foreach (var book in books)
        {
            Console.WriteLine(book.Title);
        }
    }
}