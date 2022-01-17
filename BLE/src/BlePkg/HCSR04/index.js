const HCSR04Interval = process.env.HCSR04Interval * 1;
const Sensor = require('./sensor');
const HCSR04 = (function(){
  function HCSR04(){
    this.sensorIntervalIdx = null;
    this.value = null;
    console.log("HCSR04 Done.");
  }

  HCSR04.prototype.getData = function(){
    return {
      HCSR04: this.value
    }
  }

  HCSR04.prototype.start = function(){
    if(this.sensorIntervalIdx != null) throw("HCSR04 is already start");
    const self = this;

    Sensor.watchHCSR04( (data)=> {
      self.value = data;
    });

    this.sensorIntervalIdx = setInterval( ()=> {
      Sensor.getSignal();
    }, HCSR04Interval); // TODO my interval time
  }

  HCSR04.prototype.stop = function(){
    if(this.sensorIntervalIdx != null){
      Sensor.unWatchHCSR04();
      clearInterval(this.sensorIntervalIdx);
    }
  }

  return new HCSR04();
})();

module.exports = HCSR04;
