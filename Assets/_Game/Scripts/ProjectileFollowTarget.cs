using UnityEngine;

public class ProjectileFollowTarget : MonoBehaviour
{

    [SerializeField]private ParticleSystem onImpactParticle;
    private ParticleSystem onImpactParticlesObject;
    public Transform target;
    public float speed = 5f;
    private Rigidbody rb;
    public Vector3 enemyRadiusOffset = new Vector3();
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity for smooth movement
        onImpactParticlesObject = Instantiate(onImpactParticle);
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            rb.AddForce(direction.normalized * speed);
            if(transform.position.x <= (target.position.x + enemyRadiusOffset.x) && transform.position.x >= (target.position.x - enemyRadiusOffset.x))
            {
                if (transform.position.y <= (target.position.y + enemyRadiusOffset.y) && transform.position.y >= (target.position.y - enemyRadiusOffset.y))
                {
                    if (transform.position.z <= (target.position.z + enemyRadiusOffset.z) && transform.position.z >= (target.position.z - enemyRadiusOffset.z))
                    {
                        
                        
                        onImpactParticlesObject.gameObject.transform.position = target.position;
                        onImpactParticlesObject.Emit(1000);
                    }
                }
            }
        }
    }

    private void DestroyImpactParticles()
    {
        Destroy(onImpactParticlesObject);
        Destroy(gameObject);
        Destroy(GameCharacterController.Instance.GetComponent<AttackController>().GetMagicAttackProjectileObject());
    }
}
