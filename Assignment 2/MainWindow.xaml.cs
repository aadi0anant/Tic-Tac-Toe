/* FileName:        Assignment_2
   Author:          Ritik Sharma
   Date Created:    October 12, 2024
   Description: This WPF Application is a Tic-Tac-Toe game designed for two players. Before the game can begin, both players must input their names—without this, 
                the game remains inactive. Once the names are entered, players can press a button to randomly determine which player will take the first turn. 
                After each move, the game consistently checks for a winner or a draw, updating the game state accordingly.
*/


using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_2
{
    public partial class MainWindow : Window
    {
        // Stores current player ("X" or "O")
        private string currentPlayer = string.Empty;
        // Two dimensional array to store Tic-Tac-Toe board buttons
        private Button[,] board;
        // Score for X player
        private int xScore = 0;
        // Score for O player
        private int oScore = 0;
        // Count of draw games
        private int drawScore = 0;
        // Random generator for selecting starting player
        private Random random = new Random(); 

        public MainWindow()
        {
            InitializeComponent();
            // This setup the board
            InitializeBoard();
            // Disabling board until starting player is chosen
            DisableBoard();
            // Put focus on the X player name input field
            textXPlayerName.Focus();

            // Making Score text boxes and Current player text boxes read only
            textCurrentPlayer.IsReadOnly = true;
            textXScore.IsReadOnly = true;
            textOScore.IsReadOnly = true;
            textDrawScore.IsReadOnly = true;
        }

        /// <summary>
        /// Initializing the board with buttons in a two dimensional array and disable them
        /// </summary>
        private void InitializeBoard()
        {
            board = new Button[3, 3]
            {
                { buttonR1C1, buttonR1C2, buttonR1C3 },
                { buttonR2C1, buttonR2C2, buttonR2C3 },
                { buttonR3C1, buttonR3C2, buttonR3C3 }
            };

            foreach (var button in board)
            {
                // Adding click event handler for each button
                button.Click += BoardButton_Click;
                // Clearing button content
                button.Content = string.Empty;
                // Initially disabling all the buttons
                button.IsEnabled = false;  
            }
        }

        /// <summary>
        /// Disabling all buttons (board)
        /// </summary>
        private void DisableBoard()
        {
            foreach (var button in board)
            {
                // Disabling each button
                button.IsEnabled = false;  
            }
        }

        /// <summary>
        /// Enabling buttons for unclicked squares
        /// </summary>
        private void EnableBoard()
        {
            foreach (var button in board)
            {
                if (button.Content.ToString() == string.Empty)
                {
                    // Enabling only unclicked buttons
                    button.IsEnabled = true;  
                }
            }
        }

        /// <summary>
        /// This is a common event handler which will be used for each 9 buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoardButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            // Check if the button has not been clicked yet
            if (button.Content.ToString() == string.Empty)  
            {
                // Then set button's content to the current player ("X" or "O")
                button.Content = currentPlayer;
                // We will disable the button after being clicked
                button.IsEnabled = false;

                // Check if the current player has won after clicking each button
                if (CheckWinCondition())  
                {
                    MessageBox.Show($"{currentPlayer} Wins!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Updating the score for the current player who has won
                    UpdateScore(currentPlayer);
                    // Reset the board for a new game for the same players
                    ResetBoard();  
                }

                // Check if the game is a draw
                else if (CheckDrawCondition())  
                {
                    MessageBox.Show("It's a Draw!", "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Increment draw score
                    drawScore++;
                    // Update draw score
                    textDrawScore.Text = drawScore.ToString();  
                    ResetBoard();  
                }

                // If neither the game was draw and neither any of the player won then
                else
                {
                    // Switch to the other player for continuing the game
                    SwitchPlayer();  
                }
            }
        }

        /// <summary>
        /// Update score based on the player who won
        /// </summary>
        /// <param name="player"></param>
        private void UpdateScore(string player)
        {
            // Checks if winning player was X
            if (player == "X")
            {
                // Increment x player score
                xScore++;
                // Update X player score
                textXScore.Text = xScore.ToString(); 
            }
            // If winning player was O
            else
            {
                // Increment o player score
                oScore++;
                // Update o player score
                textOScore.Text = oScore.ToString();
            }
        }

        /// <summary>
        /// Check if the current player has won (rows, columns, diagonals)
        /// </summary>
        /// <returns></returns>
        private bool CheckWinCondition()
        {
            for (int i = 0; i < 3; i++)
            {
                // Check each row for a win
                if (board[i, 0].Content == currentPlayer && board[i, 1].Content == currentPlayer && board[i, 2].Content == currentPlayer)
                    return true;
                // Check each column for a win
                if (board[0, i].Content == currentPlayer && board[1, i].Content == currentPlayer && board[2, i].Content == currentPlayer)
                    return true;
            }

            // Check Top Left to Bottom Right diagonal for a win
            if (board[0, 0].Content == currentPlayer && board[1, 1].Content == currentPlayer && board[2, 2].Content == currentPlayer)
                return true;
            // CheckTop Right to Bottom Left diagonal for a win
            if (board[0, 2].Content == currentPlayer && board[1, 1].Content == currentPlayer && board[2, 0].Content == currentPlayer)
                return true;

            return false;
        }

        /// <summary>
        /// Check if all buttons are clicked without a winner (draw condition)
        /// </summary>
        /// <returns></returns>
        private bool CheckDrawCondition()
        {
            // Go through each button in board array
            foreach (var button in board)
            {
                // If there's an empty button, then it is no draw
                if (button.Content.ToString() == string.Empty)  
                    return false;
            }
            // If no empty buttons and no win, then it's a draw
            return true;  
        }

        /// <summary>
        /// Switch between X and O players
        /// </summary>
        private void SwitchPlayer()
        {
            currentPlayer = currentPlayer == "X" ? "O" : "X";
            UpdateCurrentPlayerDisplay();
        }

        /// <summary>
        /// Update the current player display on the UI
        /// </summary>
        private void UpdateCurrentPlayerDisplay()
        {
            textCurrentPlayer.Text = currentPlayer;
        }

        /// <summary>
        /// Reset the board for a new game, keep the score
        /// </summary>
        private void ResetBoard()
        {
            foreach (var button in board)
            {
                // Clearing any content in Buttons from previous game
                button.Content = string.Empty;
                // Disabling all buttons until new game starts
                button.IsEnabled = false;  
            }
            // Clear current player
            currentPlayer = string.Empty; 
            
            UpdateCurrentPlayerDisplay();
            DisableBoard();
            // Put focus on Choose player button for next game
            buttonChoosePlayer.Focus();
        }

        /// <summary>
        /// Handle the Reset button click, resets the board, score and players name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            ResetBoard();
            // Reset scores
            xScore = oScore = drawScore = 0;  
            textXScore.Text = textOScore.Text = textDrawScore.Text = "";

            // Reset player's name
            textOPlayerName.Clear();
            textXPlayerName.Clear();

            // Put focus back to X Player Name
            textXPlayerName.Focus();
        }

        /// <summary>
        /// Handle the Exit button click, closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            // Close the Tic Tac Toe Application
            Close();  
        }

        /// <summary>
        /// Handle the Choose Starting Player button for selecting which player go first
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChoosePlayer_Click(object sender, RoutedEventArgs e)
        {
            // Validate that both player names are entered
            if (string.IsNullOrWhiteSpace(textXPlayerName.Text) || string.IsNullOrWhiteSpace(textOPlayerName.Text))
            {
                MessageBox.Show("Please enter names for both players.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Randomly select the starting player between "X" and "O"
            currentPlayer = random.Next(2) == 0 ? "X" : "O";
            MessageBox.Show($"{currentPlayer} will start the game!", "Starting Player", MessageBoxButton.OK, MessageBoxImage.Information);
            // Set Current Player
            UpdateCurrentPlayerDisplay();
            // Enabling the board once a starting player is chosen
            EnableBoard();  
        }
    }
}
