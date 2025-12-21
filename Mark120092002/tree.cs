
class Program
{
    const int size = 25;
    const int moveSpeed = 15;
    static char[,] buf = new char[size, size];
    static HashSet<(int x, int y)> tree = new HashSet<(int, int)>();
    static Queue<(int x, int y)> snake = new Queue<(int, int)>();
    static HashSet<(int x, int y)> santaRed = new HashSet<(int, int)>();
    static int snakeLength = 5;
    static int moveCount = 0;
    static void Main()
    {
        Console.CursorVisible = false;
        try
        {
            Console.SetWindowSize(size, size);
            Console.SetBufferSize(size, size);
        }
        catch { }

        Console.Clear();

        DrawNoise();
        DrawTree(false);
        RenderAll();
        RunSnakeSpiral();
        DrawTree(true);
        BlinkTreeStars();

        var (tx, ty) = GetTreeTopPosition();
        Console.SetCursorPosition(tx, ty);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write('*');
        Console.ResetColor();

        Console.SetCursorPosition(0, size - 1);
        Console.CursorVisible = true;
        Console.ReadKey();
    }

    static void DrawNoise()
    {
        char[] n = { '/', '*', '\\', '|' };
        Random r = new Random();
        for (int y = 0; y < size; y++)
            for (int x = 0; x < size; x++)
            {
                buf[x, y] = n[r.Next(n.Length)];
                Console.SetCursorPosition(x, y);
                Console.Write(buf[x, y]);
            }
    }

    static void DrawTree(bool green)
    {
        tree.Clear();
        string[] t =
        {
        "*",
        "/|\\",
        "/*|*\\",
        "/|*|*|*\\",
        "/|*|*|*|*\\",
        "/|*|*|*|*|*\\",
        "| | |",
        "[SantaCode]"
    };

        int sy = size / 2 ; 

        for (int y = 0; y < t.Length; y++)
        {
            string line = t[y];
            int sx = size / 2 - line.Length / 2; 
            for (int x = 0; x < line.Length; x++)
            {
                int px = sx + x;
                int py = sy + y; 
                if (px < 0 || px >= size || py < 0 || py >= size)
                    continue;
                buf[px, py] = line[x];
                tree.Add((px, py));
                if (green)
                {
                    Console.SetCursorPosition(px, py);
                    if (santaRed.Contains((px, py)))
                        Console.ForegroundColor = ConsoleColor.Red;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(line[x]);
                }
            }
        }
        if (green)
            Console.ResetColor();
    }


    static void RenderAll()
    {
        for (int y = 0; y < size; y++)
        {
            Console.SetCursorPosition(0, y);
            for (int x = 0; x < size; x++)
                Console.Write(buf[x, y]);
        }
    }

    static void RunSnakeSpiral()
    {
        int left = 0, right = size - 1, top = 0, bottom = size - 1;
        snake.Clear();

        while (left <= right && top <= bottom)
        {
            for (int i = left; i <= right; i++)
                MoveSnake(i, top);
            top++;
            for (int i = top; i <= bottom; i++)
                MoveSnake(right, i);
            right--;
            for (int i = right; i >= left; i--)
                MoveSnake(i, bottom);
            bottom--;
            for (int i = bottom; i >= top; i--)
                MoveSnake(left, i);
            left++;
        }

        while (snake.Count > 0)
        {
            var t = snake.Dequeue();
            if (!tree.Contains(t))
            {
                Console.SetCursorPosition(t.x, t.y);
                Console.Write(' ');
            }
            Thread.Sleep(15);
        }
    }

    static void MoveSnake(int x, int y)
    {
        moveCount++; 
        if (moveCount % 20 == 0)
            snakeLength++; 

        snake.Enqueue((x, y));

        foreach (var s in snake)
        {
            Console.SetCursorPosition(s.x, s.y);

            if (tree.Contains(s))
            {
                string santa = "[SantaCode]";
                int scStartX = -1;
                int scY = -1;

                for (int yy = 0; yy < size; yy++)
                {
                    for (int xx = 0; xx < size - santa.Length + 1; xx++)
                    {
                        bool match = true;
                        for (int i = 0; i < santa.Length; i++)
                        {
                            if (buf[xx + i, yy] != santa[i])
                            {
                                match = false;
                                break;
                            }
                        }
                        if (match)
                        {
                            scStartX = xx;
                            scY = yy;
                            break;
                        }
                    }
                    if (scStartX != -1)
                        break;
                }

                if (s.y == scY && s.x >= scStartX && s.x < scStartX + santa.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(buf[s.x, s.y]);
                    santaRed.Add((s.x, s.y));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(buf[s.x, s.y]);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write('o'); 
            }
        }

        if (snake.Count > snakeLength)
        {
            var t = snake.Dequeue();
            if (!tree.Contains(t))
            {
                Console.SetCursorPosition(t.x, t.y);
                Console.Write(' ');
            }
        }

        Console.ResetColor();
        Thread.Sleep(moveSpeed);
    }

    static void BlinkTreeStars()
    {
        string[] t =
    {
        "*",
        "/|\\",
        "/*|*\\",
        "/|*|*|*\\",
        "/|*|*|*|*\\",
        "/|*|*|*|*|*\\",
        "| | |",
        "[SantaCode]"
    };

        var starPositions = new List<(int x, int y)>();
        int sy = size / 2;
        for (int y = 0; y < t.Length; y++)
        {
            string line = t[y];
            int sx = size / 2 - line.Length / 2;
            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] == '*')
                {
                    starPositions.Add((sx + x, sy + y));
                }
            }
        }

        string message = "Merry Christmas";
        int msgX = size / 2 - message.Length / 2;
        int msgY = starPositions[0].y - 1; 

        bool starYellow = true;
        bool msgRed = true;
        for (int i = 0; i < 50; i++)
        {
            Console.ForegroundColor = starYellow ? ConsoleColor.Yellow : ConsoleColor.White;
            foreach (var (x, y) in starPositions)
            {
                Console.SetCursorPosition(x, y);
                Console.Write('*');
            }
            starYellow = !starYellow;

            Console.ForegroundColor = msgRed ? ConsoleColor.Yellow : ConsoleColor.Red ;
            Console.SetCursorPosition(msgX, msgY);
            Console.Write(message);
            msgRed = !msgRed;

            Thread.Sleep(300);
        }
        Console.ResetColor();
    }
    static (int x, int y) GetTreeTopPosition()
    {
        int sx = size / 2; 
        int sy = size / 2; 
        return (sx, sy);
    }

}
