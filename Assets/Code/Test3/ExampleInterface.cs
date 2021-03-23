using System;
using System.Collections;
using UnityEngine;

namespace Code.Test3
{
    internal sealed class ExampleInterface : MonoBehaviour
    {
        private void Start()
        {
            User user1 = new User();
            user1[0] = new Vector3();
            var s = user1[MyEnum.First];
            foreach (var poin in user1)
            {
                
            }

            using (User user5 = new User())
            {
                
            }
            
            return;
            User t = new User
            {
                Name = "Roma",
                Health = new Health
                {
                    MAXHp = 6.0f,
                    CurrentHp = 6.0f
                }
            };
            
            User user = t.Clone() as User;
            user.Name = "Ivan";
            user.Health.CurrentHp = 100;
            
            Debug.Log(t);
            Debug.Log(t.GetHashCode());
            Debug.Log(user);
            Debug.Log(user.GetHashCode());
        }

        public enum MyEnum
        {
            None   = 0,
            First  = 1,
            Second = 2
        }
        
        internal class User : ICloneable, IEnumerable, IDisposable
        {
            public string Name;
            public Health Health;
            private Vector3[] _points;

            public User(Vector3[] points)
            {
                _points = points;
            }

            public User()
            {
                
            }

            public Vector3 this[int i]
            {
                get { return _points[i]; }
                set { _points[i] = value; }
            }

            public string this[MyEnum value]
            {
                get
                {
                    switch (value)
                    {
                        case MyEnum.None:
                            return "None";
                        case MyEnum.First:
                            return "First";
                        case MyEnum.Second:
                            return "Second";
                        default:
                            throw new ArgumentOutOfRangeException(nameof(value), value, null);
                    }
                }
            }

            public override string ToString()
            {
                return $"Name {Name} Health {Health}";
            }

            public object Clone()
            {
                return new User
                {
                    Name = Name,
                    Health = new Health
                    {
                        CurrentHp = Health.CurrentHp,
                        MAXHp = Health.MAXHp
                    }
                };
            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }

    internal class Health
    {
        public float MAXHp;
        public float CurrentHp;

        public override string ToString()
        {
            return $"MAXHp {MAXHp} CurrentHp {CurrentHp}";
        }
    }
}
