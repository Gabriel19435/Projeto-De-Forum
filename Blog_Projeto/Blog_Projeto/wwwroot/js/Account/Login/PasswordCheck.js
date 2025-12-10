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