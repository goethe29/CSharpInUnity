using System;
using System.Collections;
using Code.Test2;
using UnityEngine;
using static UnityEngine.Debug;

namespace DefaultNamespace
{
    internal sealed class Starter : MonoBehaviour
    {
        private void Start()
        {
            new Example().Main();
            // using (var tester = new Tester(new []{4,8,15,16,23,42}))
            // {
            //     foreach (var t in tester)
            //     {
            //         Log(t);
            //     }
            // }
            //
            //
            // Log("*********************************");
            // var testerOne = new Tester(new []{4,8,15,16,23,42});
            // testerOne.Health = new Health {Hp = 10};
            // var testerTwo = (Tester)testerOne.Clone();
            // testerTwo.Health.Hp = 5;
            //
            // Log($"{testerOne.GetHashCode()} - {testerOne.Health.Hp}");
            // Log($"{testerTwo.GetHashCode()} - {testerTwo.Health.Hp}");
            //
            // Log("*********************************");
            // Log(testerOne[2]);
        }

        internal class Tester : IEnumerable, IDisposable, ICloneable
        {
            private readonly int[] _numbers;
            public Health Health;

            public Tester(int[] numbers)
            {
                _numbers = numbers;
            }

            public int this[int i]
            {
                get { return _numbers[i]; }
            }
            
            public IEnumerator GetEnumerator()
            {
                foreach (var number in _numbers)
                {
                    yield return number;
                }
            }

            public void Dispose()
            {
                Log(nameof(Dispose));
            }

            public object Clone()
            {
                return new Tester(_numbers)
                {
                    Health = new Health{ Hp = Health.Hp}
                };
            }
        }

        internal class Health : IComparer
        {
            public int Hp;
            public int Compare(object x, object y)
            {
                throw new NotImplementedException();
            }

            protected bool Equals(Health other)
            {
                return Hp == other.Hp;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Health) obj);
            }

            public override int GetHashCode()
            {
                return Hp;
            }

            public static bool operator ==(Health left, Health right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(Health left, Health right)
            {
                return !Equals(left, right);
            }
        }

        interface IInterface
        {
            int Test { get; }
            int this[int i] { get; }
        }

        private class Interface : IInterface
        {
            public int Test 
            {
                get { return 8; } 
            }

            public int this[int i]
            {
                get { return 8; }
            }
        }
    }
}
