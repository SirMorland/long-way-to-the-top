using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NetIrc2;
using NetIrc2.Events;

public class VoteController : MonoBehaviour
{
	IrcClient ircClient;
	string channel;

	public GameObject bossOne;
	public GameObject bossTwo;
	public GameObject bossThree;

	public Text textOne;
	public Text textTwo;
	public Text textThree;

	int bossOneVotes;
	int bossTwoVotes;
	int bossThreeVotes;

	bool firstBoss = false;
	bool secondBoss = false;
	bool thirdBoss = false;

	void Start ()
	{
		ircClient = new IrcClient();
		
		ircClient.GotMessage += new EventHandler<ChatMessageEventArgs>(GotMessage);

		channel = PlayerPrefs.GetString("TWITCH_CHANNEL", "sirmorland").ToLower().Trim();
		string oAuth = PlayerPrefs.GetString("TWITCH_OAUTH", "z1h9xf43hxh10i566b5d82qvo2fwbv").Trim();

		if (oAuth.IndexOf("oauth:") != 0)
		{
			oAuth = "oauth:" + oAuth;
		}

		ircClient.Connect("irc.chat.twitch.tv", 6667);
		ircClient.LogIn(channel, channel, channel, null, null, oAuth);
		ircClient.Join("#" + channel);
	}

	void GotMessage(object o, ChatMessageEventArgs chatMessageEventArgs)
	{
		Debug.Log(chatMessageEventArgs.Message.ToString().ToLower());

		if (chatMessageEventArgs.Message.ToString().ToLower().IndexOf("dragon") > -1)
		{
			bossOneVotes++;
		}
		if (chatMessageEventArgs.Message.ToString().ToLower().IndexOf("hephaestos") > -1)
		{
			bossTwoVotes++;
		}
		if (chatMessageEventArgs.Message.ToString().ToLower().IndexOf("???") > -1)
		{
			bossThreeVotes++;
		}
	}

	void Update ()
	{
		textOne.text = bossOneVotes.ToString ("000");
		textTwo.text = bossTwoVotes.ToString ("000");
		textThree.text = bossThreeVotes.ToString ("000");

		if (transform.position.x > 20 && !firstBoss)
		{
			firstBoss = true;

			if (bossOneVotes >= bossTwoVotes && bossOneVotes >= bossThreeVotes)
			{
				Instantiate(bossOne).transform.position = new Vector3(40f, 5f, 0f);
			}
			else if (bossTwoVotes > bossOneVotes && bossTwoVotes >= bossThreeVotes)
			{
				Instantiate(bossTwo).transform.position = new Vector3(40f, 5f, 0f);
			}
			else if (bossThreeVotes > bossOneVotes && bossThreeVotes > bossTwoVotes)
			{
				Instantiate(bossThree).transform.position = new Vector3(40f, 5f, 0f);
			}

			bossOneVotes = 0;
			bossTwoVotes = 0;
			bossThreeVotes = 0;
		}
		if (transform.position.x > 100 && !secondBoss)
		{
			secondBoss = true;

			if (bossOneVotes >= bossTwoVotes && bossOneVotes >= bossThreeVotes)
			{
				Instantiate(bossOne).transform.position = new Vector3(120f, 26f, 0f);
			}
			else if (bossTwoVotes > bossOneVotes && bossTwoVotes >= bossThreeVotes)
			{
				Instantiate(bossTwo).transform.position = new Vector3(120f, 26f, 0f);
			}
			else if (bossThreeVotes > bossOneVotes && bossThreeVotes > bossTwoVotes)
			{
				Instantiate(bossThree).transform.position = new Vector3(120f, 26f, 0f);
			}

			bossOneVotes = 0;
			bossTwoVotes = 0;
			bossThreeVotes = 0;
		}
		if (transform.position.x > 200 && !thirdBoss)
		{
			thirdBoss = true;

			if (bossOneVotes >= bossTwoVotes && bossOneVotes >= bossThreeVotes)
			{
				Instantiate(bossOne).transform.position = new Vector3(220f, 47f, 0f);
			}
			else if (bossTwoVotes > bossOneVotes && bossTwoVotes >= bossThreeVotes)
			{
				Instantiate(bossTwo).transform.position = new Vector3(220f, 47f, 0f);
			}
			else if (bossThreeVotes > bossOneVotes && bossThreeVotes > bossTwoVotes)
			{
				Instantiate(bossThree).transform.position = new Vector3(220f, 47f, 0f);
			}

			bossOneVotes = 0;
			bossTwoVotes = 0;
			bossThreeVotes = 0;
		}
	}
}
