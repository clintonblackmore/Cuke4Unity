﻿using System;
using System.IO;
using UnityEngine;

using Cuke4Nuke.Core;

namespace Cuke4Nuke.Server
{
    public class NukeServer
    {
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Listener _listener;
        readonly Options _options;

        public NukeServer(Listener listener, Options options)
        {
            _listener = listener;
            _options = options;
        }

        public void Start()
        {
            Run();
        }

        void Run()
        {
            _listener.MessageLogged += listener_LogMessage;
            try
            {
                _listener.Start();
            }
            catch (Exception ex)
            {
                string message = "Unable to start listener. Exception:\n\n" + ex.Message;
                Debug.LogError(message);
            }
            /*
            finally
            {
                Debug.Log("Finally");
                try
                {
                    _listener.Stop();
                }
                catch (Exception e)
                {
                    string message = "Unable to gracefully stop listener. Exception:\n\n" + e.Message;
                    Debug.LogError(message);
                }
            }
            */
        }

        void ShowHelp()
        {
            Debug.Log("Usage: Cuke4Nuke.Server.exe [OPTIONS]");
            Debug.Log("Start the Cuke4Nuke server to invoke .NET Cucumber step definitions.");
            Debug.Log("");
            Debug.Log(_options.ToString());
        }

        void listener_LogMessage(object sender, LogEventArgs e)
        {
            Debug.Log(e.Message);
        }

        void Log(string message)
        {
            Debug.Log(message);
        }
    }
}