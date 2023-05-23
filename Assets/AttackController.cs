using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField]private GameObject MagicAttackProjectile;
    private GameObject MagicAttackProjectileObject;
    public void FireMagicProjectile(Transform target)
    {
        MagicAttackProjectileObject = Instantiate(MagicAttackProjectile);
        MagicAttackProjectileObject.GetComponent<ProjectileFollowTarget>().target = target;
    }
    public GameObject GetMagicAttackProjectileObject()
    {
        return MagicAttackProjectileObject;
    }
}
