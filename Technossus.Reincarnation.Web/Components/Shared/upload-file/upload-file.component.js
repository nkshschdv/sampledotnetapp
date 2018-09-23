
define([], function () {
    function fileUpload() {
        var self = this;
        self.fileUploadStatus = ko.observable("Uploaded.");
    }
    return fileUpload;
});

