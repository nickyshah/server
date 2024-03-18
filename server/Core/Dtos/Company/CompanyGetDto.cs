using server.Core.Enums;

namespace server.Core.Dtos.Company
{
    public class CompanyGetDto
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public CompanySize Size { get; set; }
    }
}
