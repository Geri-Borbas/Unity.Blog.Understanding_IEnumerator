using UnityEngine;
using System;
using System.Collections;



namespace EPPZ.Blog.IEnumerator_Example_D
{


	[System.Serializable]
	public class Polygon
	{


		public Vector2[] points;
		public Polygon[] polygons;


		public void EnumeratePointsRecursive(Action<Vector2> action)
		{
			// Enumerate local points.
			foreach (Vector2 eachPoint in points)
			{
				action(eachPoint);
			}

			// Enumerate each sub-polygon points.
			foreach (Polygon eachPolygon in polygons)
			{
				foreach (Vector2 eachSubPoint in eachPolygon.points)
				{
					action(eachSubPoint);
				}
			}
		}
	}


	public class IEnumerator_Example_D : MonoBehaviour
	{


		public Polygon polygon; // Setup in inspector


		void Start()
		{
			float start = Time.realtimeSinceStartup;
			for (int i = 0; i < 100000; i++)
			{
				polygon.EnumeratePointsRecursive((Vector2 eachPoint) =>
				{
					// Debug.Log (eachPoint);
				});
			}
			float end = Time.realtimeSinceStartup;
			Debug.Log("100000 enumerations using Lambda Expressions: "(end - start)+" ms lapsed ().");
		}
	}
}