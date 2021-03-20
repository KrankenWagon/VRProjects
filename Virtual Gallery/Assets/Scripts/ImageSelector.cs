using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(GraphicRaycaster))]

public class ImageSelector : MonoBehaviour{
    public string categoryTitleName;
    public Text categoryTitle;
    public Image fullImage;
    public Material hilightMaterial;

    // Start is called before the first frame update
    void Start(){
        categoryTitle.text = categoryTitleName;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            OnPointerDown();
        }
    }
    public void OnPointerDown(){
        GraphicRaycaster gr = GetComponent<GraphicRaycaster>();
        PointerEventData data = new PointerEventData(null);
        data.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult> ();

        Debug.Log("Fire" + results.Count);
        gr.Raycast(data, results);
        Debug.Log("Dead");

        if (results.Count == 0){
            OnPreviewClick(results [0].gameObject);
        }
    }
    void OnPreviewClick (GameObject thisButton){
        Debug.Log("Pass");
        Image previewImage = thisButton.GetComponent<Image>();

        if (previewImage != null){
            fullImage.sprite = previewImage.sprite;
            fullImage.type = Image.Type.Simple;
            fullImage.preserveAspect = true;
        }
    }
    public void OnPointerEnter (Image image){
        //Highlight the image the user's gaze is pointed to
        image.material = hilightMaterial;
    }
    public void OnPointerExit (Image image){
        image.material = null;
    }
}
