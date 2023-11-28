using System.ComponentModel.DataAnnotations;

namespace Backend_WebApi.Core.Entities
{
    public abstract class SuperEntity
    {
        [Key]
        public long ID { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool isActive { get; set; } = true;
    }
}
