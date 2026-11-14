using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Unity.Collections;
using System.Reflection.Metadata.Ecma335;


public class DropZoneObjectHandler : MonoBehaviour
{
    //applied to draggable object- will read if oppsosing colider is a valid zone
    [SerializeField] public Collider2D col;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Awake()
    {
        
        
    }



    
/*foreach (Collider2D c in col.GetContactColliders(ContactFilter2D.noFilter, Unity.Collections.Allocator.Persistent))
{
    if(!c.gameObject.CompareTag("DropZone"))
    {
        return false;
                
    }
}*/


    private Collider2D GetSingleCol()
    {
        //revist
        if(this.col.GetContactColliders(ContactFilter2D.noFilter, Allocator.Temp).Length == 1 )
        {
            return this.col.GetContactColliders(ContactFilter2D.noFilter, Allocator.Temp)[0];
        }
        else
        {
            return null;
        }
    }
    public bool CheckValidDrop()
    {
        Debug.Log("Verifying valid drop");
        Collider2D objCol = GetSingleCol();

        if (objCol != null)
        {
            if (objCol.gameObject.CompareTag("DropZone"))
            {
                Debug.Log("dropzone is valid");
                return true;
            }
            else
            {
                Debug.Log("Not touching dropZone");
                return false;
            }
        }
        else
        {
            Debug.Log("touching multiple colliders");
            return false;
        }
            //gameObject.CompareTag("DropZone") && CheckTouchingCollider())

    }


 


}
