/*
	Created by Carl Emil Carlsen.
	Copyright 2016-2020 Sixth Sensor.
	All rights reserved.
	http://sixthsensor.dk
*/

using UnityEngine;

namespace OscSimpl.Examples
{
	public class GettingStartedSending : MonoBehaviour
	{
		[SerializeField] OscOut _oscOut;

		OscMessage _message1; // Cached message.
		OscMessage _message3; // Cached message.
		OscMessage _message4; // Cached message.
		OscMessage _message2; // Cached message.

		const string address1 = "/test1";
		const string address3 = "/test3";
		const string address4 = "/test4";
		const string address2 = "/test2";

		public GameObject Camera;


		void Start()
		{
			// Ensure that we have a OscOut component.
			if (!_oscOut) _oscOut = gameObject.AddComponent<OscOut>();


			// Prepare for sending messages locally on this device on port 7000.
			//_oscOut.Open( 7000 );

			// ... or, alternatively target a remote devices with an IP Address.
			_oscOut.Open(_oscOut.port, _oscOut.remoteIpAddress);

			// If you want to send a single value then you can use this one-liner.
			_oscOut.Send(address1, Random.value);

			// If you want to send a message with multiple values, then you
			// need to create a message, add your values and send it.
			// Always cache messages you create, so that you can reuse them.
			_message1 = new OscMessage(address1);
			_message2 = new OscMessage(address2);
			_message3 = new OscMessage(address3);
			_message4 = new OscMessage(address4);
			//_message2.Add(Time.frameCount).Add(Time.time).Add(Random.value);
			//_oscOut.Send(_message2);
		}


		void Update()
		{
			// We update the content of message2 and send it again.
			_message2.Set(0, Camera.transform.position.x);
			_message2.Set(1, Camera.transform.position.y);
			_message2.Set(2, Camera.transform.position.z);
			_message2.Set(3, Camera.transform.eulerAngles.x);
			_message2.Set(4, Camera.transform.eulerAngles.y);
			_message2.Set(5, Camera.transform.eulerAngles.z);
			_oscOut.Send(_message2);
		}

		public void button_One()
        {
			_message1.Set(0, true);
			_oscOut.Send(_message1);

		}

		public void button_Two()
		{
			_message3.Set(0, false);
			_oscOut.Send(_message3);
		}

		public void button_Cancle()
		{
			_message4.Set(0, false);
			_oscOut.Send(_message4);
		}
	}
}