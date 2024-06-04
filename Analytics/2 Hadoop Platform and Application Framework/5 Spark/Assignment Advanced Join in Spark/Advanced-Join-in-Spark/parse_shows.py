def split_show_views(line):
    line = line.split(",")
    show = line[0]
    views = int(line[1])
    return (show, views)

test_line = 'Hourly_Sports,21'

print split_show_views(test_line)
