
(function () {
    ko.components.register('upload-file', {
        viewModel: { require: 'Components/shared/upload-file/upload-file.component' },
        template: { require: 'text!/Components/shared/upload-file/upload-file.component.html' }
    });
})();
