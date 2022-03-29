using Core.Entities;

namespace Entities.DTOs
{
    public class LocationListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
