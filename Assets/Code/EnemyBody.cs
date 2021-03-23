using UnityEngine;

namespace Code
{
    internal sealed class EnemyBody : MonoBehaviour, IDamage
    {
        private IDamage _damage = new Damage();
        
        public float Hp { get; }
        public void AddDamage()
        {
            _damage.AddDamage();
            if (_damage.Hp <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    internal class Damage : IDamage
    {
        public float Hp { get; private set; }
        public void AddDamage()
        {
            Hp -= 1;
        }
    }
}
