using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Final_1
{
    class Fish
    {
        public Fish() { }


        public void glub()
        {
            Console.WriteLine("\nFish method:  <glub>");
            DisplayMessage();
        }
        static bool terminate = false;

        private static void TraceMsg(string msg)
        {
            Console.WriteLine("\nThread id {0} - {1} : {2}",
                Thread.CurrentThread.ManagedThreadId,
                DateTime.Now.ToString("HH:mm:ss.ffff"), msg);
        }

        private static void DisplayMessage()
        {

            using (Mutex mutex = new Mutex(false, "MutexTest"))
            {
                TraceMsg("Fish started.");

                while (!terminate)
                {
                    // Wait on the Mutex.
                    mutex.WaitOne();

                    TraceMsg("Fish owns the Mutex.");

                    Thread.Sleep(1000);

                    TraceMsg("Fish releasing the Mutex.");

                    // Release the Mutex.
                    mutex.ReleaseMutex();

                    // Sleep a little to give another thread a good chance of
                    // acquiring the Mutex.
                    Thread.Sleep(500);
                    terminate = true;
                }

                TraceMsg("Fish terminating.");
            }
        }
    }
}
