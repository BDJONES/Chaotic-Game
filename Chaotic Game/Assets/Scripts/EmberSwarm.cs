using System.Collections.Generic;
using UnityEngine;

public class EmberSwarm : MonoBehaviour
{
    Vector3 ProjectileHitLocation;
    public GameObject emberSwarmPS;
    public Transform spawnPoint;
    public float projectileSpeed = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ShootProjectile();
        }
    }

    void ShootProjectile() {
        Ray ray = new Ray(spawnPoint.transform.position, spawnPoint.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000f)) {
            ProjectileHitLocation = hit.point;
        }
        else {
            ProjectileHitLocation = ray.GetPoint(1500f);
        }
        InstantiateProjectile();
    }

    void InstantiateProjectile() {
        GameObject spawnedProjectile = Instantiate(emberSwarmPS, spawnPoint.position, spawnPoint.rotation);
        spawnedProjectile.GetComponent<Rigidbody>().linearVelocity = (ProjectileHitLocation - spawnPoint.position).normalized * projectileSpeed;
        DestroyProjectile(spawnedProjectile);
    }

    void DestroyProjectile(GameObject projectile) {
        Destroy(projectile, 2);
    }
}
