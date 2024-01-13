#include <M5StickC.h>
#include "BluetoothSerial.h"
#include <string>

BluetoothSerial SerialBT;

float accX = 0;
float accY = 0;
float accZ = 0;

void setup() {
  M5.begin();
  M5.Lcd.setRotation(3);
  M5.Lcd.fillScreen(BLACK);
  M5.Lcd.setTextSize(1);
  M5.Lcd.setTextFont(1);
  M5.Lcd.setCursor(0, 0);
  M5.Lcd.println("  X       Y       Z");
  SerialBT.begin("M5StickCBT");
  M5.MPU6886.Init();
}

void loop() {
  M5.MPU6886.getAccelData(&accX, &accY, &accZ);
  M5.Lcd.setCursor(0, 30);
  M5.Lcd.printf("%.2f   %.2f   %.2f      ", accX * 1000, accY * 1000,
                accZ * 1000);
  M5.Lcd.setCursor(140, 30);
  M5.Lcd.print("mg");

  if (Serial.available()) {
    std::string msg;
    msg = std::to_string(accX);
    Serial.print(msg);
  }

  delay(100);
}