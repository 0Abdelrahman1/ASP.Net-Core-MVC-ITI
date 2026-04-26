document.addEventListener('DOMContentLoaded',
    function ()
    {
        var createBtn = document.querySelector('.create');
        if (createBtn) {
            createBtn.classList.add('text-end');

            const link = createBtn.querySelector('a');
            if (link)
                link.classList.add('btn', 'btn-primary', 'm-2');
        }
    });