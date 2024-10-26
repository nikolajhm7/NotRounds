using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    ProjectileMod pMod;
    List<ETag> collidesWith = new List<ETag> { ETag.Player, ETag.Terrain };

    public float speed;
    public float gravityEffectiveness;
    public float damage;
    public float maxLifetime;
    public float maxDist;
    public float bounces;

    private bool fired = false;
    private float lifeTime = 0;

    //RigidBody's velocity can be changed by collisions, projectile has to have collider to get collision information
    //this.velocity is always the intended velocity
    private Vector2 velocity;
    
    public void BuildProjectile(float _speed, ProjectileMod _pMod)
    {
        speed = _speed;
        pMod = _pMod;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    public void Fire()
    {
        rb.gravityScale *= gravityEffectiveness;
        UpdateVelocity();
        fired = true;
    }

    private void Update()
    {
        if(fired)
        {
            if(lifeTime + Time.deltaTime > maxLifetime) Destroy();
            else lifeTime += Time.deltaTime;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        List<ETag> collisionTags = collision.gameObject.GetComponent<ITaggeable>()?.tags;
        if (collisionTags != null && collisionTags.Intersect(collidesWith).Any()) CollisionEnter(collision, collisionTags);
    }

    private void CollisionEnter(Collision2D collision, List<ETag> intersects)
    {
        if (intersects.Contains(ETag.Player))
        {
            Destroy();
        }
        else if (intersects.Contains(ETag.Terrain)) {
            if (bounces > 0) Bounce(collision);
            else Destroy();
        }
    }

    private void Bounce(Collision2D collision)
    {
        Vector2 newDir = Vector3.Reflect(velocity, collision.GetContact(0).normal).normalized;
        SetDir(newDir);
        bounces--;
    }

    private void SetRotation(float angle)
    {
        transform.eulerAngles = Vector3.forward * angle;
        UpdateVelocity();
    }

    private void SetDir(Vector2 dir)
    {
        float angle = Utility.LookInDirRotation(dir, Vector2.right);
        SetRotation(angle);
    }

    private void UpdateVelocity()
    {
        velocity = speed * transform.right;
        rb.velocity = velocity;
    }

    private void Destroy()
    {
        GameObject.Destroy(gameObject);
    }
}
