using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsAPI.Models
{
    public class Events
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [MaxLength(250)]
        public string title { get; set; }

        public DateTime EventDate { get; set; }

        [MaxLength(1000)]
        public string description { get; set; }

        [MaxLength(1000)]
        public string notes { get; set; }

    }
}
