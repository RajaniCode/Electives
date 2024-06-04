using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hypergraph
{
  public interface IListener
  {
    void Listen(string message);
    bool Listening { get; }
  }

  public class Broadcaster
  {
    private static List<IListener> listeners = new List<IListener>();
    public static void Add(IListener listener)
    {
      listeners.Add(listener);
    }

    public static void Broadcast(string message)
    {
      foreach(var listener in listeners)
        listener.Listen(message);
    }

    public static void Broadcast(string format, params object[] o)
    {
      Broadcast(string.Format(format, o));
    }
  }
}
