def split_fileA(line):
    # split the input line in word and count on the comma
    line = line.split(",")
    word = line[0]
    # turn the count to an integer  
    count = int(line[1])
    return (word, count)

test_line = "able,991"

print split_fileA(test_line)
