using System.Text.Json;
using System.Text.Json.Serialization;

[Serializable]
class Book
{
    [JsonIgnore]
    public int PublishingHouseId { get; set; }
    [JsonPropertyName("Name")]
    public string Title { get; set; }
    public PublishingHouse PublishingHouse { get; set; }
    public Book(int id, string title, string name, string address)
    {
        PublishingHouseId = id;
        Title = title;
        PublishingHouse = new PublishingHouse(id, name, address);
    }

}

class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
    public PublishingHouse(int id, string name, string address)
    {
        Name = name;
        Id = id;
        Adress = address;
    }
}
class Program
{
    public static async Task Main(string[] args)
    {
        Book book1 = new Book(2, "Algebra 8", "Gymnasium", "Address 2");
        Book book2 = new Book(1, "The diary of neurosurgeon", "Old Lion's Publishing house", "Address 1");
        Book book3 = new Book(2, "Algebra 9", "Gymnasium", "Address 2");
        List<Book> books = new List<Book>();
        books.Add(book1);
        books.Add(book2);
        books.Add(book3);
        using (FileStream fs = new FileStream("result.json", FileMode.OpenOrCreate))
        {
            await JsonSerializer.SerializeAsync<List<Book>>(fs, books);
        }
    }
}