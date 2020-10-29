using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace TreeViewXamarin
{
    public class Cities
    {
        public string Name { get; set; }
    }
    public class States
    {
        public List<Cities> Cities { get; set; }
        public string Name { get; set; }
    }
    public class Countries
    {
        public List<States> States { get; set; }
        public string Name { get; set; }
    }
}