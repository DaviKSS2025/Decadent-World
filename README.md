# Decadent World – Menu & Systems Refactor (Unity)

Decadent World is a narrative-driven Unity game developed as part of my graduation project.
This repository focuses on the **refactored menu systems**, showcasing clean architecture,
event-driven design, and scalable gameplay programming practices.



## Technical Highlights

- Event-driven architecture using ScriptableObject Event Channels
- Decoupled UI systems (buttons, audio, localization, resolution, chapter selection)
- Global Audio Management using Unity AudioMixer
- Modular menu components with inheritance and overrides
- Clean separation of responsibilities (SRP-focused refactor)
- Data-driven content via ScriptableObjects
- Persistent settings via PlayerPrefs
- Save system persistence via JSON serialization
- Structured JSON-based save system supporting multiple slots

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

### Chapter Selection & Save Flow

- Chapter metadata defined via ScriptableObjects
- Event-driven interaction between UI panels and controllers
- Save slots managed through serialized JSON data
- Multiple independent save slots supported
- Data structure designed for future extensibility/versioning
- Confirmation flow for overwrite operations
- Scene transitions coordinated through event channels

This system demonstrates scalable menu flow architecture,
decoupling UI, persistence, and scene management.

## Save System Architecture

The save system evolved beyond simple PlayerPrefs persistence and now uses
JSON serialization to manage structured game data.

Key characteristics:

- Multiple independent save slots
- Version-friendly data structure for future expansion
- Event-driven UI updates when slots change
- Centralized access through a SaveController layer
- Designed to support narrative progression tracking

This approach mirrors production-oriented persistence strategies,
prioritizing maintainability and scalability.


## What This Project Demonstrates

- Ability to refactor legacy code into clean, modular systems
- Strong understanding of Unity-specific architecture patterns
- Practical application of SOLID principles (especially SRP)
- Experience with scalable UI, audio, and settings systems
- Production-minded code organization suitable for real projects
- Experience building data-driven gameplay UI
- Implementation of structured save persistence systems


## Code Navigation

- `AudioManager` – Central audio controller (SFX & Music)
- `MenuBaseButton` – Base class for all menu buttons
- `ScreenSizeController` – Applies resolution & fullscreen changes
- `LocalizationController` – Manages language switching
- `WingSceneTransition` – Handles animated scene transitions

## Evolution Through Refactoring

This repository reflects iterative architectural improvements applied
throughout development:

- Migration from tightly coupled UI logic to event-driven systems
- Replacement of PlayerPrefs-only persistence with JSON serialization
- Increased use of ScriptableObjects for data-driven workflows
- Consistent architectural patterns across multiple scenes

The goal was not only feature implementation but long-term maintainability
and scalability.





