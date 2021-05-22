using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    public class GitHubApionsumer
    {
        private readonly HttpClient _httpClient;

        public GitHubApionsumer(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GitHubRepo>> GetRepos()
        {
            var response = await _httpClient.GetAsync("users/aspnet/repos");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <List<GitHubRepo>>(responseStream);
        }
    }
}
