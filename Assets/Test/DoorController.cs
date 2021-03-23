using UnityEngine;

namespace DefaultNamespace.Test
{
    internal sealed class DoorController
    {
        private readonly Animator _door;
        private readonly Camera _camera;
        private static readonly int _open = Animator.StringToHash("Open");

        public DoorController(Animator door, Camera camera)
        {
            _door = door;
            _camera = camera;
        }

        public void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    if (hit.collider.gameObject.Equals(_door.gameObject))
                    {
                        _door.SetTrigger(_open);
                    }
                }
            }
        }
    }
}
