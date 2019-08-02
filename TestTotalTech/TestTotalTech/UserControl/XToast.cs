using System;
using System.Collections.Generic;
using System.Text;

namespace TestTotalTech.UserControl
{
    public class XToast
    {
        /// <summary>
        /// solo funciona en android y ios
        /// </summary>
        /// <param name="message"></param>
        public static void ShortMessage(string message)
        {
            Xamarin.Forms.DependencyService.Get<IMessage>().ShortAlert(message);
        }

        /// <summary>
        /// solo funciona en Android y IOS
        /// </summary>
        /// <param name="message"></param>
        public static void LongMessage(string message)
        {
            Xamarin.Forms.DependencyService.Get<IMessage>().LongAlert(message);
        }

    }

    public interface IMessage
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }

}
