using UnityEngine;
using System.Collections;


namespace EPPZ.Blog.IEnumerator_Example_B
{


	[System.Serializable]
	public class Polygon
	{


		public Vector2[] points;


		// This method returns an object like `PointEnumerator` before.
		public IEnumerator PointEnumerator()
		{
			// Spit out next point if any.
			foreach (Vector2 eachPoint in points) yield return eachPoint; 	

			// Indicate end of enumeration (optional).
			yield break;
		}
	}


	public class IEnumerator_Example_B : MonoBehaviour
	{


		public Polygon polygon; // Setup in inspector


		void Start()
		{
			// Enumerate points.
			IEnumerator pointEnumerator = polygon.PointEnumerator();
			while (pointEnumerator.MoveNext())
			{
				Debug.Log(pointEnumerator.Current);
			}
		}
	}
}