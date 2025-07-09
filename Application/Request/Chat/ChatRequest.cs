using Application.Entities.Base.AIChat;

namespace Application.Request.Chat
{
    public class ChatRequest
    {
        public string Message { get; set; }
        public List<Message>? PreviousMessages { get; set; }
    }
}
