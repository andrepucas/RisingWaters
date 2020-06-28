using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    //public ObjectPooler[] theObjectPools;

    // Platform Generator
    public GameObject thePlatform;
    public Transform generationPoint;
    private float platformWidth;

    // Obstacules Generator
    public float randomTableThreshold;
    //public ObjectPooler tablePool;



    public ObjectPooler theObjectPool;


    // Start is called before the first frame update
    void Start()
    {
        // Calcula a largura do box collider
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth, transform.position.y, transform.position.z);
            //Instantiate(thePlatform, transform.position, transform.rotation);
            GameObject newPlatform = theObjectPool.GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

        }

        //if(Random.Range(0f,100f) < randomTableThreshold)
        //{
        //    GameObject newtable = tablePool.GetPooledObject();

        //    Vector3 tablePosition =

        //    newtable.transform.position = transform.position;
        //    newtable.transform.rotation = transform.rotation;
        //    newtable.SetActive(true);
        //}
    }
}
