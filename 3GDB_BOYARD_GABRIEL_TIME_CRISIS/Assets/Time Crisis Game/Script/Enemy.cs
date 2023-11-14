using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public UnityEvent whenIsDestroyed;
    public MeshRenderer MyMesh;

    void Start()
    {
        Invoke("Shoot", Random.Range(1, 10));
    }

    void Shoot()
    {
        var bullet = GameObject.Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector3 dir = GameObject.FindWithTag("Player").transform.position - transform.position;
        bullet.GetComponent<Rigidbody>().AddForce(dir.normalized * 750);

        Invoke("Shoot", Random.Range(1, 10));
    }

    private void OnDestroyed()
    {
        //if (MyMesh.meshrenderer.SetActive(false))
        {
            whenIsDestroyed?.Invoke();

        }
    }
}
