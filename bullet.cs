//using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        //check if the bullet touches the ground. apple bottom jeans. boots with the fur. the whole club is looking at her. she hit the floor. she hit the floor she's talking about low low low low low low low low
        if (target.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        
    }

    //update once whenveer the time
    private void Update()
    {
        
    }

}
