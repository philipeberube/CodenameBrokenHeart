using UnityEngine;

public class RNG : Random
{
    private static RNG instance;

    private RNG() { }

    public static RNG Instance {  get { return instance; } set { instance = new RNG(); } }

}
