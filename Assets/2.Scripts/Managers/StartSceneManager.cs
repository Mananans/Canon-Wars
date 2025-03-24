using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartSceneManager : MonoBehaviour
{
    [SerializeField] InputField _idField;
    [SerializeField] InputField _passwordField;
    [SerializeField] Button _loginBtn;
    [SerializeField] Button _signUpBtn;
    [SerializeField] Button _exitBtn;
    [SerializeField] GameObject _singupUI;


    void Start()
    {
        _loginBtn.onClick.AddListener(OnLoginClick);
        _signUpBtn.onClick.AddListener(OnSignUpClick);
        _exitBtn.onClick.AddListener(OnExitClick);
    }



    void OnLoginClick()
    {
        string email = _idField.text;
        string password = _passwordField.text;

        if (string.IsNullOrEmpty(email))
        {
            StartCoroutine(ShowWarningBorder(_idField));
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            StartCoroutine(ShowWarningBorder(_passwordField));
            return;
        }

        //���̾�̽��� �α��� ���� ���� �����ʿ�

    }

    void OnSignUpClick()
    {
        Debug.Log("ȸ�����Թ�ư Ŭ��");
        _singupUI.SetActive(true);
    }

    void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    IEnumerator ShowWarningBorder(InputField field)                     //���̵� �н����� �Է¾��� �α��ι�ưŬ���� �ش��ʵ带 ���������� ǥ����
    {
        var originalColor = field.GetComponent<Image>().color;
        field.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        field.GetComponent<Image>().color = originalColor;
    }
}
