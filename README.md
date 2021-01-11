# AllCardsOnDeck PEDA

## Problem

Create an algorithm to put the cards of a deck in numerical order. The ACE is a one, and the Jack, Queen, King to be in that order after the 10 of the suit.

- you may only turn over TWO cards at any time
- you may only swap the position of TWO cards (that you have turned over) at any time
- you may only refer to cards based on their position in your list (left-to-right). You may choose to refer to the position by 0 or by 1, whichever you prefer.
- you may NOT keep track of the value of any cards in any manner other than by turning over TWO cards and considering their value. For instance, you may not "remember" any values, or write down their values elsewhere, etc
- take your cards/notes and shuffle them again, laying them out horizontally on the table again
- invite your friend or family member to follow your algorithm precisely. They may not ask you any clarifying questions. If they do not understand a step you must STOP and revise your algorithm and have them start OVER with a new sorted set of cards/paper

## Examples

List of an Ace, 4, 6, 8, 3, 9, 2 should be made into a list of Ace, 2, 3, 4, 6, 8, 9

## Data

Individual cards

- must contain face
- must contain suit
- must be able to calculate value of face
- will also create value for suit

2 Spots for the cards

- 2 variables that contain the value of 2 cards at any given moment, and compares the value of those two cards and swaps them

## Algorithm

Generate a placeholder individual card

- have the card store the face
- have the card store the suit
- have the card determine the face value
- have the card determine the suit value

Generate a placeholder for a list of cards

- refer to this list of cards as a deck

Generate a list of individual cards

- for each suit in a 52 card deck, assign a card a suit
- within assigning a card a suit, for each card face in a deck, assign a card a face
- for each completed card, store the card within a the deck

With the deck now generated, shuffle the deck

- while each card in the deck, starting with the last card in the deck, ending with the first card in the deck, pick up the last card in the deck and place it in a random spot within the deck
- before fully placing the card within the random spot in the deck, grab the card that the card that the last card in the deck is now replacing and place that card at the end of the deck
- keep doing this with the next to last card that was moved-s card until you reach the beginning of the deck and the last card that can be moved is the first card

With the deck now shuffled, un-shuffle the deck

- start with the first two cards, in the deck, now referred to as left card and right card

- continue to do the operation below until you reach the last card in the deck and the last card (the right card) is bigger than the second to last card (the left card)
  {
- while the right card is bigger than the left card, flip back over the left card
- make the right card the new left card
- flip over the card to the right of the left card and make that the new right card

- while the right card is smaller than the left card, swap positions between the left card and the right card
- make the left card the new right card
- flip over the card to the left of the right card and make that the new left card
  }

- the deck is now un-shuffled
