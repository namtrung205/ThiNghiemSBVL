using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickWeightManager: MonoBehaviour {


	[SerializeField] private Material highlightMaterial;
	[SerializeField] private Material defaultMaterial;
	[SerializeField] private string selectableTag = "SelectableLeft";

	private Transform _selection;

	// Update is called once per frame
	void Update ()
	{

		if (_selection != null) {
		
			var selectionRenderer = _selection.GetComponent<Renderer> ();
//			selectionRenderer.material = defaultMaterial;
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
//					selectionRenderer.material = highlightMaterial;
					if (Input.GetMouseButtonDown (2)) {
						print (selectionRenderer.transform.position.y.ToString ());
						if (selectionRenderer.transform.position.y > 0.6f && selectionRenderer.transform.position.y < 1.1f) {
							
							selectionRenderer.transform.position += new Vector3 (0, -0.40f, 0);

						}
						else
						{
							selectionRenderer.transform.position += new Vector3 (0, +0.70f, 0);
						}
					}
				}

				_selection = selection;
			}
			}	
		}
		



	}
