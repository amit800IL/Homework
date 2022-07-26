using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
public class Gun : MonoBehaviour
{
    [SerializeField] GunData gunData;
    [SerializeField] private Transform muzzle;
    [SerializeField] private CrosshairHandler m_Crosshair;
    [SerializeField] private GameObject MuzzleFlashVfx;
    [SerializeField] private AudioSource gunShotSound;
    float timeSinceLastShot;

    private void Start()
    {
        PlayerShoot.ShootInput += Shoot;
        PlayerShoot.reloadInput += StartReloading;
    }

    public void StartReloading()
    {
        if (!gunData.reloading)
            StartCoroutine(Reload());

    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;

        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;

        gunData.reloading = false;

    }



    private bool canShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot()
    {
        if (gunData.currentAmmo > 0)
        {
            if (canShoot())
            {
                gunShotSound.Play();
                MuzzleFlashVfx.SetActive(true);
                if (Physics.Raycast(muzzle.position, muzzle.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    
                    m_Crosshair.PlayShootAndHitAnimation();
                    iDamagable damagable = hitInfo.transform.GetComponent<iDamagable>();
                    if (damagable == null)
                    {
                        damagable = hitInfo.transform.GetComponentInParent<iDamagable>();
                        if (damagable == null)
                        {
                            damagable = hitInfo.transform.GetComponentInChildren<iDamagable>();

                        }
                    }

                    damagable?.Damage(gunData.damage);
                }
                else
                {
                    m_Crosshair.PlayShootAnimation();
                }
            }
        }

        gunData.currentAmmo--;
        timeSinceLastShot = 0;

    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(muzzle.position, muzzle.forward);
    }



}
