# 🛰️ Asteroid Blaster: Rogue Flight

Ein vertikaler **Endless Runner im Weltraum**.  
Du steuerst dein Raumschiff durch ein endloses Asteroidenfeld, weichst aus, sammelst Energie und zerstörst Gegner und Asteroiden, um Upgrades freizuschalten.  
Mit jedem Run verdienst du Ressourcen, die du in permanente **Upgrades** investieren kannst – für mehr Feuerkraft, Leben oder Spezialfähigkeiten.

---

## 🎯 Projektziel

Dieses Projekt wurde entwickelt, um ein **komplettes Mini-Spiel mit professionellen Entwicklungsstrukturen** in Unity umzusetzen.  
Der Fokus liegt dabei auf dem **Erlernen und Anwenden zentraler Game-Development-Patterns** sowie auf der **Integration von CI/CD-Prozessen** zur Automatisierung von Builds und Releases.  

### Lernziele
- Anwendung von **Software-Architekturmustern** (z. B. Object Pooling, State Machine, Observer, Singleton)
- Aufbau einer **skalierbaren Projektstruktur**
- Nutzung von **GitHub Actions für CI/CD**
- **Release-Workflow** verstehen (Versionierung, Patches, Deployment)

---

## 🧩 Kernfeatures

- 🚀 **Endless Gameplay:** Vertikaler Space Runner mit prozeduralen Gegnerwellen  
- ☄️ **Object Pooling:** Performanceoptimiertes Spawning für Asteroiden & Projektile  
- 🔄 **State Machine:** Strukturierte Zustände für Menu, Play, Pause, GameOver  
- 💎 **Rogue-Lite Progression:** Verdiene Energie, um permanente Upgrades freizuschalten  
- 💾 **Save System:** Fortschritt wird zwischen Sessions gespeichert  
- 🔔 **Event Bus / Observer:** Lose gekoppelte Kommunikation zwischen Systemen  
- 🧠 **CI/CD-Pipeline:** Automatisierte WebGL-Builds und Versionierung über GitHub Actions  

---


### Hauptsysteme & Patterns

| System | Funktion | Pattern |
|--------|-----------|----------|
| **GameManager** | Steuert Spielzustände | Singleton + State Machine |
| **PlayerController** | Steuerung & Feuern | State Machine |
| **EnemySpawner** | Generiert Asteroiden | Object Pooling + Factory |
| **UpgradeSystem** | Verwaltet Fortschritt | Strategy + Observer |
| **SaveSystem** | Speichert Daten | Repository Pattern |
| **UIManager** | Score, Leben, Menüs | Observer |
| **EventBus** | Entkoppelte Kommunikation | Event System |

---

## 🧭 Projektzeitplan (2-Wochen-Sprint)

| Meilenstein | Zeitraum | Ziel |
|--------------|----------|------|
| 🪐 **1. Fundament & Architektur** | Tag 1–2 | Setup, Bootstrap, Struktur |
| 🚀 **2. Core Gameplay** | Tag 3–5 | Player, Gegner, Object Pooling |
| ☄️ **3. Game Loop & UI** | Tag 6–7 | States, UI, Score-System |
| 💎 **4. Rogue-Lite Layer** | Tag 8–10 | Upgrades, Save-System, Balancing |
| 🌟 **5. Polish & Release** | Tag 11–14 | Effekte, Audio, CI/CD, Build |

---
