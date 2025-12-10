const Posts = document.getElementById('Select1');
const Info = document.getElementById('Select2');

const UserPost = document.querySelector('.UserPage_Post');
const UserDescrition = document.querySelector('.UserPage_Descrition');

Posts.addEventListener('click', function () {
    Posts.style.backgroundColor = '#d4d4d4';
    Info.style.backgroundColor = 'transparent';
    UserPost.style.display = 'grid';
    UserDescrition.style.display = 'none';
});

Info.addEventListener('click', function () {
    Posts.style.backgroundColor = 'transparent';
    Info.style.backgroundColor = '#d4d4d4';
    UserPost.style.display = 'none';
    UserDescrition.style.display = 'flex';
});

const UserPostCheck = window.getComputedStyle(UserPost);

if (UserPostCheck.display == 'grid') {
    Posts.style.backgroundColor = '#d4d4d4';
}