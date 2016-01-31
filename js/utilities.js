(function(){
    'use strict';
    
    /**
     * Randomizes and mutates array.
     * 
     * @param {Array} array - The array.
     */
    window.randomize = function(array) {
        var i = array.length - 1;
        for (; i > 0; i--) {
            var tempval = Math.floor(Math.random() * i);
            var curval = array[i];
            array[i] = array[tempval];
            array[tempval] = curval;
        }
    };
})();
