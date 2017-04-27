using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load_next_level_scr : MonoBehaviour
{
	public int scene;

	public void OnTriggerEnter(Collider other)
	{

		LoadingScreenManager.LoadScene(scene);

	}



}
