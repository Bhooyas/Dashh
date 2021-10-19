using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = System.Random;
using Random2 = UnityEngine.Random;

public class GameManager : MonoBehaviour {
	
	public GameObject pillarHolder;
	public GameObject cube;	

	public float minDistance = 3f, maxDistance = 5f;

	Vector3 spawnPosition;
	bool isPaused; 

	public Pooler pooler;
	public DiamondPool powerPool; 
	public ScoreManager sm;
    Random rand;
	float time= 0; 
	

	// Use this for initialization
	void Start()
	{
		sm  = FindObjectOfType<ScoreManager>();
		spawnPosition = transform.position;
			
		isPaused = false; 
		rand = new Random();
	}

	void Update()
    {
		if(time<1)
		{
			time += Time.deltaTime;
			return;	
		}
		StartCoroutine(makingPillars());
	}



	
	IEnumerator makingPillars()
	{
		//GameObject tempPillar = Instantiate(pillarPrefab, spawnPosition, pillarPrefab.transform.rotation);
		
		while (isPaused)
		{
			yield return null;
		}
		
			GameObject tempPillar = pooler.getObject();
			// tempPillar.transform.position = spawnPosition;
			// tempPillar.SetActive(true);
			if(tempPillar!= null)
			{
				tempPillar.transform.SetParent(pillarHolder.transform);
				spawnPosition = tempPillar.transform.position;
				// SpawnDiamond();
				GameObject tempDiamond = powerPool.getObject();
				spawnPosition.y += (tempPillar.transform.localScale.y/2) + tempDiamond.transform.localScale.y + 2;
				tempDiamond.transform.position = spawnPosition;
				tempDiamond.SetActive(true);
			}
			// tempPillar.GetComponent<PillarBehaviour>().cube = cube;
			// spawnPosition = new Vector3(spawnPosition.x, Random2.Range(-8, -4),
			// 				spawnPosition.z + Random2.Range(minDistance, maxDistance));
			yield return new WaitForSeconds(3f);		
			
	}

	
	public void startSpawn()
    {
		isPaused = false; 
    }
	public void stopSpawn()
    {
		isPaused = true; 
    }
	public void restart()
	{
		sm.reset();
		SceneManager.LoadScene("Main");
		StopCoroutine(makingPillars()); 
	}

	public void increaseDistance()
    {
		maxDistance += Random2.Range(0.01f, 0.3f) ; 
    }

	void SpawnDiamond()
    {
		GameObject tempDiamond = powerPool.getObject();
		spawnPosition.y += tempDiamond.transform.localScale.y + 1;
		tempDiamond.transform.position = spawnPosition;
		tempDiamond.SetActive(true);

		/*
		if (  rand.NextDouble() <0.7)
		{
			
		}*/
    }
}
