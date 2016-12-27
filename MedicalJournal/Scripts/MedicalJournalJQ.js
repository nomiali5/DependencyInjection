(function ($) {
    function MedicJournal() {
        var $this = this;
        function initializeMedicJournal() {
            $('.datepicker').datepicker({
                "setDate": new Date(),
                "autoclose": true
            });
        }
        $this.init = function () {
            initializeMedicJournal();
        }
    }
    $(function () {
        var self = new MedicJournal();
        self.init();
    });
}(jQuery))