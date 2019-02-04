using System;

namespace Assignment2.Observer
{
    public class TestSauronEye
    {
        public static void Main(string[] args)
        {

            EyeOfSauron eye = new EyeOfSauron();
            BadGuy saruman = new BadGuy(eye, "Saruman");
            BadGuy witchKing = new BadGuy(eye, "Witch King");
            eye.SetEnemies(1, 1, 2, 0); //hobbits, elves, dwarves, men
            saruman.Defeated(); //Saruman is no longer registered with the Eye
            eye.SetEnemies(4, 2, 2, 100);
            //only the Witch King reports on the enemies

        }//end main
    }//end class
}
