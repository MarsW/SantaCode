public class Tree {
    public static void main(String[] args) {
        int height = 5;
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < height - i - 1; j++) System.out.print(" ");
            for (int k = 0; k < 2 * i + 1; k++) System.out.print("*");
            System.out.println();
        }
        for (int i = 0; i < height - 1; i++) System.out.print(" ");
        System.out.println("|");
        
        System.out.println("\nMerry Christmas! 🎄");
    }
}
