using UnityEngine;

//Este script hace que todos los efectos se comporten igual y cada efecto tiene su propio codigo.
//Es una clase abstracta, esto significa que solo puede ser heredada y no puede ser instanciada directamente.
public abstract class TowerEffect : ScriptableObject
{
    //Todos los efectos deberan usar este metodo.
    public abstract void OnImpact(Transform target, Vector3 impactPoint);
}
