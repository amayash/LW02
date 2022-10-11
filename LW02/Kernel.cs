namespace LW02
{
    internal class Kernel
    {
        String listOfProcesses;
        Process[] processes = { new Process(4, 1),
                new Process(4, 2), new Process(2, 1),
                new Process(1, 3), new Process(5, 4) };
        readonly int quantum = 50;
        public void DrawProcesses(Graphics g, int height, int width)
        {
            Brush br = new SolidBrush(Color.Black);
            Pen pen = new Pen(br, 5);
            g.DrawLine(pen, 10, 10, 10, height - 10);
            g.DrawLine(pen, 10, height - 10, width - 10, height - 10);
            g.DrawString("time", new Font("Times New Roman", 14), br,
                new Point(width - 60, height - 35));
            Brush[] brPr = new SolidBrush[50];
            Random random = new Random();
            int colors = 0;
            for (int i = 0; i < processes.Length; i++)
            {
                for (int j = 0; j < processes[i].CountOfThreads; j++)
                {
                    brPr[colors] = new SolidBrush(Color.FromArgb(random.Next(0, 256),
                        random.Next(0, 256), random.Next(0, 256)));
                    colors++;
                }
            }
            colors = 0;

            //Queue<Process> queue = new Queue<Process>();
            //for (int i = 0; i < processes.Length; i++)
            //    queue.Enqueue(processes[i]);


            //int startX = 20;
            //while (queue.Count > 0)
            //{
            //    int threadsLength = 0;
            //    Process process = queue.Peek();
            //    while (!process.End())
            //    {
            //        if (process.Time > quantum)
            //        {
            //            for (int i = 0; i < process.CountOfThreads; i++)
            //            {
            //                if (process.Thread(i).End)
            //                    continue;
            //                threadsLength += process.Thread(i).Time;
            //                if (threadsLength <= quantum)
            //                {
            //                    g.FillRectangle(brPr[colors], startX,
            //                        height - 20 * i - 50, process.Thread(i).Time, 20);
            //                    g.DrawString($"|{process.Thread(i).Time}|", new Font("Calibri", 10), br,
            //                        new Point(startX + process.Thread(i).Time,
            //                        height - 20 * i - 50 + 20));
            //                    startX += process.Thread(i).Time;
            //                    process.Thread(i).End = true;
            //                }
            //                else
            //                {
            //                    int temp = threadsLength - process.Thread(i).Time;
            //                    int dorisovali = quantum - temp;
            //                    g.FillRectangle(brPr[colors], startX,
            //                        height - 20 * i - 50, dorisovali, 20);
            //                    g.DrawString($"|{processes[i].Thread(j).Time}|", new Font("Calibri", 10), br,
            //                        new Point(startX + dorisovali,
            //                        height - 20 * i - 50 + 20));
            //                    startX += dorisovali;
            //                    process.Thread(i).Time = process.Thread(i).Time - dorisovali;
            //                }
            //            }
            //        }
            //    }
            //}
            for (int i = 0; i < processes.Length; i++)
            {
                int startX = 20;
                int? threadsLength = 0;
                for (int j = 0; j < processes[i].CountOfThreads; j++)
                {
                    if (processes[i].Time > quantum)
                    {
                        if (processes[i].Thread(j).End)
                            continue;
                        threadsLength += processes[i].Thread(j).Time;
                        if (threadsLength <= quantum)
                        {
                            g.FillRectangle(brPr[colors], startX,
                                height - 20 * i - 50, (int)processes[i].Thread(j).Time, 20);
                            g.DrawString($"|{(int)processes[i].Thread(j).Time}|", new Font("Calibri", 10), br,
                                new Point(startX + (int)processes[i].Thread(j).Time,
                                height - 20 * i - 50 + 20));
                            startX += (int)processes[i].Thread(j).Time;
                            processes[i].Thread(j).End = true;
                        }
                        else
                        {
                            int temp = (int)threadsLength - (int)processes[i].Thread(j).Time;
                            int dorisovali = quantum - temp;
                            g.FillRectangle(brPr[colors], startX,
                                height - 20 * i - 50, dorisovali, 20);
                            g.DrawString($"|{(int)processes[i].Thread(j).Time}|", new Font("Calibri", 10), br,
                                new Point(startX + dorisovali,
                                height - 20 * i - 50 + 20));
                            startX += dorisovali;
                            processes[i].Thread(j).Time = processes[i].Thread(j).Time - dorisovali;
                        }

                    }
                    else
                    {
                        g.FillRectangle(brPr[colors], startX,
                                height - 20 * i - 50, (int)processes[i].Thread(j).Time, 20);
                        g.DrawString($"|{(int)processes[i].Thread(j).Time}|", new Font("Calibri", 10), br,
                            new Point(startX + (int)processes[i].Thread(j).Time,
                            height - 20 * i - 50 + 20));
                        startX += (int)processes[i].Thread(j).Time;
                    }
                    colors++;
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
