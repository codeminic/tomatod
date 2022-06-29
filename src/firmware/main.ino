#include <EspMQTTClient.h>
#include <Arduino.h>
#include <ESP8266WiFi.h>
#include <DRV8825.h>
#include "wemos-d1.h"
#include "secrets.h"

#define MOTOR_STEPS 200
#define MOTOR_RPM 150
#define ENABLE D6
#define DIR D7
#define STEP D8

EspMQTTClient client(WLAN_SSID, WLAN_PWD, MQTT_BROKER, MQTT_USER, MQTT_PWD, MQTT_CLIENTNAME, MQTT_PORT);

DRV8825 stepper(MOTOR_STEPS, DIR, STEP, ENABLE);

void onConnectionEstablished()
{
    client.subscribe("greenhouse/water", waterPlants);
    client.subscribe("greenhouse/shutter/close", closeShutter);
    client.subscribe("greenhouse/shutter/open", openShutter);
}

void openShutter(String payload)
{
    Serial.println("Open shutter");
    stepper.enable();
    delay(500);
    int rotations = 200;
    long steps = rotations * 360;
    stepper.rotate(steps);
    delay(500);
    stepper.disable();
}

void closeShutter(String payload)
{
    Serial.println("Close shutter");
    stepper.enable();
    delay(500);
    int rotations = 200;
    long steps = rotations * -360;
    stepper.rotate(steps);
    delay(500);
    stepper.disable();
}

void waterPlants(String payload)
{
    Serial.println("Watering da plantz");
    digitalWrite(D1, HIGH);
    delay(5000);
    digitalWrite(D1, LOW);
}

void setup()
{
    Serial.begin(115200);

    pinMode(D1, OUTPUT);

    stepper.begin(MOTOR_RPM, 32);
    stepper.disable();
    stepper.setSpeedProfile(BasicStepperDriver::LINEAR_SPEED, 50, 50);

    client.enableDebuggingMessages(); // Enable debugging messages sent to serial output
}

void loop()
{
    client.loop();
    delay(500);
}
