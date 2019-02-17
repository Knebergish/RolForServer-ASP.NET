(function () {
	const htmlTabIndicator = document.getElementById('html-tab-indicator');
	const visualTabIndicator = document.getElementById('visual-tab-indicator');
	const visualTab = document.getElementById('visual-tab');
	const htmlTab = document.getElementById('html-tab');

	document.addEventListener('DOMContentLoaded',
		function () {
			document.getElementById('tabs-switcher').onclick = (function () {
				swap();
			});
			visualTab.onkeypress = (function (e) {
				if (e.key === 'Enter') {
					document.execCommand('insertHTML', false, '<br><br>');
					return false;
				}
			});

			document.getElementById('bold-function-button').onclick = (function () {
				document.execCommand('bold', null, null);
			});
			document.getElementById('italic-function-button').onclick = (function () {
				document.execCommand('italic', null, null);
			});
			document.getElementById('underline-function-button').onclick = (function () {
				document.execCommand('underline', null, null);
			});
		});

	function selectHTMLTab() {
		htmlTab.textContent = visualTab.innerHTML;
		swapTabs(visualTab, htmlTab, visualTabIndicator, htmlTabIndicator);
	}

	function selectVisualTab() {
		visualTab.innerHTML = htmlTab.textContent;
		swapTabs(htmlTab, visualTab, htmlTabIndicator, visualTabIndicator);
	}

	function swap() {
		if (htmlTab.hidden) {
			selectHTMLTab();
		} else {
			selectVisualTab();
		}
	}

	function swapTabs(tabToHide, tabToSee, tabToHideIndicator, tabToSeeIndicator) {
		const temp = tabToHide.style.height;
		tabToHide.hidden = true;
		tabToSee.hidden = false;
		tabToSee.style.height = temp;

		tabToHideIndicator.classList.remove('selected');
		tabToSeeIndicator.classList.add('selected');
	}


	//


	const messages = document.getElementById('messages');
	const button = document.getElementById('submit-button');
	button.onclick = send;

	function send() {
		selectHTMLTab();

		const text = htmlTab.textContent;
		if (text !== '') {
			const url_string = window.location.href;
			const url = new URL(url_string);
			const containerId = url.searchParams.get("containerId");
			button.disabled = true;

			ajax("/Messages/Add",
				"containerId=" + containerId + "&text=" + text,
				function (html) {
					htmlTab.textContent = '';
					const message = document.createElement("Div");
					message.classList.add('message');
					message.innerHTML = html;
					messages.appendChild(message);
					updateSpoilers(document);
					htmlTab.innerHTML = '';
					visualTab.innerHTML = '';
					button.disabled = false;
				});
		}

		selectVisualTab();
	}
})();