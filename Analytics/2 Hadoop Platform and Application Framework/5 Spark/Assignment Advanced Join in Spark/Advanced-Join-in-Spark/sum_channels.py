def sum_function(sorted_collection, val, kv, skv, result):
    for i in sorted_collection:
        val = val + int(i[1])
        kv[i[0]] = val
    skv = sorted(kv.items())
    for index in range(len(skv)):
        if index == 0:
            result[skv[index][0]] = skv[index][1]
            # print skv[index][0], skv[index][1]
        elif index > 0:
	    result[skv[index][0]] = (skv[index][1] - skv[index - 1][1])
            # print skv[index][0], (skv[index][1] - skv[index - 1][1])
    return sorted(result.items())

sorted_collection = [(u'NOX', 1052), (u'NOX', 1052), (u'XYZ', 17), (u'XYZ', 17)]

print sum_function(sorted_collection, val=0, kv={}, skv={}, result={})
# sum_function(sorted_collection, val=0, kv={}, skv={})
# skv = (sorted(kv.items()))

'''for k,v in skv:
    print k,v'''

'''for index in range(len(skv)):
    #print index
    #print skv[index][0], skv[index][1]
    if index == 0:
	print skv[index][0], skv[index][1]
    elif index > 0:
	print skv[index][0], (skv[index][1] - skv[index - 1][1])'''
