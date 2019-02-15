function ajax(url, parameters, callback) {
	const xmlHttp = new XMLHttpRequest();
	xmlHttp.open("POST", url, true);

	xmlHttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");

	xmlHttp.onreadystatechange = function () {
		if(xmlHttp.responseURL !== url){
			document.location.href = xmlHttp.responseURL;
		}
		if (xmlHttp.readyState === 4 && xmlHttp.status === 200) {
			callback(xmlHttp.responseText);
		}
	};

	xmlHttp.send(parameters);
}