function updateSpoilers(document) {
	const texts = document.getElementsByClassName("spoiler-text");
	const buttons = document.getElementsByClassName("spoiler-button");
	for (let i = 0; i < buttons.length; i++) {
		let old_element = buttons[i];
		let new_element = old_element.cloneNode(true);
		old_element.parentNode.replaceChild(new_element, old_element);

		buttons[i].addEventListener('click',
			function () {
				if (texts[i].style.height === '0px' || texts[i].style.height == 0) {
					texts[i].style.height = texts[i].scrollHeight + 'px';
				} else {
					texts[i].style.height = '0px';
				}
			});
	}
}

updateSpoilers(document);