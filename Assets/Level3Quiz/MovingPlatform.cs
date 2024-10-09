using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    static public float speed;
    public int startingPoint;
    public Transform[] points;
    private Rigidbody2D playerRigidbody;
    private bool ontrap;
    public GameObject qcanvas;

    private int i;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        transform.position = points[startingPoint].position;
        speed = 2.0f;
    }

    
    // Update is called once per frame
    void Update()
    {
        if (ontrap)
        {
            if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
            {
                i++;
                if (i == points.Length)
                {
                    i = 0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && speed != 0.0f)
        {
            ontrap = true;
            PlayerController.canMove = false;
            QuizManager3.qcount = QuizManager3.qcount + 2;
            qcanvas.SetActive(true);
            QuizManager3.interaction = "trapl3";
        }
        if (other.CompareTag("Trigger"))
        {
            speed = 0.0f;
            PlayerController.canMove = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
