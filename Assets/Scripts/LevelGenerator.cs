using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public GameObject wallPrefab;
    public GameObject objectInstance;
    public List<Material> materialList;
	public GameObject objParent;
	public GameObject wallsParent;
	public int tilesToRemove = 50;
	public int mazeSize;
	// 2D array representing the map
	private bool[,] mapData;
	private int mazeX = 4, mazeY = 1;

	// Use this for initialization
	void Start () {

		// initialize map 2D array
		mapData = GenerateMazeData();

		int unitSize=4;
		int Xstart = 16 , Zstart = 40;
		int offset = 0;
		// create actual maze blocks from maze boolean data
		for (int z = 0; z < mazeSize; z++) {
			for (int x = 0; x < mazeSize; x++) {
				if (mapData[z, x]) {
					CreateChildPrefab(wallPrefab, wallsParent, x*unitSize+Xstart, 1, Zstart+z*unitSize);

					if (Random.value < 0.2){
						int ItemMaterial = Random.Range(0,materialList.Count);
						int xRandom = Random.Range(x*unitSize+Xstart+offset, (x+1)*unitSize+Xstart-offset);
						int zRandom = Random.Range(Zstart+z*unitSize+offset, Zstart+(z+1)*unitSize-offset);
						GameObject instance = CreateChildPrefab(objectInstance, objParent, xRandom, 3, zRandom);
						instance.GetComponent<MeshRenderer> ().material = materialList[ItemMaterial];
						instance.tag = "Item"+(ItemMaterial);
						}
				}

			}
		}
	}

	bool[,] GenerateMazeData() {
		bool[,] data = new bool[mazeSize, mazeSize];

		// initialize all walls to true
		for (int y = 0; y < mazeSize; y++) {
			for (int x = 0; x < mazeSize; x++) {
				data[y, x] = true;
			}
		}

		// counter to ensure we consume a minimum number of tiles
		int tilesConsumed = 0;

		// iterate our random crawler, clearing out walls and straying from edges
		while (tilesConsumed < tilesToRemove) {
			
			// directions we will be moving along each axis; one must always be 0
			// to avoid diagonal lines
			int xDirection = 0, yDirection = 0;

			if (Random.value < 0.5) {
				xDirection = Random.value < 0.5 ? 1 : -1;
			} else {
				yDirection = Random.value < 0.5 ? 1 : -1;
			}

			// random number of spaces to move in this line
			int numSpacesMove = (int)(Random.Range(1, mazeSize - 1));

			// move the number of spaces we just calculated, clearing tiles along the way
			for (int i = 0; i < numSpacesMove; i++) {
				mazeX = Mathf.Clamp(mazeX + xDirection, 1, mazeSize - 2);
				mazeY = Mathf.Clamp(mazeY + yDirection, 1, mazeSize - 2);

				if (data[mazeY, mazeX]) {
					data[mazeY, mazeX] = false;
					tilesConsumed++;
				}
			}
		}
		//Leave empty space for the starting point
		int mid = mazeSize / 2;
		int emptySpaceWidth = 3;
		for (int i = mid - emptySpaceWidth; i < mid+emptySpaceWidth ; i++) {
			for (int j = mid - emptySpaceWidth; j < mid+emptySpaceWidth ; j++) {
					data[i, j] = false;

			}
		}

		return data;
	}

	// allow us to instantiate something and immediately make it the child of this game object's
	// transform, so we can containerize everything. also allows us to avoid writing Quaternion.
	// identity all over the place, since we never spawn anything with rotation
	GameObject CreateChildPrefab(GameObject prefab, GameObject parent, int x, int y, int z) {
		var myPrefab = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
		myPrefab.transform.parent = parent.transform;
		return myPrefab;
	}
}
