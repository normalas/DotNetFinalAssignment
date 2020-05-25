using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNet.Models
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public Actor Actor { get; set; }
        public ICollection<VideoGame> Appearances { get; } = new List<VideoGame>();

        public override string ToString()
        {
            return $"{CharacterName}, played by {Actor}";
        }
    }
}
