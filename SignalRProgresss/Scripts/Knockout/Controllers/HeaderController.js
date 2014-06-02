function HeaderController() {
    var self = this;

    self.tasks = ko.observableArray([]); //Array<TaskProgressModel>

    self.cancelTask = function (task, e) {
        console.log('cancelling task...');
        task.cancelling(true);
        $.connection.taskManagerHub.server.cancelTask(task.taskId());
        e.stopPropagation();
    }

    self.tasksNumber = ko.computed(function () {
        return self.tasks().length;
    }, self);

    $.connection.taskManagerHub.client.progressChanged = function (taskList) {
        if (taskList.length == 0)
            self.tasks.removeAll();
        else {
            // Removed
            var diff = self.tasks().filter(function (oldTask) {
                return taskList.every(function (newTask) {
                    return oldTask.taskId() !== newTask.taskId;
                });
            });
            
            $.each(diff, function (index, task) {
                self.tasks.remove(task);
            });
            

            // Added or Updated
            $.each(taskList, function (index, item) {
                var previousTask = self.tasks().filter(function (t) { return t.taskId() === item.taskId });
                if (previousTask.length > 0)
                    previousTask[0].taskPercent(item.taskPercent);
                else
                    self.tasks.push(new TaskProgressModel(item));
            });
            //self.tasks(koArray);
        }
    };
}