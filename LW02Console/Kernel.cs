namespace LW02
{
    internal class Kernel
    {
        String listOfProcesses;
        Process[] processes = { new Process(4, 0),
                new Process(4, 1), new Process(2, 2),
                new Process(1, 3), new Process(5, 4) };
        readonly int quantum = 50;

        public void StartProcesses()
        {
            Queue<Process> queue = new Queue<Process>();
            for (int i = 0; i < processes.Length; i++)
                queue.Enqueue(processes[i]);
            while (queue.Count > 0)
            {
                Process process = queue.Peek();
                if (!process.End())
                {
                    Console.Write($"{process.Pos} process: \n");
                    int threadsLength = 0;
                    if (process.Time > quantum)
                    {
                        for (int i = 0; i < process.CountOfThreads; i++)
                        {
                            if (process.Thread(i).End)
                                continue;
                            threadsLength += process.Thread(i).Time;
                            if (threadsLength <= quantum)
                            {
                                Console.Write($"thread: {process.Thread(i).Time} end\n");
                                process.Thread(i).End = true;
                                if (process.End())
                                {
                                    queue.Dequeue();
                                    Console.Write($"process {process.Pos} end\n");
                                }
                            }
                            else
                            {
                                int temp = threadsLength - process.Thread(i).Time;
                                int dorisovali = quantum - temp;
                                Console.Write($"thread: {process.Thread(i).Time} not end, {process.Thread(i).Time - dorisovali} ms left\n");
                                process.Thread(i).Time = process.Thread(i).Time - dorisovali;
                                queue.Enqueue(queue.Dequeue());
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < process.CountOfThreads; i++)
                        {
                            if (process.Thread(i).End)
                                continue;
                            threadsLength += process.Thread(i).Time;
                            if (threadsLength <= quantum)
                            {
                                Console.Write($"thread: {process.Thread(i).Time} end\n");
                                process.Thread(i).End = true;
                            }
                        }
                        if (process.End())
                        {
                            queue.Dequeue();
                            Console.Write($"process {process.Pos} end\n");
                        }
                    }
                }
            }
        }
        public String GetListProcesses()
        {
            listOfProcesses = "";
            for (int i = 0; i < processes.Length; i++)
            {
                listOfProcesses += i + ": " + processes[i].ToString() + "\n";
            }
            String temp = listOfProcesses;
            return temp;
        }

    }
}
