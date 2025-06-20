using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject[] projectiles;
    [SerializeField] float[] chargeTimeBetweenProjectiles;

    [SerializeField] SpriteRenderer spriteRenderer;

    float chargeTime;

    void Update()
    {
        if (Input.GetButton("Jump"))
            Charge();

        if (Input.GetButtonUp("Jump"))
            Shoot();
            
    }

    void Charge() {
        chargeTime += Time.deltaTime;

        spriteRenderer.color = Color.HSVToRGB((1f / projectiles.Length) * GetProjectileIndex(chargeTime), .58f, .7f);
    }

    void Shoot()
    {
        GameObject newObject = Instantiate(GetProjectile(chargeTime), transform.position, Quaternion.identity);
        chargeTime = 0;
        spriteRenderer.color = Color.white;
    }

    GameObject GetProjectile(float timeCharged) {
        return projectiles[GetProjectileIndex(timeCharged)];
    }

    int GetProjectileIndex(float timeCharged) {
        float totalChargeTime = 0;
        for (int i = 0; i < chargeTimeBetweenProjectiles.Length; i++)
        {
            totalChargeTime += chargeTimeBetweenProjectiles[i];
            if (totalChargeTime > timeCharged)
                return i;
        }
        return projectiles.Length - 1;
    }
}
