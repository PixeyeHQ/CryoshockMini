//   Project : Actors
//  Contacts : Pixeye - ask@pixeye.games 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	public class ProcessorConsole : ITick, IDisposable, IKernel
	{

		public Action consoleOpened = delegate { };
		public Action consoleClosed = delegate { };

		CommandsConsole commands;
		ComponentConsole console;

		bool isConsoleOpen;

		string cachedHelp = string.Empty;
		Dictionary<string, MethodInfo> cachedMethods = new Dictionary<string, MethodInfo>();

		public void Setup(CommandsConsole commands)
		{
			if (commands == null || this.commands != null) return;
			this.commands = commands;
			GetMethods(this.commands);
		}

		public void GetMethods(CommandsConsole commands)
		{
			var methods = commands.GetType().GetMethods().Where(m => m.GetCustomAttributes(typeof(BindAttribute), false).Length > 0).ToArray();
			var message = string.Empty;
			for (var i = 0; i < methods.Length; i++)
			{
				var method = methods[i];
				cachedMethods.Add(method.Name, method);
				var _params = method.GetParameters();
				if (method.Name == "Help") continue;
				message += "\n-> <b>" + method.Name + "</b>";

				for (var j = 0; j < _params.Length; j++)
				{
					message += " <color=#555555>(" + _params[j].ParameterType.Name + ")</color><color=#858585> " + _params[j].Name + "</color>";
				}
 
			}

			cachedHelp = message;
		}

		public void Tick(float delta)
		{
			if (!Input.GetKeyDown(KeyCode.BackQuote)) return;
			isConsoleOpen = !isConsoleOpen;
			if (isConsoleOpen)
				ConsoleOpen();
			else
				ConsoleClose();
		}

		public string Help()
		{
			return cachedHelp;
		}

		string[] par = {" >> "};

		public string ParseCommand(string line)
		{
			if (line == string.Empty) return "";
			if (line == "?" && cachedHelp != string.Empty) return Help();
			var processings = line.Split(' ');
			var parametrs = line.Substring(line.IndexOf(' ') + 1).Split(par, StringSplitOptions.RemoveEmptyEntries);
			var method = GetMethod(processings[0]);

			if (method == null)
			{
				return ReturnLog(processings[0], line == "?" ? ConsoleMessage.ADDCOMMANDS : ConsoleMessage.ERROR);
			}

			var _params = method.GetParameters();

			if (_params.Length>0&&parametrs.Length != _params.Length)
			{
				return ReturnLog(processings[0], ConsoleMessage.INVALIDARGS);
			}

			var _paramsValues = new object[_params.Length];

			for (var i = 0; i < _params.Length; i++)
			{
				if (_params[i].ParameterType == typeof(Int32))
				{
					int val;
					if (Int32.TryParse(parametrs[i], out val))
						_paramsValues[i] = val;
					else return ReturnLog(processings[0], ConsoleMessage.INVALID);
				}
				else if (_params[i].ParameterType == typeof(Single))
				{
					float val;
					if (Single.TryParse(parametrs[i], out val))
						_paramsValues[i] = val;
					else return ReturnLog(processings[0], ConsoleMessage.INVALID);
				}
				else if (_params[i].ParameterType == typeof(Vector3))
				{
					_paramsValues[i] = Vector.ParseVector3(parametrs[i]);
				}
				else
				{
					Debug.Log(parametrs[i]);
					_paramsValues[i] = parametrs[i];
				}
			}

			var callBack = method.Invoke(commands, _paramsValues);
			return callBack != null ? ReturnLog(processings[0], ConsoleMessage.SUCCESS) + "\n" + callBack : ReturnLog(processings[0], ConsoleMessage.SUCCESS);
		}

		public MethodInfo GetMethod(string name)
		{
			MethodInfo m;
			cachedMethods.TryGetValue(name, out m);
			return m;
		}

		static string ReturnLog(string message, ConsoleMessage messageType)
		{
			var messageFinal = message;

			switch (messageType)
			{
				case ConsoleMessage.ADDCOMMANDS:
					messageFinal = "<color=orange>" + message + "</color> Please, add commands scriptable object into console setup.";
					break;

				case ConsoleMessage.ERROR:
					messageFinal = "<color=red>" + message + "</color> is not recognized as command";
					break;

				case ConsoleMessage.INVALID:
					messageFinal = "<color=orange>" + message + "</color> invalid input values";
					break;

				case ConsoleMessage.INVALIDARGS:
					messageFinal = "<color=orange>" + message + "</color> miss input values";
					break;

				case ConsoleMessage.SUCCESS:
					messageFinal = "<color=#00cc66>" + message + "</color> executed!";
					break;
			}

			return messageFinal;
		}

		void ConsoleClose()
		{
			consoleClosed();
			console.ActivateConsole(false);
		}

		void ConsoleOpen()
		{
			if (console == null)
			{
				console = Obj.Spawn<ComponentConsole>("UI Console");
				console.transform.parent.name = "UI Console";
				console.gameObject.SetActive(false);
			}

			consoleOpened();
			console.ActivateConsole(true);
		}

		public void Dispose()
		{
			isConsoleOpen = false;
		}

	}

	public enum ConsoleMessage
	{

		ERROR,
		INVALID,
		INVALIDARGS,
		SUCCESS,
		ADDCOMMANDS

	}

	public static class Vector
	{

		public static Vector3 ParseVector3(this string arg)
		{
			var vals = arg.Split(',');
			return new Vector3(float.Parse(vals[0]), float.Parse(vals[1]), float.Parse(vals[2]));
		}

	}

}