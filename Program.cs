namespace Task_1
{
    /*

   Есть лабиринт описанный в виде двумерного массива где 1 это стены, 0 - проход, 2 - искомая цель.
   Пример лабиринта:

   1 1 1 1 1 1 1
   1 0 0 0 0 0 1
   1 0 1 1 1 0 1
   0 0 0 0 1 0 0
   1 1 0 0 1 1 1
   1 1 1 0 1 1 1
   1 1 1 0 1 1 1

   Напишите алгоритм определяющий наличие выхода из лабиринта и выводящий на экран координаты точки выхода если таковые имеются.
   Определите сколько всего выходов имеется в лабиринте.
          
   Сигнатура метода: static int HasExit(int startI, int startJ, int[,] l)

   */

    internal class Program
    {

        static int HasExit(int startI, int startJ, int[,] l)
        {
            Stack<Tuple<int, int>> _path = new Stack<Tuple<int, int>>();

            if (l[startI, startJ] == 0) _path.Push(new(startI, startJ));

            int CountExit = 0;

            while (_path.Count > 0)
            {
                var current = _path.Pop();

                //Console.WriteLine($"{current.Item1},{current.Item2} ");

                if (l[current.Item1, current.Item2] == 2)
                {
                    Console.WriteLine($"Найден выход {CountExit + 1}. Координаты: ({current.Item1},{current.Item2}) \n");
                    CountExit++;
                }

                l[current.Item1, current.Item2] = 1;

                if (current.Item1 + 1 < l.GetLength(0)
                && l[current.Item1 + 1, current.Item2] != 1)
                    _path.Push(new(current.Item1 + 1, current.Item2));

                if (current.Item2 + 1 < l.GetLength(1) &&
                l[current.Item1, current.Item2 + 1] != 1)
                    _path.Push(new(current.Item1, current.Item2 + 1));

                if (current.Item1 > 0 && l[current.Item1 - 1, current.Item2] != 1)
                    _path.Push(new(current.Item1 - 1, current.Item2));

                if (current.Item2 > 0 && l[current.Item1, current.Item2 - 1] != 1)
                    _path.Push(new(current.Item1, current.Item2 - 1));
            }                            
            return CountExit;

        }


        static void Main(string[] args)
        {
            int[,] labirynth1 = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 0, 0, 0, 0, 0, 1 },
                {1, 0, 1, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1, 0, 2 },
                {1, 1, 0, 0, 1, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1 },
                {1, 1, 1, 2, 1, 1, 1 }
             };

            int CountExits = HasExit(3, 0, labirynth1);

            if (CountExits == 0)
                Console.WriteLine("Выходы не найдены :(");
            else 
                Console.WriteLine($"Количество выходов: {CountExits}");

            Console.ReadLine();

            
        }
    }
}
