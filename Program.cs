using System;
using System.Collections.Generic;

namespace AllCardsOnDeck
{
    class Program
    {
        static void Main(string[] args)
        {
            var cardDeckList = new List<string>() {
            "Ace of Spades", "2 of Spades", "3 of Spades", "4 of Spades",
            "5 of Spades", "6 of Spades", "7 of Spades", "8 of Spades", "9 of Spades",
            "10 of Spades", "Jack of Spades", "Queen of Spades", "King of Spades",

            "Ace of Clubs", "2 of Clubs", "3 of Clubs", "4 of Clubs",
            "5 of Clubs", "6 of Clubs", "7 of Clubs", "8 of Clubs", "9 of Clubs",
            "10 of Clubs", "Jack of Clubs", "Queen of Clubs", "King of Clubs",

            "Ace of Hearts", "2 of Hearts", "3 of Hearts", "4 of Hearts",
            "5 of Hearts", "6 of Hearts", "7 of Hearts", "8 of Hearts", "9 of Hearts",
            "10 of Hearts", "Jack of Hearts", "Queen of Hearts", "King of Hearts",

            "Ace of Diamonds", "2 of Diamonds", "3 of Diamonds", "4 of Diamonds",
            "5 of Diamonds", "6 of Diamonds", "7 of Diamonds", "8 of Diamonds", "9 of Diamonds",
            "10 of Diamonds", "Jack of Diamonds", "Queen of Diamonds", "King of Diamonds"};

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
            var deckSize = cardDeckList.Count;

            var playerOneWarDeck = new List<string>() { };
            var playerTwoWarDeck = new List<string>() { };
            var playerOneWarDeckValues = new List<int>() { };
            var playerTwoWarDeckValues = new List<int>() { };

            Console.WriteLine("War is beginning soon!");

            for (var i = 0; i < deckSize; i++)
            {
                playerOneWarDeck.Add(cardDeckList[i]);
                playerOneWarDeckValues.Add(cardDeckListValues[i]);
                i++;
                playerTwoWarDeck.Add(cardDeckList[i]);
                playerTwoWarDeckValues.Add(cardDeckListValues[i]);
            }

            Console.WriteLine("Decks have been seperated");
            Console.WriteLine("Prepare for battle!");
        }
    }
}
