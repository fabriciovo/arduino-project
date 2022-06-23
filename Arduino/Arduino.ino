
#define left7 7
#define right6 6
#define up5 5
#define down4 4
#define button3 3

int valorSensor7 = 0;
int valorSensor6 = 0;
int valorSensor5 = 0;
int valorSensor4 = 0;
int valorSensor3 = 0;

void setup()
{

  pinMode(left7, INPUT);
  pinMode(right6, INPUT);
  pinMode(down4, INPUT);
  pinMode(up5, INPUT);
  pinMode(button3, INPUT);

  Serial.begin(9600);
}
void loop()
{

  int valorSensor7 = pulseIn(left7, HIGH, 20000);
  int valorSensor6 = pulseIn(right6, HIGH, 20000);
  int valorSensor5 = pulseIn(up5, HIGH, 20000);
  int valorSensor4 = pulseIn(down4, HIGH, 20000);
  int valorSensor3 = digitalRead(button3);

  if (valorSensor7 > 0)
  {
    Serial.println("L");
  }
  if (valorSensor6 > 0)
  {
    Serial.println("R");
  }
  if (valorSensor5 > 0)
  {
    Serial.println("U");
  }
  if (valorSensor4 > 0)
  {
    Serial.println("D");
  }
  if (valorSensor3 == 1)
  {
    Serial.println("JUMP");
  }
}
