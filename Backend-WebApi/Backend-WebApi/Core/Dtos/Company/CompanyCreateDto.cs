using Backend_WebApi.Core.Enums;

namespace Backend_WebApi.Core.Dtos.Company
{
    public class CompanyCreateDto
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }
    }
}
