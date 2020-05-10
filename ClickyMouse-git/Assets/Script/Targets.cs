using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{

    //to hold particle effect
    public ParticleSystem explostionParticle;

    //Connect with GameManager Scrpit
    private GameManager genBallManager;

    //to update score
    public int pointValue;



    //-----GameObject Fly Up and Rotate Setup-----

    private Rigidbody targetRB;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    
    //-----WHEN MOUSE CLICK-----
    //-Destroy game object, particle effect, update score (if not game over); -trigger Gameover if clicked skull
    private void OnMouseDown()
    {
        
     if (gameObject.CompareTag("Bad"))
     {
         genBallManager.GameOver();
     }

        if (genBallManager.spawnBool == true)
        {
            Destroy(gameObject);
            Instantiate(explostionParticle, transform.position, explostionParticle.transform.rotation);
            //update the score to game manager script
            genBallManager.UpdateScore(pointValue);
        }
    }


    //-----Seems no use-----
    private void OnMouseUp()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }


    //-----Destroy the game object when it left screen-----
    private void DestoryOutOfBound()
    {
        if(targetRB.position.y < -10)
        {
            Destroy(gameObject);
        }
    }


    //-----START-----


    
    void Start()
    {
        //Get rigidbody compoent in the game object to the script
        targetRB = GetComponent<Rigidbody>();

        //Get gameobject in Hierarchy which named "GameManager" and get component "GameManager"Script inside
        genBallManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //-----GameObject Fly Up and Rotate-----
        transform.position = RandomSpawnPos();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }

    
    void Update()
    {
        //Destory Object out to bound
        DestoryOutOfBound();
    }
}
