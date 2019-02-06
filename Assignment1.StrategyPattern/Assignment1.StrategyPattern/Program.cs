using System;

namespace Assignment_1_Strategy_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            GameCharacter player1 = new GameCharacterSlash();
            GameCharacter player2 = new GameCharacterJimiHendrix();
            GameCharacter player3 = new GameCharacterAngusYoung();
            player1.PlayGuitar();
            player2.Guitar = new GibsonFlyingV();
            player2.PlayGuitar();
            player3.Guitar = new FenderTelecaster();
            player3.PlayGuitar();

            player1.PerformSolo();
            player2.SoloAct = new SmashTheGuitar();
            player2.PerformSolo();
            player3.SoloAct = new PutTheGuitarOnFire();
            player3.PerformSolo();

        }
    }
}
