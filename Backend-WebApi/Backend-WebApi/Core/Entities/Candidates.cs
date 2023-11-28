namespace Backend_WebApi.Core.Entities
{
    public class Candidates : SuperEntity
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }
        public long JobID { get; set; }
        public Job Job { get; set; }
    }
}
