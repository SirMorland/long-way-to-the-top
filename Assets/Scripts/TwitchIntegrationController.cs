using System;
using System.Collections.Generic;
using UnityEngine;
using NetIrc2;
using NetIrc2.Events;
using System.Collections;

public class TwitchIntegrationController : MonoBehaviour
{
	IrcClient ircClient;
	string channel;

	void Start ()
	{
		ircClient = new IrcClient();

		ircClient.GotIrcError += new EventHandler<IrcErrorEventArgs>(PrintMessage);
		ircClient.GotMessage += new EventHandler<ChatMessageEventArgs>(PrintMessage);
		ircClient.GotWelcomeMessage += new EventHandler<SimpleMessageEventArgs>(PrintMessage);

		channel = PlayerPrefs.GetString("TWITCH_CHANNEL", "sirmorland").ToLower().Trim();
		string oAuth = PlayerPrefs.GetString("TWITCH_OAUTH", "oauth:vug3thrwdn0iqg486ickxdrswbyq03").Trim();

		if(oAuth.IndexOf("oauth:") != 0)
		{
			oAuth = "oauth:" + oAuth;
		}
		
		ircClient.Connect("irc.chat.twitch.tv", 6667);
		ircClient.LogIn(channel, channel, channel, null, null, oAuth);
		ircClient.Join("#" + channel);
	}

	void PrintMessage(object o, SimpleMessageEventArgs simpleMessageEventArgs)
	{
		Debug.Log("Welcome: " + simpleMessageEventArgs.Message.ToString());
	}
	void PrintMessage(object o, ChatMessageEventArgs chatMessageEventArgs)
	{
		Debug.Log("Message: " + chatMessageEventArgs.Sender + " - " + chatMessageEventArgs.Message);
	}
	void PrintMessage(object o, IrcErrorEventArgs ircErrorEventArgs)
	{
		Debug.Log("Error: " + ircErrorEventArgs.Data.ToString());
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			ircClient.Message("#" + channel, "Hello!");
		}
	}
}
