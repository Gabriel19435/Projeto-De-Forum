const DeleteImgBtn = document.getElementById("DeleteImgBtn");
const DeleteImgInput = document.getElementById("DeleteImgInput");

document.addEventListener("keydown", (event) => {
    if (event.key === "Enter") {
        event.preventDefault();
    }
});

DeleteImgBtn.addEventListener("click", () => {
    DeleteImgInput.disabled = false;
});