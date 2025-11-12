using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Door : MonoBehaviour
{
    public static Door Instance;
    private Animator myAnimator;
    private BoxCollider2D myCollider;
    [HideInInspector]
    public int CollectiblesCount;
    public Text countText;
    public Text WinText;
    public GameObject next;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MakeInstance();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();
        WinText.text = "";
        countText.text = "Score: 0/5";
        CollectiblesCount = CollectiblesCount -5;
        next.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void MakeInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void DecrementCollectibles()
    {
        CollectiblesCount++;
        countText.text = "Score: " + CollectiblesCount.ToString() + "/5";
        if(CollectiblesCount == 5)
        {
            WinText.text = "Wega is coming...";
            myCollider.isTrigger = true;
            myAnimator.Play("Dooropen");
        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            next.SetActive(true);
        }
    }


    //lol
}
