using UnityEngine;

public class SineProjectile : Projectile
{
    [SerializeField] float speed = 10;

    public override void MoveProjectile(float x)
    {
        transform.position = startPos + new Vector3(x * speed + 3 * Mathf.Sin(x * 8), Mathf.Sin(x * 3 * 8));
    }

    public override void Destruct()
    {
        Destroy(gameObject);
    }
}
