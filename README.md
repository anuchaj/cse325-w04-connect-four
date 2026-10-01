# CSE325 W04 - Connect Four with Blazor

A two-player Connect Four game built with ASP.NET Core Blazor.

## Assignment

This project follows Microsoft's **Build a Connect Four game with Blazor** module and adds an extra feature:

### Additional feature: Move History

The application keeps a live list of every move made during the current game. Each entry shows:

- Move number
- Player number
- Column selected

The move history resets when the user starts a new game.

## Features

- 7-column × 6-row Connect Four board
- Two-player turn system
- Pieces fall into the lowest available position
- Horizontal, vertical, and diagonal win detection
- Tie detection
- Full-column error handling
- Reset / Play Again functionality
- Custom board and player colors through component parameters
- Responsive layout
- Move History extra feature
- Accessible labels and controls

## Run locally

Requirements:

- .NET 9 SDK

From the project directory:

```powershell
dotnet restore
dotnet build
dotnet run
```

Open the HTTPS URL printed by the terminal.

## Suggested video demonstration

1. Introduce the Connect Four application.
2. Show the empty 7×6 board.
3. Explain that players alternate turns.
4. Drop several pieces into different columns.
5. Point out the Move History panel updating after each move.
6. Fill a column enough to demonstrate the full-column error.
7. Continue until a player wins.
8. Show the winner message and Play Again button.
9. Click Play Again and show that the board and move history reset.
10. Explain that Move History is the additional feature added for the assignment.

## Main Blazor concepts demonstrated

- Razor components
- Component parameters
- Dependency injection
- Scoped application state
- Event handling with `@onclick`
- Interactive Server rendering
- Conditional rendering
- C# game logic
- CSS styling and responsive design
