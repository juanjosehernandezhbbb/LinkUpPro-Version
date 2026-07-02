// Shows image preview for file inputs with class .image-preview-input
document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('input.image-preview-input[type="file"]').forEach(function (input) {
        const preview = document.createElement('img');
        preview.style.maxWidth = '120px';
        preview.style.display = 'block';
        preview.className = 'mt-2';
        input.parentNode.insertBefore(preview, input.nextSibling);

        input.addEventListener('change', function () {
            const file = input.files && input.files[0];
            if (!file) { preview.src = ''; return; }
            const allowed = ['image/jpeg', 'image/png', 'image/webp'];
            if (!allowed.includes(file.type)) {
                alert('Formato no válido. Solo jpg, png, webp.');
                input.value = '';
                preview.src = '';
                return;
            }
            if (file.size > 5 * 1024 * 1024) {
                alert('El archivo excede el tamaño máximo de 5MB.');
                input.value = '';
                preview.src = '';
                return;
            }
            const reader = new FileReader();
            reader.onload = function (e) { preview.src = e.target.result; };
            reader.readAsDataURL(file);
        });
    });
});
