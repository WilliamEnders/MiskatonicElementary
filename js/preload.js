'use strict';
 
window.PreloadState = {
	preload: function(){ 
        //battle
        this.load.image('background', 'assets/background.png');
        this.load.image('battle_box', 'assets/GUI-circle.png');

        // there are 5 slots for each character
        this.load.image('slot', 'assets/slot.png');

        // todo: update after done with debugging
        //this.load.image('mystery_slot', 'assets/mystery_slot.png');
        this.load.image('mystery_slot', 'assets/clear.png');

        this.load.image('player', 'assets/mainguy.png');
        this.load.image('enemy', 'assets/chad.png');

        this._tokens = {
            earth: this.load.image('earth', 'assets/tokens/token_earth.png'),
            air: this.load.image('air', 'assets/tokens/token_air.png'),
            organic: this.load.image('organic', 'assets/tokens/token_organic.png'),
            water: this.load.image('water', 'assets/tokens/token_water.png'),
            fire: this.load.image('fire', 'assets/tokens/token_fire.png')
        };

        // preload outcome assets here to prevent blue flash
        // todo: refactor and do this correctly
        this.load.image('background', 'assets/background.png');
        this.load.image('btn_tryagain', 'assets/btn_tryagain.png');
        this.load.image('btn_playagain', 'assets/btn_playagain.png');
        this.load.image('victory_text', 'assets/txt_victory.png');

        // load monster placeholder
        this.load.image('monster', 'assets/WoolColossus.png');

        // music
        this.load.audio('music', ['assets/audio/pumped_up.mp3']);

        //outcome
        this.load.image('background', 'assets/background.png');
        this.load.image('btn_tryagain', 'assets/btn_tryagain.png');
        this.load.image('btn_playagain', 'assets/btn_playagain.png');
        this.load.image('victory_text', 'assets/txt_victory.png');
	},

  	create: function(){
		this.game.state.start('Outcome', true, false, 'win');
	}
};
