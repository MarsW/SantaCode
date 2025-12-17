#include <iostream>
#include <string>

using namespace std;

void print_tree(int height) {
    for (int i = 0; i < height; i++) {
        cout << string(height - i - 1, ' ') << string(2 * i + 1, '*') << endl;
    }
    cout << string(height - 1, ' ') << "|" << endl;
}

int main() {
    print_tree(5);
    cout << "\nMerry Christmas! 🎄" << endl;
    return 0;
}

