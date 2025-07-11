namespace Application.Request.Activity
{
    public class UpdateActivityRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string Location { get; set; }

        public int AmountOfPeople { get; set; }

        public DateTime Date { get; set; }

    }
}
