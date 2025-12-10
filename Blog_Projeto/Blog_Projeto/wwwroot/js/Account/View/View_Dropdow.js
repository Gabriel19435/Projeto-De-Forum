document.addEventListener('DOMContentLoaded', () => {
    const moreBtns = document.querySelectorAll('.more-btn');
    const hidMenus = document.querySelectorAll('.hid_menu');

    moreBtns.forEach((btn, index) => {
        btn.addEventListener('click', (e) => {
            e.stopPropagation();
            const menu = hidMenus[index];
            menu.style.display = menu.style.display === 'flex' ? 'none' : 'flex';
        });
    });

    document.addEventListener('click', (e) => {
        if (!e.target.closest('.more-btn')) {
            hidMenus.forEach(menu => {
                menu.style.display = 'none';
            });
        }
    });
});