import math

class Calculator(object):
    def exponent(self, x, y):
        return math.pow(x, y)

    def multiply(self, x, y):
        return x * y

    def divide(self, x, y):
        return x / y

    def add(self, x, y):
        return x + y

    def subtract(self, x, y):
        return x - y

    def modulus(self, x, y):
        return x % y

    def pemdas(self, x, y):
        # 2 - 4 ** 2 + (2 - 4) * 4 / 2
        # 2 - (4 ** 2) + (-2) * 4 / 2
        # 2 - 16 + (-2) * (4 / 2)
        # 2 - 16 + (-2 * 2)
        # 2 - 16 + (-4)
        # 2 - 20
        # - 18
        return y - x ** y + (y - x) * x / y

print Calculator().exponent(4, 2)

print Calculator().multiply(4, 2)

print Calculator().divide(4, 2)

print Calculator().add(4, 2)

print Calculator().subtract(4, 2)

print Calculator().modulus(4, 2)

print Calculator().pemdas(4, 2)
