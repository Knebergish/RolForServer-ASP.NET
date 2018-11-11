(function () {
    const messages = document.getElementById('messages');
    const textarea = document.getElementById('answer-textarea');
    const button = document.getElementById('submit-button');
    button.onclick = send;

    function send() {
        const text = textarea.value;
        if (text === '')
            return;

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
            '                                        ' + text + '\n' +
            '                                    </div>\n' +
            '                                </div>\n' +
            '                            </div>';
        textarea.value = '';
        const message = document.createElement("Div");
        message.classList.add('message');
        message.innerHTML = html;
        messages.appendChild(message);
    }
})();