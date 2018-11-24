(function () {
	const registerForm = document.getElementById('registration-form');
	const login = document.getElementById('registration-login-input');
	const username = document.getElementById('registration-username-input');
	const password = document.getElementById('registration-password-input');
	const repeatPassword = document.getElementById('registration-repeat-password-input');
	const email = document.getElementById('registration-email-input');
	const button = document.getElementById('registration-submit-button');
	button.onclick = validate;

	const invalidCredentialsLabel = document.createElement("label");
	invalidCredentialsLabel.id = "registration-error-message";
	invalidCredentialsLabel.hidden = true;
	registerForm.appendChild(invalidCredentialsLabel);

	let errorCount = 0;

	function validate() {
		let error = "";
		if (!/^[a-zA-Z][A-Za-z0-9]{1,16}$/.test(login.value)) {
			error = "Логин не отвечает требованиям";
		} else if (!/^.{2,20}$/.test(username.value)) {
			error = "Имя пользователя не отвечает требованиям";
		} else if (!/^[A-Za-z0-9.,!?(){}<>;:'"\\|/*\-+=_@#№$^]{5,20}$/.test(password.value)) {
			error = "Пароль не отвечает требованиям";
		} else if (password.value !== repeatPassword.value) {
			error = "Пароли не совпадают";
		} else if (!/^[a-zA-Z0-9\-_.]+@.+\.[a-z]{1,4}$/.test(email.value)) {
			error = "Неподдерживаемый формат почтового адреса";
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
		} else
			errorCount--;
	}
})();