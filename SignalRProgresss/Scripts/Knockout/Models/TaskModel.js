var TaskModel = {
    taskDelay: ko.observable(30000),
    availableCss: ko.observableArray(['progress-bar-primary', 'progress-bar-success', 'progress-bar-info', 'progress-bar-warning', 'progress-bar-danger']),
    selectedCss: ko.observable('progress-bar-primary')
};