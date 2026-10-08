using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Draggable : MonoBehaviour
{
    [SerializeField] Vector3 mousePosOffset;
    private Vector3 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
    void OnMouseDown()
    {
        mousePosOffset = gameObject.transform.position - GetMousePos(); 
    }

    // Update is called once per frame

    void OnMouseDrag()
    {
        transform.position = GetMousePos() + mousePosOffset;
    }
}
