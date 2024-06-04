def split_show_channel(line):
    line = line.split(",")
    show = line[0]
    channel = line[1]
    return (show, channel)

test_line = 'Hourly_Sports,DEF'

print split_show_channel(test_line)
