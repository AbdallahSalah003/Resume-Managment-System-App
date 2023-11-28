using Backend_WebApi.Core.Enums;

namespace Backend_WebApi.Core.Entities
{
    public class Job : SuperEntity
    {
        public string Title { get; set; }
        public JobLevel Level { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<Candidates> Candidates { get; set; }
    }
}
