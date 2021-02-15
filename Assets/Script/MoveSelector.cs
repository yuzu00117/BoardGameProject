using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelector : MonoBehaviour {

    void Start() {
        Debug.Log( "MoveSelector has enabled" );
    }
    
    void OnTrrigerStay( Collider other ) {
        // 接触しているオブジェクトがマスだったらそのマスをtrueにする
        if ( other.gameObject.tag == "Space" ) {
        Debug.Log( "マスを発見しました");
        }
    }
}