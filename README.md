# 🎭 First Period Faces

> *A social simulation game about navigating friendships on your very first day of school.*

Built for **Global Game Jam** | Engine: **Unity 6.2** | Genre: **Social Sim / Visual Novel**

---

## 📸 Screenshots

### Main Menu
![Main Menu](Screenshots/mainmenu.png)

### Classroom Exploration
![Classroom](Screenshots/classroom.png)

### Dialogue System
![Dialogue](Screenshots/dialogue.png)

### Character Interactions
![Character 1](Screenshots/character1.png)
![Character 2](Screenshots/character2.png)

---

## 🎮 About the Game

**First Period Faces** drops you into a school classroom on your very first day. The room is full of unique, quirky characters — each with their own personality, style, and vibe. Your goal? Talk to everyone, read the room, and say the right things to build **Friendship Points** before the period ends.

Every character reacts differently to how you speak to them. Pick the wrong line and you'll lose ground. Pick the right one and unlock deeper conversations — or even a **minigame**!

---

## ✨ Features

- 🏫 **Immersive Classroom Environment** — A fully realized 3D school scene with 2D animated characters overlaid for a unique mixed-media art style
- 💬 **Dialogue Choice System** — 3 dialogue options per interaction, each affecting your Friendship Meter differently
- 📊 **Friendship Meter** — A real-time bar tracks how well each conversation is going
- 🎯 **4 Integrated Minigames** — Triggered mid-conversation for certain characters (e.g., Sprint Start, Paper Throw, QTE Fashion)
- 🧠 **Hint System** — Subtle in-world cues help you figure out which answer fits each personality
- 🎨 **Unique Character Designs** — Each NPC has a distinct visual style: the footballer, the bookworm, the fashionista, and more
- 🔊 **Sound Manager** — Background audio and interaction sounds managed via a dedicated SoundManager system
- 🎬 **Cutscene System** — Intro and transition cutscenes built with Unity's animation pipeline

---

## 🕹️ How to Play

1. **Start** the game from the Main Menu
2. You spawn in the classroom — walk around and **approach characters**
3. A **dialogue panel** opens with 3 response choices
4. Choose wisely — your answer affects the **Friendship Meter** on the right
5. Some characters will trigger a **Minigame** instead of a dialogue round
6. Try to max out friendship with as many classmates as possible!

---

## 🛠️ Tech Stack

| Category | Details |
|----------|---------|
| Engine | Unity 6.2 (6000.2.14f1) |
| Render Pipeline | Universal Render Pipeline (URP) |
| Scripting | C# |
| UI | TextMesh Pro |
| Input | Unity Input System |
| Version Control | Git + GitHub |

---

## 📁 Project Structure

```
Assets/
├── Animation/          # Character and cutscene animations
├── Audio/              # BGM and SFX
├── Images/             # UI and background images
├── Materials/          # URP materials
├── Prefab/             # Reusable game objects
├── Scenes/             # StartScene, Classroom, etc.
├── Scripts/
│   ├── DialogueSystem/ # Dialogue, SingleChoice, OptionSelector
│   ├── Minigames/      # MiniGame, SprintStart, PaperGame, QTEFashion
│   ├── Characters/     # Interaction, UICharacter, FriendlinessTracker
│   ├── UI/             # MainMenu, SceneLoader, ButtonSounds
│   └── Managers/       # GameManager, DataStream, DontDestroy
├── Pixel Font - Tripfive/
└── TextMesh Pro/
```

---

## 📜 Key Scripts

| Script | Purpose |
|--------|---------|
| `DialogueSystem` | Manages conversation flow and branching |
| `SingleChoice` | Handles individual dialogue option selection |
| `FriendlinessTracker` | Tracks and updates friendship meter per character |
| `MiniGame` | Base controller for all 4 minigame triggers |
| `SprintStart` | Sprint reaction minigame logic |
| `PaperGame` | Paper throw minigame logic |
| `QTEFashion` | Quick-time event for fashion character |
| `DataStream` | Manages persistent game state across scenes |
| `SceneLoader` | Handles transitions between scenes |
| `DontDestroy` | Persists managers across scene loads |
| `CutsceneController` | Controls intro and transition cutscenes |
| `GameManager` | Core game loop and session management |

---

## 👥 Team

Made with ❤️ at **Global Game Jam — Indore**

| Role | Name |
|------|------|
| Developer | Apoorv Goyal |
| | *(Add teammates here)* |

---

## 📦 How to Run

1. Clone the repo:
   ```bash
   git clone https://github.com/Apoorv-34/Friend-Forever-Game-.git
   ```
2. Open in **Unity 6.2** or later
3. Open `Assets/Scenes/StartScene`
4. Press **Play** ▶️

> ⚠️ Requires Unity 6.2+ and Universal Render Pipeline package installed.

---

## 🏷️ Tags

`Unity` `GameJam` `GlobalGameJam` `SocialSim` `VisualNovel` `CSharp` `URP`
