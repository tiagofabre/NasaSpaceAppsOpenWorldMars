using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {

	public int initialTiles;
	public Texture2D hMap;
	public Material mat;
	public int resolution;
	public GameObject target;

	public List<Map> maps;
	public int positionX = 0;
	private float distance = 0;
	private int offsetX = 0;
	private int lastIndex = 0;
	private int lastRemotionIndex = 0;

	void Awake()
	{
		distance = resolution -1;

		for(int i=0; i < initialTiles; i++){
			UseTile(i);
			lastIndex = i;
		}
	}

	void Update () {
		if(target.transform.position.x > distance/2 + (offsetX * distance))
		{
			UseTile(lastIndex++);
			offsetX++;
		}
	}

	void UseTile(int i=0, int direction=1){

		Map m = transform.gameObject.AddComponent<Map>();
		maps.Add(m);
		m.offset = distance * i;
		m.hMap = hMap;
		m.mat = mat;
		m.resolution = resolution;

		if(lastIndex > initialTiles || lastRemotionIndex > 0)
		{
			Destroy(maps[lastRemotionIndex].plane.gameObject);
			Destroy((Map)maps[lastRemotionIndex]);
			maps.RemoveAt(lastRemotionIndex);
			lastRemotionIndex++;
		}
	}
}
