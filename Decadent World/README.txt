# Decadent World – Menu & Systems Refactor (Unity)

Decadent World is a narrative-driven Unity game developed as part of my graduation project.
This repository focuses on the **refactored menu systems**, showcasing clean architecture,
event-driven design, and scalable gameplay programming practices.



## Technical Highlights

- Event-driven architecture using ScriptableObject Event Channels
- Decoupled UI systems (buttons, audio, localization, resolution)
- Global Audio Management using Unity AudioMixer
- Modular menu components with inheritance and overrides
- Clean separation of responsibilities (SRP-focused refactor)
- Persistent settings via PlayerPrefs (audio, resolution, localization)


## Architecture Overview

The project uses **ScriptableObject Event Channels** to decouple systems:

- UI elements raise events (click, hover, toggle)
- Controllers listen and react (AudioManager, ScreenSizeController, LocalizationController)
- No UI element directly references managers or systems

This approach avoids tight coupling, improves scalability,
and makes systems easier to maintain and extend.



## Core Systems

### Menu Button System
- Base abstract class (`MenuBaseButton`) handles shared behavior (audio, animation)
- Specific buttons override behavior only when needed

### Audio System
- Global AudioManager listening to SFX/Music event channels
- AudioMixer used for global volume control
- Volume persistence using PlayerPrefs

### Screen & Resolution
- Resolution and fullscreen handled by a dedicated controller
- UI reacts dynamically to valid/invalid resolution states

### Localization
- Uses Unity Localization package
- Language changes propagated via event channels



## What This Project Demonstrates

- Ability to refactor legacy code into clean, modular systems
- Strong understanding of Unity-specific architecture patterns
- Practical application of SOLID principles (especially SRP)
- Experience with scalable UI, audio, and settings systems
- Production-minded code organization suitable for real projects



## Code Navigation

- `AudioManager` – Central audio controller (SFX & Music)
- `MenuBaseButton` – Base class for all menu buttons
- `ScreenSizeController` – Applies resolution & fullscreen changes
- `LocalizationController` – Manages language switching
- `WingSceneTransition` – Handles animated scene transitions




