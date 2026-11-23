using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float baseArmor;
    public ArmorType armorType;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage, DamageType damageType)
    {
        //LE entregamos todos los datos necesarios para calcular el dano final
        float damageTaken = ArmorCalculator.CalculateDamage(damage, damageType, baseArmor, armorType);

        Debug.Log("Daño plano recibido: " +  damage + " | " + "Daño final: " + damageTaken);
        currentHealth -= damageTaken;
        currentHealth = Mathf.Max(0, currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
