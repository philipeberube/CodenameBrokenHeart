using UnityEngine;

public class BuffItem : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] public float buffAmt;
    [SerializeField] DropZoneObjectHandler dzh;
    [SerializeField] public bool isApplied;
    [SerializeField] public bool isAlreadyAdded;

    public BuffItemType type;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        dzh = GetComponent<DropZoneObjectHandler>();
        CheckIsApplied();
    }

    void CheckIsApplied()
    {
        if(dzh.CheckValidDrop())
        {
            isApplied = true;
        }
        else
        {
            isApplied = false;
        }
    }


}
