using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public UnityEvent onDeath;
    private float currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
        if (onDeath == null)
            onDeath = new UnityEvent();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }
}
