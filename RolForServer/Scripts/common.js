function ajax(url, parameters, callback) {
	const xmlHttp = new XMLHttpRequest();
	xmlHttp.open("POST", url, true);

	xmlHttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");

	xmlHttp.onreadystatechange = function () {
		if (xmlHttp.readyState === 4 && xmlHttp.status === 200) {
			callback(xmlHttp.responseText);
		}
	};

	xmlHttp.send(parameters);
}