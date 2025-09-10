# Smoking Cessation VR Experience

A comprehensive virtual reality application designed for Meta Quest standalone devices that provides an immersive educational experience about the health effects of smoking. This project combines interactive 3D environments, realistic physics simulations, and educational content to help users understand the impact of smoking on their health.

## 🎯 Project Overview

This VR application serves as an educational tool that simulates the smoking experience while demonstrating its harmful effects on the human body, particularly the lungs. The experience is designed to be both informative and engaging, using realistic interactions and visual feedback to convey important health information.

## ✨ Key Features

### 🏠 Main Menu System
- **Interactive Welcome Screen**: Age verification and introductory warnings
- **Scene Navigation**: Seamless transitions between different educational modules
- **Settings Management**: Configurable options and user preferences
- **Fade Transitions**: Smooth visual transitions between scenes

### 🚬 Interactive Smoking Simulation
- **Realistic Physics**: Cigarette, lighter, and ashtray interactions with proper collision detection
- **Particle Effects**: Dynamic smoke particle systems that respond to user actions
- **Audio Feedback**: Realistic smoking sounds and breathing audio
- **Object Manipulation**: Full VR hand tracking for natural interaction with smoking paraphernalia

### 🫁 Lung Visualization & Health Education
- **Progressive Lung Damage**: Visual representation of lung deterioration with each simulated smoke
- **Color Progression**: Lungs gradually darken from healthy pink to black as damage accumulates
- **Shake Effects**: Physical feedback when lungs are affected by smoke
- **Educational Messaging**: Clear information about the health consequences of smoking

### 🎭 Character Interactions
- **AI-Powered Avatars**: Intelligent NPCs that respond to user presence and actions
- **Conversation System**: Multi-stage dialogue with audio narration
- **Navigation AI**: Characters that move and interact naturally within the environment
- **Animation States**: Complex animation sequences that respond to user interactions

### 🎵 Audio System
- **Spatial Audio**: 3D positioned sound effects for immersive experience
- **Dynamic Music**: Ambient background music that adapts to the scene
- **Voice Narration**: Educational content delivered through character voices
- **Audio Segments**: Modular audio system for flexible content delivery

## 🏗️ Technical Architecture

### Core Systems
- **SceneController**: Singleton pattern for managing scene transitions and navigation
- **SystemController**: Main application state management and UI coordination
- **Audio Management**: Centralized audio system with spatial positioning
- **Animation Controller**: State machine for character animations and interactions

### Interaction Systems
- **Mouth Collider Detection**: Precise collision detection for smoking simulation
- **Cigarette Behavior**: Realistic smoking mechanics with lighting and extinguishing
- **Lung Color Change**: Progressive visual feedback system
- **Navigation Script**: AI-driven character movement and interaction

### UI/UX Components
- **Canvas Controllers**: Dynamic UI management for different scenes
- **Message System**: Text display system for educational content
- **Button Interactions**: VR-optimized button controls and navigation

## 🎮 Scenes & Environments

### 1. Main Menu Scene
- Welcome interface with age verification
- Scene selection and navigation
- Settings and configuration options

### 2. Lung Visualization Scene
- Interactive lung model with real-time damage visualization
- Educational content about smoking effects
- Progressive health impact demonstration

### 3. Club Cessation Scene
- Social environment simulation
- Character interactions and conversations
- Educational messaging about peer pressure and social aspects

### 4. Smoking Simulation Scene
- Interactive smoking environment
- Realistic physics and particle effects
- Health impact visualization

## 🛠️ Development Setup

### Prerequisites
- Unity 2022.3 LTS or later
- Meta Quest Development Kit
- Oculus Integration SDK
- Meta Voice SDK (for voice interactions)

### Installation
1. Clone the repository
2. Open the project in Unity
3. Import required packages:
   - Oculus Integration
   - Meta Voice SDK
   - TextMeshPro
4. Configure build settings for Android/Quest
5. Set up Oculus Developer account and certificates

### Build Configuration
- **Platform**: Android
- **Target Device**: Meta Quest 2/3/Pro
- **Graphics API**: OpenGL ES 3.0
- **Architecture**: ARM64

## 📁 Project Structure

```
Assets/
├── Scripts/                 # Custom C# scripts
│   ├── Core/               # Core system controllers
│   ├── Managers/           # Scene and system managers
│   ├── Gameplay/           # Game mechanics and interactions
│   ├── Interaction/        # VR interaction systems
│   ├── Audio/              # Audio management scripts
│   ├── UI/                 # User interface components
│   └── Utility/            # Helper scripts and utilities
├── Art/                    # Visual assets
│   ├── Materials/          # Shader materials
│   ├── Models/             # 3D models and meshes
│   ├── Textures/           # Image textures
│   └── Animations/         # Animation controllers
├── Audio/                  # Audio assets
│   ├── Music/              # Background music
│   └── SFX/                # Sound effects
├── Prefabs/                # Reusable game objects
├── Scenes/                 # Unity scene files
├── UI/                     # User interface assets
│   ├── Sprites/            # UI sprites and images
│   └── Icons/              # Interface icons
└── Miscellaneous/          # Additional assets and meta files
```

