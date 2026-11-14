using UnityEngine;

public class BuffItem : MonoBehaviour
{
    [SerializeField] int buffAmt;
    [SerializeField] bool isActive;
    [SerializeField] Player player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (this.gameObject.GetComponent<DropZoneObjectHandler>().CheckValidDrop())
        {
            isActive = true;
        }
    }
    public void CheckActivated()
    {
        if (isActive)
        {
            ApplyBuff();
        }
    }

    // Update is called once per frame
    public virtual void ApplyBuff()
    {

    }

}
