using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Windows.Extensions.Helpers
{
    public class ToastHelper
    {


        public  static void SendToast(string text)
        {
            //<toast>
            //    <visual>
            //        <binding template="ToastImageAndText01">
            //            <image id="1" src=""/>
            //            <text id="1"></text>
            //        </binding>
            //    </visual>
            //</toast>

            var toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(text));
            XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName("image");

            ((XmlElement)toastImageAttributes[0]).SetAttribute("src", "ms-appx:///images/redWide.png");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "red graphic");

            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            //IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.IM");
            //audio.SetAttribute("silent", "true");
            toastNode.AppendChild(audio);

            var toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

    }
}
