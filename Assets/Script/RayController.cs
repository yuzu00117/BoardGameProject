using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayController : MonoBehaviour {
    GameObject clickedPiece; // 駒がクリックされたかを確認
    bool WhiteKingClick = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if ( Input.GetMouseButtonDown( 0 ) ) {　// 左クリックが押されたら
            clickedPiece = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if ( Physics.Raycast( ray, out hit ) ) {
                clickedPiece = hit.collider.gameObject;
            }

            if ( clickedPiece == GameObject.Find( "WhiteKing" ) && WhiteKingClick != true ) {
                Debug.Log ( "WhiteClicked!");
                WhiteKingClick = true;

                
            } else {
                Debug.Log ( "Clicked" );
                WhiteKingClick = false;
            }
        }
    }
}