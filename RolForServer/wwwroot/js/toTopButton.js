(function () {
	const goTopBtn = document.getElementById('to-top-button');

	window.addEventListener('scroll', trackScroll);
	goTopBtn.addEventListener('click', backToTop);

	function trackScroll() {
		const scrolled = window.pageYOffset;
		const coords = document.documentElement.clientHeight;

		if (scrolled > coords) {
			goTopBtn.classList.add('to-top-button-show');
		}
		if (scrolled < coords) {
			goTopBtn.classList.remove('to-top-button-show');
		}
	}

	function backToTop() {
		if (window.pageYOffset > 0) {
			window.scrollBy(0, -30);
			setTimeout(backToTop, 0);
		}
	}
})();