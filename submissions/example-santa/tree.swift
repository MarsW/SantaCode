func printTree(_ height: Int) {
    for i in 0..<height {
        let spaces = String(repeating: " ", count: height - i - 1)
        let stars = String(repeating: "*", count: 2 * i + 1)
        print(spaces + stars)
    }
    let trunkSpaces = String(repeating: " ", count: height - 1)
    print(trunkSpaces + "|")
}

printTree(5)
print("\nMerry Christmas! 🎄")
