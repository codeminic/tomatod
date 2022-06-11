// #include <PubSubClient.h>
// #include <Arduino.h>
// #include <ESP8266WiFi.h>
// #include <DRV8825.h>
// #include "wemos-d1.h"

// #define MOTOR_STEPS 200
// #define MOTOR_RPM 20
// #define DIR D7
// #define STEP D8

// DRV8825 stepper(MOTOR_STEPS, DIR, STEP);

// void setup()
// {
//     stepper.begin(MOTOR_RPM, 32);
//     pinMode(D1, OUTPUT);
// }

// void loop()
// {
//     stepper.rotate(90);
//     digitalWrite(D1, HIGH);
//     delay(1000);
//     digitalWrite(D1, LOW);
//     delay(1000);
// }