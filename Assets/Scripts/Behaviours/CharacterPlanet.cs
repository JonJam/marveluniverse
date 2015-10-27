namespace MarvelUniverse.Behaviours
{
    using Model.Character;

    /// <summary>
    /// The character planet behaviour.
    /// </summary>
    public class CharacterPlanet : Planet
    {
        private Character character;

        public void HookUp(Character character)
        {
            this.character = character;

            this.SetImage(character.Thumbnail.Path, character.Thumbnail.Extension);
        }
    }
}