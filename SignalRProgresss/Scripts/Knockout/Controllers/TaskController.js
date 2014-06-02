function TaskController() {
    var self = this;

    self.model = TaskModel;

    self.startTask = function () {
        $.connection.taskManagerHub.server.startTask(self.model.taskDelay(), self.model.selectedCss());
    }
}