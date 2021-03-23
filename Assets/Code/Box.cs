using UnityEngine;

namespace Code
{
    internal sealed class Box : MonoBehaviour, IDamage
    {
        private float _hp = 100;

        public float Hp
        {
            get { return _hp; }
        }

        public void AddDamage()
        {
            _hp -= 10;

            if (Hp <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
