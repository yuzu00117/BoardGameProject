using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Lazer : MonoBehaviour {

    GameObject ClickedPiece;
    GameObject HaveObject = null;

    void Start() {
        var a = this.gameObject.GetComponents<Component>();
        foreach (var item in a) {
        }
    }

    void Update() {

        if ( Input.GetKeyDown( KeyCode.RightArrow ) && HaveObject != null ) {
            HaveObject.transform.rotation = Quaternion.Euler(-90, -90, 0);
            HaveObject = null;
            GetComponent<Renderer>().material.color = Color.white;
        }
        
        if ( Input.GetKeyDown ( KeyCode.LeftArrow ) && HaveObject != null ) {
            HaveObject.transform.rotation = Quaternion.Euler(-90, -90, -90);
            HaveObject = null;
            GetComponent<Renderer>().material.color = Color.white;
        }

        if ( Input.GetMouseButtonDown( 0 ) ) {
            ClickedPiece = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if ( Physics.Raycast( ray, out hit ) ) {
                ClickedPiece = hit.collider.gameObject;

                if ( ClickedPiece.name == "WhiteLazer" && HaveObject == null ) {
                   GetComponent<Renderer>().material.color = Color.yellow;
                    HaveObject = ClickedPiece;
                    Debug.Log( "white lazer is clicked!" );
                }

                if ( ClickedPiece.name == "RedLazer" && HaveObject == null ) {
                    GetComponent<Renderer>().material.color = Color.yellow;
                    HaveObject = ClickedPiece;
                }
            }
        }
    }
}