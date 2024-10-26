using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ITaggeable
{
    public List<ETag> tags { get; set; } = new List<ETag> { ETag.Player };

    private void Awake()
    {

    }
}
