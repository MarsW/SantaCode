fn main() {
    let height = 5;
    for i in 0..height {
        println!("{}{}", " ".repeat(height - i - 1), "*".repeat(2 * i + 1));
    }
    println!("{}|", " ".repeat(height - 1));
    println!("\nMerry Christmas! 🎄");
}

