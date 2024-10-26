using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITaggeable
{
    public List<ETag> tags { get; set; }
}

public enum ETag
{
    Player,
    Terrain
}

/// <summary>
/// This should exclusively be used for objects only defined in a scene / prefab
/// </summary>
public class Tag : MonoBehaviour, ITaggeable
{
    [SerializeField] private List<ETag> _tags = new List<ETag>();
    public List<ETag> tags { get => _tags; set { _tags = value; } }
}
