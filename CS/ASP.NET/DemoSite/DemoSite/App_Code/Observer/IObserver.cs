using System;

public interface IObserver
{
  // observed objects must provide a method 
  // that updates its content or performs the
  // appropriate actions
  void Update(Object subject);
}