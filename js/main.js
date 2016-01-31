'use strict';

/** todo: Refactor hardcoded data. */
var data = {
    elements: {
        strengths: {
            water: ['fire', 'organic'],
            fire: ['earth', 'organic'],
            earth: ['water', 'air'],
            organic: ['air', 'earth'],
            air: ['water', 'fire']
        }
    },
    player: {
        elements: ['water', 'fire', 'water', 'water', 'water']
    },
    enemy: {
        elements: ['fire', 'water', 'water', 'fire', 'water']
    }
};

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

    create: function() {
        // todo: remove after done with debugging
        window.debug = this;

        this.input.maxPointers = 1;
        this.stage.disableVisibilityChange = false;
        this.scale.scaleMode = Phaser.ScaleManager.SHOW_ALL;
        this.scale.minWidth = 800;
        this.scale.minHeight = 600;
        this.scale.pageAlignHorizontally = true;
        this.scale.pageAlignVertically = true;
        this.stage.forcePortrait = true;
        this.input.addPointer();
        this.stage.backgroundColor = '#171642';

        // game background
        this.game.add.sprite(0, 0, 'background');

        var graphics = this.game.add.graphics(0, 0);
        graphics.beginFill(0xfff000, 1);
        graphics.drawCircle(415, 310, 215);
        
        //create battlebox
        this.battlebox = this.game.add.sprite(
            this.game.world.centerX,
            this.game.world.centerY,
            'battle_box'
        );
        this.battlebox.scale.setTo(0.5);
        this.battlebox.anchor.setTo(0.5);

        // create characters
        this._createSide('player');
        this._createSide('enemy');

        this._score = {
            player: this.game.add.text(60, 100, this._battle.score.player, { fontSize: '20px', fill: '#000' }),
            enemy: this.game.add.text(this.game.width - 60, 100, this._battle.score.enemy, { fontSize: '20px', fill: '#000' })
        };
    },

    update: function() {}
};

game.state.add('GameState', GameState);
game.state.start('GameState');
