const util = require('util');
const bleno = require('bleno');

function DataChar(dataCenter){
	bleno.Characteristic.call(this, {
		uuid: '12345555555555555555555555555511',
		properties: ['read', 'write', 'notify'],
		descriptors: [
			new bleno.Descriptor({
				uuid: '2901',
				value: 'Swing'
			})
		]
	});

	this.dataCenter = dataCenter;
	this.updateValue = null;
}

util.inherits(DataChar, bleno.Characteristic);

DataChar.prototype.setUpdateValueCallback = function(cb){
	this.updateValue = cb;
	const self = this;
	this.dataCenter.updateValue = cb && function(data){
		const buf = new Buffer(1);
		buf.writeUInt8(data,0);
		if(self.updateValue)
			self.updateValue(buf);
	}
}

DataChar.prototype.onSubscribe = function(maxValueSize, updateValueCallback){
	console.log('onSubscribe');
	this.setUpdateValueCallback(updateValueCallback);
}

DataChar.prototype.onUnsubscribe = function(){
	console.log('onUnsubscribe');
	this.setUpdateValueCallback(null);
}

module.exports = DataChar;
