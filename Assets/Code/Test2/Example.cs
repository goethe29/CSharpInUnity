using System;
using System.Collections;
using static UnityEngine.Debug;
using Log = UnityEngine.Debug;

namespace Code.Test2
{
    internal sealed class Example
    {
        internal void Main()
        {
            Player<float> player = new Player<float>();
            Log(player.Hp);

            foreach (var t in player)
            {
                Log(t);
            }


            Player<float> playerNew = (Player<float>) player.Clone();

            using (Player<int> reader = new Player<int>())
            {
                
            }

            Log(playerNew[0]);
        }

        internal class Player<T> : IEnumerable, ICloneable, IDisposable
        {
            public T Hp;
            private readonly int[] _numbers = {4, 8, 15, 16, 23, 42};
            
            public IEnumerator GetEnumerator()
            {
                foreach (var number in _numbers)
                {
                    yield return number;
                }
            }

            public int this[int i]
            {
                get { return _numbers[i]; }
            }

            public object Clone()
            {
                return new Player<T>();
            }

            public void Dispose()
            {
            }
        }
    }
}
