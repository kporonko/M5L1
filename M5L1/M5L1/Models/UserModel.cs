namespace M5L1.Models
{
    public class UserModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        public override string ToString()
        {
            return $"id: {this.Id}\nemail: {this.Email}\nFirst Name: {this.FirstName}\nLast Name: {this.LastName}\nAvatar: {this.Avatar}\nName: {this.Name}\nJob: {this.Job}\nCreatedAt: {this.CreatedAt}";
        }
    }
}