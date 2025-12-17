package main

import (
	"fmt"
	"strings"
)

func main() {
	height := 5
	for i := 0; i < height; i++ {
		spaces := strings.Repeat(" ", height-i-1)
		stars := strings.Repeat("*", 2*i+1)
		fmt.Println(spaces + stars)
	}
	trunkSpaces := strings.Repeat(" ", height-1)
	fmt.Println(trunkSpaces + "|")
	fmt.Println("\nMerry Christmas! 🎄")
}
