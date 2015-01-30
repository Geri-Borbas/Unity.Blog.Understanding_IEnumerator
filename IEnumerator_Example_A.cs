using UnityEngine;
using System.Collections;


namespace EPPZ.Blog.IEnumerator_Example_A
{


	[System.Serializable]
	public class Polygon
	{
		public Vector2[] points;
	}


	public class PointEnumerator : IEnumerator
	{


		private Polygon _polygon;
		private int _currentIndex;
		private Vector2 _currentPoint;
		
		
		public PointEnumerator(Polygon polygon)
		{
			_polygon = polygon;
			Reset();
		}

		public void Reset()
		{
			_currentIndex = -1;
			_currentPoint = Vector2.zero;
		}

		public bool MoveNext()
		{
			_currentIndex++;

			// No more points, return false.
			if (_currentIndex >= _polygon.points.Length) return false;

			// Read collection value.
			_currentPoint = _polygon.points[_currentIndex];

			// Indicate we have more points.
			return true;
		}
		
		public Vector2 Current
		{
			get { return _currentPoint; }
		}

		object IEnumerator.Current
		{
			get { return Current; }
		}
	}
	
	
	public class IEnumerator_Example_A : MonoBehaviour
	{
		
		
		public Polygon polygon; // Setup in inspector
		
		
		void Start()
		{
			// Enumerate points.
			IEnumerator pointEnumerator = new PointEnumerator(polygon);
			while (pointEnumerator.MoveNext())
			{
				Debug.Log(pointEnumerator.Current);
			}
		}
	}
}