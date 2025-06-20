using UnityEngine;

public class TanProjectile : Projectile
{
    [SerializeField] float speed = 10;

    public override void MoveProjectile(float x)
    {
        transform.position = startPos + new Vector3(x * speed, Mathf.Tan(x * 3)*2);
    }

    public override void Destruct()
    {
        Destroy(gameObject);
    }
}
