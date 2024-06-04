using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRUPersonRepository.Models
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        [JsonIgnore]
        public virtual ICollection<Person> Person { get; set; } = new List<Person>();
    }
}
