using UnityEngine;

public class FireDragonProj : ProjectileBase
{
    public float speed;
    public override void Move()
    {
        //El target viene de la clase padre
        Vector3 direction = (target.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

        //Pequeno margen de error de 0.2 para el impacto
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            //OnHit tambien viene de la clase padre
            OnHit();
        }
    }
}
