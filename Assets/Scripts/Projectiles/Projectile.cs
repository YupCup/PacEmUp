using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField] int maxPierces = 1;
    [SerializeField] int damage = 10;
    [SerializeField] float lifetime = 1;

    [HideInInspector] public int combo;

    [SerializeField] GameObject destructObject;

    protected Vector3 startPos;
    float timeSinceStart = 0;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        MoveProjectile(timeSinceStart);
        timeSinceStart += Time.deltaTime;

        if (timeSinceStart > lifetime)
            StartDestruct();
    }

    public abstract void MoveProjectile(float timeSinceStart);

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;

        bool dead = collision.GetComponent<EnemyHealth>().TakeDamage(damage);
        if (dead) {
            combo ++;

            ScoreManager.Instance.IncreaseScore(combo * combo * 100);
        }

        maxPierces --;
        if (maxPierces <= 0) {
            StartDestruct();
        }
    }
    
    void StartDestruct() {
        if (destructObject != null) {
            GameObject newObject = Instantiate(destructObject, transform.position, Quaternion.identity);
            if (newObject.GetComponent<Projectile>())
                newObject.GetComponent<Projectile>().combo = combo;
        }

        Destruct();
    }

    public abstract void Destruct();
}
