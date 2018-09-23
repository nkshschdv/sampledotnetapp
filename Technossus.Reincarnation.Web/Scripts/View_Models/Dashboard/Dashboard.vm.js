define([
], function () {
    function Dashboard() {
       var self = this;
        self.test = ko.observable("cool test");
    }
        ko.applyBindings(new Dashboard(), document.getElementById('mainsection'));
});
