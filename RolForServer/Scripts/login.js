(function () {
	const loginForm = document.getElementById('login-form');
	const login = document.getElementById('login-username-input');
	const password = document.getElementById('login-password-input');
	const button = document.getElementById('login-submit-button');
	button.onclick = validate;

	const invalidCredentialsLabel = document.createElement("Label");
	invalidCredentialsLabel.id = "invalid-credentials-error-message";
	invalidCredentialsLabel.innerHTML = "";
	invalidCredentialsLabel.hidden = true;
	loginForm.appendChild(invalidCredentialsLabel);

	let errorCount = 0;

	function validate() {
		let parameters = "login=" + login.value + "&password=" + password.value;
		ajax("/Auth/CheckUser", parameters, function (text) {
			if (text !== "") {
				invalidCredentialsLabel.innerHTML = text + "<br>";
				invalidCredentialsLabel.hidden = false;
				errorCount++;
				setTimeout(hideInvalidCredentialsLabel, 3000);
			}
			else {
				document.location.href = "/Auth/Authenticate?" + parameters;
			}
		});
	}

	function hideInvalidCredentialsLabel() {
		if (errorCount === 1) {
			invalidCredentialsLabel.hidden = true;
			invalidCredentialsLabel.innerHTML = "";
			errorCount = 0;
		} else {
			errorCount--;
		}
	}
})();