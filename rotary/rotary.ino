int counter = 0;
int aState;
int aLastState;

// Pin definitions
const int dataPin = 18; 
const int clkPin = 19;  
const int startButtonPin = 23;
const int resetButtonPin = 22; 
const int stopButtonPin = 27;   

// Button states
int startButtonState = HIGH;
int lastStartButtonState = HIGH;
int resetButtonState = HIGH;
int lastResetButtonState = HIGH;
int stopButtonState = HIGH;
int lastStopButtonState = HIGH;
bool isStopped = false;

void setup() {
  pinMode(dataPin, INPUT);
  pinMode(clkPin, INPUT);
  
  // Set up buttons
  pinMode(startButtonPin, INPUT_PULLUP);
  pinMode(resetButtonPin, INPUT_PULLUP);
  pinMode(stopButtonPin, INPUT_PULLUP); 
  
  Serial.begin(9600);
  aLastState = digitalRead(clkPin);
}

void loop() {
  // Handle rotary encoder
  if (!isStopped) {
    aState = digitalRead(clkPin);
    if (aState != aLastState) {
      if (digitalRead(dataPin) != aState) {
        counter++;
      } else {
        counter--;
      }
      if (counter < 0) {
        counter = 0;
      }
      Serial.print("Counter: ");
      Serial.println(counter);
    }
    aLastState = aState;
  }

  // Handle Start button
  startButtonState = digitalRead(startButtonPin);
  if (startButtonState == LOW && lastStartButtonState == HIGH) {
    Serial.println("Status: Start");
    isStopped = false; // Allow changes to counter
  }
  lastStartButtonState = startButtonState;

  // Handle Reset button
  resetButtonState = digitalRead(resetButtonPin);
  if (resetButtonState == LOW && lastResetButtonState == HIGH) {
    counter = 0;
    Serial.println("Status: Reset");
  }
  lastResetButtonState = resetButtonState;

  // Handle Stop button
  stopButtonState = digitalRead(stopButtonPin);
  if (stopButtonState == LOW && lastStopButtonState == HIGH) {
    Serial.println("Status: Stop");
    isStopped = true; // Prevent changes to counter
  }
  lastStopButtonState = stopButtonState;

  delay(10);
}
