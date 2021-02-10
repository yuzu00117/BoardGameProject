using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSelector : MonoBehaviour {

    void Start() {
        Debug.Log( "CellMoveがオンになりました" );
    }

    void OnCollisionEnter( Collision collision) {
        // 接触しているオブジェクトがマスだったらそのマスをtrueにする
        if ( collision.gameObject.tag == "Space" );
        Debug.Log( "マスを発見しました");
    }   
}