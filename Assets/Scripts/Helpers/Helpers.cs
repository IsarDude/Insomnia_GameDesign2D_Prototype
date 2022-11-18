using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace AuxiliariyClasses {
	public static class Helpers {
		private static Camera _camera;
		public static Camera Camera {
			get {
				if (_camera == null) _camera = Camera.main;
				return Camera;
			}
		}

		private static PointerEventData _eventDataCurrentPosition;
		private static List<RaycastResult> _results;
		public static bool IsOverUI () {
			_eventDataCurrentPosition = new PointerEventData (EventSystem.current) { position = Input.mousePosition };
			_results = new List<RaycastResult> ();
			EventSystem.current.RaycastAll (_eventDataCurrentPosition, _results);
			return _results.Count > 0;
		}

		public static Vector3 RandomizeAllDirections (Vector3 initialVector) {
			return initialVector = new Vector3 (initialVector.x * (Random.Range (0, 2) * 2 - 1), initialVector.y * (Random.Range (0, 2) * 2 - 1), initialVector.z * (Random.Range (0, 2) * 2 - 1));
		}

		public static Vector3 GetRandomVector (float xMax, float xMin, float yMax, float yMin, float zMax, float zMin) {
			return new Vector3 (Random.Range (xMin, xMax), Random.Range (yMin, yMax), Random.Range (zMin, zMax));
		}

	}
}