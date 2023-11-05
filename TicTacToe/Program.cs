char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
char currentPlayer = 'X'; // Player 1 starts
int moves = 0;
int playerChoice;
bool validInput;

void DrawBoard()
{
    Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
    Console.WriteLine("---+---+---");
    Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
    Console.WriteLine("---+---+---");
    Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
}

bool IsWinner()
{
    return (board[0] == board[1] && board[1] == board[2]) || // Top row
           (board[3] == board[4] && board[4] == board[5]) || // Middle row
           (board[6] == board[7] && board[7] == board[8]) || // Bottom row
           (board[0] == board[3] && board[3] == board[6]) || // Left column
           (board[1] == board[4] && board[4] == board[7]) || // Middle column
           (board[2] == board[5] && board[5] == board[8]) || // Right column
           (board[0] == board[4] && board[4] == board[8]) || // Diagonal
           (board[2] == board[4] && board[4] == board[6]);   // Diagonal
}

while(true){
    Console.Clear();
    Console.WriteLine("Welcome to Tic-Tac-Toe\n");
    DrawBoard();

    while (true) { 
        Console.Write($"\nPlayer {currentPlayer}, choose an available spot (1-9): ");
        validInput = int.TryParse(Console.ReadLine(), out playerChoice);
        if (validInput && playerChoice >= 1 && playerChoice <= 9)
        {
            if (board[playerChoice - 1] != 'X' && board[playerChoice - 1] != 'O')
            {
                board[playerChoice - 1] = currentPlayer;
                moves++;
                break;
            }
            else
            {
                Console.WriteLine("That spot is already taken. Try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Choose a number between 1 and 9.");
        }
    }

    if (IsWinner())
    {
        Console.Clear();
        DrawBoard();
        Console.WriteLine($"\nPlayer {currentPlayer} wins! Congratulations!");
        break;
    }

    if (moves == 9)
    {
        Console.Clear();
        DrawBoard();
        Console.WriteLine("\nIt's a draw!");
        break;
    }

    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
} 

Console.WriteLine("Press any key to exit...");




Console.ReadLine();