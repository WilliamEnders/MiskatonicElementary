'use strict';

var Phaser = window.Phaser;

window.OutcomeState = {
    /**
     * Initialize outcome state.
     *
     * @param {String} - The outcome.
     */
    init: function(outcome) {
        this._outcome = outcome;
    },

    /** Preload state. */
    preload: function() {
        this.load.image('background', 'assets/background.png');
    },

    /** Create state. */
    create: function() {
    }
};
