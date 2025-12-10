document.addEventListener('DOMContentLoaded', function () {
    const postCard = document.querySelector('.Post_CardPartial');
    const postBtnOpen = document.getElementById('Post_BntOpen');
    const postBtnClose = document.getElementById('Post_Bnt');

    const input1 = document.getElementById('input1');
    const input2 = document.getElementById('input2');

    if (input1.value != "" || input2.value != "") {
        postCard.style.display = 'block';
    }

    postBtnOpen.addEventListener('click', function () {
        postCard.style.display = 'block';
    });

    postBtnClose.addEventListener('click', function () {
        postCard.style.display = 'none';
    });
});