# Testkonzept Minesweeper

## Testkonzept für die GetDifficulty-Methode in Minesweeper:

1. **Ziel des Tests:**
   - Sicherstellen, dass die GetDifficulty-Methode korrekt auf die Benutzereingabe reagiert und die Schwierigkeitsstufe entsprechend zurückgibt.

2. **Testfälle:**
   a. **GetDifficulty_EasyInput_ReturnsEasy:**
      - Beschreibung: Überprüfen, ob die Methode korrekt "E" zurückgibt, wenn der Benutzer "E" für Easy eingibt.
   b. **GetDifficulty_MediumInput_ReturnsMedium:**
      - Beschreibung: Überprüfen, ob die Methode korrekt "M" zurückgibt, wenn der Benutzer "M" für Medium eingibt.
   c. **GetDifficulty_HardInput_ReturnsHard:**
      - Beschreibung: Überprüfen, ob die Methode korrekt "H" zurückgibt, wenn der Benutzer "H" für Hard eingibt.
   d. **GetDifficulty_InvalidInput_NothingHappens:**
      - Beschreibung: Überprüfen, ob die Methode keine weiteren Aktionen ausführt, wenn der Benutzer eine ungültige Eingabe tätigt.

3. **Testumgebung:**
   - Verwendung einer Unit-Test-Bibliothek (z. B. NUnit).
   - Mocking der Console-Ein- und -Ausgabe für die Simulation von Benutzereingaben und Ausgaben.
   - Einrichtung einer StringReader- und StringWriter-Kombination für die Simulation von Benutzereingaben und -ausgaben.

4. **Testdurchführung:**
   - Jeder Testfall wird unabhängig voneinander durchgeführt.
   - Vor jedem Testfall wird die Console-Ein- und -Ausgabe umgeleitet, um die Benutzereingaben und -ausgaben zu simulieren.
   - Nach jedem Testfall wird die Umleitung der Console-Ein- und -Ausgabe zurückgesetzt.
   - Die erwarteten Ergebnisse werden mit den tatsächlichen Ergebnissen verglichen und bei Übereinstimmung wird der Testfall als erfolgreich markiert.

5. **Berichterstattung:**
   - Die Tests wurden erfolgreich ausgeführt!


## Testkonzept für die GetDifficulty-Methode in Minesweeper:

1. **Ziel des Tests:**
   - Überprüfen, ob die Anzahl der Felder und Bomben korrekt ist, wenn der Benutzer "E", "M" oder "H" für Easy, Medium oder Hard drückt.

2. **Testfälle:**
   a. **GetDifficulty_EasyInput_ReturnsCorrectBoardAndBombCount:**
      - Beschreibung: Überprüfen, ob die Methode korrekt ein Spielfeld mit den spezifizierten Abmessungen für die leichte Schwierigkeitsstufe zurückgibt und die Anzahl der Bomben korrekt ist.
   b. **GetDifficulty_MediumInput_ReturnsCorrectBoardAndBombCount:**
      - Beschreibung: Überprüfen, ob die Methode korrekt ein Spielfeld mit den spezifizierten Abmessungen für die mittlere Schwierigkeitsstufe zurückgibt und die Anzahl der Bomben korrekt ist.
   c. **GetDifficulty_HardInput_ReturnsCorrectBoardAndBombCount:**
      - Beschreibung: Überprüfen, ob die Methode korrekt ein Spielfeld mit den spezifizierten Abmessungen für die schwierige Schwierigkeitsstufe zurückgibt und die Anzahl der Bomben korrekt ist.

3. **Testumgebung:**
   - Verwendung einer Unit-Test-Bibliothek (z. B. NUnit).
   - Mocking der Console-Ein- und -Ausgabe für die Simulation von Benutzereingaben und -ausgaben.
   - Einrichtung einer StringReader- und StringWriter-Kombination für die Simulation von Benutzereingaben und -ausgaben.

4. **Testdurchführung:**
   - Jeder Testfall wird unabhängig voneinander durchgeführt.
   - Vor jedem Testfall wird die Console-Ein- und -Ausgabe umgeleitet, um die Benutzereingaben und -ausgaben zu simulieren.
   - Nach jedem Testfall wird die Umleitung der Console-Ein- und -Ausgabe zurückgesetzt.
   - Die erwarteten Ergebnisse werden mit den tatsächlichen Ergebnissen verglichen und bei Übereinstimmung wird der Testfall als erfolgreich markiert.

5. **Berichterstattung:**
   - Die Tests wurden erfolgreich ausgeführt!

## Testkonzept für die Überprüfung des Spielstates in Minesweeper:

1. **Test der Schwierigkeitsauswahl:**
   - Überprüfen, ob die Schwierigkeitsauswahl korrekt verarbeitet wird und das Spielfeld entsprechend der ausgewählten Schwierigkeit generiert wird.

2. **Test der Spielfeldgenerierung:**
   - Überprüfen, ob das Spielfeld korrekt generiert wird und die Anzahl der Bomben sowie die Positionen der Bomben den Schwierigkeitsparametern entsprechen.

3. **Test der Benutzereingaben:**
   - Überprüfen, ob die Benutzereingaben zum Aufdecken von Feldern, Platzieren von Flaggen und Entfernen von Flaggen korrekt verarbeitet werden.

4. **Test der Gewinnbedingung:**
   - Überprüfen, ob das Spiel korrekt als gewonnen erkannt wird, wenn alle nicht-bombigen Felder aufgedeckt wurden und alle Bomben korrekt markiert wurden.

5. **Test der Verlierungsbedingung:**
   - Überprüfen, ob das Spiel korrekt als verloren erkannt wird, wenn ein Feld mit einer Bombe aufgedeckt wird.

**Testumgebung**:
- Verwendung einer Unit-Test-Bibliothek wie NUnit.
- Verwendung von Mocking-Frameworks für die Simulation von Benutzereingaben und -ausgaben.
- Einrichtung einer Testumgebung, die es ermöglicht, das Spiel in einer kontrollierten Umgebung zu testen.

**Testdurchführung**:
- Jeder Testfall wird unabhängig voneinander durchgeführt.
- Die erwarteten Ergebnisse werden mit den tatsächlichen Ergebnissen verglichen, und bei Übereinstimmung wird der Testfall als erfolgreich markiert.
- Alle Tests werden automatisiert durchgeführt, um die Konsistenz und Wiederholbarkeit der Tests sicherzustellen.

**Berichterstattung**:
- Die Testergebnisse werden dokumentiert und zusammengefasst, um einen klaren Überblick über den Teststatus des Spiels zu geben.
- Fehler werden protokolliert und bei Bedarf an das Entwicklungsteam zurückgemeldet, um Korrekturen vorzunehmen.

