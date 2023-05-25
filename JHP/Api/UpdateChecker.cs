using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHP.Api
{
    internal class UpdateChecker
    {
        public static async Task<bool> Check()
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("SomeName"));
            IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("d3vdev", "JHP");

            Version latestGitHubVersion = new Version(releases[0].TagName);
            Version localVersion = new Version(Config.Version); 

            int versionComparison = localVersion.CompareTo(latestGitHubVersion);

            return versionComparison < 0;
        }
    }
}
