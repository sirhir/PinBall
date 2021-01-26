using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;
    private float defaultAngle = 20;
    private float flickAngle = -20;


    // Start is called before the first frame update
    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //キーボード上での入力チェック
        bool leftButton = false;
        bool rightButton = false;
        if ( Input.GetKey(KeyCode.LeftArrow)
            || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S)
        ){
            leftButton = true;
        }
        if ( Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.S)
        ){
            rightButton = true;
        }

        //スマホ等での入力チェック
        bool leftTouch = false;
        bool rightTouch = false;
        foreach ( Touch touch in Input.touches )
        {
            if ( touch.position.x < Screen.width/2 )
            {
                leftTouch = true;
            }else{
                rightTouch = true;
            }
        }


        if (tag == "LeftFripperTag")
        {
            if ( leftButton || leftTouch )
            {
                SetAngle (this.flickAngle);
            }else{
                SetAngle (this.defaultAngle);
            }
        }

        if (tag == "RightFripperTag"){
            if ( rightButton || rightTouch )
            {
                SetAngle (this.flickAngle);
            }else{
                SetAngle (this.defaultAngle);
            }
        }

    }

    //フリッパーの傾きを設定
    public void SetAngle (float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
