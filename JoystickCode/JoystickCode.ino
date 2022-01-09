const int x = A0;
const int y = A1;
int curX = 0;
int curY = 0;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(57600);
  pinMode(x, INPUT);
  pinMode(y, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  curX = analogRead(x);
  curY = analogRead(y);
  //Serial.print("x:");
  //Serial.println(curX);
  //Serial.print("y:");
  //Serial.println(curY);
  //delay(2000);

  if(curX>=1000){
    Serial.write(6);
    Serial.flush();
    delay(100);
  }
  else if(curX==0){
    Serial.write(4);
    Serial.flush();
    delay(100);
  }
  else if(curY==0){
    Serial.write(8);
    Serial.flush();
    delay(100);
  }
  else if(curY>=1000){
    Serial.write(2);
    Serial.flush();
    delay(100);
  }
  
}
