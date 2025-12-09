import random
def roll_the_dice(sides):
    return random.randint(1, sides) 


def play_dice_game():
    sides=6
    is_game_over=False

    while is_game_over==False:
        user_input=input("Ready to roll? Enter Q to Quit")
        if user_input.lower() !="q":
            result=roll_the_dice(sides)
            print("You have rolled a",result)
        else:
            is_game_over=true

play_dice_game()