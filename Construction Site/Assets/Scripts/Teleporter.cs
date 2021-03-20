using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter: MonoBehaviour {
    [SerializeField] GameObject target;
    [SerializeField] LayerMask layerMask;

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.rotation * Vector3.forward, out hit, 9999, layerMask)) {
            target.SetActive(true);
            target.transform.position = hit.point;
        }else {
            target.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Vector3 markerPosition = target.transform.position;
            transform.position = new Vector3(markerPosition.x, transform.position.y, markerPosition.z);
        }
    }
}
