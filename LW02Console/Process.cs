namespace LW02
{
    //пространство пользователя
    internal class Process
    {
        private Thread[] process;
        private int? time;
        private int pos;

        //инициализируем процесс потоками
        public Process(int countOfThreads, int pos)
        {
            process = new Thread[countOfThreads];
            time = 0;
            for (int i = 0; i < countOfThreads; i++)
            {
                Thread thread = new Thread();
                process[i] = thread;
                time += thread.Time;
            }
            this.pos = pos;
        }
        public int Pos { get { return pos; } }
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
        public int Time { get { return (int)time; } set { time = value; } }
        public int CountOfThreads { get { return process.Length; } }
        public override String ToString()
        {
            return $"threads: {String.Join<Thread>("ms, ", process)}" + "ms";
        }

    }
}
