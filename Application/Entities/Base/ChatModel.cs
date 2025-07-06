namespace Application.Entities.Base
{
    public class ChatModel
    {
        public string Model { get; set; }
        public List<Message> Messages { get; set; } = new();
    }
}
