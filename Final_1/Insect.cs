using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Final_1
{
    class Insect 
    {
        public Insect() { }

        public void buzz()
        {
            Console.WriteLine("\nInsect method: <buzz>");
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
                TraceMsg("Insect started.");

                while (!terminate)
                {
                    // Wait on the Mutex.
                    mutex.WaitOne();

                    TraceMsg("Insect owns the Mutex.");

                    Thread.Sleep(1000);

                    TraceMsg("Insect releasing the Mutex.");

                    // Release the Mutex.
                    mutex.ReleaseMutex();

                    // Sleep a little to give another thread a good chance of
                    // acquiring the Mutex.
                    Thread.Sleep(500);
                    terminate = true;
                }

                TraceMsg("Insect terminating.");
            }
        }
    }
}
