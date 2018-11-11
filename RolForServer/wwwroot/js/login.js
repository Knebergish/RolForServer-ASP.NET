(function () {
    const loginForm = document.getElementById('login');
    const login = document.getElementById('login-input');
    const password = document.getElementById('password-input');
    const button = document.getElementById('login-button');
    button.onclick = validate;

    const invalidCredentialsLabel = document.createElement("Label");
    invalidCredentialsLabel.id = "invalid-credentials-label";
    invalidCredentialsLabel.innerHTML = "Неверный логин или пароль<br>";
    invalidCredentialsLabel.style.color = 'Red';
    invalidCredentialsLabel.hidden = true;
    loginForm.appendChild(invalidCredentialsLabel);

    let errorCount = 0;

    function validate() {
        if (login.value === 'Knebergish' && password.value === '12345') {
            document.location.href = "/Home/Forums";
        }
        else {
            invalidCredentialsLabel.hidden = false;
            errorCount++;
            setTimeout(hideInvalidCredentialsLabel, 1000);
        }
        event.preventDefault();
    }

    function hideInvalidCredentialsLabel() {
        if (errorCount === 1) {
            invalidCredentialsLabel.hidden = true;
            errorCount = 0;
        }
        else
            errorCount--;
    }
})();