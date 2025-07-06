using Application.Entities.Base;

namespace Application.Response.Chat
{
    public class ChatResponse
    {
        public string Response { get; set; }
        public List<Message> Conversation { get; set; }
    }
}
