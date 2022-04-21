using System;
/// <summary>
/// Gupta, Mailisa , mailisa
/// </summary>
namespace ClassLibrary1
{
    public class NodeGeneric <T> 
    {
        public T data { get; set; }
        public NodeGeneric<T> refnext { get; set; } 
        public NodeGeneric<T> refprevious { get; set; } 




    }
}
