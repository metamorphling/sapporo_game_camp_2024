using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    [SerializeField] int x = 20;//�X�e�[�W�̃}�X���F���Q�O�A���S�O
    [SerializeField] int y = 40;

    [SerializeField] float posx = -9;//�u���b�N�̍��W���炷���
    [SerializeField] float posy = -38.03f;
    [SerializeField] float tileSize = 1f;
    [SerializeField] GameObject io, it, go, gt;
    int[,] mapdate;//type�L�^�p�̔z��

    void Start()
    {
        mapdate = new int[y, x];
        map();
    }


    void map()
    {
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)//��������E��Ɍ�����
            {
                int type = Random.Range(1, 5);//1�`4�̃����_���F������A��������
                GameObject prefab = null;
                mapdate[i, j] = type;
                Check(i, j);
                switch (type)//�����_���̐��l����z�u
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
    }//�}�b�v�����̊֐�

    void Check(int i, int j)
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
                                                //  if (X != 0 && Y != 0) continue;//�΂߂̃X�L�b�v

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
            mapdate[i, j] = (mapdate[i, j] % 2 == 0) ? mapdate[i, j] - 1 : mapdate[i, j] + 1;
        }
    }//�}�b�v�`�F�b�N�̊֐�
}
