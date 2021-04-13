using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Geekbrains
{
    public sealed class GameController : MonoBehaviour, IDisposable
    {
        [SerializeField] GameObject _winScreen;
        private List<InteractiveObject> _interactiveObjects;
        private int _winConditionsQty = 0;
        private int _winConditionMeet = 0;

        private void Awake()
        {
            _interactiveObjects = FindObjectsOfType<InteractiveObject>().ToList();
            var displayBonuses = new DisplayBonuses();
            foreach (var interactiveObject in _interactiveObjects)
            {
                interactiveObject.Initialization(displayBonuses);
                interactiveObject.OnDestroyChange += InteractiveObjectOnOnDestroyChange;
                if (interactiveObject is IWinCondition condition)
                {
                    condition.CheckCondition();
                    if (condition.IsRequieredToWin)
                    {
                        _winConditionsQty +=1;
                    }
                }
            }
            print(_winConditionsQty);
        }

        private void InteractiveObjectOnOnDestroyChange(InteractiveObject value)
        {
            value.OnDestroyChange -= InteractiveObjectOnOnDestroyChange;
            _interactiveObjects.Remove(value);
            if (value is IWinCondition condition && condition.IsRequieredToWin)
                {
                    _winConditionMeet +=1; 
                }
        }

        private void Update()
        {   
            if (_winConditionsQty > 0)
            {
                CheckWin();
            }
            
            for (var i = 0; i < _interactiveObjects.Count; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }

                if (interactiveObject is IFlay flay)
                {
                    flay.Flay();
                }
                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }
                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }
        }

        private void CheckWin() 
        {
            if (_winConditionsQty == _winConditionMeet)
            {
                _winScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }

        public void Dispose()
        {
            foreach (var o in _interactiveObjects)
            {
                Destroy(o.gameObject);
            }
        }
    }
}
