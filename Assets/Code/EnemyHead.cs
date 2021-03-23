using UnityEngine;

namespace Code
{
    internal sealed class EnemyHead : MonoBehaviour, IDamage, ILoggerSecond
    {
        public float Hp { get; private set; }
        public void AddDamage()
        {
            Hp -= 10;

            if (Hp <= 0.0f)
            {
                Destroy(gameObject);
            }
        }

        public void Log()
        {
            Debug.Log("nameof(EnemyBody)");
        }
    }
}
