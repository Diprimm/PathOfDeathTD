using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerData data;
    [SerializeField] private LayerMask enemyLayer;
    private ITowerAttack attackBehaviour;
    private Collider[] searchResults = new Collider[20];
    public Transform currentTarget;
    private float fireTimer;
    private float searchTimer;
    private float searchInterval = 0.1f;

    private void Awake()
    {
        attackBehaviour = GetComponent<ITowerAttack>();
    }

    void Update()
    {
        searchTimer += Time.deltaTime;

        SearchInterval();

        FireRate();
    }

    private void FireRate()
    {
        if (currentTarget == null) return;

        fireTimer += Time.deltaTime;
        if (fireTimer >= 1f / data.attackSpeed)
        {
            ExecuteAttack();
            fireTimer = 0f;
        }
    }

    private void SearchInterval()
    {
        if (searchTimer >= searchInterval)
        {
            FindTarget();
            searchTimer = 0;
        }
    }

    private void FindTarget()
    {
        currentTarget = null;

        int enemiesFound = Physics.OverlapCapsuleNonAlloc(transform.position + Vector3.up * 5, transform.position + Vector3.up * -5, data.range, searchResults, enemyLayer);

        float closestDistance = Mathf.Infinity;

        for (int i = 0; i < enemiesFound; i++)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, searchResults[i].transform.position);

            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                currentTarget = searchResults[i].transform;
            }
        }
    }

    //La torre ejecuta el metodo de ataque, NO SABE COMO ATACA SOLO LO HACE.
    //Llama a la interfaz ITowerAttack para ejecutar ExecuteAttack y busca entre sus componentes quien tiene el metodo.
    public virtual void ExecuteAttack()
    {
        Debug.Log(gameObject.name + "execute attack.");
        attackBehaviour.ExecuteAttack(currentTarget, data);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + Vector3.up * 5, data.range);
        Gizmos.DrawWireSphere(transform.position + Vector3.up * -5, data.range);
    }
}
