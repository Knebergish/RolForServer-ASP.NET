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

			const html = '<div class="message">\n' +
				'                                <div class="message-header">\n' +
				'                                    11.11.2018 0:00:00 в 17:13\n' +
				'                                </div>\n' +
				'                                <div class="message-body">\n' +
				'                                    <div class="message-user-info">\n' +
				'                                        <a href="" class="message-user-name blue-link">Аллар Кнебергиш</a>\n' +
				'                                        <img src="/images/avatars/Techpriest.jpg" alt="avatar-image" class="user-avatar">\n' +
				'                                        <div class="user-description">\n' +
				'                                            <details class="spoiler-button">\n' +
				'                                                <summary>Описание</summary>\n' +
				'                                            </details>\n' +
				'                                            <div class="spoiler-text">\n' +
				'                                                Является действующим техножрецом Адептус Механикус. В свободное время любит славить Омниссию и выпивать освящённое машинное масло.\n' +
				'                                            </div>\n' +
				'                                        </div>\n' +
				'                                    </div>\n' +
				'                                    <div class="message-content">\n' +
				'                                        ' +
				text +
				'\n' +
				'                                    </div>\n' +
				'                                </div>\n' +
				'                            </div>';
			htmlTab.textContent = '';
			const message = document.createElement("Div");
			message.classList.add('message');
			message.innerHTML = html;
			messages.appendChild(message);
		}

		selectVisualTab()
	}
})();