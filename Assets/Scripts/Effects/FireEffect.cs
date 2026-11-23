using UnityEngine;

[CreateAssetMenu(fileName = "Effect", menuName = "TD/Effects/Fire")]
public class FireEffect : TowerEffect
{
    public float damageOverTime;
    public float duration;

    public override void OnImpact(Transform target, Vector3 impactPoint)
    {
        Debug.Log("impacto de efecto de torre");
        //El efecto quemadura deberia estar en el enemigo y este metodo le entrega la info para ejecutarse
        //enemigo.ApplyFire(DoT, duration);
    }
}
