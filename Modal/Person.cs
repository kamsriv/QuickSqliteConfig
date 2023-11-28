namespace Quickapp_del.Modal
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table(name: "Person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string EmailId { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public MailingAddress Address { get; set; }
    }

    [Table("Address")]
    public class MailingAddress
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
