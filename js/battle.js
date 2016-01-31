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
        elements: ['fire', 'fire', 'earth', 'air', 'water']
    },
    enemy: {
        elements: ['fire', 'water', 'water', 'fire', 'water']
    }
};

var Phaser = window.Phaser;

window.BattleState = {
    /** Preload game. */
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

    /** Create game. */
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

    /** The player and enemy slots. */
    _slots: {
        player: [],
        enemy: [],
        mystery: []
    },

    _battle: {
        isReady: true,
        score: {
            player: 0,
            enemy: 0
        },
        currentElement: {
            player: null,
            enemy: null
        }
    },

    /**
     * Create the side for each player. 
     * Creates 5 slots
     * Put elements in each slot
     * Create a Player
     * @param {String} side - The side: player/enemy.
     */
    _createSide: function(side) {
        var slot, i, x, y;
        var slotSpace = 50; // space between slots

        // randomize enemy elements
        if (side === 'enemy'){
            window.randomize(data.enemy.elements);
        }

        for (i = 0; i < 5; i++) {
            var element;
            if (side === 'enemy') {
                x = this.game.width - i * slotSpace - 40;
                y = 30;
                slot = this.game.add.sprite(x, y, 'slot');
                element = this.game.add.sprite(
                    slot.x + slot.width / 2,
                    slot.y + slot.height / 2,
                    data.enemy.elements[i]
                );
                // mystery slot
                this._slots.mystery.push(this.game.add.sprite(x, y, 'mystery_slot'));
            } else if (side === 'player') {
                x = i * slotSpace;
                y = 30;
                slot = this.game.add.sprite(x, y, 'slot');
                element = this.game.add.sprite(
                    slot.x + slot.width / 2,
                    slot.y + slot.height / 2,
                    data.player.elements[i]
                );
            }
            element.scale.setTo(0.10);
            // center sprite anchor point
            element.anchor.setTo(0.5);
            element.type = data[side].elements[i];
            this._slots[side].push(element);
        }

        // bind events
        this._slots.player.forEach(function(element, index){
            element.inputEnabled = true;
            element.events.onInputDown.add(function(){
                if (this._battle.isReady) {
                    this._selectPlayerElement(element, index);
                    this._selectEnemyElement(index);
                }
            }, this);
        }, this);

        // create the player
        var textStyle = {
            font: "14px Arial",
            fill: "black",
            align: "center"
        };

        if (side === 'enemy') {
            this.game.add.sprite(this.game.width - 127, 200, 'enemy');
        } else if (side === 'player') {
            this.game.add.sprite(0, 200, 'player');
        }
    },

    /**
     * Selects player inventory element.
     * 
     * @param {Phaser.Sprite} element - The inventory element.
     */
    _selectPlayerElement: function(element) {
        this._battle.currentElement.player = element;
        this._battle.isReady = false;
        this.game.add.tween(element).to(
            { y: this.battlebox.y, x: this.battlebox.x - 50 },
            1000,
            Phaser.Easing.Quadratic.InOut,
            true
        );
    },

    /**
     * Selects enemy inventory element.
     */
    _selectEnemyElement: function() {
        var self = this;
        // invert selection order
        var element = this._slots.enemy[this._slots.mystery.length - 1];
        this._battle.currentElement.enemy = element;
        var tween = this.game.add.tween(element).to(
            { y: this.battlebox.y, x: this.battlebox.x + 50 },
            1000,
            Phaser.Easing.Quadratic.InOut,
            true
        );

        // invert selection order
        this._slots.mystery[this._slots.mystery.length - 1].kill();
        tween.onComplete.add(function() {
            setTimeout(function() {
                self._setScore();
                self._clearBoard();
            }, 0); // todo: add timeout after debug
        });
        this._slots.mystery.pop();
        this._slots.enemy.pop();
    },

    /**
     * The comparison between player and enemy elements.
     * 
     * @return {String}
     */
    _elementComparison: function() {
        var playerElement = this._battle.currentElement.player;
        var enemyElement = this._battle.currentElement.enemy;
    
        // draw
        if (playerElement.type === enemyElement.type) {
            return 'draw';

        // strengths found
        } else if (data.elements.strengths[playerElement.type].indexOf(enemyElement.type) !== -1) {
            return 'win';

        // strengths not found
        } else if (data.elements.strengths[playerElement.type].indexOf(enemyElement.type) === -1) {
            return 'lose';
        }
    },

    /**
     * Sets the the score for the battle.
     */
    _setScore: function() {
        var outcome = this._elementComparison();
        if (outcome === 'win') {
            this._battle.score.player +=1;
            this._score.player.text = this._battle.score.player;
        } else if( outcome === 'lose') {
            this._battle.score.enemy +=1;
            this._score.enemy.text = this._battle.score.enemy;
        }

        // check battle end
        if (!this._slots.enemy.length) { 
            this.state.start('Outcome', true, false, outcome);
        }
    },

    /**
     * Clears the board.
     */
    _clearBoard: function() {
        this._battle.currentElement.player.kill();
        this._battle.currentElement.enemy.kill();
        this._battle.isReady = true;
    }
};
