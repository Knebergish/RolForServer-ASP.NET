(function () {
	const login = document.getElementById('login-username-input');
	const password = document.getElementById('login-password-input');
	const rememberMe = document.getElementById('rememberMe');
	const button = document.getElementById('login-submit-button');
	button.onclick = validate;

	const invalidCredentialsLabel = document.getElementById("invalid-credentials-error-message");
	invalidCredentialsLabel.hidden = true;

	let errorCount = 0;

	function validate() {
		let parameters = "login=" + login.value
			+ "&password=" + password.value
			+ "&rememberMe=" + rememberMe.checked;
		ajax("/Auth/Authenticate", parameters, function (json) {
			const response = JSON.parse(json);
			if (response.Error) {
				invalidCredentialsLabel.innerHTML = response.Error + "<br>";
				invalidCredentialsLabel.hidden = false;
				errorCount++;
				setTimeout(hideInvalidCredentialsLabel, 3000);
			}
			else {
				document.location = response.RedirectURL;
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