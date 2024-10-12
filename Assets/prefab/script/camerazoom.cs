using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerazoom : MonoBehaviour
{
    [SerializeField] Camera maincam;//�J�����̃Y�[���ő�170�p�[�A25�}�X�ڂ�ڈ���
    [SerializeField] GameObject player;//1�}�X�ڂ���25�}�X�ڂ̋����F24.22
    Transform plpos;
    [SerializeField] float maxzoom = 46f;//�J�����ő�
    [SerializeField]float minzoom = 60f;//�J�����ŏ�
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
    void movecamera()//player�ɒǏ]
    {
        transform.position = new Vector3(transform.position.x, plpos.position.y, transform.position.z);
    }
    void zoomcam()//player�̗��������ɉ����ăY�[��
    {
        // �v���C���[�̌��݂�Y���W���珉���ʒu�Ƃ̍����v�Z�i���������j
        float distanceFallen = Mathf.Abs(ply - plpos.position.y);

        // ���������Ɋ�Â��ăJ�����̎���p�iFOV�j��ύX
        // ������0�̎��͍ŏ��Y�[���AmaxDistance�̎��͍ő�Y�[��
        float targetZoom = Mathf.Lerp(minzoom, maxzoom, distanceFallen / maxdis);

        // �J�����̎���p���X�V
        maincam.fieldOfView = targetZoom;
    }
}
