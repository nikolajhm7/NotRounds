using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProjectileBuilder
{
    private static GameObject Base(Vector2 pos, Quaternion rot)
    {
        GameObject build = new GameObject("Projectile");
        build.transform.position = pos;
        build.transform.rotation = rot;
        build.transform.localScale = new Vector3(0.5f, 0.5f, 1);

        Rigidbody2D rb = build.AddComponent<Rigidbody2D>();
        rb.angularDrag = 0;
        rb.mass = 0;
        rb.freezeRotation = true;

        build.AddComponent<BoxCollider2D>();
        build.AddComponent<SpriteRenderer>().sprite = ResourceLocator.Load<Sprite>(EResource.ProjectileBaseSprite);

        build.AddComponent<Projectile>();
        return build;
    }

    public static GameObject Standard(Vector2 pos, Quaternion rot)
    {
        GameObject build = Base(pos, rot);
        build.name = "Standard Projectile";

        Projectile p = build.GetComponent<Projectile>();
        p.speed = 8;
        p.gravityEffectiveness = 0f;
        p.maxLifetime = 30;
        p.bounces = 5;
        
        return build;
    }
}
