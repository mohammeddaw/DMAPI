using Gherkin;
using LivingDoc.Dtos;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlayWrightAPI.Drivers;
using PlayWrightAPI.Utilities;
using System.Security.AccessControl;
using System.Text.Json;



namespace PlayWrightAPI.StepDefinitions
{
    [Binding]
    public sealed class JimmyBogardCommitStepDefinitions : PlaywrightTest
    {
        private readonly PlayWrightDriver _playWrightDriver;
        public JimmyBogardCommitStepDefinitions(PlayWrightDriver playwrightDriver)
        {
            _playWrightDriver = playwrightDriver;
        }
      

        [Given(@"a valid auth token")]

        public async Task GivenAValidAuthToken()
        {

            var issues = await _playWrightDriver.ApiRequestContext.GetAsync("/repos/" + Settings.USER + "/" + Settings.REPO + "/git/commits/" + Settings.ENDUSERSHAKEY + "?since=" + Settings.COMMITDATE);
            Assert.True(issues.Ok);
            //Response obtained from Api


            var issuesJsonResponse = await issues.JsonAsync();
            var issuesJson = (await issues.JsonAsync())?.EnumerateArray();

            JsonElement? issue = null;
            foreach (JsonElement issueObj in issuesJsonResponse?.EnumerateArray())
            {
                if (issueObj.TryGetProperty("title", out var title) == true)
                {
                    if (title.GetString() == "[Feature] request 1")
                    {
                        issue = issueObj;
                    }
                }
            }
            Assert.NotNull(issue);
            Assert.AreEqual("Feature description", issue?.GetProperty("body").GetString());


        }





        [Then(@"the most recent commit is authored by Jimmy Bogard")]
        public async Task ThenTheMostRecentCommitIsAuthoredByJimmyBogard()
        {
            //var issues = await _playWrightDriver.ApiRequestContext.GetAsync("/repos/jbogard/MediatR/git/commits/c295291c4e8105d11a453004b42609cbf490c1cf?since=2023-07-10T00:00:00Z");

            //Assert.True(issues.Ok);
            //var issuesJsonResponse = await issues.JsonAsync();
            //JsonElement? issue = null;
            //foreach (JsonElement issueObj in issuesJsonResponse?.EnumerateArray())
            //{
            //    if (issueObj.TryGetProperty("title", out var title) == true)
            //    {
            //        if (title.GetString() == "[Bug] report 1")
            //        {
            //            issue = issueObj;
            //        }
            //    }
            //}
            //Assert.NotNull(issue);
            //Assert.AreEqual("Bug description", issue?.GetProperty("body").GetString());
        }

        [Then(@"the most recent commit is dated (.*)th July (.*)")]
        public void ThenTheMostRecentCommitIsDatedThJuly(int p0, int p1)
        {
            throw new PendingStepException();
        }


        



    }
}
