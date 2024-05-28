using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace jomi.utils { 
    public class GUIOverObjectController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public UnityEvent OnEnter;
        public UnityEvent OnExit;

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            OnEnter?.Invoke(); return;
        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            OnExit?.Invoke(); return;
        }
    }
}