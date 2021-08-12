using System;
using System.ComponentModel;
using System.Windows.Input;

namespace LcrSimulator
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private LcrSimulation _lcrSimulation;
        public MainWindowViewModel()
        {
            
            LcrSimulation = new LcrSimulation() { NumberOfPlayers = 3, NumberOfGames = 1};
            RunCommand = new RelayCommand<object>(RunCommandExecute, RunCommandCanExecute);
        }

        public LcrSimulation LcrSimulation
        {
            get => _lcrSimulation;
            set => _lcrSimulation = value;
        }

        private ICommand _runCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RunCommand
        {
            get
            {
                if (_runCommand == null)
                    _runCommand = new RelayCommand<object>(RunCommandExecute, RunCommandCanExecute);
                return _runCommand;
            }
            set 
            {
                _runCommand = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RunCommand)));
            }
        }

        private bool RunCommandCanExecute(object parameter)
        {
            // Only allow execute if parameter has data and ValidateData is true
            return parameter != null && ((LcrSimulation)parameter).ValidateData();
        }

        public void RunCommandExecute(object parameter)
        {
            var param = (LcrSimulation)parameter;
            param.ShortestGame = 10;
            param.LongestGame = 10;
            param.AverageGameLength = 10;
        }

        public class RelayCommand<T> : ICommand
        {
            #region Fields

            readonly Action<T> _execute = null;
            readonly Predicate<T> _canExecute = null;

            #endregion

            #region Constructors

            /// <summary>
            /// Initializes a new instance of <see cref="DelegateCommand{T}"/>.
            /// </summary>
            /// <param name="execute">Delegate to execute when Execute is called on the command.  This can be null to just hook up a CanExecute delegate.</param>
            /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
            public RelayCommand(Action<T> execute)
                : this(execute, null)
            {
            }

            /// <summary>
            /// Creates a new command.
            /// </summary>
            /// <param name="execute">The execution logic.</param>
            /// <param name="canExecute">The execution status logic.</param>
            public RelayCommand(Action<T> execute, Predicate<T> canExecute)
            {
                if (execute == null)
                    throw new ArgumentNullException("execute");

                _execute = execute;
                _canExecute = canExecute;
            }

            #endregion

            #region ICommand Members

            ///<summary>
            ///Defines the method that determines whether the command can execute in its current state.
            ///</summary>
            ///<param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
            ///<returns>
            ///true if this command can be executed; otherwise, false.
            ///</returns>
            public bool CanExecute(object parameter)
            {
                return _canExecute == null ? true : _canExecute((T)parameter);
            }

            ///<summary>
            ///Occurs when changes occur that affect whether or not the command should execute.
            ///</summary>
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            ///<summary>
            ///Defines the method to be called when the command is invoked.
            ///</summary>
            ///<param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
            public void Execute(object parameter)
            {
                _execute((T)parameter);
            }

            #endregion
        }
    }
}
