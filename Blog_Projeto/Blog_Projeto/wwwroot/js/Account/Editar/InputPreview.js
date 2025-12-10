const editImgs = document.querySelectorAll(".Edit_Img");
const editInfos = document.querySelectorAll(".Edit_Info");
const editUploads = document.querySelectorAll(".Edit_Upload");
const fileInputs = document.querySelectorAll(".fileInput");
const closeButtons = document.querySelectorAll(".closeBtn");
const closeButtonImgs = document.querySelectorAll(".closeBtnImg");
const deleteInputs = document.querySelectorAll(".deleteInput");

// Função para configurar os listeners de mudança de arquivo
fileInputs.forEach(function (fileInput, index) {
    fileInput.addEventListener("change", function (event) {
        const file = event.target.files[0];
        const imgPreview = editInfos[index].querySelector(".imgPreview");
        const imgInfo = editInfos[index];
        const imgUpload = editUploads[index];

        if (file && !file.type.startsWith('image/')) {
            alert('Por favor, selecione um arquivo de imagem.');
            fileInput.value = '';
            return;
        }

        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                imgPreview.src = e.target.result;
                imgInfo.style.display = "flex";
                imgUpload.style.display = "none";
            };
            reader.readAsDataURL(file);
        }
    });
});

// Função para fechar a visualização da imagem carregada e resetar o estado do input
closeButtons.forEach(function (closeBtn, index) {
    closeBtn.addEventListener("click", function () {
        const fileInput = fileInputs[index];
        const imgInfo = editInfos[index];
        const imgUpload = editUploads[index];

        // Resetar o valor do input e esconder o preview de imagem
        fileInput.value = '';
        imgInfo.style.display = "none";
        imgUpload.style.display = "flex";
    });
});

// Função para fechar a imagem existente e resetar o estado
closeButtonImgs.forEach(function (closeBtnImg, index) {
    closeBtnImg.addEventListener("click", function () {
        const fileInput = fileInputs[index];
        const imgInfo = editInfos[index];
        const imgUpload = editUploads[index];
        const editImg = editImgs[index];
        const deleteInput = deleteInputs[index];

        // Resetar o estado do input, esconder a imagem e mostrar o upload novamente
        deleteInput.disabled = false;
        fileInput.value = '';
        imgInfo.style.display = "none";
        imgUpload.style.display = "flex";
        editImg.style.display = "none";
    });
});