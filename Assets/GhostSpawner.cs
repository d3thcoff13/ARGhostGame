using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] prefabs;
    [SerializeField]
    ghost[] ghosts;
    [SerializeField]
    Manager manager;
    int randomType;
    [SerializeField]
    int ghostsToSpawn;
    [SerializeField]
    int onlyType;
    // Start is called before the first frame update
    void Start()
    {
        randomType = Random.Range(0, 3);
        for (int i = 0; i < ghostsToSpawn; i++)
        {
            GameObject instantiated_ghost;
            randomType = Random.Range(0, 3);
            if (onlyType != -1) randomType = onlyType;
            switch (randomType)
            {
                case 0:
                    //Debug.Log("White");
                    instantiated_ghost = Instantiate(prefabs[0]);
                    instantiated_ghost.transform.parent = GameObject.Find("Ghosts").transform;
                    instantiated_ghost.transform.position = new Vector3(Random.Range(-50,50), Random.Range(-50, 50), Random.Range(-50, 50));
                    instantiated_ghost.transform.Rotate(new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0), Space.Self);
                    manager.ghostCount++;
                    break;
                case 1:
                    //Debug.Log("Green");
                    instantiated_ghost = Instantiate(prefabs[1]);
                    instantiated_ghost.transform.parent = GameObject.Find("Ghosts").transform;
                    instantiated_ghost.transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
                    instantiated_ghost.transform.Rotate(new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0), Space.Self);
                    manager.ghostCount++;
                    break;
                case 2:
                   // Debug.Log("Red");
                    instantiated_ghost = Instantiate(prefabs[2]);
                    instantiated_ghost.transform.parent = GameObject.Find("Ghosts").transform;
                    instantiated_ghost.transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
                    instantiated_ghost.transform.Rotate(new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0), Space.Self);
                    manager.ghostCount++;
                    break;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
