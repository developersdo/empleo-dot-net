var NewJob = function() {

    var onGoogleMapPlaceChanged = function(place) {
        
        if (place) {
            var latitude = place.geometry.location.lat();
            var longitude = place.geometry.location.lng();
            var placeId = place.place_id;

            $('#location-latitude').val(latitude);
            $('#location-longitude').val(longitude);
            $('#location-placeid').val(placeId);
        } else {
            $('#location-input').val('');
            $('#location-latitude').val('');
            $('#location-longitude').val('');
            $('#location-placeid').val('');
        }
    }

    return {

        preventSubmitOnEnter : function(e) {
            if (e.keyCode == 13) {
                e.preventDefault();
            }
        },

        googleMapDOMListener : function() {
                google.maps.event.addDomListener(window,
                    'load',
                    function() {
                        var places = new google.maps.places.Autocomplete(document.getElementById('location-input'));

                        google.maps.event.addListener(places,
                            'place_changed',
                            function () {
                                var place = places.getPlace();
                                onGoogleMapPlaceChanged(place);
                            });
                    });
        }
    };
}


$(function() {
    var newJob = new NewJob();
    newJob.googleMapDOMListener();
    $("#location-input").on("keypress", function (e) { newJob.preventSubmitOnEnter(e) });
});