using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GitlabWallboard.Model
{
    public partial class GitLabIssues
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("iid")]
        public long Iid { get; set; }

        [JsonProperty("project_id")]
        public long ProjectId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("created_at")]
        public System.DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public System.DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("closed_at")]
        public object ClosedAt { get; set; }

        [JsonProperty("closed_by")]
        public object ClosedBy { get; set; }

        [JsonProperty("labels")]
        public List<object> Labels { get; set; }

        [JsonProperty("milestone")]
        public object Milestone { get; set; }

        [JsonProperty("assignees")]
        public List<object> Assignees { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("assignee")]
        public object Assignee { get; set; }

        [JsonProperty("user_notes_count")]
        public long UserNotesCount { get; set; }

        [JsonProperty("upvotes")]
        public long Upvotes { get; set; }

        [JsonProperty("downvotes")]
        public long Downvotes { get; set; }

        [JsonProperty("due_date")]
        public object DueDate { get; set; }

        [JsonProperty("confidential")]
        public bool Confidential { get; set; }

        [JsonProperty("discussion_locked")]
        public object DiscussionLocked { get; set; }

        [JsonProperty("web_url")]
        public string WebUrl { get; set; }

        [JsonProperty("time_stats")]
        public TimeStats TimeStats { get; set; }

        [JsonProperty("weight")]
        public object Weight { get; set; }
    }

    public partial class Author
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("web_url")]
        public string WebUrl { get; set; }
    }

    public partial class TimeStats
    {
        [JsonProperty("time_estimate")]
        public long TimeEstimate { get; set; }

        [JsonProperty("total_time_spent")]
        public long TotalTimeSpent { get; set; }

        [JsonProperty("human_time_estimate")]
        public object HumanTimeEstimate { get; set; }

        [JsonProperty("human_total_time_spent")]
        public object HumanTotalTimeSpent { get; set; }
    }

    public partial class GitLabIssues
    {
        public static List<GitLabIssues> FromJson(string json) => JsonConvert.DeserializeObject<List<GitLabIssues>>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<GitLabIssues> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
        };
    }
}