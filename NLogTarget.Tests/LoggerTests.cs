using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using Xunit;
using Zidium;
using Zidium.Api;

namespace NlogTarget.Tests
{
    public class LoggerTests
    {
        [Fact]
        public void LogTraceTest()
        {
            var client = Client.Instance;

            var logMessages = new List<Tuple<Guid, LogMessage>>();
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerName = Guid.NewGuid().ToString();
            var logger = LogManager.GetLogger(loggerName);
            var text = "Message." + Guid.NewGuid();
            logger.Trace(text);

            Assert.Equal(1, logMessages.Count);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.LogLevel.Trace, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal(loggerName, logMessage.Item2.Context);

            Assert.Equal(0, events.Count);
        }

        [Fact]
        public void LogDebugTest()
        {
            var client = Client.Instance;

            var logMessages = new List<Tuple<Guid, LogMessage>>();
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerName = Guid.NewGuid().ToString();
            var logger = LogManager.GetLogger(loggerName);
            var text = "Message." + Guid.NewGuid();
            logger.Debug(text);

            Assert.Equal(1, logMessages.Count);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.LogLevel.Debug, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal(loggerName, logMessage.Item2.Context);

            Assert.Equal(0, events.Count);
        }

        [Fact]
        public void LogInfoTest()
        {
            var client = Client.Instance;

            var logMessages = new List<Tuple<Guid, LogMessage>>();
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerName = Guid.NewGuid().ToString();
            var logger = LogManager.GetLogger(loggerName);
            var text = "Message." + Guid.NewGuid();
            logger.Info(text);

            Assert.Equal(1, logMessages.Count);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.LogLevel.Info, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal(loggerName, logMessage.Item2.Context);

            Assert.Equal(0, events.Count);
        }

        [Fact]
        public void LogWarnTest()
        {
            var client = Client.Instance;

            var logMessages = new List<Tuple<Guid, LogMessage>>();
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerName = Guid.NewGuid().ToString();
            var logger = LogManager.GetLogger(loggerName);
            var text = "Message." + Guid.NewGuid();
            logger.Warn(text);

            Assert.Equal(1, logMessages.Count);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.LogLevel.Warning, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal(loggerName, logMessage.Item2.Context);

            Assert.Equal(1, events.Count);
        }

        [Fact]
        public void LogErrorTest()
        {
            var client = Client.Instance;

            var logMessages = new List<Tuple<Guid, LogMessage>>();
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerName = Guid.NewGuid().ToString();
            var logger = LogManager.GetLogger(loggerName);
            var text = "Message." + Guid.NewGuid();
            logger.Error(text);

            Assert.Equal(1, logMessages.Count);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.LogLevel.Error, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal(loggerName, logMessage.Item2.Context);

            Assert.Equal(1, events.Count);
        }

        [Fact]
        public void LogFatalTest()
        {
            var client = Client.Instance;

            var logMessages = new List<Tuple<Guid, LogMessage>>();
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var events = new List<SendEventBase>();
            client.EventPreparer = new EventPreparer(events);

            var loggerName = Guid.NewGuid().ToString();
            var logger = LogManager.GetLogger(loggerName);
            var text = "Message." + Guid.NewGuid();
            logger.Fatal(text);

            Assert.Equal(1, logMessages.Count);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.LogLevel.Fatal, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal(loggerName, logMessage.Item2.Context);

            Assert.Equal(1, events.Count);
        }

        [Fact]
        public void LogExceptionAndMessageTest()
        {
            var logMessages = new List<Tuple<Guid, LogMessage>>();

            var client = Client.Instance;
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var loggerName = Guid.NewGuid().ToString();
            var logger = LogManager.GetLogger(loggerName);
            var exception = new Exception("Test");
            logger.Error(exception, exception.Message);

            Assert.Equal(1, logMessages.Count);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.LogLevel.Error, logMessage.Item2.Level);
            Assert.Equal("Test", logMessage.Item2.Message);
            Assert.Equal(loggerName, logMessage.Item2.Context);

            Assert.Equal(1, logMessage.Item2.Properties.Count);
            var prop = logMessage.Item2.Properties.First();
            Assert.Equal("Stack", prop.Name);
        }

        [Fact]
        public void LogExceptionOnlyTest()
        {
            var logMessages = new List<Tuple<Guid, LogMessage>>();

            var client = Client.Instance;
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var loggerName = Guid.NewGuid().ToString();
            var logger = LogManager.GetLogger(loggerName);

            Exception exception;
            try
            {
                throw new Exception("Test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            logger.Error(exception);

            Assert.Equal(1, logMessages.Count);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.LogLevel.Error, logMessage.Item2.Level);
            Assert.Equal("Test", logMessage.Item2.Message);
            Assert.Equal(loggerName, logMessage.Item2.Context);

            Assert.Equal(1, logMessage.Item2.Properties.Count);
            var prop = logMessage.Item2.Properties.First();
            Assert.Equal("Stack", prop.Name);
        }

        [Fact]
        public void LogPropertiesTest()
        {
            var logMessages = new List<Tuple<Guid, LogMessage>>();

            var client = Client.Instance;
            client.WebLogManager.OnAddLogMessage += (component, message) =>
            {
                logMessages.Add(new Tuple<Guid, LogMessage>(component.Info.Id, message));
            };

            var loggerName = Guid.NewGuid().ToString();
            var logger = LogManager.GetLogger(loggerName);
            var text = "Message." + Guid.NewGuid();
            var logEvent = new LogEventInfo(NLog.LogLevel.Info, logger.Name, text);
            logEvent.Properties["Prop1"] = "Value1";
            logEvent.Properties["Prop2"] = "Value2";
            logger.Log(logEvent);

            Assert.Equal(1, logMessages.Count);
            var logMessage = logMessages[0];
            Assert.Equal(ComponentId, logMessage.Item1);
            Assert.Equal(Zidium.Api.LogLevel.Info, logMessage.Item2.Level);
            Assert.Equal(text, logMessage.Item2.Message);
            Assert.Equal(loggerName, logMessage.Item2.Context);

            Assert.Equal(2, logMessage.Item2.Properties.Count);

            var prop = logMessage.Item2.Properties["Prop1"];
            Assert.NotNull(prop);
            Assert.Equal("Value1", prop.Value);

            prop = logMessage.Item2.Properties["Prop2"];
            Assert.NotNull(prop);
            Assert.Equal("Value2", prop.Value);
        }

        private static Guid ComponentId
        {
            get { return new Guid(LogManager.Configuration.FindTargetByName<NLogTargetLog>("ZidiumLog").ComponentId); }
        }
    }
}
