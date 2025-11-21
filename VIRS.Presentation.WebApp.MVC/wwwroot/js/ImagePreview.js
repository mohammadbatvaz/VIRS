document.querySelectorAll('.image-input').forEach(input => {
    input.addEventListener('change', function () {
        const file = this.files[0];
        const preview = this.nextElementSibling;
        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                preview.src = e.target.result;
                preview.style.display = 'block';
            }
            reader.readAsDataURL(file);
        }
    });
});