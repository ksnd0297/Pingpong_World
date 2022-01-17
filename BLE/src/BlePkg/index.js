require('dotenv').config();

const MPU6050 = require('./MPU6050');
const HCSR04 = require('./HCSR04');
const DataCenter = require('./DataCenter');
const Ble = require('./Ble');

MPU6050.start();
HCSR04.start();

const dataCenter = new DataCenter();
dataCenter.setSensor(MPU6050);
dataCenter.setSensor(HCSR04);
Ble(dataCenter);


module.exports = {
	registProcess: (cb, ms)=>{
		dataCenter.registProcess(cb, ms);
	},
	stopProcess: ()=>{
		dataCenter.stopProcess();
	}
}
