using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Rage_Against_The_Photos
{
    internal class UpdateService
    {
        private readonly HttpClient httpClient;

        private const string LatestReleaseUrl =
            "https://api.github.com/repos/skrdkrt069/RageAgainstThePhotos/releases/latest";

        public UpdateService()
        {
            httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "RageAgainstThePhotos"
            );

            httpClient.DefaultRequestHeaders.Accept.ParseAdd(
                "application/vnd.github+json"
            );
        }

        public async Task<UpdateInfo> GetLatestVersionAsync()
        {
            HttpResponseMessage response =
                await httpClient.GetAsync(LatestReleaseUrl);

            response.EnsureSuccessStatusCode();

            string json = 
                await response.Content.ReadAsStringAsync();

            using JsonDocument document =
                JsonDocument.Parse(json);

            JsonElement root = document.RootElement;

            string tagName = 
                root.GetProperty("tag_name").GetString()
            ?? throw new InvalidOperationException(
                "A resposta do GitHub não contém uma tag de versão válida."
            );

            string htmlUrl =
                root.GetProperty("html_url").GetString()
                ?? throw new InvalidOperationException(
                    "A resposta do GitHub não contém uma URL válida."
                );

            return new UpdateInfo
            {
                Version = tagName.TrimStart('v').Split('+')[0],
                DownloadUrl = htmlUrl
            };
        }
    }
}
