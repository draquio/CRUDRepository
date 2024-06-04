using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRUPersonRepository.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public int Age { set; get; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public int RolId {  get; set; }
        [JsonIgnore]
        public virtual Rol? IdRolNavigation { set; get; }

    }
}
