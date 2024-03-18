using server.Core.Enums;

namespace server.Core.Dtos.Company
{
    public class CompanyCreateDto
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }
    }
}
