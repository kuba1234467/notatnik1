# Katalog

Trzy ekrany: lista, szczegóły, dodawanie. Dane w `dane/pozycje.txt`. Zasady projektu w `AGENTS.md`.

## Sprawdzenie reguł świeżą sesją

- Przy pierwszym sprawdzeniu (ekran szczegółów, pierwsza wersja `AGENTS.md`): **2** reguły złamane.
  1. Szczegóły dostały gotowy obiekt z listy i nie otworzyły `dane/pozycje.txt` — reguła o pliku danych była za ogólna.
  2. „Krótkie metody” nie dało się zaznaczyć w diffie — to było życzenie, nie reguła.
- Po przepisaniu reguł i ekranie dodawania: **0** złamanych.

## Plik reguł w edytorze (Cursor)

Data sprawdzenia: 17 listopada 2026.

W Cursorze zasady projektu mogą leżeć w dwóch miejscach:

1. **`AGENTS.md`** w katalogu głównym repozytorium (albo w podkatalogu). Zwykły Markdown, bez metadanych. Cursor czyta ten plik i dokłada go do zapytania agenta. Dokumentacja: [Rules — AGENTS.md](https://cursor.com/docs/rules).
2. **`.cursor/rules/*.mdc`** w katalogu głównym przestrzeni roboczej. To natywny format Cursor: YAML z `alwaysApply`, `globs`, `description`. Zwykły `.md` w `.cursor/rules` jest ignorowany.

Ten projekt używa `AGENTS.md`, bo to wspólny format „README dla agentów”, a Cursor go obsługuje.

## Własną ręką

Przycisk **Policz** na ekranie listy: czyta `dane/pozycje.txt` przy każdym kliknięciu i pokazuje liczbę linii.
