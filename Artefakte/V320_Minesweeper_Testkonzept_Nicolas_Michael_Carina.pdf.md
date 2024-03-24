---
runme:
  id: 01HSS6CY3H3FEFQKRQCFP0YSG2
  version: v3
---

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

