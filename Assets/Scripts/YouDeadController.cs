using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDeadController : MonoBehaviour
{
	bool readyToEnd = false;
	
	void Start ()
	{
		StartCoroutine(Wait());
	}
	
	void Update ()
	{
		if(readyToEnd && Input.GetButtonDown("Jump"))
		{
			SceneManager.LoadScene(1);
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(5);
		readyToEnd = true;
	}
}
