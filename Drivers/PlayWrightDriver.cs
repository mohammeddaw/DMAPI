using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using static System.Net.Mime.MediaTypeNames;
using PlayWrightAPI.Utilities;
namespace PlayWrightAPI.Drivers 
{
    
    public class PlayWrightDriver : IDisposable
    {
       
        private readonly Task<IAPIRequestContext?>?  Request = null;
        public IPlaywright playwright { get; private set; }


        public PlayWrightDriver()
        {
            Request = Task.Run(CreateAPIContext);
        }

        public IAPIRequestContext? ApiRequestContext => Request.GetAwaiter().GetResult();

        
        private async Task<IAPIRequestContext> CreateAPIContext()
        {

            var headers = new Dictionary<string, string>();
            // We set this header per GitHub guidelines.
            headers.Add("Accept", "application/vnd.github.v3+json");
            // Add authorization token to all requests.
            // Assuming personal access token available in the environment.
            headers.Add("Authorization", "token " + Settings.API_TOKEN);
            IPlaywright playwright = await Playwright.CreateAsync();
            string giturl = Settings.URL;

            return await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
            {
                // All requests we send go to this API endpoint.
                BaseURL = giturl,
                ExtraHTTPHeaders = headers,
            });

        }

        public void Dispose()
        {
            Request.Dispose();
        }

    }

}