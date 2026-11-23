using UnityEngine;

//Todo proyectil tiene estos comportamientos base.
//Se mueve, detecta si tiene objetivo y aplica sus efectos.
public abstract class ProjectileBase : MonoBehaviour
{
    public Transform target;
    public TowerData data;

    public virtual void Setup(Transform target, TowerData data)
    {
        this.target = target;
        this.data = data;
    }

    //Cualquier clase que herede de esta clase debera por obligacion usar Move().
    //Por eso este metodo es abstract
    public abstract void Move();

    public virtual void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Move();
    }

    public virtual void OnHit()
    {
        target.TryGetComponent<HealthSystem>(out var enemy);
        enemy.TakeDamage(Random.Range(data.minDamage, data.maxDamage), data.damageType);

        foreach (var effect in data.effects)
        {
            effect.OnImpact(target, transform.position);
        }

        Destroy(gameObject);
    }
}
