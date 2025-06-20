using UnityEngine;

public class ReturningProjectile : Projectile
{
    [SerializeField] float speed = 10;

    public override void MoveProjectile(float x)
    {
        transform.position = startPos + new Vector3(15 * Mathf.Sin(x * 2), 0);
    }

    public override void Destruct()
    {
        Destroy(gameObject);
    }
}
