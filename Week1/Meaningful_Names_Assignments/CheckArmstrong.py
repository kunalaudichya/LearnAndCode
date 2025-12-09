
def calculate_armstrong_sum(number):
    total = 0
    num_digits = 0

    temp = number
    while temp > 0:
        num_digits += 1
        temp //= 10

    temp = number
    while temp > 0:
        digit = temp % 10
        total += digit ** num_digits
        temp //= 10

    return total

user_number  = int(input("\nPlease Enter the Number to Check for Armstrong: "))

if (user_number == calculate_armstrong_sum(user_number)):
    print("\n %d is Armstrong Number.\n" % user_number)
else:
    print("\n %d is Not a Armstrong Number.\n" % user_number)