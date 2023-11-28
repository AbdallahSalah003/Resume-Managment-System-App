namespace Backend_WebApi.Core.Dtos.Candidate
{
    public class CandidateCreateDto
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CoverLetter { get; set; }
        public long JobID { get; set; }
    }
}
