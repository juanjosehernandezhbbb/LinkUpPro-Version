// Simple password strength indicator exposing initPasswordStrength(selector)
window.initPasswordStrength = function (selector) {
    document.querySelectorAll(selector).forEach(function (input) {
        const indicator = document.createElement('div');
        indicator.className = 'password-strength small mt-1';
        input.parentNode.insertBefore(indicator, input.nextSibling);

        function evaluate(pw) {
            let score = 0;
            if (pw.length >= 8) score++;
            if (/[A-Z]/.test(pw)) score++;
            if (/[a-z]/.test(pw)) score++;
            if (/[0-9]/.test(pw)) score++;
            if (/[^A-Za-z0-9]/.test(pw)) score++;
            return score;
        }

        input.addEventListener('input', function () {
            const s = evaluate(input.value);
            let text = 'Débil';
            let cls = 'text-danger';
            if (s >= 3) { text = 'Media'; cls = 'text-warning'; }
            if (s >= 5) { text = 'Fuerte'; cls = 'text-success'; }
            indicator.innerText = text;
            indicator.className = 'password-strength small mt-1 ' + cls;
        });
    });
};
