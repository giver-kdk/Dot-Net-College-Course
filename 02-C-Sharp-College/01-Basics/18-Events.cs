// Foreground(Events generated by user) Event and Background(Events generated by process) Event
/*
    Publisher: Generates event
    Subscriber: Responds to generated event
    
 */
using System;
using System.Security.Cryptography.X509Certificates;

namespace EventApp
{

    public delegate void Notify();
    public class Process
    {
        public event Notify ProcessCompleted;
        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            Console.WriteLine("Process Running...");
            OnProcessCompleted();  
        }
        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke();
        }
        public static void Main(string[] args)
        {
            Process p1 = new Process();
            p1.ProcessCompleted += p1_ProcessCompleted;
            p1.StartProcess();
        }

        private static void p1_ProcessCompleted()
        {
            Console.WriteLine("Process Completed!");
        }
    }
}