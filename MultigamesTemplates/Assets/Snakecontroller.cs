using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snakecontroller : MonoBehaviour
{
    public float snakespeed,spaceinterval;
    public int direction;//1=right 2=up 3=left 4=down
    int firstpiecepunt;
    List<GameObject> snakepieces;
    Vector3 previousposition;
    public GameObject snakepiece,lastpiece;
    public GameControls controlscript;
    public int xvector, yvector;
    float elapsedtime;
    int score;
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        snakepieces = new List<GameObject>();
         xvector = -1;
            yvector = 0;
       
        lastpiece = this.gameObject;
        elapsedtime = Time.time;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && direction != 4)// up 
        {
          
            direction = 2;
            xvector = 0;
            yvector = 1;
           
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && direction != 2)// down
        {
           
            direction = 4;
            xvector = 0;
            yvector = -1;
          
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != 1)// left
        {
            
            direction = 3;
            xvector = 1;
            yvector = 0;
           
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && direction != 3)// right
        {
           
            direction = 1;
            xvector = -1;
            yvector = 0;
           
        }
        
    }
    public void Boundarycheck()
    {
        Vector3 Snakeheadposition = this.gameObject.transform.position;
        if (this.gameObject.transform.position.x < 0)
        {
            Snakeheadposition.x += 20;
            this.gameObject.transform.position= Snakeheadposition;
        }
        if (this.gameObject.transform.position.x > 20)
        {
            Snakeheadposition.x += -20;
            this.gameObject.transform.position = Snakeheadposition;
        }
        if (this.gameObject.transform.position.y > 0)
        {
            Snakeheadposition.y -= 10;
            this.gameObject.transform.position = Snakeheadposition;
        }
        if (this.gameObject.transform.position.y < -10)
        {
            Snakeheadposition.y += 10;
            this.gameObject.transform.position = Snakeheadposition;
        }
    }
    public void addpiece(GameObject pellet)
    {
       
        Vector3 newpieceposition = lastpiece.transform.position;
        newpieceposition.x += xvector * spaceinterval;
        newpieceposition.y += yvector * spaceinterval;
        var newpiece =Instantiate(snakepiece, newpieceposition, lastpiece.transform.rotation); 
        if (firstpiecepunt == 0)
        {
            newpiece.tag = "firstpiece";
        }

        newpiece.name = "snake " + firstpiecepunt + "";
            // newpiece.transform.position = lastpiece.transform.position;
            // newpiece.transform.Translate((new Vector3(xvector * .28f, yvector * .28f)));


            lastpiece = newpiece;
        snakepieces.Add(newpiece);
        controlscript.spawnpellet();
        GameObject.Destroy(pellet);
        score += 10;
        Score.text = "Score: " + score;
        firstpiecepunt++;
        snakespeed += -(.01f-(firstpiecepunt/40));
      //  movesnake();
    }
    public void movesnake()
    {
        int count = 0;
        foreach(GameObject i in snakepieces)
        {
            var tempnewpos = i.transform.position;
            i.transform.position = previousposition;
           // i.transform.Translate(new Vector3(xvector * .16f, yvector * .16f));
            previousposition = tempnewpos;
            count++;
        }
    }
    private void FixedUpdate()
    {
        if(elapsedtime<Time.time-snakespeed)
        {
            Boundarycheck();
            previousposition = this.transform.position;
            if (direction == 1)
            {
                transform.Translate(Vector3.right * spaceinterval);
            }
            else if (direction == 2)
            {
                transform.Translate(Vector3.up * spaceinterval);
            }
            else if (direction == 3)
            {
                transform.Translate(Vector3.left * spaceinterval);
            }
            else if (direction == 4)
            {
                transform.Translate(Vector3.down * spaceinterval);
               
            }
            movesnake();
            elapsedtime = Time.time;
        }
       
    }
}
