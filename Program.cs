using System;
using System.Collections.Generic;

namespace AllCardsOnDeck
{
    class Program
    {

        class Card
        {
            public string Suit { get; set; }
            public string Rank { get; set; }
            public int RelativeValue()
            {

                switch (Rank)
                {
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                        return int.Parse(Rank);
                    case "Jack":
                        return 11;
                    case "Queen":
                        return 12;
                    case "King":
                        return 13;
                    case "Ace":
                        return 1;
                    default:
                        return 0;
                }
            }
            public int AbsoluteValue()
            {
                var suitValue = 0;
                var totalValue = 0;
                switch (Suit)
                {
                    case " of Spades":
                        suitValue = 1;
                        break;
                    case " of Clubs":
                        suitValue = 2;
                        break;
                    case " of Hearts":
                        suitValue = 3;
                        break;
                    case " of Diamonds":
                        suitValue = 4;
                        break;

                }
                totalValue = RelativeValue() * suitValue;
                return totalValue;
            }
        }
        static List<Card> Build(List<Card> deckToBeBuilt)
        // Method that builds deck, using the Card class to create each card and places each card in a list
        {
            var listOfSuits = new List<string>()
                 {
                    " of Spades", " of Clubs", " of Hearts", " of Diamonds"
                  };
            var listOfRanks = new List<string>()
                 {
                    "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"
                  };
            foreach (var suit in listOfSuits)
            {
                foreach (var rank in listOfRanks)
                {
                    var newCard = new Card()
                    {
                        Rank = rank,
                        Suit = suit,
                    };
                    deckToBeBuilt.Add(newCard);
                }
            }
            return deckToBeBuilt;
        }
        static List<Card> Shuffle(List<Card> deckToBeShuffled)
        // Method that shuffles deck on command
        {
            var lastUnmovedCardPosition = deckToBeShuffled.Count;
            var randomNumber = 0;
            var randomCardBasedOnRandomNumber = deckToBeShuffled[randomNumber];

            while (lastUnmovedCardPosition-- > 0)
            {
                randomNumber = new Random().Next(0, lastUnmovedCardPosition);

                randomCardBasedOnRandomNumber = deckToBeShuffled[randomNumber];
                deckToBeShuffled[randomNumber] = deckToBeShuffled[lastUnmovedCardPosition];
                deckToBeShuffled[lastUnmovedCardPosition] = randomCardBasedOnRandomNumber;
            }
            return deckToBeShuffled;
        }
        static List<Card> Organize(List<Card> deckToBeOrganized)
        {
            // - start with the first two cards, in the deck, now referred to as left card and right card
            var leftCardIndex = 0;
            var rightCardIndex = 1;
            var leftCard = deckToBeOrganized[leftCardIndex];
            var rightCard = deckToBeOrganized[rightCardIndex];

            // - continue to do the operation below until you reach the last card in the deck and the last card (the right card) is bigger than the second to last card (the left card)
            do
            {
                // - while the right card is bigger than the left card, flip back over the left card
                while (leftCard.AbsoluteValue() < rightCard.AbsoluteValue())
                {
                    // - make the right card the new left card
                    // - flip over the card to the right of the left card and make that the new right card
                    if (rightCardIndex < deckToBeOrganized.Count - 1)
                    {
                        leftCardIndex++;
                        rightCardIndex++;
                    }
                    leftCard = deckToBeOrganized[leftCardIndex];
                    rightCard = deckToBeOrganized[rightCardIndex];
                }
                // - while the right card is smaller than the left card, swap positions between the left card and the right card
                while (leftCard.AbsoluteValue() > rightCard.AbsoluteValue())
                {
                    // - make the left card the new right card
                    var transitioningCard = leftCard;
                    deckToBeOrganized[leftCardIndex] = rightCard;
                    deckToBeOrganized[rightCardIndex] = transitioningCard;
                    if (leftCardIndex > 0)
                    {
                        leftCardIndex--;
                        rightCardIndex--;
                    }
                    // - flip over the card to the left of the right card and make that the new left card
                    leftCard = deckToBeOrganized[leftCardIndex];
                    rightCard = deckToBeOrganized[rightCardIndex];
                }
            }
            while (!((deckToBeOrganized[0].AbsoluteValue() == 1) && (deckToBeOrganized[deckToBeOrganized.Count - 1].AbsoluteValue() == deckToBeOrganized.Count - 1)));
            return deckToBeOrganized;
        }
        static void Main(string[] args)
        {
            var deck = new List<Card>();
            deck = Build(deck);

            Console.WriteLine("\n\nDeck has been built");
            foreach (var card in deck)
            {
                Console.WriteLine(card.Rank + card.Suit);
            }

            deck = Shuffle(deck);
            Console.WriteLine("\n\nDeck has been shuffled");
            Console.WriteLine($"{deck[0].Rank + deck[0].Suit} and {deck[1].Rank + deck[1].Suit}");
            Console.WriteLine("...are the first two cards of the shuffled deck\n");

            // Adventure mode
            var playerOnesHand = new List<Card>();
            var playerTwosHand = new List<Card>();

            playerOnesHand.Add(deck[2]);
            playerOnesHand.Add(deck[4]);
            playerTwosHand.Add(deck[3]);
            playerTwosHand.Add(deck[5]);

            Console.WriteLine($"\nPlayer 1 received a {playerOnesHand[0].Rank + playerOnesHand[0].Suit} and a {playerOnesHand[1].Rank + playerOnesHand[1].Suit}");
            Console.WriteLine($"Player 2 received a {playerTwosHand[0].Rank + playerTwosHand[0].Suit} and a {playerTwosHand[1].Rank + playerTwosHand[1].Suit}\n");

            // Epic mode
            var playerOneWarDeck = new List<Card>();
            var playerTwoWarDeck = new List<Card>();

            Console.WriteLine("War is beginning soon!");

            for (var i = 0; i < deck.Count; i++)
            {
                playerOneWarDeck.Add(deck[i]);
                i++;
                playerTwoWarDeck.Add(deck[i]);
            }
            Console.WriteLine("Decks have been seperated");
            Console.WriteLine("Prepare for battle!");

            while (playerOneWarDeck.Count > 1 && playerTwoWarDeck.Count > 1)
            {
                if (playerOneWarDeck[0].RelativeValue() > playerTwoWarDeck[0].RelativeValue())
                {
                    playerOneWarDeck.Add(playerTwoWarDeck[0]);
                    playerTwoWarDeck.Remove(playerTwoWarDeck[0]);
                    Console.WriteLine($"Player 2 lost the {playerTwoWarDeck[0].Rank + playerTwoWarDeck[0].Suit} to the {playerOneWarDeck[0].Rank + playerOneWarDeck[0].Suit}");
                }
                else if (playerOneWarDeck[0].RelativeValue() < playerTwoWarDeck[0].RelativeValue())
                {
                    playerTwoWarDeck.Add(playerOneWarDeck[0]);
                    playerOneWarDeck.Remove(playerOneWarDeck[0]);
                    Console.WriteLine($"Player 1 lost the {playerOneWarDeck[0].Rank + playerOneWarDeck[0].Suit} to the {playerTwoWarDeck[0].Rank + playerTwoWarDeck[0].Suit}");
                }
                else
                {
                    Console.WriteLine("War!");
                    var battleGround = new List<Card>();
                    do
                    {
                        battleGround.Add(playerOneWarDeck[0]);
                        battleGround.Add(playerTwoWarDeck[0]);
                        playerOneWarDeck.Remove(playerOneWarDeck[0]);
                        playerTwoWarDeck.Remove(playerTwoWarDeck[0]);
                        Console.WriteLine("The battle rages on!");

                    }
                    while (playerOneWarDeck[0].RelativeValue() == playerTwoWarDeck[0].RelativeValue());

                    Console.WriteLine("The victor has risen");

                    for (var warLength = battleGround.Count - 1; warLength > 0; warLength--)
                    {
                        if (playerOneWarDeck[0].RelativeValue() > playerTwoWarDeck[0].RelativeValue())
                        {
                            playerOneWarDeck.Add(battleGround[warLength]);
                            Console.WriteLine("Adding cards to the victor's deck");
                        }
                        else
                        {
                            playerTwoWarDeck.Add(battleGround[0]);
                            Console.WriteLine("Adding cards to the victor's deck");
                        }
                    }

                    if (playerOneWarDeck[0].RelativeValue() > playerTwoWarDeck[0].RelativeValue())
                    {
                        Console.WriteLine("Player 1 won the battle!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 won the battle!");
                    }
                }
            }

            if (playerOneWarDeck.Count <= 1)
            {
                Console.WriteLine("Player 2 Won the War!!!");
            }
            else if (playerTwoWarDeck.Count <= 1)
            {
                Console.WriteLine("Player 1 Won the War!!!");
            }
            else
            {
                Console.WriteLine("There are no winners in war");
            }

            Console.WriteLine("Organizing deck...");
            deck = Organize(deck);
            Console.WriteLine("\n\nDeck has been organized");
            foreach (var card in deck)
            {
                Console.WriteLine(card.Rank + card.Suit);
            }

        }
    }
}
