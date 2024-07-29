using XOSimpleToolkit.ClassicXO.AI;
using XOSimpleToolkit.ClassicXO.Constants;
using XOSimpleToolkit.Common.Enums;
using XOSimpleToolkit.Common.Interfaces;
using XOSimpleToolkit.Common.Models;

namespace XOSimpleToolkit.ClassicXO.Game
{
    /// <summary>
    /// Игровая сессия для классических крестиков-ноликов
    /// </summary>
    public class ClassicXOSession : IXOSession
    {
        private Human _humanPlayer = default!;
        private Computer _computerPlayer = default!;
        private Cell[,] _field = default!;
        private Difficulty _difficulty;
        private Turn _currentTurn;
        private Turn _firstTurn;

        private int _totalMovesCount;
        private bool _isVictorious;
        private bool _isNobody;

        public event Action<MoveInformation>? HumanMoveEvent;
        public event Action<MoveInformation>? ComputerMoveEvent;
        public event Action<VictoryInformation>? HumanVictoryEvent;
        public event Action<VictoryInformation>? ComputerVictoryEvent;
        public event Action? DrawVictoryEvent;

        /// <summary>
        /// Старт игры
        /// </summary>
        /// <param name="difficulty">Уровень сложности</param>
        /// <param name="first">Кто ходит первым</param>
        public void Start(Difficulty difficulty, Turn first)
        {
            SetGameOptions(difficulty, first);
            if (first == Turn.Computer)
            {
                ComputerMove();
                return;
            }

            _currentTurn = Turn.Human;
        }

        private void SetGameOptions(Difficulty difficulty, Turn first)
        {
            _difficulty = difficulty;
            _totalMovesCount = FieldConstants.FieldWidth * FieldConstants.FieldHeight;
            _firstTurn = first;
            _isNobody = false;
            _isVictorious = false;
            CreateField();
            AddPlayers();
        }

        private void AddPlayers()
        {
            _computerPlayer = ComputerFactory(_difficulty);
            _humanPlayer = new Human();
        }

        private Computer ComputerFactory(Difficulty difficalty)
        {
            Strategy strategy = difficalty switch
            {
                Difficulty.Easy => new SimpleStrategy(),
                Difficulty.Normal => new NormalStrategy(),
                Difficulty.Hard => new CleverStrategy(),
                _ => throw new ArgumentException("Такой уровень сложности отсутствует!")
            };

            return new Computer(strategy, _field);
        }

        private void CreateField()
        {
            _field = new Cell[FieldConstants.FieldWidth, FieldConstants.FieldHeight];
            for (int i = 0; i < FieldConstants.FieldWidth; i++)
            {
                for (int j = 0; j < FieldConstants.FieldHeight; j++)
                {
                    _field[i, j] = new Cell(i, j, CellState.Empty);
                }
            }
        }

        private void HumanMove(int x, int y)
        {
            var cell = _humanPlayer.MakeMove(_field, x, y);
            if (cell != null)
            {
                var moveInfo = new MoveInformation()
                {
                    X = cell.X,
                    Y = cell.Y,

                    WhoWasFirst = _firstTurn
                };
                OnHumanMoveEvent(moveInfo);
                _currentTurn = Turn.Computer;
                _totalMovesCount--;
            }
        }

        private void ComputerMove()
        {
            var cell = _computerPlayer.MakeMove();
            if (cell != null)
            {
                var moveInfo = new MoveInformation()
                {
                    X = cell.X,
                    Y = cell.Y,
                    WhoWasFirst = _firstTurn
                };
                OnComputerMoveEvent(moveInfo);
                _currentTurn = Turn.Human;
                _totalMovesCount--;
            }
        }

        /// <summary>
        /// Ход игрока/компьютера
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        public void Move(int x, int y)
        {
            if (_currentTurn == Turn.Human && !_isVictorious && !_isNobody)
            {
                HumanMove(x, y);
                ScanField();
            }
            if (_currentTurn == Turn.Computer && !_isVictorious && !_isNobody)
            {
                ComputerMove();
                ScanField();
            }
        }

        private void ScanField()
        {
            CompWin();
            HumanWin();
            NoOneWin();
        }

        private void NoOneWin()
        {
            if (_totalMovesCount == 0 && !_isVictorious)
            {
                OnDrawVictoryEvent();
                _isNobody = true;
            }
        }

        private void CompWin()
        {
            var victoryCombination = GetVictoryCombinationCells(CellState.Computer);
            if (victoryCombination != null)
            {
                var victoryInfo = new VictoryInformation()
                {
                    VictoryCombinationCells = victoryCombination,
                    WhoWasFirst = _firstTurn
                };
                OnComputerVictoryEvent(victoryInfo);
                _isVictorious = true;
            }
        }

        private void HumanWin()
        {
            var victoryCombination = GetVictoryCombinationCells(CellState.Human);
            if (victoryCombination != null)
            {
                var victoryInfo = new VictoryInformation()
                {
                    VictoryCombinationCells = victoryCombination,
                    WhoWasFirst = _firstTurn
                };
                OnHumanVictoryEvent(victoryInfo);
                _isVictorious = true;
            }
        }

        private IEnumerable<Cell>? GetVictoryCombinationCells(CellState subject)
        {
            for (int i = 0; i < 3; i++)
            {
                if (_field[i, 0].CellState == subject && _field[i, 1].CellState == subject && _field[i, 2].CellState == subject)
                {
                    return [_field[i, 0], _field[i, 1], _field[i, 2]];
                }
                else if (_field[0, i].CellState == subject && _field[1, i].CellState == subject && _field[2, i].CellState == subject)
                {
                    return [_field[0, i], _field[1, i], _field[2, i]];
                }
            }

            if (_field[0, 0].CellState == subject && _field[1, 1].CellState == subject && _field[2, 2].CellState == subject)
            {
                return [_field[0, 0], _field[1, 1], _field[2, 2]];
            }

            if (_field[0, 2].CellState == subject && _field[1, 1].CellState == subject && _field[2, 0].CellState == subject)
            {
                return [_field[0, 2], _field[1, 1], _field[2, 0]];
            }

            return null;
        }

        protected virtual void OnHumanMoveEvent(MoveInformation moveInformation)
        {
            var raiseEvent = HumanMoveEvent;
            if (raiseEvent != null)
            {
                raiseEvent(moveInformation);
            }
        }

        protected virtual void OnComputerMoveEvent(MoveInformation moveInformation)
        {
            var raiseEvent = ComputerMoveEvent;
            if (raiseEvent != null)
            {
                raiseEvent(moveInformation);
            }
        }

        protected virtual void OnHumanVictoryEvent(VictoryInformation victoryInformation)
        {
            var raiseEvent = HumanVictoryEvent;
            if (raiseEvent != null)
            {
                raiseEvent(victoryInformation);
            }
        }

        protected virtual void OnComputerVictoryEvent(VictoryInformation victoryInformation)
        {
            var raiseEvent = ComputerVictoryEvent;
            if (raiseEvent != null)
            {
                raiseEvent(victoryInformation);
            }
        }

        protected virtual void OnDrawVictoryEvent()
        {
            var raiseEvent = DrawVictoryEvent;
            if (raiseEvent != null)
            {
                raiseEvent();
            }
        }
    }
}
