
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonRightClickListener : MonoBehaviour, IPointerClickHandler
{  
    public UnityEvent onRightClick;
  
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {           

            Debug.Log("RightClick");
            onRightClick?.Invoke();

        }
    }
}
