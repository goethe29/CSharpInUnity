using System;
using UnityEngine;

namespace Code
{
    internal sealed class Weapon : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    if (hit.collider.TryGetComponent(out IEnemy enemy))
                    {
                        if (enemy is ILoggerSecond e1)
                        {
                            e1.Log();
                        }
                        if (enemy is IDamage e2)
                        {
                            e2.AddDamage();
                        }
                    }
                    
                    // if (hit.collider.TryGetComponent(out Box enemy))
                    // {
                    //     enemy.AddDamage();
                    // }
                    // else if (hit.collider.TryGetComponent(out EnemyBody enemyBody))
                    // {
                    //     enemyBody.AddDamage();
                    // } 
                    // else if (hit.collider.TryGetComponent(out EnemyHead enemyHead))
                    // {
                    //     enemyHead.AddDamage();
                    // } 
                    
                    
                }
            }
        }
    }
}
