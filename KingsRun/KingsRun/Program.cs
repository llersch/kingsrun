using System;

namespace KingsRun
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (KingsRun game = new KingsRun())
            {
                game.Run();
            }
        }
    }
#endif
}

