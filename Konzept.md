#Das Konzept

# Konzept #

Es soll eine Schnittstelle geschaffen werden, mit der es möglich ist Werte aus einem Powershellscript in eine HTML basierte zu importieren.
## Powershell Seite ##
Von einem Powershellscript wird eine bestimmte Ausgabe erwartet, welche dann von der Schnittstelle entgegenkommen wird und entweder in eine CSV oder einer XML Datei abgelegt.
Inhalt der **CSV** Datei sollen zum Monitoring von z.B. CPU, RAM, HDD Space über einen längeren Zeitraum dienen.
Inhalt der **XML** Dateien sind Systeminformationen und Statusangaben zum System. Welche Dienste sind installiert? Welchen Status haben diese Dienste? Ist die Festplatte voll?
## HTML Seite ##
Es kann eine HTML Vorlage erstellt werden, welche bestimmte Markups enthält. Die Schnittstelle erstellt bei Aufruf einer entsprechenden URL aus der Vorlage und den Daten aus XML und CSV eine neue HTML Seite.
Vorlagen:
  * home.html
  * server.html
  * server\_detail.html