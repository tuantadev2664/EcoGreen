﻿using Application.Entities.Base.AIChat;
using Application.Response.Chat;

namespace EcoGreen.Service.Chat
{
    public class AIChatAPIClient : IDisposable
    {
        private readonly HttpClient _client;

        public AIChatAPIClient()
        {
            var baseUrl = Environment.GetEnvironmentVariable("OLLAMA_API") ?? "http://localhost:11434";
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<AIResponse> GenerateChatAsync(ChatModel model)
        {
            var payload = new
            {
                model = model.Model,
                messages = model.Messages.Select(m => new { role = m.Role, content = m.Content }),
                stream = false
            };

            var response = await _client.PostAsJsonAsync("/api/chat", payload);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<AIResponse>();
        }

        public void Dispose() => _client.Dispose();
    }
}

