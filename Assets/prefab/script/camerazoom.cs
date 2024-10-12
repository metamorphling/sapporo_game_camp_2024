using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerazoom : MonoBehaviour
{
    [SerializeField] Camera maincam;//カメラのズーム最大170パー、25マス目を目安に
    [SerializeField] GameObject player;//1マス目から25マス目の距離：24.22
    Transform plpos;
    [SerializeField] float maxzoom = 46f;//カメラ最大
    [SerializeField]float minzoom = 60f;//カメラ最小
    float maxdis = 24.22f;
    float ply;
    void Start()
    {
        maincam = GetComponent<Camera>();
        plpos = player.transform;
        ply = plpos.position.y;
    }
    private void LateUpdate()
    {
        movecamera();
        zoomcam();
    }
    void movecamera()//playerに追従
    {
        transform.position = new Vector3(transform.position.x, plpos.position.y, transform.position.z);
    }
    void zoomcam()//playerの落下距離に応じてズーム
    {
        // プレイヤーの現在のY座標から初期位置との差を計算（落下距離）
        float distanceFallen = Mathf.Abs(ply - plpos.position.y);

        // 落下距離に基づいてカメラの視野角（FOV）を変更
        // 距離が0の時は最小ズーム、maxDistanceの時は最大ズーム
        float targetZoom = Mathf.Lerp(minzoom, maxzoom, distanceFallen / maxdis);

        // カメラの視野角を更新
        maincam.fieldOfView = targetZoom;
    }
}
