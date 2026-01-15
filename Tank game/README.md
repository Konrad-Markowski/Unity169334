# Tank Game

Gra akcji 3D, w której gracz steruje czołgiem i walczy z wrogimi czołgami na różnych poziomach.

## Opis gry

Tank Game to gra akcji, w której gracz kontroluje czołg i musi przetrwać oraz zniszczyć wszystkich wrogów na każdym poziomie. Wrogowie są rozsiani po mapie i aktywnie ścigają gracza, gdy zostaną wykryci. Za każde celne trafienie gracz otrzymuje punkty, które są mnożone przez wartość combo - im więcej trafień z rzędu, tym wyższy mnożnik punktów!

## Mechanika gry

### System punktacji
- **Punkty bazowe**: 10 punktów za każde trafienie we wroga
- **System combo**: Każde celne trafienie zwiększa wartość combo
- **Punktacja**: `Punkty = 10 × wartość_combo`
- **Najlepszy wynik**: Gra zapisuje najlepszy wynik i wyświetla go w menu

### Sterowanie
- **Ruch**: Strzałki / WASD - poruszanie czołgiem do przodu/tyłu i obracanie
- **Celowanie**: Mysz - głowica czołgu celuje w kierunku kursora myszy
- **Strzał**: Lewy przycisk myszy - wystrzał pocisku

### Wrogowie
- Wrogowie używają AI opartego na NavMesh
- Wykrywają gracza w zasięgu 25 jednostek
- Ścigają gracza i strzelają, gdy są w zasięgu strzału (15 jednostek)
- Gubią gracza, gdy oddali się na więcej niż 40 jednostek

### Poziomy
Gra zawiera kilka poziomów (Level1, Level2, Level3), które są poziomami podłużnymi z różnym ułożeniem modeli będacych osłonami dla gracza.

## Struktura projektu

```
Assets/
├── Scripts/              # Skrypty C# gry
│   ├── PlayerController.cs      # Sterowanie gracza
│   ├── EnemyAI.cs               # AI wrogów
│   ├── PointTracker.cs          # System punktacji i combo
│   ├── Health.cs                # System zdrowia
│   ├── ShootShell.cs            # Mechanika strzelania
│   ├── Shell.cs                 # Skrypt pocisku
│   ├── HUDDisplay.cs            # Wyświetlanie interfejsu
│   ├── CameraFollow.cs          # Kamera podążająca za graczem
│   └── ...
├── Scenes/              # Sceny Unity
│   ├── MainMenu.unity           # Menu główne
│   ├── Level1.unity             # Poziom 1
│   ├── Level2.unity             # Poziom 2
│   └── Level3.unity             # Poziom 3
├── Prefabs/            # Prefabrykaty obiektów
├── ShootingSound/      # Dźwięki strzałów
└── FPS Menu Music Themes Vol. 1/  # Muzyka menu
```

## Wymagania

- **Unity**: Wersja zgodna z projektem (sprawdź `ProjectSettings/ProjectVersion.txt`)
- **Input System**: Projekt używa nowego Unity Input System
- **NavMesh**: Wrogowie używają NavMesh do nawigacji

## Instalacja

### Opcja 1: Rozwój w Unity Editor

1. Sklonuj repozytorium:
   ```bash
   git clone https://github.com/Konrad-Markowski/UnityGameProject
   ```

2. Otwórz projekt w Unity Editor

3. Upewnij się, że wszystkie zależności są zainstalowane (Unity powinien je pobrać automatycznie)

4. Otwórz scenę `MainMenu` lub wybrany poziom z folderu `Assets/Scenes/`

### Opcja 2: Build do pliku wykonywalnego (.exe)

1. Pobierz pliki projektu (sklonuj repozytorium lub pobierz jako ZIP)

2. Otwórz projekt w Unity Editor

3. Przejdź do `File > Build Settings`

4. Wybierz platformę `PC, Mac & Linux Standalone` i ustaw `Target Platform` na `Windows`

5. Kliknij `Build` i wybierz folder docelowy

6. Unity wygeneruje plik `.exe`, który można uruchomić bezpośrednio bez Unity Editor

## Rozgrywka

1. **Start**: Uruchom grę i wybierz poziom z menu głównego
2. **Cel**: Zniszcz wszystkich wrogów na poziomie
3. **Strategia**: 
   - Utrzymuj combo, trafiając celnie wrogów z rzędu
   - Unikaj ataków wrogów - mogą cię zniszczyć!
   - Wykorzystuj teren do osłony
4. **Punkty**: Im wyższe combo, tym więcej punktów za trafienie

## Funkcje

- ✅ System poziomów
- ✅ AI wrogów z NavMesh
- ✅ System punktacji z combo
- ✅ Zapisywanie najlepszego wyniku
- ✅ Interfejs użytkownika (HUD)
- ✅ Dźwięki i muzyka
- ✅ Kamera podążająca za graczem
- ✅ System zdrowia

## Autor

Konrad Markowski

---

*README częściowo wygenerowane przez model AI (Auto - agent router zaprojektowany przez Cursor)*
