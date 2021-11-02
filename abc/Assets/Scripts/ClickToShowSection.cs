using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToShowSection : MonoBehaviour {

	[SerializeField] private Material highlightMaterial;
	[SerializeField] private Material defaultMaterial;
	[SerializeField] private string selectableTag = "SectionViewable";
	[SerializeField] private Camera viewByCamera;
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

			if (selection.CompareTag (selectableTag)) 
			{
				var selectionRenderer = selection.GetComponent<Renderer> ();
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterial;
					if (Input.GetMouseButtonDown (0)) {
						print (selectionRenderer.name);

						Vector3 offSet = new Vector3 (-0.2f, 0, 0.15f);

						viewByCamera.transform.position = selectionRenderer.transform.position+offSet;

					}
				}

				_selection = selection;
			}
		}	
	}
}
