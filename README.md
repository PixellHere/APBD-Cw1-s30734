# APBD‑Cw1‑s30734

## Opis projektu
APBD‑Cw1‑s30734 to aplikacja konsolowa w C#, która obsługuje uczelnianą wypożyczalnię sprzętu. System modeluje urządzenia (takie jak laptopy, projektory czy kamery), śledzi ich status dostępności, obsługuje procesy wypożyczania i zwrotów, pozwala na oznaczanie sprzętu jako niedostępnego (np. z powodu serwisu/uszkodzenia) oraz generuje podstawowe raporty. 

## Decyzje projektowe

- **Struktura katalogów i warstwy** – Główne przestrzenie nazw odzwierciedlają logiczny podział aplikacji, oddzielając od siebie interfejs konsolowy, logikę biznesową i model domeny.
  - `APBD_Cw1_s30734.Models`: Klasy przechowujące stan i dane. Obejmują część wspólną dla sprzętu (klasa bazowa `Item`) oraz klasy dziedziczące, mające własne, specyficzne pola (`Laptop`, `Projector`, `Camera`). Znajdują się tu również modele reprezentujące użytkowników (`Student`, `Employee`) oraz szczegóły wypożyczenia (`ItemRental`).
  - `APBD_Cw1_s30734.Service`: Klasy (np. `ItemService`, `ServicingService`, `RentalService`) skupiające w sobie czystą logikę operacyjną. Dzięki temu ominięto umieszczenie całej logiki biznesowej w `Program.cs` lub w jednej ogromnej klasie `App`.

- **Kohezja (Spójność)** – Klasy w projekcie posiadają jedną, wyraźną odpowiedzialność.
  - `ItemService` wie jedynie, jak tworzyć sprzęt i pobierać jego listy.
  - `RentalService` zajmuje się wyłącznie procesem najmu. To tutaj scentralizowana jest logika decyzyjna: pilnowanie limitów (maksymalnie 2 aktywne wypożyczenia dla studenta i 5 dla pracownika) oraz wyliczanie kar za opóźnienia. Dzięki temu zasady te nie są rozproszone po całym kodzie, co czyni je łatwymi do ewentualnej zmiany.

- **Coupling (Zależności)** – Zadbano o uniknięcie silnego sprzężenia (couplingu) pomiędzy serwisami.
  - Serwisy opierają się na modelach z warstwy `Models` i nie wywołują się nawzajem bez wyraźnej potrzeby. Zamiast budować skomplikowaną bazę danych w ramach tego ćwiczenia, serwisy działają na współdzielonych listach w pamięci, co redukuje narzut technologiczny, zachowując poprawną logikę.
  - Zmiana statusu sprzętu, wypożyczenie czy oznaczenie niedostępności są realizowane jawnie – w przypadku próby wykonania błędnej akcji (np. wypożyczenie niedostępnego urządzenia), system czytelnie blokuje operację bez "wywracania" aplikacji.

## Użytkowanie (Scenariusz demonstracyjny)
Program należy uruchomić korzystając z wiersza poleceń. Metoda `Main` w pliku `Program.cs` służy jako scenariusz demonstracyjny prezentujący poprawne działanie systemu. Uruchomienie aplikacji automatycznie zaprezentuje:
1. Dodanie kilku egzemplarzy sprzętu oraz użytkowników.
2. Poprawne wypożyczenie sprzętu.
3. Próbę przekroczenia limitu wypożyczeń lub wypożyczenia uszkodzonego urządzenia (zablokowaną przez logikę).
4. Terminowy zwrot sprzętu.
5. Opóźniony zwrot, skutkujący poprawnym naliczeniem kary.
6. Wyświetlenie końcowego raportu podsumowującego dostępność sprzętu w wypożyczalni.

## Budowanie i uruchamianie
Poniżej znajduje się krótka instrukcja uruchomienia projektu z poziomu terminala:

```bash
# Przywracanie pakietów (opcjonalne, w zależności od środowiska)
dotnet restore
# Budowanie aplikacji
dotnet build
# Uruchomienie programu
dotnet run