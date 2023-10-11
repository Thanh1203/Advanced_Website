namespace MyWebApi.Models
{
    public class ShowTimesModels
    {
        public int? IdMovieShowtime { get; set; }
        public string? MovieDate { get; set; }
        public DateTime TimeSlot { get; set; }
        public int NofTickets { get; set; }
    }
}