using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collidercheck : MonoBehaviour
{
    public Snakecontroller SnakecontrollerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="snakepiece")
        {
            //end gameprint 
            //print("you lose");
            //print(collision.gameObject.name);
            //restart scene
            SceneManager.LoadScene("SnakeTemplate");
        }
        if (collision.gameObject.tag == "Pellet")
        {
           
            SnakecontrollerScript.addpiece(collision.gameObject);
           

        }
        if (collision.gameObject.tag == "Wall")
        {
            //end gameprint 
            print("you lose");
            SceneManager.LoadScene("SnakeTemplate");
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
