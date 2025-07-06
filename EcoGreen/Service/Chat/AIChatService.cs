using Application.Entities.Base;

namespace EcoGreen.Service.Chat
{
    public class AIChatService
    {
        public async Task<string> ChatAsync(ChatModel model, string userMessage)
        {
            using var ollama = new AIChatAPIClient();

            model.Messages.Add(new Message { Role = "user", Content = userMessage });

            var result = await ollama.GenerateChatAsync(model);

            model.Messages.Add(new Message { Role = "assistant", Content = result.Message.Content });

            return result.Message.Content;
        }
    }
}
