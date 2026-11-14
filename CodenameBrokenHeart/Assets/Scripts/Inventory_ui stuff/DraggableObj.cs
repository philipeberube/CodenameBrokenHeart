using UnityEngine;
using UnityEngine.InputSystem;

public class DraggableObj : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Collider2D objCol;
    [SerializeField] Vector3 mousePosOffset;
    public bool isDrag;
    [SerializeField] public Vector3 ogPos;
    [SerializeField] DropZoneObjectHandler dropZoneHandler;

    void Awake()
    {
        GetMousePos();

    }
    private Vector3 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    void OnMouseDown()
    {
        ogPos = GetMousePos();
        ogPos.z = 0;

        Debug.Log($"OgPos {ogPos} og Psition set successfully");

        isDrag = true;

        Debug.Log($"IsDrag is {isDrag}: MouseDown called successfully");

        mousePosOffset = gameObject.transform.position - GetMousePos();

    }
    void OnMouseDrag()
    {
        

        Debug.Log("OnMouseDrag: object is dragging");

        Vector3 mousePos = GetMousePos();
        mousePos.z = 0;
        mousePosOffset.z = 0;

        this.gameObject.transform.position = mousePos + mousePosOffset;
    }
    public void OnMouseUp()
    {
        Debug.Log("OnMouseUp called successfully");

        

        isDrag = false;

        Debug.Log($"IsDrag = {isDrag}");

    }
    
/*    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(" Trigger Detected");


    }*/


    //problem is OnTriggerEnter is Called before onMouseUp()
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerStay2D sucessfully called");

        if (!isDrag)
        {
            Debug.Log("Conditions met and looking and the if/else options");
            if (dropZoneHandler.CheckValidDrop())
            {
                ogPos = this.gameObject.transform.position;
                Debug.Log("Collision was triggered and read as valid");
            }
            else
            {
                this.gameObject.transform.position = ogPos;
                Debug.Log("collision triggered but not seen as valid");
            }


            isDrag = false;
        }
        else
        {
            Debug.Log("Conditions not met");
            //this.gameObject.transform.position = ogPos;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        //this.gameObject.transform.position = ogPos;

    }
}
