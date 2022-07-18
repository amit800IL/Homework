using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public static UnityAction ShootInput;
    public static UnityAction reloadInput;

    [SerializeField] private KeyCode reloadKey;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootInput?.Invoke();
        }

        if (Input.GetKeyDown(reloadKey))
            reloadInput?.Invoke();
    }
}
