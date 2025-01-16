using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sql.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MinLength(6), MaxLength(30)]
        public required string Username { get; set; }

        [MinLength(60), MaxLength(60)]
        public required string Password { get; set; }

        [MaxLength(16)]
        public required byte[] Salt { get; set; }
    }
}
