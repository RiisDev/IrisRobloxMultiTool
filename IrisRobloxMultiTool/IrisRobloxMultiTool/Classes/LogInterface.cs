using System;
using System.Drawing;
namespace IrisRobloxMultiTool.Classes
{
    public class LogInterface
    {
        public enum LogType
        {
            System,
            Error,
            Info,
        }

        public void DoLog(VertexFramework.UIControls.VRichTextBox LogBox, LogType logType,string Message)
        {
            LogBox.Invoke(new Action(() =>
            {
                switch (logType)
                {
                    case LogType.System:
                        LogBox.BindText(Color.DimGray, "[SYSTEM] ");
                        LogBox.BindText(Color.White, $"{Message}\n");
                        break;
                    case LogType.Info:
                        LogBox.BindText(Color.DimGray, "[LOG] ");
                        LogBox.BindText(Color.FromArgb(85, 136, 238), $"{Message}\n");
                        break;
                    case LogType.Error:
                        LogBox.BindText(Color.DimGray, "[ERROR] ");
                        LogBox.BindText(Color.Red, $"{Message}\n");
                        break;
                }
            }));

            Console.WriteLine($"{logType} {Message}");
        }
    }
}
