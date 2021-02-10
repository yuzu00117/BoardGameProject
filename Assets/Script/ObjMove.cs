using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour {

    GameObject ClickedPiece;
    public GameObject HaveObject = null;
    GameObject ChildObject;
    GameObject CellMove;

    float x = 0;

    // Start is called before the first frame update
    void Start() {

        var a = this.gameObject.GetComponents<Component>();
        foreach (var item in a) {
            Debug.Log( a );
        }
    } 
    // Update is called once per frame
    void Update() {

        // コマの選択をキャンセル
        if ( Input.GetKeyDown( KeyCode.Escape ) && HaveObject != null ) {
            HaveObject = null;
            ChildObject.SetActive( false );
        }
        // 他のマスを押したらコマを離す
        else if ( HaveObject != ClickedPiece && HaveObject != null ) {
            HaveObject = null;
            ChildObject.SetActive( false );
        }

/* コマの回転
---------------------------------------------------------------------------
*/

        // WhiteMirrorの回転
        if ( HaveObject != null && ( HaveObject.tag == "Mirror_White" || HaveObject.tag == "DoubleMirror_White" ) && Input.GetKeyDown( KeyCode.RightArrow ) ) {
            TurnRight();
        } else if ( HaveObject != null && ( HaveObject.tag == "Mirror_White" || HaveObject.tag == "DoubleMirror_White" ) && Input.GetKeyDown( KeyCode.LeftArrow ) ) { 
            TurnLeft();
        }

        // RedMirrorの回転
        if ( HaveObject != null && ( HaveObject.tag == "Mirror_Red" || HaveObject.tag == "DoubleMirror_Red" ) && Input.GetKeyDown( KeyCode.RightArrow ) ) {
            TurnRight();
        } else if ( HaveObject != null && ( HaveObject.tag == "Mirror_Red" || HaveObject.tag == "DoubleMirror_Red" ) && Input.GetKeyDown( KeyCode.LeftArrow ) ) {
            TurnLeft();
        }

        // 左クリックを押したらRayを飛ばして当たったオブジェクトを ClickedPiece に格納
        if ( Input.GetMouseButtonDown( 0 ) ) {
            ClickedPiece = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if ( Physics.Raycast( ray, out hit ) ) {
                ClickedPiece = hit.collider.gameObject;

/* コマを選択して HaveObject に格納
---------------------------------------------------------------------------
*/


                // Kingのコマを選択
                if ( (ClickedPiece.tag == "King_White" || ClickedPiece.tag == "King_Red" ) && HaveObject == null ) {
                    KeepKing();
                    CellKeep();
                }

                // Mirrorのコマを選択
                else if ( ( ClickedPiece.tag == "Mirror_White" || ClickedPiece.tag == "Mirror_Red" ) && HaveObject == null ) {
                    KeepMirror();
                }

                // DoubleMirrorのコマを選択
                if ( ( ClickedPiece.tag == "DoubleMirror_White"|| ClickedPiece.tag == "DoubleMirror_Red" ) && HaveObject == null ) {
                    KeepDoubleMirror();
                }

                // Lazerのコマを選択
                if ( ( ClickedPiece.tag == "Lazer_White" || ClickedPiece.tag == "Lazer_Red" ) && HaveObject == null ) {
                    KeepKing();
                }

/* コマの移動
---------------------------------------------------------------------------
*/

                // 空きマスを選択して移動
                if ( ClickedPiece.tag == "Space" && HaveObject != null && ( HaveObject.tag != "Lazer_White" || HaveObject.tag != "Lazer_Red") ) {
                    PieceMove();
                }

                // 白いマスをクリックしたらWhitePieceのみは移動可能
                if ( HaveObject != null && ClickedPiece.tag == "Space_White" && ( HaveObject.tag == "Mirror_White" || HaveObject.tag == "DoubleMirror_White" || HaveObject.tag == "King_White" ) ) {
                    PieceMove();
                }

                // 赤いマスをクリックしたらRedPieceのみは移動可能
                if ( HaveObject != null && ClickedPiece.tag == "Space_Red" && ( HaveObject.tag == "Mirror_Red" || HaveObject.tag == "DoubleMirror_Red" || HaveObject.tag == "King_Red" ) ) {
                    PieceMove();
                }
            }
        }
    }

/* コマの回転
---------------------------------------------------------------------------
*/

    void PieceMove() {
        HaveObject.transform.position = ClickedPiece.transform.position;
        HaveObject = null;
        ChildObject.SetActive( false );
        ChildObject = null;
    }
    // KingとLazerのコマの保持

    void KeepKing() {
        HaveObject = ClickedPiece;
        ChildObject = HaveObject.transform.GetChild( 0 ).gameObject;
        ChildObject.SetActive( true );
    }
    // Mirrorの保持
    void KeepMirror() {
        HaveObject = ClickedPiece;
        ChildObject = HaveObject.transform.GetChild( 2 ).gameObject;
        ChildObject.SetActive( true );
    }
    // DoubleMirrorの保持
    void KeepDoubleMirror() {
        HaveObject = ClickedPiece;
        ChildObject = HaveObject.transform.GetChild( 3 ).gameObject;
        ChildObject.SetActive( true );
    }

    void TurnRight() {
        x += 90;
        HaveObject.transform.rotation = Quaternion.Euler( 0, x, 0 );
        ChildObject.SetActive( false );
        HaveObject = null;
    }

    void TurnLeft() {
        x -= 90;
        HaveObject.transform.rotation = Quaternion.Euler( 0, x, 0 );
        ChildObject.SetActive( false );
        HaveObject = null;
    }

    void CellKeep() {
        CellMove = HaveObject.transform.GetChild( 1 ).gameObject;
        Debug.Log( CellMove.name + "が検知されました" );
        CellMove.SetActive( true );

    }
}