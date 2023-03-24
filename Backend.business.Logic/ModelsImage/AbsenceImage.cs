

namespace Backend.business.Logic.ModelsImage
{
    public class AbsenceImage
    {
        public int AbsenceId { get; set; }
        public int StudentId { get; set; }
        public int SessionCoursId { get; set; }
        public string? AbsenceReason { get; set; }
        public string? Status { get; set; }


    }
}