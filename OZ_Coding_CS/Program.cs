using System;
using System.Collections;
using System.Collections.Generic;

namespace OZ_Coding_CS
{
    public enum InputType : byte
    {
        O = 0,
        X = 1,
        None = 2,
    }

    public struct InputData
    {
        public int x;
        public int y;

        public InputData(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class GameManager
    {
        // 맵 크기
        private const int _xSize = 3;
        private const int _ySize = 3;
        
        // 턴
        private InputType turn;
        // 맵
        private InputType[,] _map = new InputType[_ySize, _xSize];
        private Queue<InputData> inputs;
        
        // 초기화
        public void Init()
        {
            turn = InputType.O;
            inputs = new Queue<InputData>();

            for (int i = 0; i < _ySize; i++)
            {
                for(int j = 0; j < _xSize; j++)
                {
                    _map[i, j] = InputType.None;
                }
            }
        }

        // 맵에 표시할 아이콘
        private char PrintIcon(int x, int y)
        {
            char icon = ' ';
            switch(_map[y, x]){
                case InputType.O:
                    icon = 'O';
                    break;
                case InputType.X:
                    icon = 'X';
                    break;
            }

            return icon;
        }

        // 맵 출력
        public void PrintMap()
        {
            Console.WriteLine($" {PrintIcon(0, 0)} ┃ {PrintIcon(1, 0)} ┃ {PrintIcon(2, 0)} ");
            Console.WriteLine($"━━━╋━━━╋━━━");
            Console.WriteLine($" {PrintIcon(0, 1)} ┃ {PrintIcon(1, 1)} ┃ {PrintIcon(2, 1)} ");
            Console.WriteLine($"━━━╋━━━╋━━━");
            Console.WriteLine($" {PrintIcon(0, 2)} ┃ {PrintIcon(1, 2)} ┃ {PrintIcon(2, 2)} ");
        }

        // 입력값 정상인지 체크
        public bool CheckInput(int x, int y)
        {
            if(x < 0 || x >= _xSize || y < 0 || y >= _ySize || _map[y, x] != InputType.None)
            {
                Console.WriteLine("잘못된 좌표 입력 값입니다.");
                return true;
            }
            return false;
        }

        // 입력 값 map에 입력
        public void InputTicTakTok(int x, int y)
        {
            _map[y, x] = turn;
            inputs.Enqueue(new InputData(x, y));

            turn = (InputType)(1 - (int)turn);
        }

        // 턴 종료
        public void EndTurn()
        {
            if (inputs.Count > 6)
            {
                var input = inputs.Dequeue();
                _map[input.y, input.x] = InputType.None;
            }
            Console.Clear();
        }

        // 게임 종료해도 되는지 체크
        public bool CheckEnd()
        {
            for (int i = 0; i < _ySize; i++)
            {
                if (_map[i, 0] == InputType.None)
                    continue;
                if (_map[i, 0] == _map[i, 1] && _map[i, 1] == _map[i, 2])
                    return true;
            }

            // 세로 체크
            for (int i = 0; i < _xSize; i++)
            {
                if (_map[0, i] == InputType.None)
                    continue;
                if (_map[0, i] == _map[1, i] && _map[1, i] == _map[2, i])
                    return true;
            }

            // 대각선 체크
            if (_map[0, 0] != InputType.None)
                if (_map[0, 0] == _map[1, 1] && _map[1, 1] == _map[2, 2])
                    return true;
            if (_map[0, 2] != InputType.None)
                if (_map[0, 2] == _map[1, 1] && _map[1, 1] == _map[2, 0])
                    return true;

            return false;
        }

        // 게임 종료
        public void EndGame(Player winner)
        {
            Console.Clear();
            PrintMap();
            Console.WriteLine($"{winner.Name}님의 승리입니다.");
        }
    }

    public class Player
    {
        public string Name { get; private set; }

        // 이름 입력
        public void InputName()
        {
            Console.Write("이름을 입력해주세요 : ");
            Name = Console.ReadLine();
        }

        // 좌표 입력
        public void InputPos(GameManager gameManager)
        {
            int x = 0, y = 0;
            do
            {
                Console.Write($"{Name}님의 턴입니다. 좌표를 입력해주세요 : ");
                string input = Console.ReadLine();

                try
                {
                    x = int.Parse(input.Split()[0]);
                    y = int.Parse(input.Split()[1]);
                }
                catch(Exception e)
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                    continue;
                }
                
            } while (gameManager.CheckInput(x - 1, y - 1));

            gameManager.InputTicTakTok(x - 1, y - 1);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.Init();

            Player player1 = new Player();
            Player player2 = new Player();

            player1.InputName();
            player2.InputName();

            Console.Clear();
            while (true)
            {
                gameManager.PrintMap();
                player1.InputPos(gameManager);
                if (gameManager.CheckEnd())
                {
                    gameManager.EndGame(player1);
                    break;
                }
                gameManager.EndTurn();
                gameManager.PrintMap();

                player2.InputPos(gameManager);
                if (gameManager.CheckEnd())
                {
                    gameManager.EndGame(player1);
                    break;
                }
                gameManager.EndTurn();   
            }
        }
    }
}
