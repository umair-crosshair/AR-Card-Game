using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacterController : MonoBehaviour
{
    public Transform EnemyTarget;
    [SerializeField]private ProgressBarPro playerHealthRadial;
    enum AttackCostType
    {
        Stamina,
        Mana
    }
    enum AnimationStates
    {
        
        IsDizzy,
        IsVictory,
        MinorAttackTrigger,
        MajorAttackTrigger,
        MajorAttackCompletedTrigger,
        IsHitTrigger,
        IsDizzyTrigger,
        IsDieTrigger,
        IsVictoryTrigger
    }
    [SerializeField] private Animator PlayerAnimator;
    private int MaxHealth;
    private int Health = 100;
    private int Stamina = 100;
    private int Mana = 100;
    public static GameCharacterController Instance;
    private void Start()
    {
        MaxHealth = Health;
    }

    public int GetHealth()
    {
        return Health;
    }
    public void SetHealth(int value)
    {
        Health = value;
    }
    public int GetStamina()
    {
        return Stamina;
    }
    public void SetStamina(int value)
    {
        Stamina = value;
    }public int GetMana()
    {
        return Mana;
    }
    public void SetMana(int value)
    {
        Mana = value;
    }

    public void GetDamage(int amount)
    {
        if(Health > 0)
        {
            Health -= amount;
            PlayerAnimator.SetTrigger(StateToAnimParameter(AnimationStates.IsHitTrigger));
            if(Health <= 0)
            {
                Health = 0;
                Die();
            }
            RefreshUI();


        }
    }
    private string StateToAnimParameter(AnimationStates animationState)
    {
        string animationStateValue = "";
        switch (animationState)
        {
            // bools
            
            case AnimationStates.IsDizzy:
                {
                    animationStateValue = "is dizzy";
                    break;
                }
            case AnimationStates.IsVictory:
                {
                    animationStateValue = "is victory";
                    break;
                }
            // triggers
            case AnimationStates.MinorAttackTrigger:
                {
                    animationStateValue = "is minor attack trigger";
                    break;
                }
            case AnimationStates.MajorAttackTrigger:
                {
                    animationStateValue = "is major attack trigger";
                    break;
                }
            case AnimationStates.MajorAttackCompletedTrigger:
                {
                    animationStateValue = "is major attack completed trigger";
                    break;
                }
            case AnimationStates.IsHitTrigger:
                {
                    animationStateValue = "is hit trigger";
                    break;
                }
            case AnimationStates.IsDizzyTrigger:
                {
                    animationStateValue = "is dizzy trigger";
                    break;
                }
            case AnimationStates.IsDieTrigger:
                {
                    animationStateValue = "is die trigger";
                    break;
                }
            case AnimationStates.IsVictoryTrigger:
                {
                    animationStateValue = "is victory trigger";
                    break;
                }
            default:
                animationStateValue = "is idle";
                break;
        }
        return animationStateValue;
    }
    public void DoDamage(int amount)
    {
        // Damage Enemy
    }
    public void DoMinorAttack(int amount, Transform target)
    {
        DoDamage(amount);
        PlayerAnimator.SetTrigger(StateToAnimParameter(AnimationStates.MinorAttackTrigger));
        GetComponent<AttackController>().FireMagicProjectile(target);

    }
    public void FireAttackProjectile(Transform target, float moveSpeed)
    {

    }
    public void DoMajorAttack(int amount, int attackDuration)
    {
        DoDamage(amount);
        PlayerAnimator.SetTrigger(StateToAnimParameter(AnimationStates.MajorAttackTrigger));
        Invoke("EndMajorAttack", attackDuration);
    }
    private void EndMajorAttack()
    {
        PlayerAnimator.SetTrigger(StateToAnimParameter(AnimationStates.MajorAttackCompletedTrigger));
    }
    public void Die()
    {
        PlayerAnimator.SetTrigger(StateToAnimParameter(AnimationStates.IsDieTrigger));
    }
    private void RefreshUI()
    {
        float healthPercentage = ((float)Health / (float)MaxHealth);
        playerHealthRadial.SetValue(healthPercentage);
    }
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.H))
        {
            GetDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            DoMajorAttack(10, 5);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            DoMinorAttack(10, EnemyTarget);
        }
        
#endif
    }
}
