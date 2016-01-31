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

    /** Preload state. */
    preload: function() {
        this.load.image('background', 'assets/background.png');
        this.load.image('btn_tryagain', 'assets/btn_tryagain.png');
        this.load.image('btn_playagain', 'assets/btn_playagain.png');
        this.load.image('victory_text', 'assets/txt_victory.png');
    },

    /** Create state. */
    create: function() {
        var button;
        console.log(this._outcome);

        // game background
        this.game.add.sprite(0, 0, 'background');

        if (this._outcome === 'draw' || this._outcome === 'lose') {
            button = this.game.add.sprite(
                this.game.world.centerX,
                this.game.world.centerY,
                'btn_tryagain'
            );
        } else {
            // display the code to pass back to unity
            var victoryText = this.game.add.sprite(
                    0,
                    0,
                    'victory_text'
                );
            button = this.game.add.sprite(
                this.game.world.centerX,
                this.game.world.centerY,
                'btn_playagain'
            );
        }

        button.scale.setTo(0.1);
        button.anchor.setTo(0.5);

        button.inputEnabled = true;
        button.events.onInputDown.add(this._clickButton, this);
    },

    /**
     * Clicks button to restart game.
     */
    _clickButton: function() {
        this.state.start('Battle', true, true);
    }
};
