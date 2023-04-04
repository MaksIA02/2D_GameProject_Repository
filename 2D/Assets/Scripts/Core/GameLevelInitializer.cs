using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelInitializer : MonoBehaviour
{
	[SerializeField] private HeroKnight _heroKnight;
	[SerializeField] private GameUIInputView _gameUIInputView;

	private ExternalDevicesInputReader _externalDevicesInput;
	private PlayerBrain _playerBrain;

	private readonly bool _onPause = false;

	private void Awake()
	{
		_externalDevicesInput = new ExternalDevicesInputReader();
		_playerBrain = new PlayerBrain(_heroKnight, new List<IEntityInputSource>
		{
			_gameUIInputView,
			_externalDevicesInput
		});
	}

	private void Update()
	{
		if (_onPause)
			return;
		_externalDevicesInput.OnUpdate();

	}

	private void FixedUpdate()
	{
		if (_onPause)
			return;
		_playerBrain.OnFixedUpdate();
	}

}
