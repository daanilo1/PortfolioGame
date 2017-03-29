using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrackManager : MonoBehaviour {
    public GameObject[] trackPrefabs;
    private Transform playerTransform;
    private float spawnZ = -12.0f;
    private float trackLenght = 15.0f;
    private float safeZone = 20.0f;
    private int tracksOnScreen = 7;

    private List<GameObject> activeTracks;

    // Use this for initialization
    private void Start () {
        activeTracks = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        for(int i = 0; i < tracksOnScreen; i++)
        {
            SpawnTrack();
        }
            
    }
	
	// Update is called once per frame
	private void Update () {
        if(playerTransform.position.z - safeZone > (spawnZ - tracksOnScreen * trackLenght))
        {
            SpawnTrack();
            DeleteTrack();
        }
	
	}
       private void SpawnTrack(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(trackPrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += trackLenght;
        activeTracks.Add(go);
    }

    private void DeleteTrack()
    {
        Destroy(activeTracks[0]);
        activeTracks.RemoveAt(0);
    }
}
