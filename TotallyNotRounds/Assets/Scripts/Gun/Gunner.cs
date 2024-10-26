using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    private ProjectileMod pMod;
    private List<Gun> guns;

    private void Awake()
    {
        guns = new List<Gun>();
    }
}
