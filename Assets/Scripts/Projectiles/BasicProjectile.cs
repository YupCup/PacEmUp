using UnityEngine;

public class BasicProjectile : Projectile
{
    [SerializeField] float speed = 10;

    public override void MoveProjectile(float x)
    {
        transform.position = startPos + new Vector3(x * speed, 0);
    }

    public override void Destruct()
    {
        Destroy(gameObject);
    }
}
