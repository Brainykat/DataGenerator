using DataGenerator.Data;
using DataGenerator.Models;
using System;

namespace DataGenerator.Services
{
  public interface IPeopleService
  {
    Task GenerateData();
  }

  public class PeopleService : IPeopleService
  {
    private readonly ApplicationDbContext context;
    Random rand = new Random((int)DateTime.Now.Ticks);
    public PeopleService(ApplicationDbContext context)
    {
      this.context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task GenerateData()
    {
      List<Person> people = new List<Person>();
      RandomName nameGen = new RandomName(rand);
      for (int i = 0; i < 24000; i++)
      {
        string name = i % 2 == 0 ? nameGen.Generate(Sex.Female, 1, true) : nameGen.Generate(Sex.Male, 1);
        Gender g = i % 2 == 0 ? Gender.Female : Gender.Male;
        var p = new Person(Guid.NewGuid(), name, rand.NextInt64(), $"{GenerateString(5)}@{GenerateString(4)}.com",
         $"+{rand.Next(100, 999)} {rand.Next(100000, 9999999)}", DateTime.Now, GenerateString(10), g, GenerateString(12), GenerateString(6),
         $"A{rand.Next(100000, 9999999)}X", Guid.NewGuid(), $"+ {rand.Next(100000, 9999999)}",
         $"{GenerateString(6)}@{GenerateString(6)}.net");
        people.Add(p);
      }
      context.People.AddRange(people);
      await context.SaveChangesAsync();
    }

    private static string GenerateString(int len)
    {
      Random r = new Random();
      string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
      string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
      string Name = "";
      Name += consonants[r.Next(consonants.Length)].ToUpper();
      Name += vowels[r.Next(vowels.Length)];
      int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
      while (b < len)
      {
        Name += consonants[r.Next(consonants.Length)];
        b++;
        Name += vowels[r.Next(vowels.Length)];
        b++;
      }

      return Name;


    }
  }
}
