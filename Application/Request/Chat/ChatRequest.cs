using Application.Entities.Base;

namespace Application.Request.Chat
{
    public class ChatRequest
    {
        public string Message { get; set; }
        public List<Message>? PreviousMessages { get; set; }
    }
}
