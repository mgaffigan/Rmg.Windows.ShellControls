using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Rmg.Windows.ShellControls.NativeMethods;
using IDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace Rmg.Windows.ShellControls
{
    public sealed class AssociatedHandler
    {
        private readonly IDataObject Dao;
        private readonly IAssocHandler Handler;

        private AssociatedHandler(IAssocHandler handler, IDataObject dao)
        {
            this.Handler = handler;
            this.Dao = dao;

            this.Name = handler.GetName();
            this.DisplayName = handler.GetUIName();
        }

        public string DisplayName { get; private set; }
        public string Name { get; private set; }

        public static IEnumerable<AssociatedHandler> ForPath(string path)
        {
            var item = (IShellItem)SHCreateItemFromParsingName(path, null, typeof(IShellItem).GUID);
            var assocenum = (IEnumAssocHandlers)item.BindToHandler(null, BHID_EnumAssocHandlers, typeof(IEnumAssocHandlers).GUID);
            var dao = (IDataObject)item.BindToHandler(null, BHID_DataObject, typeof(IDataObject).GUID);
            var results = new List<AssociatedHandler>();
            IAssocHandler handler; int retrieved;
            while (true)
            {
                assocenum.Next(1, out handler, out retrieved);
                if (retrieved != 1)
                {
                    break;
                }

                results.Add(new AssociatedHandler(handler, dao));
            }
            return results.AsReadOnly();
        }

        public void Invoke()
        {
            Handler.Invoke(Dao);
        }
    }
}
