#!/bin/sh

height=5

for i in $(seq 0 $(($height - 1))); do
    spaces=$((height - i - 1))
    stars=$((2 * i + 1))
    
    # Print spaces
    j=0
    while [ $j -lt $spaces ]; do
        printf " "
        j=$((j + 1))
    done
    
    # Print stars
    j=0
    while [ $j -lt $stars ]; do
        printf "*"
        j=$((j + 1))
    done
    printf "\n"
done

# Print trunk
j=0
while [ $j -lt $((height - 1)) ]; do
    printf " "
    j=$((j + 1))
done
echo "|"

echo ""
echo "Merry Christmas! 🎄"
