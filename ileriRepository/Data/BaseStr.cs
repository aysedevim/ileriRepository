using System.ComponentModel.DataAnnotations;

namespace ileriRepository.Data
{
    public class BaseStr
    {
        [Key]
        public string Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
