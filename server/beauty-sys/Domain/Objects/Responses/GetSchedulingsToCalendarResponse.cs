namespace Domain.Objects.Responses
{
    public record GetSchedulingsToCalendarResponse
    {
        public int Day { get; set; }
        public DailySchedule? DailySchedules { get; set; }
    }

    public record DailySchedule
    {
        public required string CustomerId { get; set; }
        public required string CustomerName { get; set; }
    }
}
