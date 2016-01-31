'use strict';

var Phaser = window.Phaser;
var game = new Phaser.Game(800, 600, Phaser.AUTO);

var GameState = {
    preload: function() {
        this.load.image('background', 'assets/background.png');
        this.load.image('battle_box', 'assets/GUI-circle.png');

        // there are 5 slots for each character
        this.load.image('slot', 'assets/slot.png');

        // todo: update after done with debugging
        //this.load.image('mystery_slot', 'assets/mystery_slot.png');
        this.load.image('mystery_slot', 'assets/clear.png');

        this.load.image('player', 'assets/player.png');
        this.load.image('enemy', 'assets/enemy.png');

        this._tokens = {
            earth: this.load.image('earth', 'assets/tokens/token_earth.png'),
            air: this.load.image('air', 'assets/tokens/token_air.png'),
            organic: this.load.image('organic', 'assets/tokens/token_organic.png'),
            water: this.load.image('water', 'assets/tokens/token_water.png'),
            fire: this.load.image('fire', 'assets/tokens/token_fire.png')
        };
    },

    create: function() {},
    update: function() {}
};

game.state.add('GameState', GameState);
game.state.start('GameState');
