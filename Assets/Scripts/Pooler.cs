using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public int poolSize;
    public GameObject Prefab;
    List<GameObject> Pool;
    public GameObject cube;

    Vector3 pos = new Vector3(0, -8, 0);
    // Start is called before the first frame update
    void Start()
    {
        Pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            print(transform.position);
            GameObject gameObject = (GameObject)Instantiate(Prefab, pos, Prefab.transform.rotation);
        
            // gameObject.SetActive(false);
            pos.y = Random.Range(-8, -4);
            pos.z += Random.Range(3f, 5f);
            gameObject.GetComponent<PillarBehaviour>().cube = cube;
            Pool.Add(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if(time<1)
        // {
        //     time += Time.deltaTime;
        //     return;
        // }
    }

    public GameObject getObject()
    {
        foreach (GameObject obj in Pool)
        {
            if(!obj.GetComponent<Renderer>().isVisible)
            {
                obj.transform.position = pos;
                pos.y = Random.Range(-8, -4);
                pos.z += Random.Range(3f, 5f);
                Pool.Remove(obj);
                Pool.Add(obj);
                return obj;
            }
            else{
                break;
            }
        }
        return null;
        // foreach (GameObject obj in Pool)
        // {
        //     if (!obj.GetComponent<Renderer>().isVisible)
        //     {
        //         return obj;
        //     }
        // }

        // GameObject gameObject = (GameObject)Instantiate(Prefab, transform.position, Prefab.transform.rotation);
        // gameObject.SetActive(false);
        // Pool.Add(gameObject);
        // return gameObject;
    }
}
