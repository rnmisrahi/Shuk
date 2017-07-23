using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFShook
{
    public partial class TextBoxPlaceHolder : Component
    {
        public TextBoxPlaceHolder()
        {
            InitializeComponent();
        }

        public TextBoxPlaceHolder(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
