using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�p��= �ق��̃N���X�̋@�\���󂯌p���Ŋg��
public class ToNextScene : MonoBehaviour
{
    [Tooltip("�؂�ւ������V�[����"), SerializeField]
    string nextScene = default;

    bool sceneChanged;

    public void ChangeScene()
    {
        if (sceneChanged) return;

        sceneChanged = true;
        SceneManager.LoadScene(nextScene);
    }

}
