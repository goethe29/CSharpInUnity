using System;
using UnityEngine;

namespace DefaultNamespace.Test
{
    internal sealed class Starter : MonoBehaviour
    {
        [SerializeField] private Animator _door;
        private DoorController _doorController;

        private void Start()
        {
            _doorController = new DoorController(_door, Camera.main);
        }

        private void Update()
        {
            _doorController.Execute();
        }
    }
}
