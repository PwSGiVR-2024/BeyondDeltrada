using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")] public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    private Vector3 _screenPoint;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        print("Begin drag");
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _screenPoint = Input.mousePosition;
        _screenPoint.z = 10.0f; //distance of the plane from the camera
        print("Dragging");
        transform.position = Camera.main.ScreenToWorldPoint(_screenPoint);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        print("End drag");
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }
}
