using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace SoupsUp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "InstrumentationKey=f5825bac-652a-412c-ab9d-6421bc92c178;IngestionEndpoint=https://eastus-8.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/;ApplicationId=1c47158a-595b-4c65-9987-b247b7c56c7d";

            var configuration = TelemetryConfiguration.CreateDefault();
            configuration.ConnectionString = connectionString;
            var telemetryClient = new TelemetryClient(configuration);

            Console.WriteLine("I really like soup...");
            while (true)
            {
                await SendTelemetry(telemetryClient);
            }
        }

        static async Task SendTelemetry(TelemetryClient telemetryClient)
        {
            telemetryClient.TrackTrace(aboutSoup);

            telemetryClient.TrackEvent("CustomEvent", new Dictionary<string, string>
        {
            {"Category", "DEI"},
            {"Action", "Revolt"}
        });

            telemetryClient.TrackMetric("PageViewPerformance", uint.MaxValue);

            telemetryClient.TrackException(new InvalidOperationException(aboutSoup));

            await telemetryClient.FlushAsync(CancellationToken.None);
        }

        const string aboutSoup = @"Soup is one of the most versatile and comforting dishes enjoyed worldwide. Found in nearly every cuisine, it is a simple yet satisfying meal that can be adapted to suit any season, diet, or occasion. From rich and creamy bisques to hearty stews, soup has been a staple of human diets for centuries.

A Brief History of Soup
Soup dates back to ancient times, with evidence suggesting that early humans boiled ingredients in water as soon as they had the means to do so. Archaeological findings show that people were making soup at least 20,000 years ago, using hot stones to boil water in animal hides or clay pots. Over time, soups evolved into cultural staples—whether it was the thick and meaty stews of medieval Europe or the delicate broths of East Asia.

Types of Soup
Soup comes in countless varieties, but it can generally be divided into two main categories: clear soups and thick soups. Clear soups, like consommé and broth, are made by simmering ingredients to extract flavor while keeping the liquid transparent. Thick soups, such as chowders, purées, and bisques, rely on ingredients like cream, potatoes, or blended vegetables for a richer consistency.

Health Benefits of Soup
Soup is often seen as a nutritious and easily digestible meal. It provides hydration, warmth, and essential nutrients, making it an ideal choice for those feeling under the weather. Broth-based soups can be low in calories while still being filling, making them popular for weight management. On the other hand, hearty soups with legumes, lean meats, and vegetables are excellent sources of protein, fiber, and vitamins.

Cultural Variations
Every culture has its own take on soup, often influenced by local ingredients and traditions. In Japan, miso soup is a daily staple made from fermented soybean paste. France is famous for its onion soup, topped with melted cheese and bread. In Mexico, pozole—a hominy and meat-based soup—is a festive dish. Meanwhile, in the United States, chicken noodle soup is the go-to comfort food for cold days and sick days alike.

Making the Perfect Soup
A great soup starts with quality ingredients. A well-made broth forms the foundation, whether it’s vegetable, chicken, beef, or seafood-based. Fresh herbs, spices, and seasoning enhance flavor, while simmering allows the ingredients to meld together beautifully. Soups can be customized with a variety of add-ins, such as pasta, rice, dumplings, or legumes.

Whether enjoyed as a light appetizer or a hearty meal, soup remains a beloved dish that brings warmth, nourishment, and comfort to tables across the globe.";

    }
}
