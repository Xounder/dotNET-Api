namespace dotNET_Api.Models
{
    public class TaskSchedule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public EnumTaskStatus Status { get; set; }
    }
}