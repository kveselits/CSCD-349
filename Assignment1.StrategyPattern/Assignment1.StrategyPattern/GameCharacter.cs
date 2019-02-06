using System;

namespace Assignment_1_Strategy_Pattern
{
    class GameCharacter
    {
        readonly string CharacterName;
 
        public IGuitar Guitar { get; set; }
        public ISoloAct SoloAct { get; set; }

        public GameCharacter(string characterName)
            //defaults to GibsonSG and SmashTheGuitar, but can be changed at runtime
            : this(characterName, new GibsonSG(), new JumpOffTheStage()) {
        }

        public GameCharacter(string characterName, IGuitar guitar, ISoloAct soloAct)
        {
            CharacterName = characterName;
            Guitar = guitar;
            SoloAct = soloAct;
        }

        public void PlayGuitar()
        {
            Console.WriteLine($"{CharacterName} {Guitar.PlayGuitar()} {Environment.NewLine}");
        }

        public void PerformSolo()
        {
            Console.WriteLine($"{CharacterName} {SoloAct.PerformSolo()} {Environment.NewLine}");
        }
    }
}
