const imgPreview = document.getElementById("imgPreview");
const fileInput = document.getElementById("fileInput");
const closeButton = document.getElementById("closeBtn");
const imgInfo = document.querySelector(".Img_InfoPartial");
const imgUpload = document.querySelector(".Img_UploadPartial");

fileInput.addEventListener("change", function (event) {
    const file = event.target.files[0];

    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            imgPreview.src = e.target.result;
            imgUpload.style.display = "none";
            imgInfo.style.display = "flex";
        };
        reader.readAsDataURL(file);
    }
});

closeButton.addEventListener("click", function () {
    fileInput.value = '';
    imgUpload.style.display = "flex";
    imgInfo.style.display = "none";
});