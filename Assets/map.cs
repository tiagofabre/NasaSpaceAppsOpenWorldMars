using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class map : MonoBehaviour
{
		public Texture2D hMap;
		public Material mat;
		public int resolution;
		public GameObject plane;

		
		public int offset;

		Mesh procMesh;
		List<Vector3> verts;
		List<int> tris;

		// Use this for initialization
		void Start ()
		{
				plane = new GameObject ("ProcPlane"); //Create GO and add necessary components
				plane.AddComponent<MeshFilter> ();
				plane.AddComponent<MeshRenderer> ();
				procMesh = new Mesh ();

				verts = new List<Vector3> ();
				tris = new List<int> ();
				
				//Bottom left section of the map, other sections are similar
				for (int i = 0; i < resolution; i++) {
						for (int j = 0; j < resolution; j++) {
								//Add each new vertex in the plane
								verts.Add (new Vector3 (i, hMap.GetPixel (i + offset, j).grayscale * 50, j));
								//Skip if a new square on the plane hasn't been formed
								if (i == 0 || j == 0)
										continue;
								//Adds the index of the three vertices in order to make up each of the two tris
								tris.Add (resolution * i + j); //Top right
								tris.Add (resolution * i + j - 1); //Bottom right
								tris.Add (resolution * (i - 1) + j - 1); //Bottom left - First triangle
								tris.Add (resolution * (i - 1) + j - 1); //Bottom left 
								tris.Add (resolution * (i - 1) + j); //Top left
								tris.Add (resolution * i + j); //Top right - Second triangle
						}
				}
		
				Vector2[] uvs = new Vector2[verts.Count];
				for (var i = 0; i < uvs.Length; i++) //Give UV coords X,Z world coords
						uvs [i] = new Vector2 (verts [i].x, verts [i].z);
				
				procMesh.vertices = verts.ToArray (); //Assign verts, uvs, and tris to the mesh
				procMesh.uv = uvs;
				procMesh.triangles = tris.ToArray ();
				procMesh.RecalculateNormals (); //Determines which way the triangles are facing
		plane.transform.position = new Vector3(transform.position.x + offset,transform.position.y, transform.position.z);
				plane.GetComponent<MeshFilter> ().mesh = procMesh; //Assign Mesh object to MeshFilter
				plane.gameObject.GetComponent<MeshRenderer> ().material = mat;
				plane.AddComponent<MeshCollider> ();
		}

		// Update is called once per frame
		void Update ()
		{
				
		}
}
