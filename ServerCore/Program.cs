using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    
    class Program
    {
        // 1. 근성
        // 2. 양보
        // 3. 갑질

        // 상호배제
        // Monitor
        static object _lock = new object();
        static SpinLock _lock2 = new SpinLock();
        // 직접 만든다.

        class Reward
        {

        }
        // RWlock ReaderWriteLock
        static ReaderWriterLockSlim _lock3 = new ReaderWriterLockSlim();
        static Reward GetRewardByid(int id)
        {
            _lock3.EnterReadLock();
            _lock3.ExitReadLock();

            
            return null;
        }
        static void AddReward(Reward reward)
        {
            _lock3.EnterWriteLock();
            _lock3.ExitWriteLock();
            lock (_lock)
            {

            }
        }
        static void Main(string[] args)
        {
            lock(_lock)
            {

            }
            

        }
    }
}
