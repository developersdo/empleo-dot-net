(function($) {
	
	// Check if the section has the parallax class.
	if ($('section').hasClass('parallax')) {
		$('section.parallax').data('type', 'background');
		$('section.parallax').data('speed', '3');
	}

	$(document).ready( function() {
		// Cache the Window object
		$window = $(window);

		// $('section[data-type="background"]').each(function() {
		$('section.parallax').each(function() {
			// assigning the object
			var $bgobj = $(this);

			$(window).scroll(function() {
				// Scroll the background at var speed
				// the yPos is a negative value because we're scrolling it UP!
				var yPos = -(($(window).scrollTop() - $bgobj.offset().top) / $bgobj.data('speed'));

				// Put together our final background position
				var coords = '50% ' + yPos + 'px';

				// Move the background
				$bgobj.css({ backgroundPosition: coords });
			});
			// window scroll Ends
		});
	});
})(jQuery);