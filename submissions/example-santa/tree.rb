def print_tree(height)
  height.times do |i|
    puts (' ' * (height - i - 1)) + ('*' * (2 * i + 1))
  end
  puts (' ' * (height - 1)) + '|'
end

print_tree(5)
puts "\nMerry Christmas! 🎄"
