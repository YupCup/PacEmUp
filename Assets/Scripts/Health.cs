using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    int currentHealth;
    protected bool invulnerable = false;

    public virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public bool TakeDamage(int damage) {
        if (invulnerable) return false;

        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
            return true;
        }
        
        DamageFeedback();
        return false;        
    }

    public abstract void DamageFeedback();
    public abstract void Die();
}
