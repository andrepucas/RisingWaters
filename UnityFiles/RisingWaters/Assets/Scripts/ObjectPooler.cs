using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject[] pooledObject;

    public int pooledAmount;

    List<GameObject> pooledObjects;


    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();

        int obstacle = Random.Range(0, pooledObject.Length);
        for (int i = 0; i < pooledAmount; i++)
        {
            //GameObject obj = (GameObject)Instantiate(pooledObject);
            GameObject obj = (GameObject)Instantiate(pooledObject[obstacle], transform.position, transform.rotation);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        int obstacle = Random.Range(0, pooledObject.Length);
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject[obstacle], transform.position, transform.rotation);
        //GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
