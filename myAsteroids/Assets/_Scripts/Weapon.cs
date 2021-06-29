using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _laserPrefab;

    [SerializeField] private List<Image> _laserShots;
    [SerializeField, Range(0f, 10f)] private float _laserShotDelay = 1f;
    private int _laserAmount;

    private void Start()
    {
        _laserAmount = _laserShots.Count;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot(_bulletPrefab);

        if (Input.GetButtonDown("Fire2") && _laserAmount > 0)
        {
            Shoot(_laserPrefab);
            StartCoroutine(Delaing());
        }
    }

    private void Shoot(GameObject projectile)
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }

    private IEnumerator Delaing()
    {
        _laserAmount--;
        _laserShots[_laserAmount].gameObject.SetActive(false);

        yield return new WaitForSeconds(_laserShotDelay * (_laserShots.Count - _laserAmount));

        _laserShots[_laserAmount].gameObject.SetActive(true);
        _laserAmount++;
    }
}
