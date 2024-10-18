Tic-Tac-Toe WPF Application

**Overview**

This is a simple two-player Tic-Tac-Toe game built using Windows Presentation Foundation (WPF). The game is designed to provide a user-friendly interface for players to enjoy a classic game of Tic-Tac-Toe on their desktop. Players are required to enter their names before playing, and the game automatically checks for a winner or a draw after every move.

**Features**

-->Two-player mode: The game supports two players. Both players must input their names to start.

-->Random player selection: After entering their names, players press a button to randomly determine which player will take the first turn.

-->Winner detection: The game checks for a winner or a draw after every move and updates the UI accordingly.

-->Intuitive UI: The interface makes it easy to play and track the game. The board is clear, and players can easily interact with the buttons.

-->Accessibility features:

    1. Keyboard navigation: Players can navigate through the game using the Tab key to switch focus between the text fields, buttons, and grid cells.
    2. Access keys: Access keys (keyboard shortcuts) are implemented for major buttons, allowing players to use the game more efficiently with a keyboard. For example, pressing Alt + C will fire the Choose               Starting Player button, and Alt + X will activate the button to quit the application.

**How to Play**

Start the game:

When the game is launched, both players must enter their names in the provided input fields. The game cannot proceed until both names are entered.

Select first player:

After entering the names, press the "Choose Starting Player" button to randomly decide who will play first. The first player will be marked as "X" and the second player as "O."

Take turns:

Players take turns clicking on the grid to place their symbol (X or O) on the board. The game will switch turns automatically.

Check for a winner:

After every move, the game checks for a winner or a draw. If a player wins or if the game ends in a draw, the game will display a message and the board will reset for a new game.

**Project Structure**

The project consists of the following key components:

-->MainWindow.xaml: Contains the XAML layout for the UI, including the text fields for player names, the game grid, and buttons for interacting with the game.

-->MainWindow.xaml.cs: Contains the C# code-behind for handling game logic, including player turns, winner detection, and game state management.

-->App.xaml: Provides the basic application setup for the WPF framework.

**Requirements**

-->.NET Framework or .NET Core (compatible with WPF)

-->Visual Studio (or any other IDE supporting WPF projects)

**Future Improvements**

-->Add support for playing against an CPU.

-->Add sound effects and animations for a more engaging experience.
