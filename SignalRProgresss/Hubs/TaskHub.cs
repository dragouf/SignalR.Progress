using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using SignalRProgresss.ViewModels;
using System.Threading.Tasks;
using System.Threading;
using SignalRProgresss.Tasks;

namespace SignalRProgresss.Hubs
{
    public class TaskManagerHub : Hub
    {
        private static ConcurrentDictionary<string, TaskDetails> _CurrentTasks;
        private ConcurrentDictionary<string, TaskDetails> CurrentTasks
        {
            get
            {
                if (_CurrentTasks == null)
                    _CurrentTasks = new ConcurrentDictionary<string, TaskDetails>();

                return _CurrentTasks;
            }
        }

        private void ReportProgress()
        {
            Clients.All.progressChanged(CurrentTasks.Select(t => t.Value));
            foreach (var task in CurrentTasks)
            {
                if (task.Value.Percent >= 100)
                {
                    TaskDetails taskDetails;
                    CurrentTasks.TryRemove(task.Key, out taskDetails);
                    ReportProgress();
                }
            }
        }


        public void CancelTask(string taskId)
        {
            if (CurrentTasks.ContainsKey(taskId))
                CurrentTasks[taskId].CancelToken.Cancel();
        }

        public async Task<string> StartTask(int delay, string css)
        {
            var tokenSource = new CancellationTokenSource();

            string taskId = string.Format("progress{0}", Guid.NewGuid());
            
            CurrentTasks.TryAdd(taskId, new TaskDetails { 
                Percent = 0, 
                CancelToken = tokenSource, 
                Id = taskId,
                Name = string.Format("Empty task #{0}", this.CurrentTasks.Count),
                BarCss = css, 
                TaskPage = "/" 
            });

            //var task = Task.Factory.StartNew(() => Calculation(delay, taskId, tokenSource.Token), tokenSource.Token);
            var task = MyEmptyTask.StartCalculation(delay, tokenSource.Token, new Progress<int>(pourcent =>
            {
                if (CurrentTasks.ContainsKey(taskId))
                    CurrentTasks[taskId].Percent = pourcent;
                ReportProgress();
            }));

            await task;

            return "Task result";
        }
    }
}