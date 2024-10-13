using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    [SerializeField] int x = 20; // ステージのマス数：横２０、縦４０
    [SerializeField] int y = 40;

    [SerializeField] float posx = -9; // ブロックの座標ずらすやつ
    [SerializeField] float posy = -38.03f;
    [SerializeField] float fit = 23.5f; // Y座標の調整用
    [SerializeField] float tileSize = 1f; // ブロックサイズ
    [SerializeField] GameObject io, it, go, gt; // プレハブ

    int[,] mapdate; // type記録用の配列
    int[,] fitmap; // 下がったかどうかの確認用の配列

    void Start()
    {
        mapdate = new int[y, x];
        fitmap = new int[y, x];
        Map();
    }

    void Map()
    {
        for (int i = 0; i < y; i++) // 行のループ
        {
            for (int j = 0; j < x; j++) // 列のループ
            {
                int type = Random.Range(1, 5); // 1～4のランダム：奇数が凹、偶数が凸
                GameObject prefab = null; 

                mapdate[i, j] = type;
                Check(i, j,type);
                mapdate[i, j] = type;
                // タイプに応じてプレハブを選択
                switch (type)
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

                float yOffset = 0f;

                // 必要に応じて位置を調整
                if (type % 2 == 0 && i > 0 && mapdate[i - 1, j] % 2 != 0)
                {
                    yOffset -= fit;
                    fitmap[i, j] = 2;
                }
                  if (i > 0 && fitmap[i - 1, j] == 2)
                {
                    yOffset -= fit;
                }

                Vector2 position = new Vector2(j * tileSize + posx, i * tileSize + posy + yOffset);
                Instantiate(prefab, position, Quaternion.identity);

                
                if (i < y - 1 && fitmap[i, j] == 1)
                {
                    fitmap[i + 1, j] = 1;
                }
            }
        }
    } // マップ生成の関数

    void Check(int i, int j,int type)
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
            type += 1; ;
        }
    } // マップチェックの関数
}
