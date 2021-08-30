using System.ComponentModel.DataAnnotations;

namespace Ntvspace.GlobalStoreApi.Domain.Models
{
    public class GlobalSearch
    {
        [Key]
        public int Id { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
    }
}
