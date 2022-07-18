using UnityEngine;

public class CrosshairHandler : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    


    public void PlayShootAnimation()
    {
       
        m_Animator.SetTrigger("Shoot");
    }
    public void PlayShootAndHitAnimation()
    {

        m_Animator.SetTrigger("Hit");

    }
}
