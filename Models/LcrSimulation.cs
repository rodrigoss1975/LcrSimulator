using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LcrSimulator
{
    public class LcrSimulation : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _error;
        private int _numberOfPlayers;
        private int _numberOfGames;
        private int _shortestGame;
        private int _longestGame;
        private double _averageGameLength;

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                //validator.Invoke(newValue);
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
        #endregion

        public int NumberOfPlayers 
        {
            get => _numberOfPlayers; 
            set => SetProperty(ref _numberOfPlayers, value);
        }
        public int NumberOfGames
        {
            get => _numberOfGames;
            set => SetProperty(ref _numberOfGames, value);
        }
        public int ShortestGame
        {
            get => _shortestGame;
            set => SetProperty(ref _shortestGame, value);
        }
        public int LongestGame
        {
            get => _longestGame;
            set => SetProperty(ref _longestGame, value);
        }
        public double AverageGameLength
        {
            get => _averageGameLength;
            set => SetProperty(ref _averageGameLength, value);
        }
        public string Error
        {
            get => _error;
            set => SetProperty(ref _error, value);
        }

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(NumberOfPlayers):
                        if(!ValidateNumberOfPlayers()) 
                            error = "Number of players has to be 3 or greater.";
                        break;
                    case nameof(NumberOfGames):
                        if (!ValidateNumberOfGames())
                            error = "Number of players has to be 1 or greater.";
                        break;
                }
                return error;
            }
        }

        private bool ValidateNumberOfPlayers()
        {
            return _numberOfPlayers > 2;
        }

        private bool ValidateNumberOfGames()
        {
            return _numberOfGames > 0;
        }

        public bool ValidateData()
        {
            return ValidateNumberOfGames() && ValidateNumberOfPlayers();
        }

    }
}
