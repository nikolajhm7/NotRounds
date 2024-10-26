using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EResource
{
    ProjectileBaseSprite,
}

public static class ResourceLocator
{
    private static Dictionary<EResource, string> _resources;
    public static Dictionary<EResource, string> resources
    {
        get
        {
            if(_resources == null)
            {
                _resources = new Dictionary<EResource, string>();
                _resources.Add(EResource.ProjectileBaseSprite, "MagnetLookinAss");
            }
            return _resources;
        }
    }

    public static T Load<T>(EResource resource) where T : Object
    {
        return Resources.Load<T>(resources[resource]);
    }
}
