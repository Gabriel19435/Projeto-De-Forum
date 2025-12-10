const FileUpload = document.getElementById("FileUpload")

FileUpload.addEventListener("change", function () {
    if (FileUpload.files.length > 0) {
        document.getElementById("overlayer").submit();
    }
});