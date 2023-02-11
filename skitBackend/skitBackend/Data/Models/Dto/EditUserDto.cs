namespace skitBackend.Data.Models.Dto
{
    public class EditUserDto
    {
        public int Id { get; set; }
        public string? Nickname { get; set; }
        public string? DiscordNickname { get; set; }
        public string? Email { get; set; }
    }
}
