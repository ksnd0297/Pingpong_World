const MPU6050Interval = process.env.MPU6050Interval * 1; // ms
const Sensor = require('./sensor');

const MPU6050 = (function(){
	function MPU6050(){
		this.sensorIntervalIdx = null;
		this.value = null;
		console.log("MPU6050 Done.");
	}

	MPU6050.prototype.getData = function(){
		return { MPU6050: this.value };
	}

	MPU6050.prototype.getSensorData = function(){
		const result = {};
		result.Temp = Sensor.getTemp();
		result.Accel = Sensor.getAccel();
		result.Gyro = Sensor.getGyro();
		return result;
	}

	MPU6050.prototype.start = function(){
		if(this.sensorIntervalIdx != null) throw("MPU6050 is already start");
		const self = this;

		this.sensorIntervalIdx = setInterval( ()=> {
			self.value = self.getSensorData();
		} , MPU6050Interval );
	}

	MPU6050.prototype.stop = function(){
		if(this.sensorIntervalIdx != null){
			clearInterval(this.sensorIntervalIdx);
		}
	}

	return new MPU6050();
})();

module.exports = MPU6050;
