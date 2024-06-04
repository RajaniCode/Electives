def split_fileB(line):
    # split the input line into word, date and count_string
    line = line.split(",")
    date_word = line[0]
    count_string = line[1]
    date_word = date_word.split(" ")
    date = date_word[0]
    word = date_word[1]
    return (word, date + " " + count_string)

test_line = "Jan-01 able,5"

print split_fileB(test_line)
