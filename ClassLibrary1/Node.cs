using System;
/// <summary>
/// Gupta, Mailisa , mailisa
/// </summary>

namespace ClassLibrary1
{
    public class Node
    {
        public int? data { get; set; }
        public Node refnext { get; set; }  /// at the end of the list the next ref will be null
        public Node refprevious { get; set; } /// <summary>
        /// at the begining of the list the previous ref will be null
        /// </summary>
       

        

    }
}
