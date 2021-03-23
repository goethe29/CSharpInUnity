using System;
using UnityEngine;

namespace Code.Test2
{
    internal sealed class TemplateExmple : MonoBehaviour
    {
        private void Start()
        {
            Display(7);
            Display(7d);
            Display(7f);
            Display(7l);
            Display("6565654");


            var enemy = UnitFactory<Unit<float>, float>(9.0f);
            var player = UnitFactory<Player<int>, int>(9);
        }

        private void Display<T>(T value)
        {
            Debug.Log(value);
        }

        private T UnitFactory<T, T2>(T2 hp) where T : IInit<T2>, new()
        {
            T result = new T();
            result.Init(hp);
            return result;
        }
    }

    internal interface IUnit<T> : IInit<T>
    {
        T Hp { get; }
    }

    class Player<T> : IUnit<T>
    {
        public T Hp { get; private set; }
        public void Init(T hp)
        {
            Hp = hp;
        }
    }

    class Unit<T> : IUnit<T>
    {
        public T Hp { get; private set; }
        public void Init(T hp)
        {
            Hp = hp;
        }
    }

    interface IInit<T>
    {
        void Init(T hp);
    }
}
