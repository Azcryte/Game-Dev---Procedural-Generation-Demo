using UnityEngine;
using System.Collections;

public class Pathmaker : MonoBehaviour {

	public Transform floorPrefab;
	public Transform pathmakerPrefab;

	GameObject tiles;
	int tile_limit;
	float y_variation;
	
	//float timer = 0f;
	//float creation_time = 5f;

	// Use this for initialization
	void Start () {
		tile_limit = Random.Range(50, 250);
		y_variation = Random.Range(0.01f, 0.2f);
		//counter = 0;
		//timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameVariables.counter < tile_limit) {
			float rand = Random.value;
			if (rand < 0.25f) {
				transform.Rotate(new Vector3(0f, 90f, 0f));
			}
			else if (rand < 0.5f) {
				transform.Rotate(new Vector3(0f, -90f, 0f));
			}
			else if (rand < 0.5f + y_variation) {
				transform.Translate(new Vector3( 0f, 0.7f, 0f));
			}
			else if (rand < 0.5f + 2*y_variation) {
				transform.Translate (new Vector3(0f, -0.7f, 0f));
			}
			else if (rand > 0.95f) {
				Instantiate(pathmakerPrefab, transform.position, transform.rotation);
			}

			tiles = Instantiate(floorPrefab, transform.position, transform.rotation) as GameObject;
			transform.Translate (0f, 0f, 5f);
			GameVariables.counter++;

			//tiles.GetComponent<Renderer>().material.color = new Color(0f, 255f, 0f);//Color.Lerp(Color.red, Color.blue, timer);
		}
		else {
			Destroy (transform.gameObject);
		}
		//creation_time += Time.deltaTime;

	}
}
