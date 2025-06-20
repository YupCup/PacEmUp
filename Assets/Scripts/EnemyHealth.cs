using System.Collections;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] SpriteRenderer spriteRenderer;

    public override void DamageFeedback()
    {
        StartCoroutine(DamageFreeze());
    }

    IEnumerator DamageFreeze() {
        Color baseColor = spriteRenderer.color;
        spriteRenderer.color = Color.white;

        float randomRotation = Random.Range(-15f, 15f);
        spriteRenderer.transform.Rotate(0, 0, randomRotation);

        yield return new WaitForSeconds(.1f);

        spriteRenderer.color = baseColor;
        spriteRenderer.transform.Rotate(0, 0, -randomRotation);
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
