using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class MessageBus
    {
        internal class Subscription
        {
            public Func<object, Task> Handler;
            public Type Type;
            public string Subscriber;

            public Subscription(Type type, Func<object, Task> handler, string subscriber)
            {
                Type = type;
                Handler = handler;
                Subscriber = subscriber;
            }
        }

        private static List<Subscription> Subscriptions = new List<Subscription>();

        public static object Subscribe<T>(Func<T, Task> handler, [CallerMemberName] string caller = null)
        {
            var sub = new Subscription(typeof(T), msg => handler.Invoke((T)msg), caller);
            Subscriptions.Add(sub);
            return sub;
        }

        public static async void Publish(object message)
        {
            var type = message.GetType();

            var subs = Subscriptions
                .Where(s => s.Type.IsAssignableFrom(type));


            foreach (var sub in subs)
            {
                try
                {
                    await sub.Handler.Invoke(message);
                }
                catch (Exception ex)
                {
                    //continue with all the handlers, even if one fails
                    var errorMessage = $"handler [{sub.Subscriber}] failed for ['{type.Name}':{message}]";
                    Console.WriteLine(errorMessage);
                }
            }

        }

        public static void Unsubscribe(object sub)
        {
            Subscriptions.Remove((Subscription)sub);
        }
    }
}
