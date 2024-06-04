def make_adder(x):
    def add(y):
        return x + y
    return add

#plus5 = make_adder(5)
#print(plus5(12))  

print(make_adder(5)(12))
