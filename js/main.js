'use strict';

var Phaser = window.Phaser;
var game = new Phaser.Game(800, 600, Phaser.AUTO);

var GameState = {
    preload: function() {},
    create: function() {},
    update: function() {}
};

game.state.add('GameState', GameState);
game.state.start('GameState');
