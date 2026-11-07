# Voxora

**A Modern Desktop Speech-to-Text Application**

Voxora is a Windows desktop application designed to convert spoken language into text through a modern, intuitive, and customizable user interface.

Built with C#, WPF, and .NET 10, Voxora aims to provide an efficient speech transcription experience with a focus on local processing, performance, and usability.

---

## Overview

Voxora is designed to simplify speech transcription by providing a unified environment for recording audio, processing speech, and working with generated transcripts.

The project focuses on creating a modern desktop experience while exploring local speech recognition technologies.

## Features

### Core Features

- Speech-to-text transcription
- Audio recording through a microphone
- Audio file transcription
- Persian and English speech recognition
- Local speech processing using Whisper-based technologies

### Audio Management

- Audio recording and playback
- Recorded audio history
- Audio file selection
- WAV audio file support

### Transcription Workspace

- Display generated transcripts
- Edit transcription results
- Copy transcription text
- Export transcription results

### User Interface

- Modern Dark Premium design
- Custom WPF controls
- Black and turquoise color palette
- Recording status indicators
- Audio visualization and waveform interface

> **Development Status:** Voxora is currently under active development. Features listed above represent the project's goals and development scope; availability may vary depending on the current implementation.

---

## Screenshots

Screenshots of the application will be added here as the user interface develops.

<img width="1344" height="753" alt="image" src="https://github.com/user-attachments/assets/775d6951-fe12-4120-a8b8-ee1d6d0788d1" />
<img width="1344" height="753" alt="image" src="https://github.com/user-attachments/assets/50083c45-186b-4956-bd4f-e730677b6b43" />
<img width="1344" height="753" alt="image" src="https://github.com/user-attachments/assets/449de16e-ad1b-445b-b9ec-f82ce56a0e22" />
<img width="1440" height="753" alt="image" src="https://github.com/user-attachments/assets/acfd0324-99c7-43ce-bd34-1c8373b43cd4" />

---

## Technology Stack

| Technology  | Purpose                                    |
| ----------- | ------------------------------------------ |
| C#          | Application development                    |
| .NET 10     | Application framework                      |
| WPF         | Windows desktop user interface             |
| XAML        | UI layout and presentation                 |
| MVVM        | UI architecture and separation of concerns |
| NAudio      | Audio recording and audio processing       |
| Whisper     | Speech recognition and transcription       |

### Additional Technologies

- Git — version control
- Visual Studio — development environment

Technologies may change as the project evolves.

---

## Supported Languages

Voxora is designed to support:

| Language        | Recognition            |
| --------------- | ---------------------- |
| English         | Planned / experimental |
| Persian (Farsi) | Planned / experimental |

Language support depends on the selected speech recognition model.

---

## Architecture

Voxora is being developed with a focus on separation of concerns and maintainable application design.

The application is intended to separate the user interface, audio management, transcription processing, and application logic.

### Architectural Goals

- Separation of UI and business logic
- Maintainable and testable components
- Asynchronous audio processing
- Responsive user interface
- Modular transcription services
- Clear responsibility boundaries

The architecture will evolve as implementation progresses.

---

## Requirements

### Development Environment

- Windows 10 or Windows 11
- Visual Studio 2026 or a compatible development environment
- .NET 10 SDK
- Git

### Hardware

For basic desktop application development:

- A modern Windows-compatible processor
- 8 GB RAM or more recommended

For local GPU-accelerated speech recognition:

- NVIDIA GPU with compatible CUDA support, depending on the selected inference backend
- Additional GPU memory depending on the selected model

CPU-based inference may also be possible depending on the backend and model.

---

## Installation

### 1. Clone the Repository

```bash
git clone https://github.com/hamedkarimi214/Voxora.git
```

### 2. Navigate to the Project Directory

```bash
cd Voxora
```

### 3. Open the Project

Open the Voxora solution in Visual Studio.

### 4. Restore Dependencies

```bash
dotnet restore
```

### 5. Build the Application

```bash
dotnet build
```

### 6. Run the Application

```bash
dotnet run
```

> Note: These instructions assume a standard .NET project configuration. Additional model files, native libraries, or runtime dependencies may be required depending on the current implementation.

---

## Project Structure

The following is an example of the intended project organization. The actual structure may differ.

```text
Voxora/
│
├── Voxora.sln
│
├── Voxora/
│   ├── App.xaml
│   ├── MainWindow.xaml
│   ├── Cyan Blue AI Waveform Emblem.ico
│   ├── README.md
│   ├── AssemblyInfo.cs
│   │
│   ├── Views/
│   │   ├── MainWindow.xaml
│   │   └── ExtractedTextView.xaml
│   │
│   ├── ViewModels/
│   │   ├── MainWindowViewModel.cs
│   │   └── ExtractedTextViewViewModel.cs
│   │
│   ├── Models/
│   │   ├── IWhisperService.cs
│   │   └── IWindowService.cs
│   │   └── RecordManager.cs
│   │   └── RelayCommand.cs
│   │   └── WhisperService.cs
│   │   └── WindowService.cs
│   │   └── WindowSizeManager.cs
│   │
│   └── Sounds/
│
└── ...
```
---

## Performance and Privacy

Voxora explores local speech recognition to reduce dependence on external transcription services.

Local processing can help keep audio data on the user's device, depending on the selected implementation.

Performance and privacy characteristics depend on the inference backend and application configuration.

---

## Contributing

Contributions, suggestions, and feedback are welcome.

If you would like to contribute:

1. Fork the repository.
2. Create a new branch.
3. Implement your changes.
4. Submit a Pull Request.

Please ensure that your changes are readable, maintainable, and consistent with the project's architecture.

---

## License

The project license has not yet been specified.

A license will be added when the distribution and usage terms are determined.

---

## Author

**Hamed Karimi**

GitHub: hamedkarimi214(https://github.com/hamedkarimi214)

---

## Acknowledgments

- [Microsoft .NET](https://dotnet.microsoft.com/)
- [Microsoft WPF](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/)
- [NAudio](https://github.com/naudio/NAudio)
- [Whisper](https://github.com/openai/whisper)
- [Whisper.cpp](https://github.com/ggml-org/whisper.cpp)

---

**Voxora — Turning Speech into Text.**
