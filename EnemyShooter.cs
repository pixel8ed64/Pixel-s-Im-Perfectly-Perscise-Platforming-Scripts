using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    IEnumerator Attack() //IEnumerators are time-based.
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        Instantiate(bullet,transform.position,Quaternion.identity);
        StartCoroutine(Attack());
    }
        
}
