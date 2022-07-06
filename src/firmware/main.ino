#include <DHT_U.h>
#include <DHT.h>

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
#define DHT_PIN D4

EspMQTTClient client(WLAN_SSID, WLAN_PWD, MQTT_BROKER, MQTT_USER, MQTT_PWD, MQTT_CLIENTNAME, MQTT_PORT);

DRV8825 stepper(MOTOR_STEPS, DIR, STEP, ENABLE);

DHT dht(DHT_PIN, DHT22);

ulong previousTime = 0;
ulong intervalTime = 60 * 1000;

void onConnectionEstablished()
{
    client.subscribe("greenhouse/water", waterPlants);
    client.subscribe("greenhouse/shutter/close", closeShutter);
    client.subscribe("greenhouse/shutter/open", openShutter);
}

void openShutter(String payload)
{
    Serial.println("Open shutter");
    client.publish("greenhouse/telemetry/shutter", "opening");
    stepper.enable();
    delay(500);
    int rotations = 200;
    long steps = rotations * 360;
    stepper.rotate(steps);
    delay(500);
    stepper.disable();
    client.publish("greenhouse/telemetry/shutter", "open");
}

void closeShutter(String payload)
{
    Serial.println("Close shutter");
    client.publish("greenhouse/telemetry/shutter", "closing");
    stepper.enable();
    delay(500);
    int rotations = 200;
    long steps = rotations * -360;
    stepper.rotate(steps);
    delay(500);
    stepper.disable();
    client.publish("greenhouse/telemetry/shutter", "closed");
}

void waterPlants(String payload)
{
    Serial.println("Watering da plantz");
    digitalWrite(D1, HIGH);
    delay(5000);
    digitalWrite(D1, LOW);
}

void printMeasurement(float value, String dimension, String unit)
{
    Serial.print(dimension);
    Serial.print(": ");
    Serial.print(value);
    Serial.print(" ");
    Serial.println(unit);
}

void setup()
{
    Serial.begin(115200);

    pinMode(D1, OUTPUT);

    dht.begin();

    stepper.begin(MOTOR_RPM, 32);
    stepper.disable();
    stepper.setSpeedProfile(BasicStepperDriver::LINEAR_SPEED, 50, 50);

    client.enableDebuggingMessages();
}

void loop()
{
    client.loop();

    ulong currentTime = millis();

    if (currentTime - previousTime >= intervalTime)
    {
        float humidity = dht.readHumidity();
        float temperature = dht.readTemperature();

        printMeasurement(temperature, "Temperature", "°C");
        printMeasurement(humidity, "Humidity", "%");

        client.publish("greenhouse/telemetry/humidity", String(humidity));
        client.publish("greenhouse/telemetry/temperature", String(temperature));

        previousTime = currentTime;
    }
}
