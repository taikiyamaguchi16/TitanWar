using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : ItemBase
{
    [Header("各アイテムの独自パラメータ")]
    [SerializeField]
    [Tooltip("弾")]
    private GameObject bullet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            InPlayerAction();
        }
        
    }

    public override void InPlayerAction()
    {
        elapsedTime += Time.deltaTime;
        if(rateTime < elapsedTime)
        {
            Shot();
        }

    }

    public override void EndPlayerAction()
    {
        
    }

    private void Shot()
    {
        // 上で取得した場所に、"bullet"のPrefabを出現させる
        GameObject newBall = Instantiate(bullet, transform.position, transform.rotation);
        // 出現させたボールのforward(z軸方向)
        Vector3 direction = newBall.transform.forward;
        // 弾の発射方向にnewBallのz方向(ローカル座標)を入れ、弾オブジェクトのrigidbodyに衝撃力を加える
        newBall.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.Impulse);
        // 出現させたボールの名前を"bullet"に変更
        newBall.name = bullet.name;
        // 出現させたボールを0.8秒後に消す
        Destroy(newBall, 1.8f);
        elapsedTime = 0f;
    }
  

}
