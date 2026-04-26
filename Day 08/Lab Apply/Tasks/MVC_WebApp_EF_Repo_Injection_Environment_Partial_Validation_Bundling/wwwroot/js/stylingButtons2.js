document.addEventListener('DOMContentLoaded',
    function () {
        var editBtns = document.querySelectorAll('.edit');
        editBtns.forEach(
            function (btn) {
                btn.classList.add('btn', 'btn-warning', 'm-2');
            });

        var detailsBtns = document.querySelectorAll('.details');
        detailsBtns.forEach(
            function (btn) {
                btn.classList.add('btn', 'btn-info', 'm-2');
            });

        var deleteBtns = document.querySelectorAll('.delete');
        deleteBtns.forEach(
            function (btn) {
                btn.classList.add('btn', 'btn-danger', 'm-2');
            });

        var addBtns = document.querySelectorAll('.add');
        addBtns.forEach(
            function (btn) {
                btn.classList.add('btn', 'btn-primary', 'm-2');
            });

        var backBtns = document.querySelectorAll('.back');
        backBtns.forEach(
            function (btn) {
                btn.classList.add('btn', 'btn-secondary', 'm-2');
            });
    });