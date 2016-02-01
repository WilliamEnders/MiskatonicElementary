'use strict';

var Phaser = window.Phaser;

/** Battle outcome. */
window.OutcomeState = {
    /**
     * Initialize outcome state.
     *
     * @param {String} - The outcome.
     */
    init: function(outcome) {
        this._outcome = outcome;
    },

    /** Create state. */
    create: function() {
        var button;
        console.log(this._outcome);

        // game background
        this.game.add.sprite(0, 0, 'background');

        if (this._outcome === 'draw' || this._outcome === 'lose') {
            button = this.game.add.button(
                this.game.world.centerX,
                this.game.world.centerY,
                'btn_tryagain',
                this._clickButton,
                0, 1, 2
            );
        } else {
            // display the code to pass back to unity
            var victoryText = this.game.add.sprite(
                    0,
                    0,
                    'victory_text'
                );
            button = this.game.add.button(
                this.game.world.centerX,
                this.game.world.centerY,
                'btn_playagain',
                this._clickButton,
                0, 1, 2
            );
        }
        button.scale.setTo(0.1);
        button.anchor.setTo(0.5);

    },

    /**
     * Clicks button to restart game.
     */
    _clickButton: function() {
        this.game.state.start('Battle');
    }
};
