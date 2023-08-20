using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Commands
{
    internal class BackCommand : CompositeCommand
    {
        private static BackCommand? _instance;

        internal static BackCommand Instance => _instance ??= new BackCommand();

        private BackCommand() : base("Go back") { }

        public override void Execute()
        {

        }
    }
}
