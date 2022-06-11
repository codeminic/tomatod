/* #include "DRV8825.h"

#define CW 0
#define CCW 1

class Driver
{

private:
    DRV8825 _stepper;
    short _enable_pin;
    short _reset_pin;
    short _rotateCw_pin;
    short _rotateCcw_pin;
    short _cwLimit_pin;
    short _ccwLimit_pin;

    bool _prev_rot_ccw = false;
    bool _prev_rot_cw = false;
    bool _is_rotating = false;
    bool _direction = CW;

public:
    Driver(short steps, short dir_pin, short step_pin, short sleep_pin, short mode0_pin, short mode1_pin, short mode2_pin, short enablePin, short reset_pin, short rotateCw_Pin, short rotateCcw_pin, short cwLimit_pin, short ccwLimit_pin);

    void begin(float rpm = 60, short microsteps = 1);

    void setSpeedProfile(short accel, short decel);

    void next();
}; */