def is_correct_guess(guess):
    return guess.isdigit() and 1 <= int(guess) <= 100

def guess_the_number():
    ultimate_number=random.randint(1,100)
    is_guessed_correct=False
    user_input=input("Guess a number between 1 and 100:")
    total_attempts=0
    while not is_guessed_correct:
        if not is_correct_guess(user_input):
            user_input=input("I wont count this one Please enter a number between 1 to 100")
            continue

        total_attempts+=1
        guess=int(user_input)

        if guess<ultimate_number:
            user_input=input("Too low. Guess again")
        elif guess>ultimate_number:
            user_input=input("Too High. Guess again")
        else:
            print("You guessed it in",total_attempts,"guesses!")
            is_guessed_correct=True


guess_the_number()