using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject ObjectToShoot;
    public Transform ShootPoint;
    public float bulletSpeedMultiplier = 10f;
    
   public void Shoot()
    {
        var bullet = Instantiate(ObjectToShoot, ShootPoint.position, ShootPoint.rotation);
        Vector3 shootDir = GameSystems.instance.playerMovement.transform.position - ShootPoint.position;
        bullet.GetComponent<Rigidbody>().velocity = shootDir * bulletSpeedMultiplier;

    }
}
