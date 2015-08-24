# Idee: Ein Nagios ähnlicher Windows Dienst #

Ein eigenständiges Programm, das als HTTP Server dient und auf einem frei definierbaren Port Informationen über ein Windows Setup zusammenzustellen, dabei werden Statusinformationen(OK, Warninng, Error) und Langzeitinformationen (Graphen, Tabellen) zu den einzelnen Servern darstellt.

## Geplante Informationen: ##
  * Festplattenauslastung
  * RAMauslastung
  * CPUauslastung
  * Dienststatus
  * Eventlog

## Genutze Technologien: ##
  * .net 4.0
  * Powershell
  * XML
  * CSV
  * HTML
  * CSS