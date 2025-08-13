# Old File Cleaner

**Old File Cleaner** is a simple and easy-to-use tool to automatically delete old files from one or multiple folders. The tool allows end users to clean their folders based on the number of previous days to keep, without needing programming knowledge.

---

## Tools & Technology Used

- **Programming Language:** C#
- **Framework:** .NET 8 (Console Application)
- **IDE:** Visual Studio 2022
- **Platform:** Windows (supports any PC with .NET runtime installed)
- **Distribution:** Published executable (`.exe`) for end users

---

## Features

- Deletes files older than a specified number of days.
- Supports **multiple folders** in a single configuration.
- Handles folder paths with **spaces** (e.g., `product Details`).
- Friendly console messages showing deleted files.
- Safe: skips folders that don’t exist and logs errors instead of crashing.

---

## Getting Started for End Users

### 1. Download and Extract Tool

1. Download the published folder (from GitHub releases or repository).
2. Extract it anywhere on your PC, e.g., `C:\OldFileCleaner`.

You should see:

```
OldFileCleaner.exe
config.txt
README.md
```

---

### 2. Configure Folders

Open `config.txt` in Notepad.\
Example configuration:

```txt
# Folders to clean (comma-separated, use quotes if spaces exist)
FolderPath="C:\Users\Admin\Downloads\product","C:\Users\Admin\Downloads\product Details"

# Number of previous days to keep files
# 0  = delete all files before today
# 1  = keep only today, delete files older than yesterday
# 3  = keep last 3 days, delete files older than that
# 5  = keep last 5 days
# 10 = keep last 10 days
# 20 = keep last 20 days
# 30 = keep last 30 days
previousDays=0
```

**Notes:**

- `FolderPath` → List of folders to clean, separated by commas. Use quotes if folder name contains spaces.
- `previousDays` → Number of days to keep. Older files will be deleted.

---

### 3. Run the Program

1. Double-click `OldFileCleaner.exe`.
2. The program will automatically read `config.txt` and clean the specified folders.
3. Console will display messages:

```
Cleaning folder: C:\Users\Admin\Downloads\product
Deleted: oldfile1.txt (Modified: 2025-08-12)
Deleted: oldfile2.txt (Modified: 2025-08-10)

Old files deleted successfully (files older than 0 days).
```

---

### 4. Important Notes for End Users

- **Permanent Deletion:** Deleted files cannot be recovered. Always back up important files.
- **Folder Check:** Make sure folders exist. The program will skip missing folders and show a warning.
- **Safe Usage:** Start with `previousDays=0` to delete only files before today. Increase gradually to keep more recent files.
- **Multiple Folders:** You can add as many folders as needed using commas, with quotes if the folder name has spaces.

---

## How to Contribute

- Fork the repository and clone it locally.
- Make changes to `Program.cs` or other files.
- Test your changes and commit them with meaningful messages.
- Create a Pull Request for review.

---

## License

This project is licensed under the **MIT License** – see the `LICENSE` file for details.

