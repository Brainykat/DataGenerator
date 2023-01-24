using System.ComponentModel.DataAnnotations;

namespace DataGenerator.Models
{
  public class Person
  {
    public Person(Guid id, string name,
      long idnumber, string email, string phone, DateTime dOB, string location,
      Gender gender, string occupation, string educationLevel, string pIN, Guid bankId, 
      string secPhone, string secEmail)
    {
      Id = id;
      Name = name;
      Idnumber = idnumber;
      Email = email;
      Phone = phone;
      DOB = dOB;
      Location = location;
      Gender = gender;
      Occupation = occupation;
      EducationLevel = educationLevel;
      PIN = pIN;
      BankId = bankId;
      SecPhone = secPhone;
      SecEmail = secEmail;
      DateCreated = DateTime.UtcNow;
    }
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public long Idnumber { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DOB { get; set; }
    public string Location { get; set; }
    public Gender  Gender { get; set; }
    public string Occupation { get; set; }
    public string EducationLevel { get; set; }
    public string PIN { get; set; }
    public Guid BankId { get; set; }
    public string SecPhone { get; set; }
    public string SecEmail { get; set; }
    public DateTime DateCreated { get; set; }
    
  }
  public enum Gender
  {
    Male,Female,Other
  }
}
