using Obsidian.Domain.Commons;

namespace Obsidian.Domain.Entities
{
    public class Comment : Auditable
    {
        public string Content { get; set; }
        public long OwnedId { get; set; }
        public User Owner { get; set; }
    }
}
