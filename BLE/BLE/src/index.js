const BlePkg = require('./BlePkg');

const mainInterval = process.env.mainInterval;
var cnt=0;

/**
	@params data 입력받은 센서 데이터
	@params updateValue 블루투스로 전송할 데이터
		=> 8Bit Data만 가능!(0 ~ 255)
*/
const Callback = (data, updateValue)=>{
	// console.log(data);
	// data.MPU6050.Gyro[0] = Math.sqrt(data.MPU6050.Gyro[0])
	// data.MPU6050.Gyro[1] = Math.sqrt(data.MPU6050.Gyro[1])
	// data.MPU6050.Gyro[2] = Math.sqrt(data.MPU6050.Gyro[2])
	// console.log(typeof(data.MPU6050.Gyro));
	console.clear();
	console.log(data.MPU6050);
	// console.log(data);
	// cnt++;
	// console.log(cnt);
	const { MPU6050, HCSR04 } = data;

	if(
		(MPU6050.Accel[0] >= -14000 && MPU6050.Accel[0] <= -8000) &&
		(MPU6050.Accel[1] >= -2000 && MPU6050.Accel[1]<= 4000)
	)
	{
		updateValue(parseInt(0))
	}else if(
		(MPU6050.Accel[0] >= 3000 && MPU6050.Accel[0] <= 8000) &&
		(MPU6050.Accel[1] >= 8000 && MPU6050.Accel[1]<= 14000)
	)
	{
		updateValue(parseInt(2));
	}else{
		updateValue(parseInt(1));
	}
	// console.log(MPU6050.Accel);
	// console.log(typeof(MPU6050.Accel[0]));

	// if(60 <= HCSR04 && HCSR04 <= 100 )
	// 	updateValue(parseInt(1));
}

/**
	@params Callback
	@params ms Process가 동작할 주기
*/
BlePkg.registProcess( Callback, mainInterval );
