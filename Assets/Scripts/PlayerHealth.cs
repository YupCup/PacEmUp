using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    [SerializeField] SpriteRenderer spriteRenderer;
    Color baseColor;

    public override void Start()
    {
        base.Start();
        baseColor = spriteRenderer.color;
    }

    public override void DamageFeedback()
    {
        StartCoroutine(DamageFreeze());
    }

    IEnumerator DamageFreeze() {
        float randomRotation = Random.Range(-15f, 15f);
        spriteRenderer.transform.Rotate(0, 0, randomRotation);

        yield return new WaitForSeconds(.1f);

        spriteRenderer.transform.Rotate(0, 0, -randomRotation);
    }

    IEnumerator SetInvulnerable() {
        invulnerable = true;
        for (int i = 0; i < 5; i++)
        {
            baseColor.a = 0.2f;
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(.1f);
            baseColor.a = 1f;
            spriteRenderer.color = baseColor;
        }
        baseColor.a = 1f;
        spriteRenderer.color = baseColor;
        invulnerable = false;
    }

    public override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || invulnerable) return;

        TakeDamage(1);
        StartCoroutine(SetInvulnerable());
    }
}
