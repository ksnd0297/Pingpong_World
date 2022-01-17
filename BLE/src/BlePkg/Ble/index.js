const bleno = require('bleno');
const DataService = require('./DataService');

const name = 'PingPong';

function Ble(dataCenter){
	const dataService = new DataService(dataCenter);

	bleno.on('stateChange', function(state){
		console.log('stateChange', state);

		if(state === 'poweredOn'){
			bleno.startAdvertising(name, [dataService.uuid]);
		}else{
			bleno.stopAdvertising();
		}
	});

	bleno.on('advertisingStart', function(err){
		if(!err){
			console.log('advertisingStart');

			bleno.setServices([
				dataService	
			]);
		}
	});
}

module.exports = Ble;
