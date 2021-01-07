using System;
using System.Collections.Generic;

namespace AllCardsOnDeck
{
    class Program
    {
        static void Main(string[] args)
        {

            var listOfSuits = new List<string>()
            {
              " of Spades", " of Clubs", " of Hearts", " of Diamonds"
            };
            var listOfRanks = new List<string>()
            {
              "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"
            };
            var cardDeckList = new List<string>() { };

            foreach (var suit in listOfSuits)
            {
                foreach (var rank in listOfRanks)
                {
                    cardDeckList.Add(rank + suit);
                }
            }

            var cardDeckListValues = new List<int>(){
            14, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
            14, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
            14, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,
            14, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,};

            var lastUnmovedCardPosition = cardDeckList.Count;
            var randomNumber = 0;
            var randomCardBasedOnRandomNumber = "";
            var randomCardValueBasedOnRandomNumber = 0;

            while (lastUnmovedCardPosition-- > 0)
            {
                randomNumber = new Random().Next(0, lastUnmovedCardPosition);

                randomCardBasedOnRandomNumber = cardDeckList[randomNumber];
                cardDeckList[randomNumber] = cardDeckList[lastUnmovedCardPosition];
                cardDeckList[lastUnmovedCardPosition] = randomCardBasedOnRandomNumber;

                randomCardValueBasedOnRandomNumber = cardDeckListValues[randomNumber];
                cardDeckListValues[randomNumber] = cardDeckListValues[lastUnmovedCardPosition];
                cardDeckListValues[lastUnmovedCardPosition] = randomCardValueBasedOnRandomNumber;
            }

            Console.WriteLine(cardDeckList[0]);
            Console.WriteLine(cardDeckList[1]);

            // Adventure mode
            var playerOnesHand = new List<string>() { };
            var playerTwosHand = new List<string>() { };

            playerOnesHand.Add(cardDeckList[2]);
            playerOnesHand.Add(cardDeckList[4]);
            playerTwosHand.Add(cardDeckList[3]);
            playerTwosHand.Add(cardDeckList[5]);

            Console.WriteLine($"Player 1 received a {playerOnesHand[0]} and a {playerOnesHand[1]}");
            Console.WriteLine($"Player 2 received a {playerTwosHand[0]} and a {playerTwosHand[1]}");

            // Epic mode
            var playerOneWarDeck = new List<string>() { };
            var playerTwoWarDeck = new List<string>() { };
            var playerOneWarDeckValues = new List<int>() { };
            var playerTwoWarDeckValues = new List<int>() { };

            Console.WriteLine("War is beginning soon!");

            for (var i = 0; i < cardDeckList.Count; i++)
            {
                playerOneWarDeck.Add(cardDeckList[i]);
                playerOneWarDeckValues.Add(cardDeckListValues[i]);
                i++;
                playerTwoWarDeck.Add(cardDeckList[i]);
                playerTwoWarDeckValues.Add(cardDeckListValues[i]);
            }
            var winningDeckSize = playerOneWarDeck.Count;
            var losingDeckSize = playerTwoWarDeck.Count;
            Console.WriteLine("Decks have been seperated");
            Console.WriteLine("Prepare for battle!");

            while ((playerOneWarDeckValues.Count != 0) || (playerTwoWarDeckValues.Count != 0))
            {
                for (var currentCardInHand = 0; currentCardInHand < losingDeckSize; currentCardInHand++)
                {
                    if ((playerOneWarDeckValues[currentCardInHand] > playerTwoWarDeckValues[currentCardInHand]) && (playerTwoWarDeckValues.Count != 0))
                    {
                        playerOneWarDeck.Add(playerTwoWarDeck[currentCardInHand]);
                        playerTwoWarDeck.Remove(playerTwoWarDeck[currentCardInHand]);
                        playerOneWarDeckValues.Add(playerOneWarDeckValues[currentCardInHand]);
                        playerTwoWarDeckValues.Remove(playerTwoWarDeckValues[currentCardInHand]);
                        Console.WriteLine($"Player 2 lost the {playerTwoWarDeck[currentCardInHand]} to the {playerOneWarDeck[currentCardInHand]}");
                    }
                    else if ((playerOneWarDeckValues[currentCardInHand] < playerTwoWarDeckValues[currentCardInHand]) && (playerOneWarDeckValues.Count != 0))
                    {
                        playerTwoWarDeck.Add(playerOneWarDeck[currentCardInHand]);
                        playerOneWarDeck.Remove(playerOneWarDeck[currentCardInHand]);
                        playerTwoWarDeckValues.Add(playerTwoWarDeckValues[currentCardInHand]);
                        playerOneWarDeckValues.Remove(playerOneWarDeckValues[currentCardInHand]);
                        Console.WriteLine($"Player 1 lost the {playerOneWarDeck[currentCardInHand]} to the {playerTwoWarDeck[currentCardInHand]}");
                    }
                    else
                    {
                        Console.WriteLine("War!");
                        var battleGround = new List<string>() { };
                        var battleGroundValues = new List<int>() { };
                        do
                        {
                            battleGround.Add(playerOneWarDeck[currentCardInHand]);
                            battleGround.Add(playerTwoWarDeck[currentCardInHand]);
                            playerOneWarDeck.Remove(playerOneWarDeck[currentCardInHand]);
                            playerTwoWarDeck.Remove(playerTwoWarDeck[currentCardInHand]);
                            battleGroundValues.Add(playerOneWarDeckValues[currentCardInHand]);
                            battleGroundValues.Add(playerTwoWarDeckValues[currentCardInHand]);
                            playerOneWarDeckValues.Remove(playerOneWarDeckValues[currentCardInHand]);
                            playerTwoWarDeckValues.Remove(playerTwoWarDeckValues[currentCardInHand]);
                            currentCardInHand--;
                            Console.WriteLine("The battle rages on!");
                        }
                        while ((playerOneWarDeckValues[currentCardInHand] == playerTwoWarDeckValues[currentCardInHand]) && ((playerOneWarDeckValues.Count != 0) || (playerTwoWarDeckValues.Count != 0)));

                        Console.WriteLine("The victor has risen");

                        for (var warLength = battleGround.Count - 1; warLength > 0; warLength--)
                        {
                            if (playerOneWarDeckValues[currentCardInHand] > playerTwoWarDeckValues[currentCardInHand])
                            {
                                playerOneWarDeck.Add(battleGround[warLength]);
                                playerOneWarDeckValues.Add(battleGroundValues[warLength]);
                                Console.WriteLine("Adding cards to the victor's deck");
                            }
                            else
                            {
                                playerTwoWarDeck.Add(battleGround[warLength]);
                                playerTwoWarDeckValues.Add(battleGroundValues[warLength]);
                                Console.WriteLine("Adding cards to the victor's deck");
                            }
                        }

                        if (playerOneWarDeckValues[currentCardInHand] > playerTwoWarDeckValues[currentCardInHand])
                        {
                            Console.WriteLine("Player 1 won the battle!");
                        }
                        else
                        {
                            Console.WriteLine("Player 2 won the battle!");
                        }
                    }

                    if (playerOneWarDeckValues.Count >= playerTwoWarDeckValues.Count)
                    {
                        winningDeckSize = playerOneWarDeckValues.Count;
                        losingDeckSize = playerTwoWarDeckValues.Count;
                    }
                    else
                    {
                        winningDeckSize = playerTwoWarDeckValues.Count;
                        losingDeckSize = playerOneWarDeckValues.Count;
                    }
                }
            }
            if (playerOneWarDeckValues.Count == 0)
            {
                Console.WriteLine("Player Two Won the War!!!");
            }
            else
            {
                Console.WriteLine("Player One Won the War!!!");
            }

        }
    }
}
