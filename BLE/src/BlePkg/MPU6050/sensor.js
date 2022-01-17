const i2c = require('i2c-bus');

const Code = require('./code');

const i2c1 = i2c.openSync(1);
console.log('connect mpu6050');

i2c1.writeByteSync(Code.MCP6050_LOW, Code.RA_PWR_MGMT_1, 0);
console.log('wake up mpu6050');

function getByte(high, low){
	const H = i2c1.readByteSync(Code.MCP6050_LOW, high);
	const L = i2c1.readByteSync(Code.MCP6050_LOW, low);
	
	const buf = Buffer.from([H, L]);
	return buf.readInt16BE();
}

function getTemp(){
	return getByte(Code.TEMP_OUT_H, Code.TEMP_OUT_L) / 340 + 36.53;
}
exports.getTemp = getTemp;

function getGyro(){
	const X = getByte(Code.GYRO_XOUT_H, Code.GYRO_XOUT_L);
	const Y = getByte(Code.GYRO_YOUT_H, Code.GYRO_YOUT_L);
	const Z = getByte(Code.GYRO_ZOUT_H, Code.GYRO_ZOUT_L);

	return [X, Y, Z];
}
exports.getGyro = getGyro;

function getAccel(){
	const X = getByte(Code.ACCEL_XOUT_H, Code.ACCEL_XOUT_L);
	const Y = getByte(Code.ACCEL_YOUT_H, Code.ACCEL_YOUT_L);
	const Z = getByte(Code.ACCEL_ZOUT_H, Code.ACCEL_ZOUT_L);

	return [X, Y, Z];
}
exports.getAccel = getAccel;

process.on('exit', ()=>{
	console.log('disconnect mpu6050');
	i2c1.closeSync();
});
