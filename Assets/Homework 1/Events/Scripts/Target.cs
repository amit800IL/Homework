using UnityEngine;
using UnityEngine.Audio;

public class Target : MonoBehaviour, iDamagable
{
    [SerializeField] private float Health = 100f;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private AudioSource RobotExplosion;
    [SerializeField] private Animator m_animator;
    [SerializeField] private EnemyShoot m_shooter;
    public Transform playerRefrence;
    public float rotationSpeed = 2f;
    public float sightRange;
    bool playerFound;
    public void Damage(float Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Explosion.SetActive(true);
            RobotExplosion.Play();
            Destroy(gameObject, 0.5f);
 
        }
     
            

    }

    private void Update()
    {
        Vector3 enemyDirection = playerRefrence.position - transform.position;
        float singleStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, enemyDirection, singleStep, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);

        if(Vector3.Distance(transform.position,playerRefrence.position) < sightRange)
        {
           
            if (!playerFound)
            {//just now found player

                m_shooter.Shoot();
                playerFound = true;
                m_animator.SetBool("PlayerInRange", playerFound);
            }
        }
        else
        {
            if (playerFound)
            {
                playerFound = false;
                m_animator.SetBool("PlayerInRange", playerFound);
            }
        }
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
