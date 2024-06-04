def extract_channel_views(show_views_channel):
    views = int(show_views_channel[1][0])
    channel = show_views_channel[1][1]
    return (channel, views)

test_tuple = (u'Baked_Talking', (u'168', u'MAN'))

print extract_channel_views(test_tuple)
