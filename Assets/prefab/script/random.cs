using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    [SerializeField] int x = 20;//ステージのマス数：横２０、盾４０
    [SerializeField] int y = 40;

    [SerializeField] float posx = -9;//ブロックの座標ずらすやつ
    [SerializeField] float posy = -38.03f;
    [SerializeField] float tileSize = 1f;
    [SerializeField] GameObject io, it, go, gt;
    int[,] mapdate;//type記録用の配列

    void Start()
    {
        mapdate = new int[y, x];
        map();
    }


    void map()
    {
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)//左下から右上に向かう
            {
                int type = Random.Range(1, 5);//1～4のランダム：奇数が凹、偶数が凸
                GameObject prefab = null;
                mapdate[i, j] = type;
                Check(i, j);
                switch (type)//ランダムの数値から配置
                {
                    case 1:
                        prefab = io;
                        break;
                    case 2:
                        prefab = it;
                        break;
                    case 3:
                        prefab = go;
                        break;
                    case 4:
                        prefab = gt;
                        break;
                }
                Vector2 position = new Vector2(j * tileSize + posx, i * tileSize + posy);
                Instantiate(prefab, position, Quaternion.identity);

            }
        }
    }//マップ生成の関数

    void Check(int i, int j)
    {
        bool dif = false; // 異なる奇数偶数があるかどうか

        // 自分の確認
        bool isCurrentOdd = mapdate[i, j] % 2 != 0;

        // 周囲8方向を確認
        for (int Y = -1; Y <= 1; Y++)
        {
            for (int X = -1; X <= 1; X++)
            {
                if (X == 0 && Y == 0) continue; // 自分はスキップ
                                                //  if (X != 0 && Y != 0) continue;//斜めのスキップ

                int nX = j + X;
                int nY = i + Y;

                // スキップ
                if (nX < 0 || nX >= x || nY < 0 || nY >= y) continue;

                // 周囲の奇数偶数を確認
                bool isNeighborOdd = mapdate[nY, nX] % 2 != 0;

                // 異なる奇数・偶数が見つかった場合
                if (isNeighborOdd != isCurrentOdd)
                {
                    dif = true;
                    break;
                }
            }

            if (dif) break;
        }

        if (!dif)
        {
            mapdate[i, j] = (mapdate[i, j] % 2 == 0) ? mapdate[i, j] - 1 : mapdate[i, j] + 1;
        }
    }//マップチェックの関数
}
