# 🐱 Cat Browser

A custom Windows browser exclusively for cat-related websites. Because why browse the entire internet when you can just browse cats?

## Features

- 🐱 Curated selection of cat-related websites
- 🖱️ Simple dropdown menu to navigate
- 💻 Built with C# and CefSharp (Chromium-based rendering)
- ⚡ Fast and lightweight
- 🎨 Cat-themed interface

## Supported Websites

1. YouTube - Cat Videos
2. The Cat API
3. Cats Are Awesome
4. Cat Time
5. Purina Cats
6. PetSmart Cats
7. MeowFlix
8. Reddit - r/cats
9. Instagram - #cats
10. PetFinder - Cat Breeds
11. ASPCA - Cat Care
12. 9GAG - Cats

## Requirements

- Windows 10 or later
- .NET 8.0 Runtime or later

## Building

### From Source

```bash
cd CatBrowser
dotnet build -c Release
dotnet publish -c Release
```

### Using GitHub Actions

Push to the repository and the GitHub Actions workflow will automatically:
1. Restore dependencies
2. Build the project
3. Publish the executable
4. Upload artifacts

## Installation

1. Download the latest release from GitHub Releases
2. Extract the files
3. Run `CatBrowser.exe`

## Usage

1. Select a cat website from the dropdown menu
2. Click the "Go! 🐾" button
3. Browse and enjoy!

## Development

The project uses:
- **CefSharp** for Chromium-based web rendering
- **Windows Forms** for the UI
- **.NET 8.0** as the target framework

### Project Structure

```
CatBrowser/
├── CatBrowser.csproj      # Project configuration
├── Program.cs             # Entry point
├── MainForm.cs            # Main UI and browser logic
└── README.md              # This file
```

## License

MIT License - Feel free to fork and create your own themed browsers!

---

Made with ❤️ for cat lovers everywhere 🐱
