namespace Backend_WebApi.Core.Dtos.Candidate
{
    public class CandidateGetDto
    {
        public long ID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public string ResumeUrl { get; set; }
        public long JobID { get; set; }
        public string JobTitle { get; set; }
    }
}
