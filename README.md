# Reading Aid App

A comprehensive VR reading assistance application designed for Meta Quest standalone devices, featuring eye-tracking analysis, interactive text highlighting, and educational assessment tools.

## 🎯 Project Overview

The Reading Aid App is a personal project developed for the Meta Quest Pro that combines immersive VR technology with advanced reading analytics. The application provides real-time reading assistance through gaze tracking, interactive text manipulation, and comprehensive assessment reporting for educational purposes.

## 🚀 Key Features

### 📖 Interactive Reading Experience
- **Gaze-Based Highlighting**: Automatic text highlighting based on user eye movement
- **Interactive Word Selection**: Tap-to-select words for instant dictionary lookup
- **Reading Session Management**: Comprehensive session tracking with pause/resume functionality

### 👁️ Eye Tracking & Analytics
- **Pattern Recognition**: Advanced algorithms to detect reading patterns including:
  - Fixations (focused gaze points)
  - Regressions (backward eye movements)
  - Saccades (rapid eye movements)
  - Word skipping detection
  - Reading flow analysis
- **Visual Feedback**: Real-time visualization of eye movement patterns with colored traces
- **Assessment Reports**: Detailed analytics on reading behavior and comprehension

### 📚 Educational Tools
- **Dictionary Integration**: Built-in dictionary with definitions, synonyms, and phonetic information
- **Student Management**: Comprehensive student data tracking and assessment history
- **Progress Monitoring**: Session-based progress tracking with detailed reports
- **Instructor Dashboard**: Tools for educators to monitor student reading patterns

### 🎮 VR Interaction
- **Gaze Interaction**: Eye-tracking based text selection and navigation
- **Spatial UI**: Immersive 3D user interface optimized for VR environments
- **Audio Feedback**: Sound effects for user interactions and system notifications

## 🏗️ Technical Architecture

### Core Systems

#### **Reading Session Controller**
- Manages the overall reading experience
- Handles session state (start, pause, resume, quit)
- Coordinates between text generation and highlighting systems
- Tracks reading time and progress

#### **Text Processing Pipeline**
- **Paragraph Text Generator**: Converts text strings into interactive 3D word objects
- **Text Positioner**: Manages spatial layout and pagination of text elements
- **Highlight System**: Real-time text highlighting based on gaze patterns
- **Text Controllers**: Individual word interaction and selection handling

#### **Data Management**
- **Student Data Manager**: Centralized student information and assessment tracking
- **Dictionary System**: Word lookup and definition management
- **Pattern Recognition**: Eye movement analysis and reading pattern detection
- **Assessment Storage**: Persistent storage of reading sessions and analytics

#### **Visualization & Feedback**
- **Feedback Visualizer**: Eye movement trace visualization
- **UI Controllers**: Canvas management and user interface coordination
- **Animation System**: Smooth transitions and visual effects

### Technology Stack
- **Unity 2022.x**: Primary development platform
- **Meta Quest SDK**: VR platform integration
- **Oculus Integration**: Hand tracking and eye tracking APIs
- **TextMesh Pro**: Advanced text rendering and manipulation
- **XR Interaction Toolkit**: VR interaction framework

## 📁 Project Structure

```
Assets/
├── Scripts/
│   ├── Controllers/          # Core system controllers
│   ├── Managers/            # Data and system managers
│   ├── Data/               # Data structures and models
│   ├── UI/                 # User interface components
│   ├── Text/               # Text processing and highlighting
│   └── Utilities/          # Helper functions and utilities
├── Art/
│   ├── Textures/           # Visual assets and materials
│   ├── Materials/          # Shader materials
│   ├── Models/             # 3D models and meshes
│   └── Animations/         # Animation assets
├── Audio/
│   ├── Music/              # Background music
│   └── SFX/                # Sound effects
├── UI/
│   ├── Icons/              # UI icon assets
│   └── Sprites/            # 2D sprite assets
├── Prefabs/                # Reusable game objects
├── Shaders/                # Custom shader files
└── Resources/              # Runtime data and configurations
```
