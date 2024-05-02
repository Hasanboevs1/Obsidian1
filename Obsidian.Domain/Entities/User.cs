using Obsidian.Domain.Commons;

namespace Obsidian.Domain.Entities
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
