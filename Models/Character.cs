namespace DotNet.Models
{
    public class Character
    {
        public string CharacterName { get; set; }
        public string ActorName { get; set; }
        public VideoGame[] Appearances { get; set; }

        public override string ToString()
        {
            return $"{CharacterName}, played by {ActorName}";
        }
    }
}
