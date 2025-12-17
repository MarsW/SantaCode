using System;

class Program {
    static void Main() {
        int height = 5;
        for (int i = 0; i < height; i++) {
            Console.Write(new String(' ', height - i - 1));
            Console.WriteLine(new String('*', 2 * i + 1));
        }
        Console.Write(new String(' ', height - 1));
        Console.WriteLine("|");
        
        Console.WriteLine("\nMerry Christmas! 🎄");
    }
}

