using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    [SerializeField] int x = 20; // �X�e�[�W�̃}�X���F���Q�O�A�c�S�O
    [SerializeField] int y = 40;

    [SerializeField] float posx = -9; // �u���b�N�̍��W���炷���
    [SerializeField] float posy = -38.03f;
    [SerializeField] float fit = 23.5f; // Y���W�̒����p
    [SerializeField] float tileSize = 1f; // �u���b�N�T�C�Y
    [SerializeField] GameObject io, it, go, gt; // �v���n�u

    int[,] mapdate; // type�L�^�p�̔z��
    int[,] fitmap; // �����������ǂ����̊m�F�p�̔z��

    void Start()
    {
        mapdate = new int[y, x];
        fitmap = new int[y, x];
        Map();
    }

    void Map()
    {
        for (int i = 0; i < y; i++) // �s�̃��[�v
        {
            for (int j = 0; j < x; j++) // ��̃��[�v
            {
                int type = Random.Range(1, 5); // 1�`4�̃����_���F������A��������
                GameObject prefab = null; 

                mapdate[i, j] = type;
                Check(i, j,type);
                mapdate[i, j] = type;
                // �^�C�v�ɉ����ăv���n�u��I��
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

                // �K�v�ɉ����Ĉʒu�𒲐�
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
    } // �}�b�v�����̊֐�

    void Check(int i, int j,int type)
    {
        bool dif = false; // �قȂ����������邩�ǂ���

        // �����̊m�F
        bool isCurrentOdd = mapdate[i, j] % 2 != 0;

        // ����8�������m�F
        for (int Y = -1; Y <= 1; Y++)
        {
            for (int X = -1; X <= 1; X++)
            {
                if (X == 0 && Y == 0) continue; // �����̓X�L�b�v

                int nX = j + X;
                int nY = i + Y;

                // �X�L�b�v
                if (nX < 0 || nX >= x || nY < 0 || nY >= y) continue;

                // ���͂̊�������m�F
                bool isNeighborOdd = mapdate[nY, nX] % 2 != 0;

                // �قȂ��E���������������ꍇ
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
    } // �}�b�v�`�F�b�N�̊֐�
}
