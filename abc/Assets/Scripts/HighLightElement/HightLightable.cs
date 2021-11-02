using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightLightable : MonoBehaviour {

	[SerializeField] private Material highlightMaterial;
	[SerializeField] private Material defaultMaterial;
	[SerializeField] private string selectableTag1 = "Viewable";
	[SerializeField] private string selectableTag2 = "Selectable";
	[SerializeField] private string selectableTag3 = "ToolTip";
	[SerializeField] private string selectableTag4 = "WeightLeft";
	[SerializeField] private string selectableTag5 = "WeightRight";
	[SerializeField] private string selectableTag6 = "measure";
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

			if (selection.CompareTag (selectableTag1) || selection.CompareTag (selectableTag2)|| selection.CompareTag (selectableTag3)
			
				|| selection.CompareTag (selectableTag4) || selection.CompareTag (selectableTag5)|| selection.CompareTag (selectableTag6)) 
			{
				var selectionRenderer = selection.GetComponent<Renderer> ();
				defaultMaterial = selectionRenderer.material;
				if (selectionRenderer != null) 
				{
					selectionRenderer.material = highlightMaterial;


				}

				_selection = selection;
			}
		}	
	}
}
