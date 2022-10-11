namespace LW02
{
    //пространство пользователя
    internal class Process
    {
        private Thread[] process;
        private int? time;

        //инициализируем процесс потоками
        public Process(int countOfThreads, int priority)
        {
            process = new Thread[countOfThreads];
            time = 0;
            for (int i = 0; i < countOfThreads; i++)
            {
                Thread thread = new Thread();
                process[i] = thread;
                time += thread.Time;
            }
        }
        public bool End()
        {
            for (int i = 0; i < process.Length; i++)
            {
                if (!process[i].End)
                {
                    return false;
                }
            }
            return true;
        }
        public Thread Thread(int indx) { return process[indx]; }
        public int Time { get { return (int)time; } }
        public int CountOfThreads { get { return process.Length; } }
        public override String ToString()
        {
            return $"threads: {String.Join<Thread>("ms, ", process)}" + "ms";
        }

    }
}
