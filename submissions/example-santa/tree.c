#include <stdio.h>

void print_tree(int height) {
    for (int i = 0; i < height; i++) {
        for (int j = 0; j < height - i - 1; j++) printf(" ");
        for (int k = 0; k < 2 * i + 1; k++) printf("*");
        printf("\n");
    }
    for (int i = 0; i < height - 1; i++) printf(" ");
    printf("|\n");
}

int main() {
    print_tree(5);
    printf("\nMerry Christmas! 🎄\n");
    return 0;
}

