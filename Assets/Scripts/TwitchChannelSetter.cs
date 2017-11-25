using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TwitchChannelSetter : MonoBehaviour
{
	public GameObject channel;
	public GameObject oAuth;

	InputField channelInputField;
	InputField oAuthInputField;

	void Start ()
	{
		channelInputField = channel.GetComponent<InputField>();
		oAuthInputField = oAuth.GetComponent<InputField>();

		channelInputField.text = PlayerPrefs.GetString("TWITCH_CHANNEL", "");
		oAuthInputField.text = PlayerPrefs.GetString("TWITCH_OAUTH", "");
	}
	
	void OnGUI ()
	{
		if (oAuthInputField.isFocused && channelInputField.text != "" && oAuthInputField.text != "" && Input.GetKeyDown(KeyCode.Return))
		{
			PlayerPrefs.SetString("TWITCH_CHANNEL", channelInputField.text);
			PlayerPrefs.SetString("TWITCH_OAUTH", oAuthInputField.text);
			SceneManager.LoadScene(1);
		}
	}
}
