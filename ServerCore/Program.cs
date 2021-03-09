using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    // 메모리 베리어 예제

    class Program
    {
        static volatile int number = 0;

        static void Thread_1()
        {

            // atomic = 원자성 --> 지켜지지 않으면 아이템 복사가 일어난다.

            // 집행검 User 2 인벤에 넣어라 - OK
            // 집행검 User 1 인벤에서 없애라 - fail

            for (int i = 0; i < 100000; i++)
            {
                // All or Nothing
                Interlocked.Increment(ref number);
            }
        }
        static void Thread_2()
        {
            for (int i = 0; i < 100000; i++)
            {
                Interlocked.Decrement(ref number);
            }
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Thread_1);
            Task t2 = new Task(Thread_2);
            t1.Start();
            t2.Start();

            Task.WaitAll(t1, t2);

            Console.WriteLine(number);


        }
    }
}
