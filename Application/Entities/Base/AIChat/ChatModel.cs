namespace Application.Entities.Base.AIChat
{
    public class ChatModel
    {
        public string Model { get; set; }
        public List<Message> Messages { get; set; } = new();
    }
}
