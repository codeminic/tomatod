#include <Arduino.h>
#line 13 "d:\\Projects\\tomato-guard-3000\\src\\firmware\\main.ino"
void setup();
#line 19 "d:\\Projects\\tomato-guard-3000\\src\\firmware\\main.ino"
void loop();
#line 0 "d:\\Projects\\tomato-guard-3000\\src\\firmware\\main.ino"
#line 1 "d:\\Projects\\tomato-guard-3000\\src\\firmware\\driver.cpp"
/* #include <Arduino.h>
#include "driver.h"
#include "DRV8825.h"

Driver::Driver(
    short steps,
    short dir_pin,
    short step_pin,
    short sleep_pin,
    short enable_pin,
    short reset_pin)
    : _stepper(steps, dir_pin, step_pin, sleep_pin, mode0_pin, mode1_pin, mode2_pin)
{
    _enable_pin = enable_pin;
    _reset_pin = reset_pin;
    _rotateCw_pin = rotateCw_pin;
    _rotateCcw_pin = rotateCcw_pin;
    _cwLimit_pin = cwLimit_pin;
    _ccwLimit_pin = ccwLimit_pin;
}

void Driver::begin(float rpm, short microsteps)
{
    pinMode(_rotateCw_pin, INPUT);
    pinMode(_rotateCcw_pin, INPUT);
    pinMode(_cwLimit_pin, INPUT);
    pinMode(_ccwLimit_pin, INPUT);

    pinMode(_enable_pin, OUTPUT);
    pinMode(_reset_pin, OUTPUT);

    _stepper.begin(rpm, microsteps);
    _stepper.setEnableActiveState(HIGH);
}

void Driver::setSpeedProfile(short accel, short decel)
{
    _stepper.setSpeedProfile(_stepper.LINEAR_SPEED, accel, decel);
}

void Driver::next()
{
    // TODO: find out why this does not work in setup()
    digitalWrite(_enable_pin, LOW);
    digitalWrite(_reset_pin, HIGH);

    bool rotate_CCW = !digitalRead(_rotateCcw_pin);
    bool rotate_CW = !digitalRead(_rotateCw_pin);
    bool limit_CCW = !digitalRead(_ccwLimit_pin);
    bool limit_CW = !digitalRead(_cwLimit_pin);

    if (_is_rotating && _direction == CCW && limit_CCW)
    {
        _stepper.stop();
        _is_rotating = false;
        Serial.println("Stopping due to left limit switch");
    }
    if (_is_rotating && _direction == CW && limit_CW)
    {
        _stepper.stop();
        _is_rotating = false;
        Serial.println("Stopping due to right limit switch");
    }
    else if (!limit_CW && !_prev_rot_cw && rotate_CW)
    {
        _stepper.enable();
        _stepper.startRotate(100 * 360);
        _is_rotating = true;
        _direction = CW;
        Serial.println("Starting left rotation");
    }
    else if (!limit_CCW && !_prev_rot_ccw && rotate_CCW)
    {
        _stepper.enable();
        _stepper.startRotate(-100 * 360);
        _is_rotating = true;
        _direction = CCW;
        Serial.println("Starting right rotation");
    }
    else if (_is_rotating && ((_prev_rot_cw && !rotate_CW) || (_prev_rot_ccw && !rotate_CCW)))
    {
        _stepper.startBrake();
        Serial.println("Braking motor");
    }

    _prev_rot_ccw = rotate_CCW;
    _prev_rot_cw = rotate_CW;

    if (_is_rotating)
    {
        unsigned wait_time_micros = _stepper.nextAction();

        // 0 wait time indicates the motor has stopped
        if (wait_time_micros <= 0)
        {
            _stepper.disable();
            _is_rotating = false;
            Serial.println("Motor stopped");
        }
    }
    else
    {
        delay(50);
    }
}
 */
#line 1 "d:\\Projects\\tomato-guard-3000\\src\\firmware\\main.ino"
#include <Arduino.h>
#include <ESP8266WiFi.h>
#include <DRV8825.h>
#include "wemos-d1.h"

#define MOTOR_STEPS 200
#define MOTOR_RPM 20
#define DIR D7
#define STEP D8

DRV8825 stepper(MOTOR_STEPS, DIR, STEP);

void setup()
{
    stepper.begin(MOTOR_RPM, 32);
    pinMode(D1, OUTPUT);
}

void loop()
{
    stepper.rotate(90);
    digitalWrite(D1, HIGH);
    delay(1000);
    digitalWrite(D1, LOW);
    delay(1000);
}
