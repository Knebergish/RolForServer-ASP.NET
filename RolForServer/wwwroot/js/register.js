(function () {
    const registerForm = document.getElementById('register-form');
    const login = document.getElementById('register-username-input');
    const password = document.getElementById('register-password-input');
    const repeatPassword = document.getElementById('register-repeat-password-input');
    const button = document.getElementById('register-submit-button');
    button.onclick = validate;

    const invalidCredentialsLabel = document.createElement("Label");
    invalidCredentialsLabel.id = "register-error-message";
    invalidCredentialsLabel.hidden = true;
    registerForm.appendChild(invalidCredentialsLabel);

    let errorCount = 0;

    function validate() {
        let error = "";
        if (login.value.length <= 1) {
            error = "Логин слишком короткий.";
        } else if (password.value.length <= 5) {
            error = "Пароль слишком короткий.";
        } else if (password.value !== repeatPassword.value) {
            error = "Пароли не совпадают.";
        }

        if (error !== "") {
            invalidCredentialsLabel.innerHTML = error;
            invalidCredentialsLabel.hidden = false;
            errorCount++;
            setTimeout(hideInvalidCredentialsLabel, 3000);
        } else {
            document.location.href = "/Home/Forums";
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