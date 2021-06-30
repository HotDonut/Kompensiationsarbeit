using NumberGuesser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace NumberGuesser.ViewModels
{
    public class NumberGuesserViewModel : ViewModelBase
    {

        private ICommand submitGuessedNumberCommand;
        private ICommand newGameCommand;
        private int guessedNum;
        private int actualNumber;
        private string higherOrLower;
        private Random randomNumberGenerator = new Random();

        public ICommand SubmitGuessedNumberCommand => submitGuessedNumberCommand ??= new RelayCommand(SubmitGuessedNumber);
        public ICommand NewGameCommand => newGameCommand ??= new RelayCommand(NewGame);

        public NumberGuesserViewModel()
        {
            actualNumber = 42;
        }

        public int GuessedNumber {
            get { return guessedNum; }
            set
            {
                    if (guessedNum != value)
                {
                    guessedNum = value;
                    RaisePropertyChangedEvent();
                }
            }
        }

        public string HigherOrLower
        {
            get { return higherOrLower; }
            set
            {
                if (higherOrLower != value)
                {
                    higherOrLower = value;
                    RaisePropertyChangedEvent(nameof(HigherOrLower));
                }
            }
        }

        private void SubmitGuessedNumber(object commandParameter)
        {

            if (actualNumber > GuessedNumber)
            {
                HigherOrLower = "Your guessed number is too low!";
            }
            if(actualNumber < GuessedNumber)
            {
                HigherOrLower = "Your guessed number is too high!";
            }
            if(actualNumber == GuessedNumber)
            {
                HigherOrLower = "Your guess is correct!\nClick 'New Game' for the next round.";
            }
        }

        private void NewGame(object commandParameter)
        {
            actualNumber = randomNumberGenerator.Next(1, 100);
            HigherOrLower = "Make a guess to get new information!";
        }
    }
}
