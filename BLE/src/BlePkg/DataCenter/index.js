const util = require('util');
const events = require('events');

function DataCenter(sensor){
	events.EventEmitter.call(this);
	this.processIntervalIdx = null;
	this.updateValue = null;
	this.sensor = null;
}

DataCenter.prototype.setSensor = function(sensor){
	if(!this.sensor) this.sensor = [];
	this.sensor.push(sensor);
}

DataCenter.prototype.registProcess = function(processCallback, ms){
	if(this.processIntervalIdx != null) throw('process is already regist');
	const self = this;
	this.processIntervalIdx = setInterval(()=>{
		if(self.sensor && self.updateValue){
			let result = {};
			self.sensor.forEach(i=>{
				result = {
					...result,
					...i.getData()
				};
				// console.log(result);
			})
			processCallback(result, self.updateValue);
		}
	}, ms);
}

DataCenter.prototype.stopProcess = function(){
	if(this.processIntervalIdx != null){
		clearInterval(this.processIntervalIdx);
		this.processIntervalIdx = null;
	}
}

DataCenter.prototype.process = function(){
	if(!this.updateValue) return;
}

util.inherits(DataCenter, events.EventEmitter);

module.exports = DataCenter;
