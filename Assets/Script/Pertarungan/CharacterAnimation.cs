using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;
    private bool hasPlayedFirstSound = false;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Walk(float speed)
    {
        anim.SetFloat(AnimationTags.Walk, Mathf.Abs(speed));
    }
    public void Jump(bool isJumping)
    {
        AudioControler.audioControler.PlaySound("Jump");
        anim.SetBool(AnimationTags.Jumping_Bool, isJumping);
    }
    public void Pukul()
    {
        AudioControler.audioControler.PlaySound("Pukul");
        anim.SetTrigger(AnimationTags.Pukul_Trigger);
        Debug.Log("Nyala");
    }
    public void Senjata()
    {
        AudioControler.audioControler.PlaySound("Sword");
        anim.SetTrigger(AnimationTags.Senjata_Trigger);
        Debug.Log("bisa");
    }

    public void Ulti()
    {
        AudioControler.audioControler.PlaySound("Boom");
        anim.SetTrigger(AnimationTags.Ulti_Trigger);
        Debug.Log("bisa");
    }
    public void Hurt()
    {
        anim.SetTrigger(AnimationTags.Hurt_Trigger);
    }
    public void Defense(bool isDefense)
    {
        anim.SetBool(AnimationTags.Defense_Bool, isDefense);
    }
    public void Die(bool isDie)
    {
        anim.SetBool(AnimationTags.Die_Bool, isDie);
    }
    public void EnemyWalk(float speed)
    {
        anim.SetFloat(AnimationTags.Walk, Mathf.Abs(speed));
    }

}
