using System.Runtime.CompilerServices;

namespace DragonsWay.Logic
{
    public class Game
    {
        private char[,] _caven;

        public Game(int n, string path)
        {
            N = n;
            Path = path;
            _caven = new char[N, N];
            Start();
        }


        public int N { get; }

        public string Path { get; set; }

        public override string ToString()
        {
       
            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                output += $"{i}";
                for (int j = 0; j < N; j++)
                {
                    
                    output += $"{_caven[i, j]}";
                }

                output += "\n";
            }
            return output;
        }
        private void Start()
        {
            Caven();
            Win();
        }
        private void Caven()
        {
            for (int i = 0; i < N; i++)
            {
                _caven[0, i] = '▄';
            }
            for (int i = 0; i < N - 1; i++)
            {
                _caven[1, i] = ' ';
            }

            _caven[1, N - 1] = '█';
            for (int i = 2; i < N - 2; i++)
            {
                _caven[i, 0] = '█';
                for (int j = 1; j < N - 1; j++)
                {
                    _caven[i, j] = ' ';
                }
                _caven[i, N - 1] = '█';

            }
            _caven[N - 2, 0] = '█';
            for (int i = 1; i < N; i++)
            {
                _caven[N - 2, i] = ' ';
            }

            for (int i = 0; i < N; i++)
            {
                _caven[N - 1, i] = '▄';
            }


        }

        private char PathToFree()
        {
            char step = ' ';
            for (int i = 0; i < Path.Length;i++)
            {
                 step = Path[i];
            }
            return step;
        }

        private void Win()
        {
            for (int i = 1; i < N - 1; i++)
            {
                for (int j = 1; j < N-1; j++)
                {
                    var step = PathToFree();
                    if (step == '→'  )
                    {
                        _caven[i, j] = step;
                    }
                    else
                    {
                        if (step == '↓'  )
                        {
                            _caven[i + 1, j] = step;
                            i++;
                            j--;
                        }
                        else
                        {
                            return;
                        }     
                    }   
                }
            }
        }
    }
}