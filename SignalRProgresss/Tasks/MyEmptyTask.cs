using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SignalRProgresss.Tasks
{
    // Static can be removed
    public static class MyEmptyTask
    {
        // static can be removed
        public static async Task StartCalculation(int timeDelay, CancellationToken token, IProgress<int> progress)
        {
            for (int i = 0; i <= 100; i++)
            {
                if (token.IsCancellationRequested)
                {
                    if (progress != null)
                        progress.Report(100);                    
                    token.ThrowIfCancellationRequested();
                }
                if (progress != null)
                    progress.Report(i);

                await System.Threading.Tasks.Task.Delay(timeDelay / 100);
            }

            if (progress != null)
                progress.Report(100);
        }
    }
}