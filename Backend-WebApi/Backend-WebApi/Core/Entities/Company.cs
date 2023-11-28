using Backend_WebApi.Core.Enums;

namespace Backend_WebApi.Core.Entities
{
    public class Company : SuperEntity
    {
        public string Name { get; set; }
        public CompanySize Size { get; set; }
        public ICollection<Job> jobs { get; set; }

    }
}
