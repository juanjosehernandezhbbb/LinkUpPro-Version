// Adds a toggle button to any <input class="toggle-password" type="password"> to show/hide password
document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('input.toggle-password').forEach(function (input) {
        const wrapper = document.createElement('div');
        wrapper.className = 'input-group';
        input.parentNode.insertBefore(wrapper, input);
        wrapper.appendChild(input);

        const btnWrapper = document.createElement('span');
        btnWrapper.className = 'input-group-text';
        const btn = document.createElement('button');
        btn.type = 'button';
        btn.className = 'btn btn-sm btn-outline-secondary';
        btn.innerText = 'Show';
        btn.addEventListener('click', function () {
            if (input.type === 'password') {
                input.type = 'text';
                btn.innerText = 'Hide';
            } else {
                input.type = 'password';
                btn.innerText = 'Show';
            }
        });
        btnWrapper.appendChild(btn);
        wrapper.appendChild(btnWrapper);
    });
});
