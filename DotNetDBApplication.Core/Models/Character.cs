using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNet.Models
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }

        public override string ToString()
        {
            return $"{CharacterName}";
        }
    }
}
