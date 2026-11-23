using UnityEngine;

public class ProjectileAttack : MonoBehaviour, ITowerAttack
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public void ExecuteAttack(Transform target, TowerData data)
    {
        Debug.Log("Ataque de proyectil de " + gameObject.name);

        GameObject newProjectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        newProjectile.TryGetComponent<ProjectileBase>(out var projectile);

        projectile.Setup(target, data);
    }
}
