using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToView : MonoBehaviour {




	[SerializeField] private Material highlightMaterial;
	[SerializeField] private Material defaultMaterial;
	[SerializeField] private string selectableTag = "Viewable";
	[SerializeField] private Camera viewByCamera;
	[SerializeField] private GameObject centerObject;
	private Transform _selection;

	// Update is called once per frame
	void Update ()
	{

		if (_selection != null) {

			var selectionRenderer = _selection.GetComponent<Renderer> ();
			selectionRenderer.material = defaultMaterial;
			_selection = null;
		}

		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) 
		{
			var selection = hit.transform;

			if (selection.CompareTag (selectableTag)||selection.CompareTag("measure")) 
			{
				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterial;
//					if (Input.GetMouseButtonDown (0)) {
//						print (selectionRenderer.name);
//
//						Vector3 offSet = new Vector3 (0, 0, -1f);
//
//						viewByCamera.transform.position = selectionRenderer.transform.position+offSet;
//
//						if (!viewByCamera.isActiveAndEnabled) {
//							viewByCamera.enabled = true;
////							Camera.main.enabled = false;
//						}
//
//					}
					if (Input.GetMouseButtonDown (2)) {
						print (selectionRenderer.name);

						Vector3 offSet = new Vector3 (0, -0.00f, 0);

						centerObject.transform.position = selectionRenderer.transform.position+offSet;

						

					}
				}

				_selection = selection;
			}
		}	
	}
}
