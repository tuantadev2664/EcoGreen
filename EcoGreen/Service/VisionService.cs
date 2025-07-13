using Google.Cloud.Vision.V1;

namespace EcoGreen.Service
{
    public class VisionService
    {
        public async Task<string> DetectObjectFromImage(string base64Image)
        {
            // Load Google Vision client
            ImageAnnotatorClient client = await ImageAnnotatorClient.CreateAsync();

            // Remove "data:image/jpeg;base64," if it exists
            var cleanBase64 = base64Image.Contains(",") ? base64Image.Split(',')[1] : base64Image;

            // Convert to byte array
            var imageBytes = Convert.FromBase64String(cleanBase64);
            var image = Image.FromBytes(imageBytes);

            // Perform label detection
            var response = await client.DetectLabelsAsync(image);

            if (response.Count == 0)
                return null;

            // Return the most confident label
            return response.OrderByDescending(x => x.Score).First().Description;
        }
    }
}