namespace ConnectFourBlazor.Services;

public sealed class GameMove
{
    public int Number { get; init; }
    public int Player { get; init; }
    public int Column { get; init; }
}

public sealed class GameState
{
    public const int Rows = 6;
    public const int Columns = 7;

    private readonly int[] board = new int[Rows * Columns];

    public int CurrentPlayer { get; private set; } = 1;
    public bool IsGameOver { get; private set; }
    public string StatusMessage { get; private set; } = string.Empty;
    public string ErrorMessage { get; private set; } = string.Empty;
    public List<GameMove> Moves { get; } = new();

    public int CurrentTurn => Moves.Count;

    public GameState()
    {
        ResetBoard();
    }

    public int GetPiece(int index) => board[index];

    public void ResetBoard()
    {
        Array.Clear(board);
        CurrentPlayer = 1;
        IsGameOver = false;
        StatusMessage = string.Empty;
        ErrorMessage = string.Empty;
        Moves.Clear();
    }

    public void PlayPiece(byte column)
    {
        ErrorMessage = string.Empty;

        if (IsGameOver)
        {
            ErrorMessage = "The game is over. Select Play Again to start a new game.";
            return;
        }

        if (column >= Columns)
        {
            ErrorMessage = "Please choose a valid column.";
            return;
        }

        var row = FindAvailableRow(column);

        if (row < 0)
        {
            ErrorMessage = $"Column {column + 1} is full. Choose another column.";
            return;
        }

        var index = row * Columns + column;
        board[index] = CurrentPlayer;

        Moves.Add(new GameMove
        {
            Number = Moves.Count + 1,
            Player = CurrentPlayer,
            Column = column + 1
        });

        if (HasWon(row, column, CurrentPlayer))
        {
            IsGameOver = true;
            StatusMessage = $"Player {CurrentPlayer} Wins!";
            return;
        }

        if (Moves.Count == Rows * Columns)
        {
            IsGameOver = true;
            StatusMessage = "It's a tie!";
            return;
        }

        CurrentPlayer = CurrentPlayer == 1 ? 2 : 1;
    }

    private int FindAvailableRow(int column)
    {
        for (var row = Rows - 1; row >= 0; row--)
        {
            if (board[row * Columns + column] == 0)
            {
                return row;
            }
        }

        return -1;
    }

    private bool HasWon(int row, int column, int player)
    {
        return CountDirection(row, column, 0, 1, player) +
                   CountDirection(row, column, 0, -1, player) - 1 >= 4
            || CountDirection(row, column, 1, 0, player) +
                   CountDirection(row, column, -1, 0, player) - 1 >= 4
            || CountDirection(row, column, 1, 1, player) +
                   CountDirection(row, column, -1, -1, player) - 1 >= 4
            || CountDirection(row, column, 1, -1, player) +
                   CountDirection(row, column, -1, 1, player) - 1 >= 4;
    }

    private int CountDirection(int row, int column, int rowStep, int columnStep, int player)
    {
        var count = 0;

        while (row >= 0 && row < Rows &&
               column >= 0 && column < Columns &&
               board[row * Columns + column] == player)
        {
            count++;
            row += rowStep;
            column += columnStep;
        }

        return count;
    }
}
