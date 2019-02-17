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
		let parameters = "login=" + login.value + "&password=" + password.value;
		ajax("/Auth/CheckUser", parameters, function (text) {
			if (text !== "") {
				invalidCredentialsLabel.innerHTML = text + "<br>";
				invalidCredentialsLabel.hidden = false;
				errorCount++;
				setTimeout(hideInvalidCredentialsLabel, 3000);
			}
			else {
				parameters += "&rememberMe=" + rememberMe.checked;
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