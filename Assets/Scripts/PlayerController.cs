using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public GameObject Player;
    private Vector3 offset;
    public int score;
    private int count;
    //private Text ScoreText;

    //public TextAlignment 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        offset = transform.position - Player.transform.position;
        count = 0;
    }
   
    // Update is called once per frame
    void Update()
    {

        
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moverHorizontal, 0, moverVertical);
        rb.AddForce(movement * speed);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 10;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            //increase score
            score += 10;
        }
    }
    private void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
   void SetScoreText()
    {
        //ScoreText.text = "Score: " + score.ToString();
    }
    
}
