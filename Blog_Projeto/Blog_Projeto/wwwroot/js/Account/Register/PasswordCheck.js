const passwordInput = document.getElementById('Password');
const confirmPasswordInput = document.getElementById('Confirm');

passwordInput.addEventListener('input', function () {
    if (passwordInput.value.trim() !== '') {
        confirmPasswordInput.style.display = 'block';
    }
    else {
        confirmPasswordInput.style.display = 'none';
        confirmPasswordInput.value = "";
    }
});

confirmPasswordInput.addEventListener('input', function () {
    if (confirmPasswordInput.value.trim() !== passwordInput.value.trim()) {
        confirmPasswordInput.style.backgroundColor = 'rgba(255, 0, 0, 0.100)';
        confirmPasswordInput.style.border = '1px red solid';
    }
    else {
        confirmPasswordInput.style.backgroundColor = 'transparent';
        confirmPasswordInput.style.border = '1px lightgray solid';
    }
});