const util = require('util');
const bleno = require('bleno');
const DataChar = require('./DataChar');

//const DataServiceUUID = '12345555555555555555555555555501';
const DataServiceUUID = "C103"; // keyboard uuid

function DataService(dataCenter){
	bleno.PrimaryService.call(this, {
		uuid: DataServiceUUID,
		characteristics: [
			new DataChar(dataCenter)
		]
	});
}

util.inherits(DataService, bleno.PrimaryService);

module.exports = DataService;
