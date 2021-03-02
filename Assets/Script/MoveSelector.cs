using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelector : MonoBehaviour {

    GameObject TileObj;
    GameObject otherTile;
    GameObject LastTile;

// OnTriggerStay でマスを探してハイライトする
    void OnTriggerStay( Collider other ) {
        if ( other.gameObject.CompareTag( "Space" ) ) {
            TileObj = GameObject.Find( other.name );
            Debug.Log( TileObj );
            EnableHighLight();
            Invoke( "DisableOtherTile", 0.1f );
        }
    }

    void Disablehighlight() {

    }

    // 周囲8マス意外のマスへの移動を無効化する
    void DisableOtherTile() {
        otherTile = GameObject.FindWithTag( "Space" );
        otherTile.SetActive( false );
        Debug.Log( otherTile );
    }

    void EnableHighLight() {
        TileObj.tag = "SelectedTile";
    }
}