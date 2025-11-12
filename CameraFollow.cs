using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; //This assigns the player in the inspector (gadget)
    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Stores the initial offset between the camera and the player and the camera and plamera and the cayer and the aaamera and mera and play and plamerica and &
        offset = transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //only on the x-axis
        Vector3 newPosition = transform.position + offset;
        newPosition.x = player.position.x + offset.x;
        transform.position = newPosition;
    }
}
