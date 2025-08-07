namespace IntegrationTestLab.Application.DTOs
{
    public record UserRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
