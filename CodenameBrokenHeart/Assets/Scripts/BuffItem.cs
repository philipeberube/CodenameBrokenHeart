using UnityEngine;

public abstract class BuffItem : MonoBehaviour
{
    [SerializeField] int buffAmt;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected abstract void ApplyBuff();

}
