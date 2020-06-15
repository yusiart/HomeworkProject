using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
  [SerializeField] private TMP_Text _textAbout;

  private void Start()
  {
    _textAbout.enabled = false;
  }

  public void OpenPanel(GameObject panel)
  {
    panel.SetActive(true);
    Time.timeScale = 0;
  }

  public void ClosePanel(GameObject panel)
  {
    panel.SetActive(false);
    Time.timeScale = 1;
    _textAbout.enabled = false;
  }

  public void Exit()
  {
    Application.Quit();
  }

  public void ShowInfo()
  {
    _textAbout.enabled = true;
  }
}
