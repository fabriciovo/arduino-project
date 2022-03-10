// setup pins
const char BUTTON_PIN = 7;
bool pressed = false;
          
void setup() {
 Serial.begin(9600);
// Setup pin modes
 pinMode(BUTTON_PIN, INPUT_PULLUP);
}
void loop() {
 // Read button
 bool currentState = digitalRead(BUTTON_PIN);
 if (currentState == pressed) {
  Serial.println(10);
  delay(500);
 }
}
