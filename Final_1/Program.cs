using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//darlene alcorn
namespace Final_1
{
    class Program
    {

        static void Main(string[] args)
        {
            Bird bird = new Bird();
            Fish fish = new Fish();
            Insect bug = new Insect();
            Echinoderm starfish = new Echinoderm();
            Reptile snake = new Reptile();


            Thread tBird = new Thread(bird.chirp);
            tBird.Start();

            Thread tFish = new Thread(fish.glub);
            tFish.Start();

            Thread tBug = new Thread(bug.buzz);
            tBug.Start();

            Thread tEchinoderm = new Thread(starfish.makeNoise);
            tEchinoderm.Start();

            Thread tReptile = new Thread(snake.saySomething);
            tReptile.Start();

            //press enter to terminate
            Console.ReadLine();

            //randomly generate a delay for each thread
            Random r = new Random();
            int time0 = 100 * r.Next(5, 11);
            int time1 = 100 * r.Next(5, 11);
            int time2 = 100 * r.Next(5, 11);
            int time3 = 100 * r.Next(5, 11);
            int time4 = 100 * r.Next(5, 11);

            tBird.Join(time0);
            tFish.Join(time1);
            tBug.Join(time2);
            tEchinoderm.Join(time3);
            tReptile.Join(time4);
            Console.WriteLine("Bird delay randomly generated: " + time0 + " milliseconds");
            Console.WriteLine("Fish delay randomly generated: " + time1 + " milliseconds");
            Console.WriteLine("Insect delay randomly generated: " + time2 + " milliseconds");
            Console.WriteLine("Echinoderm delay randomly generated: " + time3 + " milliseconds");
            Console.WriteLine("Reptile delay randomly generated: " + time4 + " milliseconds");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Main method complete. Press Enter.");
            Console.ReadLine();

        }
    }
}
