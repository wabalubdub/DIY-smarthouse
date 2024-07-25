#include <ESP32Servo.h>

#include <ArduinoJson.h>

#include <AsyncFsWebServer.h>
#include <WiFi.h>


const char *ssid = "wifiname";
const char *password = "wifipasswprd";

AsyncWebServer server(80);
Servo myservo;

void setup() {

  Serial.begin(115200);
  
  //servo setup
  myservo.attach(2);
  myservo.write(0);

  // Connect to Wi-Fi
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(1000);
    Serial.println("Connecting to WiFi...");
  }
  Serial.println("Connected to WiFi");
  Serial.println(WiFi.localIP());
  
  
  // Define REST endpoints
  server.on("/function-off", HTTP_GET, [](AsyncWebServerRequest *request){
    // Perform hardware function here (e.g., turn on an LED)
    myservo.write(90);

    request->send(200, "text/plain", "servo turned to 90");
  });

  server.on("/function-on", HTTP_GET, [](AsyncWebServerRequest *request){
    // Perform hardware function here (e.g., turn off an LED)
    myservo.write(0);

    request->send(200, "text/plain", "servo turned to 0");
  });

  // Start server
  server.begin();
}

void loop() {
  // Your main code here
}
