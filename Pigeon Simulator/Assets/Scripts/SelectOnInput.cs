using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

	public EventSystem eventSystem;
    public GameObject selectedObject;
    public GameObject panel;

    private bool buttonSelected;

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
        if (buttonSelected == true && eventSystem.currentSelectedGameObject.Equals(panel))
        {
            eventSystem.SetSelectedGameObject(selectedObject);
        }
    }

    private void OnDisable()
    {
        buttonSelected = false;
    }
}
